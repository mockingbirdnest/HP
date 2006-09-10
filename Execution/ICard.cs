using Mockingbird.HP.Control_Library;
using System;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
    public interface ICard
    {

        // This interface supports a poor man's mixin.  The concrete calculator classes that have a
        // card reader must implement it by declaring a local object of type CardImplementation and
        // calling its methods.  The methods of CardImplementation that do not correspond to a
        // method of this interface represent behaviors specific to the card reader and may be
        // called from the concrete calculator class to implement its own behavior.

        #region Controls

        Mockingbird.HP.Control_Library.CardSlot cardSlot
        {
            get;
            set;
        }

        ToolStripMenuItem editToolStripMenuItem
        {
            get;
            set;
        }

        ToolStripMenuItem editLabelsToolStripMenuItem
        {
            get;
            set;
        }

        ToolStripMenuItem rtfToolStripMenuItem
        {
            get;
            set;
        }

        #endregion

        #region Event Handlers

        void editLabelsToolStripMenuItem_Click (object sender, System.EventArgs e);

        void rtfToolStripMenuItem_Click (object sender, System.EventArgs e);

        #endregion

    }
}
