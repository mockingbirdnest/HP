using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p83p85 ()
        {
            // Trigonometric Functions

            // Degrees/Radians Conversions
            UIMap.Four ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 45.           ");
            UIMap.DegreesToRadians ();
            UIMap.AssertNumeric (" 0.79          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.79          ");
            UIMap.AssertPrinter ("          45.00  D→R",
                                 "           0.79  ***");

            UIMap.Four ();
            UIMap.AssertNumeric (" 4.            ");
            UIMap.RadiansToDegrees();
            UIMap.AssertNumeric (" 229.18        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 229.18        ");
            UIMap.AssertPrinter ("           4.00  R→D",
                                 "         229.18  ***");

            // Trigonometric Modes

            // Functions
            UIMap.Three ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 35.           ");
            UIMap.COS ();
            UIMap.AssertNumeric (" 0.82          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.82          ");
            UIMap.AssertPrinter ("          35.00  COS",
                                 "           0.82  ***");

            UIMap.RAD ();
            UIMap.AssertNumeric (" 0.82          ");
            UIMap.Period ();
            UIMap.Nine ();
            UIMap.Six ();
            UIMap.Four ();
            UIMap.AssertNumeric (" .964          ");
            UIMap.ArcSIN ();
            UIMap.AssertNumeric (" 1.30          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1.30          ");
            UIMap.AssertPrinter ("                 RAD",
                                 "           .964 SIN¹",
                                 "           1.30  ***");

            UIMap.GRD ();
            UIMap.AssertNumeric (" 1.30          ");
            UIMap.SendKeys ("43.66");
            UIMap.AssertNumeric (" 43.66         ");
            UIMap.TAN ();
            UIMap.AssertNumeric (" 0.82          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.82          ");
            UIMap.AssertPrinter ("                GRAD",
                                 "          43.66  TAN",
                                 "           0.82  ***");
        }
    }
}
