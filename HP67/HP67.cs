using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mockingbird.HP.HP67
{
    /// <summary>
    /// The user interface for the HP-67 calculator.
    /// </summary>
    public partial class HP67 :
#if DESIGN
 Form
#else
 ProgrammableCalculator, CardInterface
#endif
    {

        // The silly language doesn't do mixins, so we use containment.  Sigh.
        ProgrammableCalculator.CardImplementation card;

        public HP67 (string [] arguments)
            : base (arguments, CalculatorModel.HP67)
        {
        }

        protected override void PreInitializeComponent (string [] arguments, CalculatorModel model)
        {
            base.PreInitializeComponent (arguments, model);
            card = new CardImplementation (this);
        }

        #region Implementation of The Card Interface

#if !DESIGN

        public Mockingbird.HP.Control_Library.CardSlot cardSlot
        {
            get
            {
                return card.cardSlot;
            }
            set
            {
                card.cardSlot = value;
            }
        }

        public ToolStripMenuItem editToolStripMenuItem
        {
            get
            {
                return card.editToolStripMenuItem;
            }
            set
            {
                card.editToolStripMenuItem = value;
            }
        }

        public ToolStripMenuItem editLabelsToolStripMenuItem
        {
            get
            {
                return card.editLabelsToolStripMenuItem;
            }
            set
            {
                card.editLabelsToolStripMenuItem = value;
            }
        }

        public ToolStripMenuItem rtfToolStripMenuItem
        {
            get
            {
                return card.rtfToolStripMenuItem;
            }
            set
            {
                card.rtfToolStripMenuItem = value;
            }
        }

        public void editLabelsToolStripMenuItem_Click (object sender, System.EventArgs e)
        {
            card.editLabelsToolStripMenuItem_Click (sender, e);
        }

        public void rtfToolStripMenuItem_Click (object sender, System.EventArgs e)
        {
            card.rtfToolStripMenuItem_Click (sender, e);
        }

#endif

        #endregion

        protected override bool KeyEventsPreempted
        {
            get
            {
                return card.KeyEventsPreempted;
            }
        }

        protected override void UpdateUIToReflectProgram (bool programIsEmpty)
        {
            card.UpdateUIToReflectProgram (programIsEmpty);
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main (string [] arguments)
        {
            try
            {
                //Application.EnableVisualStyles ();
                //Application.SetCompatibleTextRenderingDefault (false);
                Application.Run (new HP67 (arguments));
            }
            catch (Shutdown)
            {
            }
        }
    }
}