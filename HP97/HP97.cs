﻿using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.HP97
{
    /// <summary>
    /// The user interface for the HP-97 calculator.
    /// </summary>
    public partial class HP97 :
#if DESIGN
 Form
#else
 ProgrammableCalculator, ICardMixin, IPrinterMixin
#endif
    {

        // The silly language doesn't do mixins, so we use containment.  Sigh.
        ProgrammableCalculator.CardMixin card;
        BaseCalculator.PrinterMixin printer;

        public HP97 (string [] arguments)
            : base (arguments, CalculatorModel.HP97)
        {
        }

        protected override void PreInitializeComponent (string [] arguments, CalculatorModel model)
        {
            base.PreInitializeComponent (arguments, model);
            card = new CardMixin (this);
            printer = new PrinterMixin (this);
        }

        protected override void PostInitializeComponent (string [] arguments, CalculatorModel model, Control [] sharedControls)
        {
            Array.Resize<Control> (ref sharedControls, sharedControls.Length + 1);
            sharedControls [sharedControls.Length - 1] = printerPaperRoll;
            base.PostInitializeComponent (arguments, model, sharedControls);
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

        #region Implementation of The Printer Interface

#if !DESIGN

        public Button printerFeedButton
        {
            get
            {
                return printer.printerFeedButton;
            }
            set
            {
                printer.printerFeedButton = value;
            }
        }

        public Mockingbird.HP.Control_Library.Printer printerPaperRoll
        {
            get
            {
                return printer.printerPaperRoll;
            }
            set
            {
                printer.printerPaperRoll = value;
            }
        }

        public void printerFeedButton_MouseDown (object sender, MouseEventArgs e)
        {
            printer.printerFeedButton_MouseDown (sender, e);
        }

        public void printerFeedButton_MouseUp (object sender, MouseEventArgs e)
        {
            printer.printerFeedButton_MouseUp (sender, e);
        }

#endif

        #endregion

        public override EngineModes CrossThreadNotifyUI (bool threadIsBusy, bool programIsEmpty)
        {
            EngineModes modes = base.CrossThreadNotifyUI (threadIsBusy, programIsEmpty);

            switch (toggleManTraceNorm.Position) {
                case TogglePosition.Left:
                    modes.tracing = EngineModes.Tracing.Manual;
                    break;
                case TogglePosition.Center:
                    modes.tracing = EngineModes.Tracing.Trace;
                    break;
                case TogglePosition.Right:
                    modes.tracing = EngineModes.Tracing.Normal;
                    break;
            }
            return modes;
        }

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

        private void toggleManTraceNorm_ToggleMoved (object sender, TogglePosition position)
        {
            // See toggleWprgmRun_ToggleMoved for explanations.
            if (Monitor.TryEnter (executionThread.IsBusy))
            {
                try
                {
                    executionThread.Enqueue (new RefreshMessage ());
                }
                finally
                {
                    Monitor.Exit (executionThread.IsBusy);
                }
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main (string [] arguments)
        {
            try
            {
                Application.Run (new HP97 (arguments));
            }
            catch (Shutdown)
            {
            }
        }

    }
}
