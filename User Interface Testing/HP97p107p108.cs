using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p107p108 ()
        {
            // Vector Arithmetic.

            UIMap.CLREG ();
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Four ();
            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 45.00         ");
            UIMap.SendKeys ("150");
            UIMap.AssertNumeric (" 150.          ");
            UIMap.ToRectangular ();
            UIMap.AssertNumeric (" 106.07        ");
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 1.00          ");
            UIMap.Two ();
            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 25.00         ");
            UIMap.Four ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 40.           ");
            UIMap.ToRectangular ();
            UIMap.SigmaMinus ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.AssertPrinter ("                CLRG",
                                 "                 P⇄S",
                                 "          45.00 ENT↑",
                                 "         150.00   →R",
                                 "                  Σ+",
                                 "          25.00 ENT↑",
                                 "          40.00   →R",
                                 "                  Σ-");

            UIMap.RCLSigma ();
            UIMap.AssertNumeric (" 69.81         ");
            UIMap.ToPolar ();
            UIMap.AssertNumeric (" 113.24        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 113.24        ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 51.94         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 51.94         ");
            UIMap.AssertPrinter ("                RCLΣ",
                                 "                  →P",
                                 "         113.24  ***",
                                 "                 X⇄Y",
                                 "          51.94  ***");
        }
    }
}
