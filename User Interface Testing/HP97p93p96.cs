using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p93p96 ()
        {
            // Logarithmic and Exponential Functions

            // Logarithms

            UIMap.Eight ();
            UIMap.Period ();
            UIMap.Two ();
            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 8.25          ");
            UIMap.SendKeys ("105");
            UIMap.LOG ();
            UIMap.AssertNumeric (" 2.02          ");
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 6.23          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 6.23          ");
            UIMap.AssertPrinter ("           8.25 ENT↑",
                                 "         105.00  LOG",
                                 "                  - ",
                                 "           6.23  ***");

            UIMap.Three ();
            UIMap.Zero ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 30.00         ");
            UIMap.Nine ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 3.19          ");
            UIMap.LN ();
            UIMap.AssertNumeric (" 1.16          ");
            UIMap.Two ();
            UIMap.Five ();
            UIMap.ZeroZeroZero ();
            UIMap.AssertNumeric (" 25000.        ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 29012.19      ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 29012.19      ");
            UIMap.AssertPrinter ("          30.00 ENT↑",
                                 "           9.40   ÷ ",
                                 "                  LN",
                                 "       25000.00   × ",
                                 "       29012.19  ***");

            // Raising Numbers to Powers

            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Nine ();
            UIMap.AssertNumeric (" 9.            ");
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 512.00        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 512.00        ");
            UIMap.AssertPrinter ("           2.00 ENT↑",
                                 "           9.00   Yˣ",
                                 "         512.00  ***");

            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 8.00          ");
            UIMap.SendKeys ("1.256");
            UIMap.Seven ();
            UIMap.CHS ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 0.07          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.07          ");
            UIMap.AssertPrinter ("           8.00 ENT↑",
                                 "        -1.2567   Yˣ",
                                 "           0.07  ***");

            UIMap.Two ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.CHS ();
            UIMap.ENTER ();
            UIMap.AssertNumeric ("-2.50          ");
            UIMap.Five ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric ("-97.66         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric ("-97.66         ");
            UIMap.AssertPrinter ("          -2.50 ENT↑",
                                 "           5.00   Yˣ",
                                 "         -97.66  ***");

            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.Three ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 0.33          ");
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 1.71          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1.71          ");
            UIMap.AssertPrinter ("           5.00 ENT↑",
                                "           3.00  1/X",
                                "                  Yˣ",
                                "           1.71  ***");

            UIMap.SendKeys ("350");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 350.00        ");
            UIMap.Six ();
            UIMap.SendKeys ("61.");
            UIMap.Five ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 0.53          ");
            UIMap.Square ();
            UIMap.AssertNumeric (" 0.28          ");
            UIMap.SendKeys (".2");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.06          ");
            UIMap.One ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 1.06          ");
            UIMap.Three ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 1.21          ");
            UIMap.One ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 0.21          ");
            UIMap.One ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 1.00          ");
            UIMap.Six ();
            UIMap.Period ();
            UIMap.Eight ();
            UIMap.Seven ();
            UIMap.Five ();
            UIMap.EEX ();
            UIMap.AssertNumeric (" 6.875       00");
            UIMap.CHS ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 6.875      -06");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 6.875000000-06");
            UIMap.SendKeys ("25500");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.18          ");
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 0.82          ");
            UIMap.SendKeys ("5.2656");
            UIMap.CHS ();
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 2.76          ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.58          ");
            UIMap.One ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 1.58          ");
            UIMap.Period ();
            UIMap.SendKeys ("286");
            UIMap.YToTheXth ();
            UIMap.AssertNumeric (" 1.14          ");
            UIMap.One ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 0.14          ");
            UIMap.Five ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.70          ");
            UIMap.Sqrt ();
            UIMap.AssertNumeric (" 0.84          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.84          ");
            UIMap.AssertPrinter ("         350.00 ENT↑",
                                 "         661.50   ÷ ",
                                 "                  X²",
                                 "            .20   × ",
                                 "           1.00   + ",
                                 "           3.50   Yˣ",
                                 "           1.00   - ",
                                 "           1.00 ENT↑",
                                 "       6.875-06 ENT↑",
                                 "       25500.00   × ",
                                 "                  - ",
                                 "        -5.2656   Yˣ",
                                 "                  × ",
                                 "           1.00   + ",
                                 "           .286   Yˣ",
                                 "           1.00   - ",
                                 "           5.00   × ",
                                 "                  √X",
                                 "           0.84  ***");
        }
    }
}
