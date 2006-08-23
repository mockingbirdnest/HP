using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using System;
using System.Drawing;
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
 CardCalculator
#endif
    {

        public HP67 (string [] arguments)
            : base (arguments, CalculatorModel.HP67)
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
                Application.Run (new HP67 (arguments));
            }
            catch (Shutdown)
            {
            }
        }

    }
}