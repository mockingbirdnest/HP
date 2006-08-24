using Mockingbird.HP.Control_Library;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{

    public partial class ProgrammableCalculator
    {

        // Logically, this class is a mixin applicable to ProgrammableCalculator.  It is nested
        // within ProgrammableCalculator in order to have visibility to its internal data and
        // methods.

        public class CardImplementation : CardInterface
        {
            #region Private Data

            private ProgrammableCalculator parent;

            private Mockingbird.HP.Control_Library.CardSlot _cardSlot;
            private ToolStripMenuItem _editToolStripMenuItem;
            private ToolStripMenuItem _editLabelsToolStripMenuItem;
            private ToolStripMenuItem _rtfToolStripMenuItem;

            #endregion

            #region Constructor

            public CardImplementation (ProgrammableCalculator parent)
            {
                this.parent = parent;
            }

            #endregion

            #region Controls

            public Mockingbird.HP.Control_Library.CardSlot cardSlot
            {
                get
                {
                    return _cardSlot;
                }
                set
                {
                    _cardSlot = value;
                }
            }

            public ToolStripMenuItem editToolStripMenuItem
            {
                get
                {
                    return _editToolStripMenuItem;
                }
                set
                {
                    _editToolStripMenuItem = value;
                }
            }

            public ToolStripMenuItem editLabelsToolStripMenuItem
            {
                get
                {
                    return _editLabelsToolStripMenuItem;
                }
                set
                {
                    _editLabelsToolStripMenuItem = value;
                }
            }

            public ToolStripMenuItem rtfToolStripMenuItem
            {
                get
                {
                    return _rtfToolStripMenuItem;
                }
                set
                {
                    _rtfToolStripMenuItem = value;
                }
            }

            #endregion

            #region Event Handlers

            public void editLabelsToolStripMenuItem_Click (object sender, System.EventArgs e)
            {
                if (cardSlot.State != CardSlotState.Unloaded)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem) sender;
                    bool isChecked = item.Checked;

                    isChecked = !isChecked;
                    item.Checked = isChecked;
                    if (isChecked)
                    {
                        cardSlot.State = CardSlotState.Editable;
                    }
                    else
                    {
                        parent.UpdateUIToReflectProgram (/* programIsEmpty */ false);
                    }
                }
            }

            public void rtfToolStripMenuItem_Click (object sender, System.EventArgs e)
            {
                if (cardSlot.State != CardSlotState.Unloaded)
                {
                    ToolStripMenuItem item = (ToolStripMenuItem) sender;
                    bool isChecked = item.Checked;

                    isChecked = !isChecked;
                    item.Checked = isChecked;
                    cardSlot.RichText = isChecked;
                }
            }

            #endregion

            #region Specific Behavior

            public bool KeyEventsPreempted
            {
                get
                {
                    return cardSlot.State >= CardSlotState.Editable && cardSlot.ContainsFocus;
                }
            }

            public void UpdateUIToReflectProgram (bool programIsEmpty)
            {
                if (programIsEmpty)
                {
                    cardSlot.State = CardSlotState.Unloaded;
                    editLabelsToolStripMenuItem.Enabled = false;
                    rtfToolStripMenuItem.Enabled = false;
                }
                else if (parent.fileName != null &&
                    ((File.GetAttributes (parent.fileName) & FileAttributes.ReadOnly) != 0))
                {
                    cardSlot.State = CardSlotState.ReadOnly;
                    editLabelsToolStripMenuItem.Enabled = false;
                    rtfToolStripMenuItem.Enabled = false;
                }
                else
                {
                    cardSlot.State = CardSlotState.ReadWrite;
                    editLabelsToolStripMenuItem.Enabled = true;
                    rtfToolStripMenuItem.Enabled = true;
                }
            }

            #endregion
        }
    }
}
