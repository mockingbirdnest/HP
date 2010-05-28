using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p48p53 ()
        {
            // Manipulating Stack Contents

            // Reviewing the Stack
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.AssertPrinter ("           4.00 ENT↑",
                                 "           3.00 ENT↑",
                                 "           2.00 ENT↑");
            UIMap.AssertNumeric (" 1.            ");
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("           1.00 PRST",
                                 "",
                                 "           4.00   T ",
                                 "           3.00   Z ",
                                 "           2.00   Y ",
                                 "           1.00   X ",
                                 "");
            UIMap.AssertNumeric (" 1.00          ");

            UIMap.RDown ();
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                  R↓",
                                 "                PRST",
                                 "",
                                 "           1.00   T ",
                                 "           4.00   Z ",
                                 "           3.00   Y ",
                                 "           2.00   X ",
                                 "");
            UIMap.AssertNumeric (" 2.00          ");

            UIMap.RDown ();
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                  R↓",
                                 "                PRST",
                                 "",
                                 "           2.00   T ",
                                 "           1.00   Z ",
                                 "           4.00   Y ",
                                 "           3.00   X ",
                                 "");
            UIMap.AssertNumeric (" 3.00          ");

            UIMap.RDown ();
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                  R↓",
                                 "                PRST",
                                 "",
                                 "           3.00   T ",
                                 "           2.00   Z ",
                                 "           1.00   Y ",
                                 "           4.00   X ",
                                 "");
            UIMap.AssertNumeric (" 4.00          ");

            UIMap.RDown ();
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                  R↓",
                                 "                PRST",
                                 "",
                                 "           4.00   T ",
                                 "           3.00   Z ",
                                 "           2.00   Y ",
                                 "           1.00   X ",
                                 "");
            UIMap.AssertNumeric (" 1.00          ");

            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                PRST",
                                 "",
                                 "           4.00   T ",
                                 "           3.00   Z ",
                                 "           2.00   Y ",
                                 "           1.00   X ",
                                 "");
            UIMap.AssertNumeric (" 1.00          ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 2.00          ");
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                 X⇄Y",
                                 "                PRST",
                                 "",
                                 "           4.00   T ",
                                 "           3.00   Z ",
                                 "           1.00   Y ",
                                 "           2.00   X ",
                                 "");
            UIMap.AssertNumeric (" 2.00          ");

            // Clearing the Display
            UIMap.CLx ();
            UIMap.AssertPrinter ("                 CLX");
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                PRST",
                                 "",
                                 "           4.00   T ",
                                 "           3.00   Z ",
                                 "           1.00   Y ",
                                 "           0.00   X ",
                                 "");
            UIMap.AssertNumeric (" 0.00          ");
            
            // The ENTER Key
            UIMap.Three ();
            UIMap.One ();
            UIMap.Four ();
            UIMap.Period ();
            UIMap.Three ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.AssertPrinter ("         314.32 ENT↑");
            UIMap.AssertNumeric (" 314.32        ");
            // Not in the manual, but useful to check the stack
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                PRST",
                                 "",
                                 "           3.00   T ",
                                 "           1.00   Z ",
                                 "         314.32   Y ",
                                 "         314.32   X ",
                                 "");
            
            UIMap.Five ();
            UIMap.Four ();
            UIMap.Three ();
            UIMap.Period ();
            UIMap.Two ();
            UIMap.Eight ();
            UIMap.AssertNumeric (" 543.28        ");
            UIMap.CLx ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Six ();
            UIMap.Eight ();
            UIMap.Nine ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 689.4         ");

            // One-Number Functions and the Stack
            UIMap.Sqrt ();
            UIMap.AssertPrinter ("         689.40   √X");
            UIMap.AssertNumeric (" 26.26         ");
            // Not in the manual, but useful to check the stack
            UIMap.PrintStack ();
            UIMap.AssertPrinter ("                PRST",
                                 "",
                                 "           3.00   T ",
                                 "           1.00   Z ",
                                 "         314.32   Y ",
                                 "          26.26   X ",
                                 "");
        }
    }
}
