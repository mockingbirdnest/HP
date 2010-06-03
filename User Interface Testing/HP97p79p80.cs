using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p79p80 ()
        {
            // Reciprocals
            UIMap.Two ();
            UIMap.Five ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 0.04          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.04          ");
            UIMap.AssertPrinter ("          25.00  1/X",
                                 "           0.04  ***");

            UIMap.Two ();
            UIMap.Two ();
            UIMap.Zero ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 4.545454545-03");
            UIMap.Five ();
            UIMap.Six ();
            UIMap.Zero ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 1.785714286-03");
            UIMap.Addition ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.ZeroZero ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 8.333333333-04");
            UIMap.Addition ();
            UIMap.Five ();
            UIMap.ZeroZeroZero ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 2.000000000-04");
            UIMap.Addition ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 135.79        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 135.79        ");
            UIMap.AssertPrinter ("         220.00  1/X",
                                 "         560.00  1/X",
                                 "                  + ",
                                 "        1200.00  1/X",
                                 "                  + ",
                                 "        5000.00  1/X",
                                 "                  + ",
                                 "                 1/X",
                                 "         135.79  ***");

            // Factorials
            UIMap.Six ();
            UIMap.AssertNumeric (" 6.            ");
            UIMap.Factorial ();
            UIMap.AssertNumeric (" 720.00        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 720.00        ");
            UIMap.AssertPrinter ("           6.00   N!",
                                 "         720.00  ***");

            // Square Roots
            UIMap.One ();
            UIMap.Six ();
            UIMap.Sqrt ();
            UIMap.AssertNumeric (" 4.00          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 4.00          ");
            UIMap.AssertPrinter ("          16.00   √X",
                                 "           4.00  ***");

            // Squaring
            UIMap.Four ();
            UIMap.Five ();
            UIMap.Square ();
            UIMap.AssertNumeric (" 2025.00       ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 2025.00       ");
            UIMap.AssertPrinter ("          45.00   X²",
                                 "        2025.00  ***");

            UIMap.Square ();
            UIMap.AssertNumeric (" 4100625.00    ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 4100625.00    ");
            UIMap.AssertPrinter ("                  X²",
                                 "     4100625.00  ***");
        }
    }
}
