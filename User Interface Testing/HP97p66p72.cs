using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p66p72 ()
        {
            // Set up memory by re-running some tests.
            p64p65 ();
            p65 ();

            // Protected Secondary Storage Registers
            UIMap.One ();
            UIMap.Six ();
            UIMap.Four ();
            UIMap.Nine ();
            UIMap.Five ();
            UIMap.SendKeys ("000");
            UIMap.AssertNumeric (" 16495000.     ");
            UIMap.STO ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 16495000.00   ");
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 16495000.00   ");
            UIMap.AssertPrinter ("    16495000.00 STO5",
                                 "                 P⇄S");

            UIMap.RCL ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.AssertPrinter ("                RCL5");

            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.RCL ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 16495000.00   ");
            UIMap.AssertPrinter ("                 P⇄S",
                                 "                RCL5");

            UIMap.Five ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 82475000.00   ");
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 82475000.00   ");
            UIMap.STO ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 82475000.00   ");
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 82475000.00   ");
            UIMap.AssertPrinter ("           5.00   × ",
                                 "                 P⇄S",
                                 "                STO5",
                                 "                 P⇄S");

            UIMap.RCL ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 16495000.00   ");
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 16495000.00   ");
            UIMap.RCL ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 82475000.00   ");
            UIMap.AssertPrinter ("                RCL5",
                                 "                 P⇄S",
                                 "                RCL5");

            // Printing the Storage Registers
            UIMap.PrintReg ();
            UIMap.AssertNumeric (" 82475000.00   ");
            UIMap.AssertPrinter ("                PREG",
                                 "",
                                 "           0.00   0 ",
                                 "           0.00   1 ",
                                 "           0.00   2 ",
                                 "           0.00   3 ",
                                 "           0.00   4 ",
                                 "    82475000.00   5 ",
                                 "           0.00   6 ",
                                 "           0.00   7 ",
                                 "           0.00   8 ",
                                 "           0.00   9 ",
                                 "           0.00   A ",
                                 " 3.624040000+47   B ",
                                 "           0.00   C ",
                                 "           0.00   D ",
                                 "           0.00   E ",
                                 "           3.79   I ",
                                 "");

            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 82475000.00   ");
            UIMap.PrintReg ();
            UIMap.AssertNumeric (" 82475000.00   ");
            UIMap.AssertPrinter ("                 P⇄S",
                                 "                PREG",
                                 "",
                                 "           0.00   0 ",
                                 "           0.00   1 ",
                                 " 6.020000000+23   2 ",
                                 "           0.00   3 ",
                                 "           0.00   4 ",
                                 "    16495000.00   5 ",
                                 "           0.00   6 ",
                                 "           0.00   7 ",
                                 "           0.00   8 ",
                                 "           0.00   9 ",
                                 "           0.00   A ",
                                 " 3.624040000+47   B ",
                                 "           0.00   C ",
                                 "           0.00   D ",
                                 "           0.00   E ",
                                 "           3.79   I ",
                                 "");

            // Clearing Storage Registers
            UIMap.Zero ();
            UIMap.STO ();
            UIMap.B ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.PrintReg ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.AssertPrinter ("           0.00 STOB",
                                 "                PREG",
                                 "",
                                 "           0.00   0 ",
                                 "           0.00   1 ",
                                 " 6.020000000+23   2 ",
                                 "           0.00   3 ",
                                 "           0.00   4 ",
                                 "    16495000.00   5 ",
                                 "           0.00   6 ",
                                 "           0.00   7 ",
                                 "           0.00   8 ",
                                 "           0.00   9 ",
                                 "           0.00   A ",
                                 "           0.00   B ",
                                 "           0.00   C ",
                                 "           0.00   D ",
                                 "           0.00   E ",
                                 "           3.79   I ",
                                 "");

            // Not mentioned by the user manual but probably required to get an extra blank line.
            UIMap.PrinterFeedShort ();

            UIMap.CLREG ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.PrintReg ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.AssertPrinter ("",
                                 "                CLRG",
                                 "                PREG",
                                 "",
                                 "           0.00   0 ",
                                 "           0.00   1 ",
                                 "           0.00   2 ",
                                 "           0.00   3 ",
                                 "           0.00   4 ",
                                 "           0.00   5 ",
                                 "           0.00   6 ",
                                 "           0.00   7 ",
                                 "           0.00   8 ",
                                 "           0.00   9 ",
                                 "           0.00   A ",
                                 "           0.00   B ",
                                 "           0.00   C ",
                                 "           0.00   D ",
                                 "           0.00   E ",
                                 "           0.00   I ",
                                 "");

            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.CLREG ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.PrintReg ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.AssertPrinter ("                 P⇄S",
                                 "                CLRG",
                                 "                PREG",
                                 "",
                                 "           0.00   0 ",
                                 "           0.00   1 ",
                                 "           0.00   2 ",
                                 "           0.00   3 ",
                                 "           0.00   4 ",
                                 "           0.00   5 ",
                                 "           0.00   6 ",
                                 "           0.00   7 ",
                                 "           0.00   8 ",
                                 "           0.00   9 ",
                                 "           0.00   A ",
                                 "           0.00   B ",
                                 "           0.00   C ",
                                 "           0.00   D ",
                                 "           0.00   E ",
                                 "           0.00   I ",
                                 "");
        }
    }
}
