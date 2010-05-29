using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p60p61 ()
        {
            // Constant Arithmetic
            UIMap.ManTraceNorm1Left ();
            UIMap.One ();
            UIMap.Period ();
            UIMap.One ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 1.15          ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 1.15          ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 1.15          ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 1.15          ");
            UIMap.One ();
            UIMap.Zero ();
            UIMap.Zero ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 1000.         ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 1150.00       ");
            UIMap.AssertPrinter ("           1.15 ENT↑",
                                 "                ENT↑",
                                 "                ENT↑",
                                 "        1000.00   × ",
                                 "        1150.00  ***");

            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 1322.50       ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 1520.88       ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 1749.01       ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 2011.36       ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 2313.06       ");
            UIMap.AssertPrinter ("                  × ",
                                 "        1322.50  ***",
                                 "                  × ",
                                 "        1520.88  ***",
                                 "                  × ",
                                 "        1749.01  ***",
                                 "                  × ",
                                 "        2011.36  ***",
                                 "                  × ",
                                 "        2313.06  ***");
        }
    }
}
