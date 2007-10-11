using Mockingbird.HP.Control_Library;
using System;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
    public interface IPrinterMixin
    {

        // This interface supports a poor man's mixin.  The concrete calculator classes that have a
        // printer must implement it by declaring a local object of type PrinterMixin and calling its
        // methods.  The methods of PrinterMixin that do not correspond to a method of this interface
        // represent behaviors specific to the printer and may be called from the concrete calculator
        // class to implement its own behavior.

        #region Controls

        Button printerFeedButton
        {
            get;
            set;
        }

        Mockingbird.HP.Control_Library.Printer printerPaperRoll
        {
            get;
            set;
        }

        Mockingbird.HP.Control_Library.Toggle toggleManTraceNorm
        {
            get;
            set;
        }

        #endregion

        #region Event Handlers

        void printerFeedButton_MouseDown (object sender, MouseEventArgs e);

        void printerFeedButton_MouseUp (object sender, MouseEventArgs e);

        void toggleManTraceNorm_ToggleMoved (object sender, TogglePosition position);

        #endregion

    }
}
