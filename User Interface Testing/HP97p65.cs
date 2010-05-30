using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p65 ()
        {
            // The I Register
            UIMap.Three ();
            UIMap.Period ();
            UIMap.Seven ();
            UIMap.Eight ();
            UIMap.Five ();
            UIMap.STO ();
            UIMap.I ();
            UIMap.AssertNumeric (" 3.79          ");
            UIMap.Two ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 7.57          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 7.57          ");
            UIMap.One ();
            UIMap.Four ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.I ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 54.50         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 54.50         ");
            UIMap.Five ();
            UIMap.Five ();
            UIMap.I ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 208.18        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 208.18        ");
            UIMap.AssertPrinter ("          3.785 STOI",
                                 "           2.00   × ",
                                 "           7.57  ***",
                                 "          14.40 RCLI",
                                 "                  × ",
                                 "          54.50  ***",
                                 "          55.00 RCLI",
                                 "                  × ",
                                 "         208.18  ***");
        }
    }
}
