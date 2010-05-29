using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p53p54 ()
        {
            // Two-Number Functions and the Stack
            UIMap.CLx ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Three ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 34.           ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 34.00         ");
            UIMap.AssertPrinter ("                 CLX",
                                 "                ENT↑",
                                 "                ENT↑",
                                 "                ENT↑",
                                 "          34.00 ENT↑");

            UIMap.Two ();
            UIMap.One ();
            UIMap.AssertNumeric (" 21.           ");
            UIMap.PrintStack ();
            UIMap.AssertNumeric (" 21.00         ");
            UIMap.AssertPrinter ("          21.00 PRST",
                                 "",
                                 "           0.00   T ",
                                 "           0.00   Z ",
                                 "          34.00   Y ",
                                 "          21.00   X ",
                                 "");

            UIMap.Addition ();
            UIMap.AssertNumeric (" 55.00         ");
            UIMap.PrintStack ();
            UIMap.AssertNumeric (" 55.00         ");
            UIMap.AssertPrinter ("                  + ",
                                 "                PRST",
                                 "",
                                 "           0.00   T ",
                                 "           0.00   Z ",
                                 "           0.00   Y ",
                                 "          55.00   X ",
                                 "");
        }
    }
}
