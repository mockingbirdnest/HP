using HP67_Class_Library;
using HP67_Control_Library;
using HP67_Parser;
using System;
using Queue = System.Collections.Queue;
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
		
		private AutoResetEvent isInitialized = new AutoResetEvent (false);
		private Queue keystrokesQueue;
		private AutoResetEvent keyWasTyped = new AutoResetEvent (false);

		private Control main;
		private CrossThreadUINotification notifyUI;
		private Reader reader;
		private Thread thread;

		#endregion

		#region Constructors & Destructors

		public ExecutionThread
			(Control main,
			Reader reader,
			CrossThreadUINotification notifyUI,
			out Program program)
		{
			this.main = main;
			this.reader = reader;
			this.notifyUI = notifyUI;

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
			Keystroke keystroke;
			Memory memory;
			Stack stack;

			bool ignoreNext = false;
			bool mustCreateDisplay = true;
			bool mustUnbusyUI = true;

			// Controls must be accessed from the thread that created them.  For most controls,
			// this is the main thread.  But the display is special, as it is mostly updated
			// during execution.  So it is created by the execution thread.  If the display already
			// exists because it was created by a previous incarnation of the execution thread, we
			// reuse it.
			display = null;
			foreach (Control c in main.Controls) 
			{
				if (c.GetType () == typeof (Display)) 
				{
					mustCreateDisplay = false;
					display = (Display) c;
					// TODO: This won't work: the display belongs to a dead thread.
					break;
				}
			}
			if (mustCreateDisplay) 
			{
				display = new Display (keyWasTyped);
				main.Controls.Add (display);
			}
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
			display.Value = 0;
			display.AcceptKeystrokes +=
				new HP67_Control_Library.Display.DisplayEvent (ExecutionAcceptKeystrokes);
			display.CompleteKeystrokes +=
				new HP67_Control_Library.Display.DisplayEvent (ExecutionCompleteKeystrokes);

			// Create the components that depend on the display.
			memory = new Memory (display);
			program = new Program (display);
			stack = new HP67_Class_Library.Stack (display);
			engine = new Engine (display, memory, program, stack, keyWasTyped);

			// We need two parsers: one that processes the MouseDown events, and one that processes
			// the MouseUp events, because both events have different effects for a given key (e.g.,
			// R/S displays the next instruction when depressed, and runs the program when
			// released).  The two parsers will go through exactly the same productions, but they
			// will pass a different motion indicator to the engine.
			downActions = new Actions (engine, KeystrokeMotion.Down);
			downParser = new Parser (reader, downActions);
			upActions = new Actions (engine, KeystrokeMotion.Up);
			upParser = new Parser (reader, upActions);

			// The display is initially black, as when the calculator is powered off.
			display.ShowText ("", 0, 0);

			// For some reason the first exception that is raised on this thread takes a long time
			// to propagate.  It is better to raise it here, while the thread initializes, than
			// later, when it could cause a delay visible to the user.
			try 
			{
				throw new Stop ();
			}
			catch 
			{
			}

			// Notify the main thread that we are ready to process keystrokes.
			isInitialized.Set ();

			// Now wait until the main thread tells us that we may run, i.e., that the calculator
			// has been powered on.  The display is set to numeric mode, which is appropriate when
			// the application has just started.  In case of a power cycle the main thread will
			// force us to refresh the display mode based on the W/PRGM-RUN toggle: we couldn't call
			// notifyUI here, because the main window may not be built yet.
			PowerOn.WaitOne ();
			display.Mode = DisplayMode.Numeric;

			for (;;) 
			{
				try 
				{
					// TODO: What if we get several keys in the queue and keyWasTyped is set only
					// once?

					// Wait until we get a keystroke from the UI.
					keyWasTyped.WaitOne ();

					keystroke = (Keystroke) keystrokesQueue.Dequeue ();

					// We want to protect this sequence against asynchronous changes to the menus
					// which may happen if the W/PGRM-RUN switch is moved: we wouldn't want the 
					// menus to be changed by the main thread between the invocation of
					// DisableUI and the call to the parser, or during the execution of
					// the keystroke.
					lock (IsBusy)
					{
						main.Invoke (notifyUI, new object [] {true});
						switch (keystroke.Motion) 
						{
							case KeystrokeMotion.Up :

								// The first up-keystroke after an error is ignored.
								if (ignoreNext) 
								{
									ignoreNext = false;
								}
								else 
								{
									upParser.Parse (keystroke.Tag);
								}
								mustUnbusyUI = true;
								break;

							case KeystrokeMotion.Down :

								// On the first down-keystroke after an error, we reset the display.
								// We do not clear ignoreNext, though, because we want to ensure
								// that the next up-keystroke will be ignored, too.  A normal 
								// down-keystroke may show the current instruction, so we don't
								// refresh the display mode in that case.
								mustUnbusyUI = ignoreNext;
								if (! ignoreNext) 
								{
									downParser.Parse (keystroke.Tag);
								}
								break;
						}
					}
				}
				catch (Error)
				{
					display.Value = display.Value; // Refresh the numeric display.
					display.ShowText (Localization.GetString (Localization.Error), 500, 100);
					mustUnbusyUI = false;
					ignoreNext = true;
					ExecutionCompleteKeystrokes (this);
				}
				catch (Interrupt)
				{

					// We land here if a character was typed during a computation.  In this case,
					// we have a keystroke in the queue, but the keyWasTyped event was cleared by 
					// the code that detected the keystroke.  We must set it again here to make sure
					// that the queue and the event are consistent.
					keyWasTyped.Set ();
					display.Value = display.Value; // Refresh the numeric display.
					mustUnbusyUI = true;
					ignoreNext = true;
					ExecutionCompleteKeystrokes (this);
				}
				catch (Stop)
				{
					mustUnbusyUI = true;
				}
				finally 
				{
					// No cross-thread notification if we are being aborted.
					if (mustUnbusyUI &&
						((thread.ThreadState & ThreadState.AbortRequested) == 0)) 
					{
						engine.Mode = 
							(EngineMode) main.Invoke (notifyUI, new object [] {false});
					}
				}
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

		#endregion

		#region Public Operations

		public void Abort () 
		{
			thread.Abort ();
		}

		public void Enqueue (Keystroke keystroke) 
		{
			keystrokesQueue.Enqueue (keystroke);
			keyWasTyped.Set ();
		}

		#endregion

	}
}
