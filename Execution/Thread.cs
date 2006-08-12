using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using Queue = System.Collections.Queue;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
    /// <summary>
    /// The execution thread of an HP calculator.
    /// </summary>
    public class Thread
    {

        #region Public Data

        // Delegates used for cross-thread invocation.
        public delegate EngineMode CrossThreadUINotification
            (bool threadIsBusy, bool programIsEmpty);
        public delegate FileStream CrossThreadFileOperation ();

        // Lock this object to ensure that the thread is idle.
        public object IsBusy = new object ();

        // Set this event to power-on the execution thread.
        public AutoResetEvent PowerOn = new AutoResetEvent (false);

        #endregion

        #region Private Data

        private Actions downActions;
        private Parser.Parser downParser;
        private Actions upActions;
        private Parser.Parser upParser;

        private AutoResetEvent downKeystrokeWasEnqueued = new AutoResetEvent (false);
        private Queue messageQueue;
        private AutoResetEvent messageWasEnqueued = new AutoResetEvent (false);

        private Display display;
        private CalculatorModel model;
        private string [] tags;
        private CrossThreadUINotification notifyUI;
        private System.Threading.Thread thread;

        private volatile bool mustAbort;

        #endregion

        #region Constructors & Destructors

        public Thread
            (Display display,
            CalculatorModel model,
            string [] tags,
            CrossThreadUINotification notifyUI)
        {
            this.display = display;
            this.model = model;
            this.tags = tags;
            this.notifyUI = notifyUI;

            // Create the execution thread and wait until it is ready to process requests.
            messageQueue = Queue.Synchronized (new Queue ());
            thread = new System.Threading.Thread (new ThreadStart (Execution));
            thread.Start ();
        }

        #endregion

        #region Callbacks

        private void ExecutionAcceptKeystroke ()
        {

            // Send the key that was just typed (in pause mode) to the parser for execution.
            // TODO: But then the two parsers get desynchronized???
            // TODO: But what if the current message is not a keystroke?
            upParser.Parse (((KeystrokeMessage) messageQueue.Dequeue ()).Tag);
        }

        private void ExecutionCompleteKeystrokes ()
        {

            // Pretend that we accepted the input in order to put the parsers back into a pristine
            // state (in particular, drop any remaining text).
            downActions.ParserAccept ();
            upActions.ParserAccept ();
        }

        private bool ExecutionWaitForKeystroke (int ms)
        {
            return downKeystrokeWasEnqueued.WaitOne (ms, false);
        }

#endregion

        #region Message Handling

        private void ExecutionProcessKeystrokeMessage
            (KeystrokeMessage keystroke,
            Engine engine,
            Program program,
            ref bool ignoreNextDown,
            ref bool ignoreNextUp,
            out bool mustUnbusyUI)
        {
            try
            {
                mustUnbusyUI = true;
                // TODO: What if we get several keys in the queue and keyWasTyped is set only once?

                // We want to protect this sequence against asynchronous changes to the menus which
                // may happen if the W/PGRM-RUN switch is moved: we wouldn't want the menus to be
                // changed by the main thread between the invocation of notifyUI and the call to the
                // parser, or during the execution of the keystroke.
                lock (IsBusy)
                {
                    display.Invoke
                        (notifyUI, new object [] { /* threadIsBusy */ true, program.IsEmpty });

                    switch (keystroke.Motion)
                    {
                        case KeystrokeMotion.Up:

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
                            mustUnbusyUI = !ignoreNextDown;
                            break;
                        case KeystrokeMotion.Down:

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
            catch (Interrupt)
            {
                display.Value = display.Value; // Refresh the numeric display.
                ignoreNextDown = true;
                ignoreNextUp = true;
                mustUnbusyUI = true;
                ExecutionCompleteKeystrokes ();
            }
        }

        private void ExecutionProcessOpenMessage (OpenMessage open, Reader reader)
        {
            FileStream stream = open.Stream;

            try
            {
                // The calls to Card below can throw Error.
                if (open.Merge)
                {
                    Card.Merge (stream, reader);
                }
                else
                {
                    Card.Read (stream, reader);
                }
            }
            finally
            {
                stream.Close ();
            }
        }

        private void ExecutionProcessPrintMessage (PrintMessage print, Program program)
        {
            program.PrintOnePage (print.Arguments, new Font ("Arial Unicode MS", 10));
        }

        private void ExecutionProcessRefreshMessage (RefreshMessage message, out bool mustUnbusyUI)
        {
            mustUnbusyUI = true;
        }

        private void ExecutionProcessSaveMessage (SaveMessage save)
        {
            FileStream stream = save.Stream;

            try
            {
                Card.Write (stream, save.Part);
            }
            finally
            {
                stream.Close ();
            }
        }

        private void ExecutionProcessMessage
            (Engine engine,
            Program program,
            Reader reader,
            ref bool ignoreNextDown,
            ref bool ignoreNextUp,
            out bool mustReinitialize)
        {
            Message message;
            bool mustUnbusyUI = false;

            mustReinitialize = false;
            try
            {
                // TODO: What if we get several keys in the queue and keyWasTyped is set only once?

                // Wait until we get a message from the UI.
                messageWasEnqueued.WaitOne ();
                message = (Message) messageQueue.Dequeue ();

                switch (message.Kind)
                {
                    case MessageKind.Keystroke:
                        ExecutionProcessKeystrokeMessage ((KeystrokeMessage) message,
                                                            engine,
                                                            program,
                                                            ref ignoreNextDown,
                                                            ref ignoreNextUp,
                                                            out mustUnbusyUI);
                        break;
                    case MessageKind.Open:
                        ExecutionProcessOpenMessage ((OpenMessage) message, reader);
                        break;
                    case MessageKind.Print:
                        ExecutionProcessPrintMessage ((PrintMessage) message, program);
                        break;
                    case MessageKind.Refresh:
                        ExecutionProcessRefreshMessage ((RefreshMessage) message, out mustUnbusyUI);
                        break;
                    case MessageKind.Save:
                        ExecutionProcessSaveMessage ((SaveMessage) message);
                        break;
                }
            }
            catch (Error)
            {
                display.Value = display.Value; // Refresh the numeric display.
                display.ShowText (Localization.GetString (Localization.Error), 500, 100);
                ignoreNextDown = true;
                ignoreNextUp = true;
                mustUnbusyUI = false;
                ExecutionCompleteKeystrokes ();
            }
            catch (ThreadAbortException)
            {
                mustUnbusyUI = false; // No cross-thread notification if we are being aborted.
                if (!mustAbort)
                {

                    // A fake abort for reinitialization.
                    System.Threading.Thread.ResetAbort ();
                    mustReinitialize = true;
                }
            }
            finally
            {
                if (mustUnbusyUI)
                {
                    engine.Mode = (EngineMode) display.Invoke
                        (notifyUI, new object [] { /*threadIsBusy*/ false, program.IsEmpty });
                }
            }
        }

        #endregion

        #region Main Loop

        private void Execution ()
        {
            Engine engine;
            Memory memory;
            Program program;
            Reader reader;
            Stack stack;

            bool ignoreNextDown = false;
            bool ignoreNextUp = false;
            bool mustReinitialize = false;

            //// For some reason the first exception that is raised on this thread takes a long time
            //// to propagate.  It is better to raise it here, while the thread initializes, than
            //// later, when it could cause a delay visible to the user.
            //try
            //{
            //    throw new Error ();
            //}
            //catch
            //{
            //}

            // Set the delegates that the display calls to detect and process keys that are typed
            // asynchronously. 
            display.AcceptKeystroke +=
                new Display.ImmediateKeystrokeEvent (ExecutionAcceptKeystroke);
            display.CompleteKeystrokes +=
                new Display.ImmediateKeystrokeEvent (ExecutionCompleteKeystrokes);
            display.WaitForKeystroke +=
                new Display.TimedKeystrokeEvent (ExecutionWaitForKeystroke);

            for (; ; )
            {

                // The display is initially black, as when the calculator is powered off.
                display.ShowText ("", 0, 0);

                // Create the components that depend on the display.
                reader = new Reader ("Mockingbird.HP.Parser.Parser", "CGT", model, tags);
                memory = new Memory (display);
                program = new Program (display, reader);
                stack = new Class_Library.Stack (display);
                engine = new Engine (display, memory, program, reader, stack);
                engine.WaitForKeystroke +=
                    new Engine.TimedKeystrokeEvent (ExecutionWaitForKeystroke);

                // We need two parsers: one that processes the MouseDown events, and one that
                // processes the MouseUp events, because both events have different effects for a
                // given key (e.g., R/S displays the next instruction when depressed, and runs the
                // program when released).  The two parsers will go through exactly the same
                // productions, but they will pass a different motion indicator to the engine.
                downActions = new Actions (engine, KeystrokeMotion.Down);
                downParser = new Parser.Parser (reader, program, downActions);
                upActions = new Actions (engine, KeystrokeMotion.Up);
                upParser = new Parser.Parser (reader, program, upActions);

                // Now wait until the main thread tells us that the calculator has been powered on.
                PowerOn.WaitOne ();

                // Reinitialize the display to its power-on state.
                display.Digits = 2;
                display.Format = DisplayFormat.Fixed;
                display.Mode = DisplayMode.Numeric;
                display.Value = 0;

                do
                {
                    ExecutionProcessMessage
                        (engine,
                        program,
                        reader,
                        ref ignoreNextDown,
                        ref ignoreNextUp,
                        out mustReinitialize);
                } while (!mustReinitialize);
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
            messageQueue.Clear ();
            messageWasEnqueued.Reset ();
            downKeystrokeWasEnqueued.Reset ();
        }

        public void Enqueue (Message message)
        {
            messageQueue.Enqueue (message);
            messageWasEnqueued.Set ();
            if (message.Kind == MessageKind.Keystroke &&
                ((KeystrokeMessage) message).Motion == KeystrokeMotion.Down)
            {
                downKeystrokeWasEnqueued.Set ();
            }
        }

        public void Reset ()
        {

            // In order to power-off the calculator, we send an abort to the execution thread.  
            // That's the only way that we can interrupt an operation in a fully asynchronous
            // manner.  The boolean mustAbort is used to indicate whether we want the thread to
            // abort for good, or merely to reinitialize all of its objects.
            mustAbort = false;
            thread.Abort ();
        }

        #endregion

    }
}
