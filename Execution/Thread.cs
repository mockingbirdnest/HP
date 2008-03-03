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
        public delegate void CrossThreadUINotification (bool threadIsBusy, bool programIsEmpty);
        public delegate FileStream CrossThreadFileOperation ();

        // Lock this object to ensure that the thread is idle.
        public object IsBusy = new object ();

        // Set this event to power-on the execution thread.
        public AutoResetEvent PowerOn = new AutoResetEvent (false);

        #endregion

        #region Private Data

        private const int capacity = 1000;

        private Actions downActions;
        private Parser.Parser downParser;
        private Actions upActions;
        private Parser.Parser upParser;

        private AutoResetEvent downKeystrokeWasEnqueued = new AutoResetEvent (false);

        // This will look strange.  We want to keep track of the number of entries in the message
        // queue, and to block when that number is 0.  We use a semaphore which is initially fully
        // reserved, and has therefore a free count of 0.  When a message is queued, we call Release
        // to increment the free count.  The execution thread suspends by calling WaitOne until
        // the free count is positive, i.e., until there is one or several messages in the queue.
        private Semaphore messagesEnqueued = new Semaphore (0, capacity);
        private Queue messageQueue;

        private byte digits;
        private Display display;
        private sbyte fixedUnderflowExponentThreshold;
        private bool hasExtraDigitBetween0And1;
        private CalculatorModel model;
        private Printer printer;
        private bool stripZeros;
        private string [] tags;
        private CrossThreadUINotification notifyUI;
        private System.Threading.Thread thread;

        private volatile bool mustAbort;

        #endregion

        #region Constructors & Destructors

        public Thread (CalculatorModel model,
                       string [] tags,
                       Control [] sharedControls,
                       CrossThreadUINotification notifyUI)
        {
            this.model = model;
            this.tags = tags;
            this.notifyUI = notifyUI;
            switch (model)
            {
                case CalculatorModel.HP35:
                    digits = 9;
                    fixedUnderflowExponentThreshold = -2;
                    hasExtraDigitBetween0And1 = true;
                    stripZeros = true;
                    break;
                case CalculatorModel.HP67:
                case CalculatorModel.HP97:
                    digits = 2;
                    fixedUnderflowExponentThreshold = sbyte.MinValue;
                    hasExtraDigitBetween0And1 = false;
                    stripZeros = false;
                    break;
            }
            for (int i = 0; i < sharedControls.Length; i++)
            {
                if (sharedControls [i] is Display)
                {
                    Trace.Assert (this.display == null);
                    this.display = (Display) sharedControls [i];
                }
                else if (sharedControls [i] is Printer)
                {
                    Trace.Assert (this.printer == null);
                    this.printer = (Printer) sharedControls [i];
                }
                else
                {
                    Trace.Assert (false);
                }
            }

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

        private void ExecutionProcessExecutionModeMessage (ExecutionModeMessage execution,
                                                           Engine engine,
                                                           out bool mustUnbusyUI)
        {
            engine.ExecutionMode = execution.Mode;
            mustUnbusyUI = true;
        }

        private void ExecutionProcessKeystrokeMessage
            (KeystrokeMessage keystroke,
             Engine           engine,
             Program          program,
             Stack            stack,
             ref bool         ignoreNextDown,
             ref bool         ignoreNextUp,
             out bool         mustUnbusyUI)
        {
            try
            {
                mustUnbusyUI = true;

                // We want to protect this sequence against asynchronous changes to the menus which
                // may happen if the W/PGRM-RUN switch is moved: we wouldn't want the menus to be
                // changed by the main thread between the invocation of notifyUI and the call to the
                // parser, or during the execution of the keystroke.
                lock (IsBusy)
                {
                    bool programWasEmpty = program.IsEmpty;
                    display.Invoke
                        (notifyUI, new object [] { /* threadIsBusy */ true, programWasEmpty });

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

                            // In general we *don't* refresh the display here because a down
                            // keystroke may display the current instruction.  There are three
                            // exceptions to this, though: we refresh if the display is blurred, or
                            // if this is the key that clears an error, or if the state of the
                            // program changed.  The latter is necessary because we are not sure to
                            // get an up keystroke for MERGE, as the mouse is likely to move to the
                            // dialog box.

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
                            mustUnbusyUI = ignoreNextUp ||
                                           display.IsBlurred ||
                                           program.IsEmpty != programWasEmpty;
                            break;
                    }
                }
            }
            catch (Interrupt)
            {
                display.Formatter.Value = stack.X; // Refresh the numeric display.
                ignoreNextDown = true;
                ignoreNextUp = true;
                mustUnbusyUI = true;
                ExecutionCompleteKeystrokes ();
            }
        }

        private void ExecutionProcessOpenMessage
            (OpenMessage open,
            Reader reader,
            out bool mustUnbusyUI)
        {
            FileStream stream = open.Stream;

            mustUnbusyUI = true;
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

        //private void ExecutionProcessRefreshMessage (RefreshMessage message, out bool mustUnbusyUI)
        //{
        //    mustUnbusyUI = true;
        //}

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

        private void ExecutionProcessTracingModeMessage (TracingModeMessage tracing, 
                                                         Engine engine,
                                                         out bool mustUnbusyUI)
        {
            engine.TracingMode = tracing.Mode;
            mustUnbusyUI = true;
        }

        private void ExecutionProcessMessage
            (Engine           engine,
             Program          program,
             Reader           reader,
             Stack            stack,
             ref bool         ignoreNextDown,
             ref bool         ignoreNextUp,
             out bool         mustReinitialize)
        {
            Message message = null;
            bool mustUnbusyUI = false;

            mustReinitialize = false;
            try
            {

                // Wait until we get a message from the UI.
                messagesEnqueued.WaitOne ();
                message = (Message) messageQueue.Dequeue ();

                switch (message.Kind)
                {
                    case MessageKind.ExecutionMode:
                        ExecutionProcessExecutionModeMessage ((ExecutionModeMessage) message,
                                                              engine,
                                                              out mustUnbusyUI);
                        break;
                    case MessageKind.Keystroke:
                        ExecutionProcessKeystrokeMessage ((KeystrokeMessage) message,
                                                           engine,
                                                           program,
                                                           stack,
                                                           ref ignoreNextDown,
                                                           ref ignoreNextUp,
                                                           out mustUnbusyUI);
                        break;
                    case MessageKind.Open:
                        ExecutionProcessOpenMessage ((OpenMessage) message,
                                                     reader,
                                                     out mustUnbusyUI);
                        break;
                    case MessageKind.Print:
                        ExecutionProcessPrintMessage ((PrintMessage) message, program);
                        break;
                    case MessageKind.Save:
                        ExecutionProcessSaveMessage ((SaveMessage) message);
                        break;
                    case MessageKind.TracingMode:
                        ExecutionProcessTracingModeMessage ((TracingModeMessage) message,
                                                            engine,
                                                            out mustUnbusyUI);
                        break;
                }
            }
            catch (Error)
            {
                // It is important to update the printer before the display, otherwise the error
                // message will be printed after a long delay.
                if (engine.MustTrace)
                {
                    printer.PrintText (Localization.PrinterError);
                }
                display.Formatter.Value = stack.X; // Refresh the numeric display.
                display.ShowText (Localization.DisplayError, 500, 100);
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
                    display.Invoke
                        (notifyUI, new object [] { /*threadIsBusy*/ false, program.IsEmpty });
                }

                // If the message was executed synchronously, release the calling thread now.
                if (message != null && message.Synchronous)
                {
                    try
                    {
                        Monitor.Enter (message);
                        Monitor.Pulse (message);
                    }
                    finally
                    {
                        Monitor.Exit (message);
                    }
                }
            }
        }

        #endregion

        #region Main Loop

        private void Execution ()
        {
            Engine           engine;
            Memory           memory;
            Program          program;
            Reader           reader;
            Stack            stack;
            Number.Validater validater;

            bool ignoreNextDown = false;
            bool ignoreNextUp = false;
            bool mustReinitialize = false;

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

                // Create the component that do not depend on the display.
                reader = new Reader ("Mockingbird.HP.Parser.Parser", "CGT", model, tags);
                validater = new Number.Validater ();

                // Initialize the display and the printer.  This must happen early, because the
                // engine might want to echo the display on the printer, and that's not appropriate
                // at power on.
                display.Formatter = new Number.Formatter (digits,
                                                          Number.DisplayFormat.Fixed,
                                                          fixedUnderflowExponentThreshold,
                                                          hasExtraDigitBetween0And1,
                                                          /*padMantissa*/ true,
                                                          /*showPlusSignInExponent*/ false,
                                                          stripZeros);
                display.Formatter.Value = 0.0M;
                if (printer != null)
                {
                    printer.Formatter = new Number.Formatter (digits,
                                                              Number.DisplayFormat.Fixed,
                                                              fixedUnderflowExponentThreshold,
                                                              hasExtraDigitBetween0And1,
                                                              /*padMantissa*/ false,
                                                              /*showPlusSignInExponent*/ true,
                                                              stripZeros);
                }

                // Create the components that depend on the display.
                memory = new Memory (display, printer);
                program = new Program (display, printer, reader);
                stack = new Stack (display, printer, validater);
                engine = new Engine (display,
                                     memory,
                                     printer,
                                     program,
                                     reader,
                                     stack,
                                     validater);
                engine.WaitForKeystroke +=
                    new Engine.TimedKeystrokeEvent (ExecutionWaitForKeystroke);
                display.Invoke
                    (notifyUI, new object [] { /*threadIsBusy*/ false, /* programIsEmpty */ true });

                // We need two parsers: one that processes the MouseDown events, and one that
                // processes the MouseUp events, because both events have different effects for a
                // given key (e.g., R/S displays the next instruction when depressed, and runs the
                // program when released).  The two parsers will go through exactly the same
                // productions, but they will pass a different motion indicator to the engine.
                downActions = new Actions (engine, KeystrokeMotion.Down);
                downParser = new Parser.Parser (reader, program, downActions);
                upActions = new Actions (engine, KeystrokeMotion.Up);
                upParser = new Parser.Parser (reader, program, upActions);

                // The display is initially black, as when the calculator is powered off.  This must
                // be done last, as some of the operations above may interact with the display.
                display.ShowText ("", 0, 0);

                // Now wait until the main thread tells us that the calculator has been powered on.
                PowerOn.WaitOne ();

                // Reinitialize the display to its power-on state.
                display.Mode = DisplayMode.Numeric;

                do
                {
                    ExecutionProcessMessage
                        (engine,
                         program,
                         reader,
                         stack,
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

            // Decrement the free count.  We do not expect it to ever get big, so we won't go
            // through this loop many times.
            while (messagesEnqueued.WaitOne (0, false)) { 
            }
            downKeystrokeWasEnqueued.Reset ();
            messageQueue.Clear ();
        }

        public void Enqueue (Message message)
        {
            messageQueue.Enqueue (message);

            // In synchronous mode, we use the message as a lock, and we wait until the execution
            // thread pulses us to tell that it is done with the message.  The synchronous bit is
            // used to control whether pulsing must happen.  It is not required for correctness, but
            // it avoids unnecessary pulsing.
            if (message.Synchronous)
            {
                try
                {
                    Monitor.Enter (message);
                    messagesEnqueued.Release ();
                    Monitor.Wait (message);
                }
                finally
                {
                    Monitor.Exit (message);
                }
            }
            else
            {
                messagesEnqueued.Release ();
            }

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
