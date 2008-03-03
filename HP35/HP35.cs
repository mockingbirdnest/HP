using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using System;
using System.Windows.Forms;

namespace Mockingbird.HP.HP35
{
    public partial class HP35:
#if DESIGN
 Form
#else
 BaseCalculator
#endif
    {

        public HP35 (string [] arguments)
            : base (arguments, CalculatorModel.HP35)
        {
        }

        protected override void PreInitializeComponent (string [] arguments, CalculatorModel model)
        {
            base.PreInitializeComponent (arguments, model);
        }

        protected override bool KeyEventsPreempted
        {
            get
            {
                return false;
            }
        }

        protected override void BusyUI ()
        {
        }

        public override void CrossThreadNotifyUI (bool threadIsBusy, bool programIsEmpty)
        {
        }

        protected override void PowerOff ()
        {
            // OFF.  We abort the execution thread and start a new one.  We leave it in the
            // state where its display is black and it doesn't accept keystrokes.
            BusyUI ();
            executionThread.Reset ();
        }

        protected override void ProcessCommandLine (string [] arguments)
        {
        }

        protected override void UnbusyUI ()
        {
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
                Application.Run (new HP35 (arguments));
            }
            catch (Shutdown)
            {
            }
        }
    }
}