using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p81 ()
        {
            // Using Pi
            UIMap.Three ();
            UIMap.Pi ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 9.42          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 9.42          ");
            UIMap.AssertPrinter ("           3.00   Pi",
                                 "                  × ",
                                 "           9.42  ***");

            UIMap.One ();
            UIMap.Two ();
            UIMap.EEX ();
            UIMap.Three ();
            UIMap.AssertNumeric (" 12.         03");
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 6000.00       ");
            UIMap.Pi ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 1909.86       ");
            UIMap.Six ();
            UIMap.Zero ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 31.83         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 31.83         ");
            UIMap.AssertPrinter ("         12.+03 ENT↑",
                                 "           2.00   ÷ ",
                                 "                  Pi",
                                 "                  ÷ ",
                                 "          60.00   ÷ ",
                                 "          31.83  ***");
        }
    }
}
