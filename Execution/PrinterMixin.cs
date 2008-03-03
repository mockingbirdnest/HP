using Mockingbird.HP.Control_Library;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
    public partial class BaseCalculator
    {

        // Logically, this class is a mixin applicable to BaseCalculator.  It is nested within
        // BaseCalculator in order to have visibility to its internal data and methods.

        public class PrinterMixin : IPrinterMixin
        {
            #region Private Data

            private BaseCalculator parent;

            private Mockingbird.HP.Control_Library.Printer _printerPaperRoll;
            private System.Windows.Forms.Button _printerFeedButton;
            private Mockingbird.HP.Control_Library.Toggle _toggleManTraceNorm;

            private System.Windows.Forms.Timer paperFeedTimer;

            #endregion

            #region Private Event Handlers

            private void paperFeedTimer_Tick (object sender, EventArgs e)
            {
                printerPaperRoll.Advance ();
            }

            #endregion

            #region Constructor

            public PrinterMixin (BaseCalculator parent)
            {
                this.parent = parent;
                paperFeedTimer = new System.Windows.Forms.Timer ();
                paperFeedTimer.Tick += new EventHandler (paperFeedTimer_Tick);
            }

            #endregion

            #region Dispatching Operations

            public void PowerOn ()
            {
                toggleManTraceNorm_ToggleMoved (_toggleManTraceNorm, _toggleManTraceNorm.Position);
            }

            #endregion

            #region Controls

            public Button printerFeedButton
            {
                get
                {
                    return _printerFeedButton;
                }
                set
                {
                    _printerFeedButton = value;
                }
            }

            public Mockingbird.HP.Control_Library.Printer printerPaperRoll
            {
                get
                {
                    return _printerPaperRoll;
                }
                set
                {
                    _printerPaperRoll = value;
                }
            }

            public Mockingbird.HP.Control_Library.Toggle toggleManTraceNorm
            {
                get
                {
                    return _toggleManTraceNorm;
                }
                set
                {
                    _toggleManTraceNorm = value;
                }
            }

            #endregion

            #region Inherited Event Handlers

            public void printerFeedButton_MouseDown (object sender, MouseEventArgs e)
            {
                paperFeedTimer.Interval = 500; // ms
                paperFeedTimer.Enabled = true;
                printerPaperRoll.Advance ();
            }

            public void printerFeedButton_MouseUp (object sender, MouseEventArgs e)
            {
                paperFeedTimer.Enabled = false;
            }

            public void toggleManTraceNorm_ToggleMoved (object sender, TogglePosition position)
            {
                switch (position)
                {
                    case TogglePosition.Left:
                        parent.executionThread.Enqueue
                            (new TracingModeMessage (EngineModes.Tracing.Manual));
                        break;
                    case TogglePosition.Center:
                        parent.executionThread.Enqueue
                            (new TracingModeMessage (EngineModes.Tracing.Trace));
                        break;
                    case TogglePosition.Right:
                        parent.executionThread.Enqueue
                            (new TracingModeMessage (EngineModes.Tracing.Normal));
                        break;
                }
            }

            #endregion

        }
    }
}
