using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p42p43 ()
        {
            // Automatic Display Switching
            UIMap.CLx ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Period ();
            UIMap.Zero ();
            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 0.05          ");
            UIMap.Three ();
            UIMap.YToTheXth ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1.250000000-04");
            UIMap.AssertPrinter ("                 CLX",
                                 "            .05 ENT↑",
                                 "           3.00   Yˣ",
                                 " 1.250000000-04  ***");

            UIMap.One ();
            UIMap.Five ();
            UIMap.Eight ();
            UIMap.Two ();
            UIMap.ZeroZeroZero ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 1582000.00    ");
            UIMap.One ();
            UIMap.Eight ();
            UIMap.Four ();
            UIMap.Two ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 2914044000.   ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 2914044000.   ");
            UIMap.AssertPrinter ("     1582000.00 ENT↑",
                                 "        1842.00   × ",
                                 "    2914044000.  ***");

            UIMap.One ();
            UIMap.Zero ();
            UIMap.Multiplication ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 2.914044000 10");
            UIMap.AssertPrinter ("          10.00   × ",
                                 " 2.914044000+10  ***");
        }
    }
}
