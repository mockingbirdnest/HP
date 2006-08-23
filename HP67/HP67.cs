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
        CardCalculator
#endif
    {

        public HP67 (string [] arguments)
            : base (arguments, CalculatorModel.HP67)
        {
        }

    }
}