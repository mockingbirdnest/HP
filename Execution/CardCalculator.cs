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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected abstract override void InitializeComponent ();
        #endregion

        #endregion

        #region Overriding Operations

        protected override bool KeyEventsPreempted
        {
            get
            {
                return cardSlot.State >= CardSlotState.Editable && cardSlot.ContainsFocus;
            }
        }

        protected override void PowerOff ()
        {
            // OFF.  We abort the execution thread and start a new one.  We leave it in the
            // state where its display is black and it doesn't accept keystrokes.
            BusyUI ();
            executionThread.Reset ();
            UpdateCardSlot (/* programIsEmpty */ true);
        }

        protected override void UpdateUI (bool programIsEmpty)
        {
            UpdateCardSlot (programIsEmpty);
        }

        #endregion

        #region Cross-Thread Operations

        public FileStream CrossThreadOpen ()
        {
            string name;

            if (openFileDialog.ShowDialog () == DialogResult.OK)
            {
                name = openFileDialog.FileName;
                return Open (ref name);
            }
            else
            {
                return null;
            }
        }

        public FileStream CrossThreadSaveDataAs ()
        {
            string name = null;

            return Save (/* saveAs */ true, ref name);
        }

        #endregion

        #region UI Utilities

        private void UpdateCardSlot (bool programIsEmpty)
        {
            bool wasUnloaded = (cardSlot.State == CardSlotState.Unloaded);

            //TODO: Separate UpdateCardSlot from UpdateMenus.  Also disable Save/Print when program is empty. 
            // Make sure that the state of the card slot reflects the state of the program memory.
            try
            {
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
            finally
            {

                // If the program was just cleared, clear the current file name.  This ensures that
                // the next program won't be stupidly saved on the previous card.
                if (!wasUnloaded && cardSlot.State == CardSlotState.Unloaded)
                {
                    fileName = null;
                }
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
                    UpdateCardSlot (/* programIsEmpty */ false);
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
