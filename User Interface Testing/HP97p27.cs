using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p27 ()
        {
            // One-Number Functions
            UIMap.ManTraceNorm1Left ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 4.            ");

            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 0.25          ");
            UIMap.AssertPrinter ("           4.00  1/X",
                                 "           0.25  ***");

            UIMap.Two ();
            UIMap.Five ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 0.04          ");

            UIMap.Two ();
            UIMap.Five ();
            UIMap.ZeroZero ();
            UIMap.Sqrt ();
            UIMap.AssertNumeric (" 50.00         ");

            UIMap.Five ();
            UIMap.TenToTheXth ();
            UIMap.AssertNumeric (" 100000.00     ");

            UIMap.Three ();
            UIMap.Two ();
            UIMap.Zero ();
            UIMap.Four ();
            UIMap.One ();
            UIMap.ZeroZero ();
            UIMap.Sqrt ();
            UIMap.AssertNumeric (" 1790.00       ");

            UIMap.One ();
            UIMap.Two ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.Eight ();
            UIMap.Nine ();
            UIMap.Two ();
            UIMap.Five ();
            UIMap.Four ();
            UIMap.OneOne ();
            UIMap.LOG ();
            UIMap.AssertNumeric (" 1.10          ");

            UIMap.Seven ();
            UIMap.One ();
            UIMap.Square ();
            UIMap.AssertNumeric (" 5041.00       ");
        }
    }
}
