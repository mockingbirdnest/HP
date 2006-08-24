using Mockingbird.HP.Control_Library;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{

    public partial class BaseCalculator
    {

        // Logically, this class is a mixin applicable to BaseCalculator.  It is nested within
        // BaseCalculator in order to have visibility to its internal data and methods.

        public class PrinterImplementation : PrinterInterface
        {
            #region Private Data

            private BaseCalculator parent;

            private Mockingbird.HP.Control_Library.Printer _printerPaperRoll;
            private System.Windows.Forms.Button _printerFeedButton;

            #endregion

            #region Constructor

            public PrinterImplementation (BaseCalculator parent)
            {
                this.parent = parent;
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

            #endregion

            #region Event Handlers

            public void printerFeedButton_Click (object sender, EventArgs e)
            {
                // TODO: Use a timer.
                printerPaperRoll.Advance ();
            }

            #endregion

        }
    }
}
