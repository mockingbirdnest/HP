using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p99p100 ()
        {
            // Statistical Functions

            // Accumulations

            UIMap.CLREG ();
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Seven ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 7.00          ");
            UIMap.Five ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 1.00          ");
            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.Three ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 2.00          ");
            UIMap.Nine ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 9.00          ");
            UIMap.Eight ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.PrintReg ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.AssertPrinter ("                CLRG",
                                 "                 P⇄S",
                                 "           7.00 ENT↑",
                                 "           5.00   Σ+",
                                 "           5.00 ENT↑",
                                 "           3.00   Σ+",
                                 "           9.00 ENT↑",
                                 "           8.00   Σ+",
                                 "                 P⇄S",
                                 "                PREG",
                                 "",
                                 "           0.00   0 ",
                                 "           0.00   1 ",
                                 "           0.00   2 ",
                                 "           0.00   3 ",
                                 "          16.00   4 ",
                                 "          98.00   5 ",
                                 "          21.00   6 ",
                                 "         155.00   7 ",
                                 "         122.00   8 ",
                                 "           3.00   9 ",
                                 "           0.00   A ",
                                 "           0.00   B ",
                                 "           0.00   C ",
                                 "           0.00   D ",
                                 "           0.00   E ",
                                 "           0.00   I ",
                                 "");

            UIMap.RCL ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 16.00         ");
            UIMap.RCL ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 98.00         ");
            UIMap.RCL ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 21.00         ");
            UIMap.RCL ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 155.00        ");
            UIMap.RCL ();
            UIMap.Eight ();
            UIMap.AssertNumeric (" 122.00        ");
            UIMap.RCL ();
            UIMap.Nine ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.AssertPrinter ("                RCL4",
                                 "                RCL5",
                                 "                RCL6",
                                 "                RCL7",
                                 "                RCL8",
                                 "                RCL9");
        }
    }
}
