using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p58 ()
        {
            // Order of Execution
            UIMap.Three ();
            UIMap.AssertNumeric (" 3.            ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.Four ();
            UIMap.AssertNumeric (" 4.            ");
            UIMap.Division ();
            UIMap.AssertNumeric (" 0.75          ");

            UIMap.Five ();
            UIMap.AssertNumeric (" 5.            ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.Two ();
            UIMap.AssertNumeric (" 2.            ");
            UIMap.Division ();
            UIMap.AssertNumeric (" 2.50          ");

            UIMap.Subtraction ();
            UIMap.AssertNumeric ("-1.75          ");

            UIMap.Four ();
            UIMap.AssertNumeric (" 4.            ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 4.00          ");
            UIMap.Three ();
            UIMap.AssertNumeric (" 3.            ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 12.00         ");

            UIMap.Addition ();
            UIMap.AssertNumeric (" 10.25         ");

            UIMap.Three ();
            UIMap.AssertNumeric (" 3.            ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.Period ();
            UIMap.Two ();
            UIMap.One ();
            UIMap.Three ();
            UIMap.AssertNumeric (" .213          ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.64          ");

            UIMap.Division ();
            UIMap.AssertNumeric (" 16.04         ");
            UIMap.Five ();
            UIMap.AssertNumeric (" 5.            ");

            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 80.20         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 80.20         ");
            UIMap.AssertPrinter ("           3.00 ENT↑",
                                 "           4.00   ÷ ",
                                 "           5.00 ENT↑",
                                 "           2.00   ÷ ",
                                 "                  - ",
                                 "           4.00 ENT↑",
                                 "           3.00   × ",
                                 "                  + ",
                                 "           3.00 ENT↑",
                                 "           .213   × ",
                                 "                  ÷ ",
                                 "           5.00   × ",
                                 "          80.20  ***");
        }
    }
}
