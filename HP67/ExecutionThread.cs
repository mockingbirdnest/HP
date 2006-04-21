using HP67_Class_Library;
using HP67_Control_Library;
using HP_Parser;
using System;
using Queue = System.Collections.Queue;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace HP67
{
	/// <summary>
	/// The execution thread of the HP67 calculator.
	/// </summary>
	public class ExecutionThread
	{

		#region Public Data

		// Delegates used for cross-thread invocation.
		public delegate EngineMode CrossThreadUINotification (bool busy);
		public delegate bool CrossThreadOperation ();

		// Lock this object to ensure that the thread is idle.
		public object IsBusy = new object ();

		// Set this event to power-on the execution thread.
		public AutoResetEvent PowerOn = new AutoResetEvent (false);

		#endregion

		#region Private Data

		private Actions downActions;
		private Parser downParser;
		private Program program;
		private Actions upActions;
		private Parser upParser;
		
		private AutoResetEvent downKeystrokeWasEnqueued = new AutoResetEvent (false);
		private AutoResetEvent isInitialized = new AutoResetEvent (false);
		private Queue keystrokesQueue;
		private AutoResetEvent keystrokeWasEnqueued = new AutoResetEvent (false);

		private Control main;
		private CrossThreadUINotification notifyUI;
		private Reader reader;
		private Thread thread;

		private volatile bool mustAbort;

		#endregion

		#region Constructors & Destructors

		public ExecutionThread
			(Control main,
			Reader reader,
			CrossThreadUINotification notifyUI,
			out Program program)
		{
			this.main = main;
			this.notifyUI = notifyUI;
			this.reader = reader;

			// Create the execution thread and wait until it is ready to process requests.
			keystrokesQueue = Queue.Synchronized (new Queue ());
			thread = new Thread (new ThreadStart (Execution));
			thread.Start ();
			isInitialized.WaitOne ();

			program = this.program;
		}

		#endregion

		#region Private Operations

		private void Execution ()
		{
			Display display;
			Engine engine;
			Memory memory;
			Stack stack;

			bool ignoreNextDown = false;
			bool ignoreNextUp = false;
			bool mustReinitialize = false;

			// For some reason the first exception that is raised on this thread takes a long time
			// to propagate.  It is better to raise it here, while the thread initializes, than
			// later, when it could cause a delay visible to the user.
			try 
			{
				throw new Error ();
			}
			catch 
			{
			}

			// Controls must be accessed from the thread that created them.  For most controls, this
			// is the main thread.  But the display is special, as it is mostly updated during
			// execution.  So it is created by the execution thread. 
			display = new Display (downKeystrokeWasEnqueued);
			display.Font =
				new System.Drawing.Font
					("Quartz",
					26.25F,
					System.Drawing.FontStyle.Regular,
					System.Drawing.GraphicsUnit.Point,
					((System.Byte)(0)));
			display.ForeColor = System.Drawing.Color.Red;
			display.Location = new System.Drawing.Point (8, 8);
			display.Name = "display";
			display.Size = new System.Drawing.Size (288, 40);
			display.TabIndex = 0;
			display.AcceptKeystrokes +=
				new HP67_Control_Library.Display.DisplayEvent (ExecutionAcceptKeystrokes);
			display.CompleteKeystrokes +=
				new HP67_Control_Library.Display.DisplayEvent (ExecutionCompleteKeystrokes);
			main.Controls.Add (display);

			for (;;) 
			{
		
				// The display is initially black, as when the calculator is powered off.
				display.ShowText ("", 0, 0);

				// Create the components that depend on the display.
				memory = new Memory (display);
				program = new Program (display, reader);
				stack = new HP67_Class_Library.Stack (display);
				engine =
					new Engine (display, memory, program, reader, stack, downKeystrokeWasEnqueued);

				// We need two parsers: one that processes the MouseDown events, and one that
				// processes the MouseUp events, because both events have different effects for a
				// given key (e.g., R/S displays the next instruction when depressed, and runs the
				// program when released).  The two parsers will go through exactly the same
				// productions, but they will pass a different motion indicator to the engine.
				downActions = new Actions (engine, KeystrokeMotion.Down);
				downParser = new Parser (reader, program, downActions);
				upActions = new Actions (engine, KeystrokeMotion.Up);
				upParser = new Parser (reader, program, upActions);

				// Notify the main thread that we are ready to process keystrokes.
				isInitialized.Set ();

				// Now wait until the main thread tells us that the calculator has been powered on.
				// Note that we couldn't call notifyUI here to set the display mode, because the
				// main window may not be built yet.  The main thread will have to send a dummy
				// keystroke when it wants the display mode to be refreshed.
				PowerOn.WaitOne ();

				// Reinitialize the display to its power-on state.
				display.Digits = 2;
				display.Format = DisplayFormat.Fixed;
				display.Mode = DisplayMode.Numeric;
				display.Value = 0;

				do
				{
					ExecutionProcessKeystroke
						(display,
						engine,
						ref ignoreNextDown,
						ref ignoreNextUp,
						out mustReinitialize);
				} while (! mustReinitialize);
			}
		}

		private void ExecutionAcceptKeystrokes (object sender)
		{

			// Send the key that was just typed (in pause mode) to the parser for execution.
			upParser.Parse (((Keystroke) keystrokesQueue.Dequeue ()).Tag);
		}

		private void ExecutionCompleteKeystrokes (object sender)
		{

			// Pretend that we accepted the input in order to put the parser back into a pristine
			// state (in particular, drop any remaining text).
			downActions.ParserAccept ();
			upActions.ParserAccept ();
		}

		private void ExecutionProcessKeystroke
			(Display display,
			Engine engine,
			ref bool ignoreNextDown,
			ref bool ignoreNextUp,
			out bool mustReinitialize) 
		{
			Keystroke keystroke;
			bool mustUnbusyUI = true;			

			mustReinitialize = false;
			try 
			{
				// TODO: What if we get several keys in the queue and keyWasTyped is set only once?

				// Wait until we get a keystroke from the UI.
				keystrokeWasEnqueued.WaitOne ();

				keystroke = (Keystroke) keystrokesQueue.Dequeue ();

				// We want to protect this sequence against asynchronous changes to the menus which
				// may happen if the W/PGRM-RUN switch is moved: we wouldn't want the menus to be
				// changed by the main thread between the invocation of notifyUI and the call to the
				// parser, or during the execution of the keystroke.
				lock (IsBusy)
				{
					main.Invoke (notifyUI, new object [] {true});

					switch (keystroke.Motion) 
					{
						case KeystrokeMotion.Up :

							// We may have to ignore two up keystrokes after an error: the one for
							// the key that caused the error, and the one for the key that clears
							// the error.
							if (ignoreNextUp) 
							{
								ignoreNextUp = ignoreNextDown;
							}
							else 
							{
								upParser.Parse (keystroke.Tag);
							}
							mustUnbusyUI = ! ignoreNextDown;
							break;
						case KeystrokeMotion.Down :

							// We only refresh the display if it is blurred, or if this is the key
							// that clears an error.  That's because a down keystroke may display
							// the current instruction.

							// TODO: What if another down key was queued in-between?
							downKeystrokeWasEnqueued.Reset ();
							if (ignoreNextDown)
							{
								Trace.Assert (ignoreNextUp);
								ignoreNextDown = false;
							}
							else
							{
								downParser.Parse (keystroke.Tag);
							}
							mustUnbusyUI = ignoreNextUp || display.IsBlurred;
							break;
					}
				}
			}
			catch (Error)
			{
				display.Value = display.Value; // Refresh the numeric display.
				display.ShowText (Localization.GetString (Localization.Error), 500, 100);
				ignoreNextDown = true;
				ignoreNextUp = true;
				mustUnbusyUI = false;
				ExecutionCompleteKeystrokes (this);
			}
			catch (Interrupt)
			{
				display.Value = display.Value; // Refresh the numeric display.
				ignoreNextDown = true;
				ignoreNextUp = true;
				mustUnbusyUI = true;
				ExecutionCompleteKeystrokes (this);
			}
			catch (ThreadAbortException) 
			{
				mustUnbusyUI = false; // No cross-thread notification if we are being aborted.
				if (! mustAbort) 
				{

					// A fake abort for reinitialization.
					Thread.ResetAbort ();
					mustReinitialize = true;
				}
			}
			finally 
			{
				if (mustUnbusyUI) 
				{
					engine.Mode = (EngineMode) main.Invoke (notifyUI, new object [] {false});
				}
			}
		}		

		#endregion

		#region Public Operations

		public void Abort () 
		{
			mustAbort = true;
			thread.Abort ();
		}

		public void Clear () 
		{
			keystrokesQueue.Clear ();
			keystrokeWasEnqueued.Reset ();
			downKeystrokeWasEnqueued.Reset ();
		}

		public void Enqueue (Keystroke keystroke) 
		{
			keystrokesQueue.Enqueue (keystroke);
			keystrokeWasEnqueued.Set ();
			if (keystroke.Motion == KeystrokeMotion.Down) 
			{
				downKeystrokeWasEnqueued.Set ();
			}
		}

		public void Reset (out Program program)
		{

			// In order to power-off the calculator, we send an abort to the execution thread.  
			// That's the only way that we can interrupt a calcutation in a fully asynchronous
			// manner.  The boolean mustAbort is used to indicate whether we want the thread to
			// abort for good, or merely to reinitialize all of its objects.
			mustAbort = false;
			thread.Abort ();
			isInitialized.WaitOne ();

			program = this.program;
		}

		#endregion

	}
}
