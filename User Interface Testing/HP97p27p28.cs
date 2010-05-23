using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p27p28 ()
        {
            // Two-Number Functions
            UIMap.ManTraceNorm1Left ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 15.00         ");
            UIMap.AssertPrinter ("          12.00 ENT↑",
                                 "           3.00   + ",
                                 "          15.00  ***");
            UIMap.PRINTx ();
            UIMap.AssertPrinter ("          15.00  ***");
            UIMap.One ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 9.00          ");
            UIMap.AssertPrinter ("          12.00 ENT↑",
                                 "           3.00   - ",
                                 "           9.00  ***");
            UIMap.One ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 36.00         ");
            UIMap.AssertPrinter ("          12.00 ENT↑",
                                 "           3.00   × ",
                                 "          36.00  ***");
            UIMap.One ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 4.00          ");
            UIMap.AssertPrinter ("          12.00 ENT↑",
                                 "           3.00   ÷ ",
                                 "           4.00  ***");

            UIMap.Three ();
            UIMap.AssertNumeric (" 3.            ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.Six ();
            UIMap.AssertNumeric (" 6.            ");
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 729.00        ");
            UIMap.AssertPrinter ("           3.00 ENT↑",
                                 "           6.00   Yˣ",
                                 "         729.00  ***");
            UIMap.One ();
            UIMap.Six ();
            UIMap.ENTER ();
            UIMap.Four ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 65536.00      ");
            UIMap.Eight ();
            UIMap.One ();
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 6561.00       ");
            UIMap.SendKeys ("22");
            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 15.00         ");
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Six ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 65536.00      ");
            UIMap.One ();
            UIMap.Six ();
            UIMap.ENTER ();
            UIMap.Period ();
            UIMap.Two ();
            UIMap.Five ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 2.00          ");
        }
    }
}
