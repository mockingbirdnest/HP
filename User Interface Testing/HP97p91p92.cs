using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p91p92 ()
        {
            // Polar/Rectangular Coordinate Conversions
            UIMap.RAD ();
            UIMap.Three ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.Four ();
            UIMap.AssertNumeric (" 4.            ");
            UIMap.ToPolar ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 0.64          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.64          ");
            UIMap.AssertPrinter ("                 RAD",
                                 "           3.00 ENT↑",
                                 "           4.00   →P",
                                 "           5.00  ***",
                                 "                 X⇄Y",
                                 "           0.64  ***");

            UIMap.GRD ();
            UIMap.AssertNumeric (" 0.64          ");
            UIMap.One ();
            UIMap.Two ();
            UIMap.Zero ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 120.00        ");
            UIMap.Eight ();
            UIMap.AssertNumeric (" 8.            ");
            UIMap.ToRectangular ();
            UIMap.AssertNumeric ("-2.47          ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 7.61          ");
            UIMap.AssertPrinter ("                GRAD",
                                 "         120.00 ENT↑",
                                 "           8.00   →R",
                                 "                 X⇄Y");

            UIMap.DEG ();
            UIMap.AssertNumeric (" 7.61          ");
            UIMap.Three ();
            UIMap.Six ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.CHS ();
            UIMap.AssertNumeric ("-36.5          ");
            UIMap.ENTER ();
            UIMap.AssertNumeric ("-36.50         ");
            UIMap.Seven ();
            UIMap.Seven ();
            UIMap.Period ();
            UIMap.Eight ();
            UIMap.AssertNumeric (" 77.8          ");
            UIMap.ToRectangular ();
            UIMap.AssertNumeric (" 62.54         ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric ("-46.28         ");
            UIMap.AssertPrinter ("                 DEG",
                                 "         -36.50 ENT↑",
                                 "          77.80   →R",
                                 "                 X⇄Y");
        }
    }
}
