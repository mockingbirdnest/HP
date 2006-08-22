using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
    /// <summary>
    /// Abstract base class for magnetic card calculators.
    /// </summary>
    public abstract class CardCalculator : ProgrammableCalculator
    {

        #region Protected & Private Data

        protected Mockingbird.HP.Control_Library.CardSlot cardSlot;
        protected ToolStripMenuItem editToolStripMenuItem;
        protected ToolStripMenuItem editLabelsToolStripMenuItem;
        protected ToolStripMenuItem rtfToolStripMenuItem;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors & Destructors

        public CardCalculator (string [] argument, CalculatorModel model)
            :
            base (argument, model)
        {
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose (bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose ();
                }
            }
            base.Dispose (disposing);
        }

        #endregion

        #region Overriding Operations

        protected override bool KeyEventsPreempted
        {
            get
            {
                return cardSlot.State >= CardSlotState.Editable && cardSlot.ContainsFocus;
            }
        }

        protected override void UpdateUIToReflectProgram (bool programIsEmpty)
        {
            base.UpdateUIToReflectProgram (programIsEmpty);
            if (programIsEmpty)
            {
                cardSlot.State = CardSlotState.Unloaded;
                editLabelsToolStripMenuItem.Enabled = false;
                rtfToolStripMenuItem.Enabled = false;
            }
            else if (fileName != null &&
                ((File.GetAttributes (fileName) & FileAttributes.ReadOnly) != 0))
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

        #region UI Event Handlers

        protected void editLabelsToolStripMenuItem_Click (object sender, System.EventArgs e)
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
                    UpdateUIToReflectProgram (/* programIsEmpty */ false);
                }
            }
        }

        protected void rtfToolStripMenuItem_Click (object sender, System.EventArgs e)
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

    }
}
