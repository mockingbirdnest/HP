using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p14 ()
        {
            // Manual Problem Solving
            UIMap.ManTraceNorm2Left ();

            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.Six ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 11.00         ");

            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 4.00          ");

            UIMap.Seven ();
            UIMap.ENTER ();
            UIMap.Four ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 3.00          ");

            UIMap.Nine ();
            UIMap.ENTER ();
            UIMap.Eight ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 72.00         ");

            UIMap.Five ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 0.20          ");

            UIMap.Three ();
            UIMap.Zero ();
            UIMap.SIN ();
            UIMap.AssertNumeric (" 0.50          ");

            UIMap.ManTraceNorm2Right ();

            UIMap.Three ();
            UIMap.Two ();
            UIMap.ZeroZero ();
            UIMap.AssertNumeric (" 3200.         ");

            UIMap.Square ();
            UIMap.AssertNumeric (" 10240000.00   ");
            UIMap.AssertPrinter ("        3200.00   X²");

            UIMap.Pi ();
            UIMap.AssertNumeric (" 3.14          ");
            UIMap.AssertPrinter ("                  Pi");

            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 32169908.78   ");
            UIMap.AssertPrinter ("                  × ");

            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 32169908.78   ");
            UIMap.AssertPrinter ("    32169908.78  ***");
        }
    }
}
