using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p29p33 ()
        {
            // Chain Calculations
            UIMap.ManTraceNorm1Left ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 12.           ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 12.00         ");
            UIMap.Three ();
            UIMap.AssertNumeric (" 3.            ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 15.00         ");
            UIMap.AssertPrinter ("          12.00 ENT↑",
                                 "           3.00   + ",
                                 "          15.00  ***");

            UIMap.Seven ();
            UIMap.AssertNumeric (" 7.            ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 105.00        ");
            UIMap.AssertPrinter ("           7.00   × ",
                                 "         105.00  ***");

            UIMap.ManTraceNorm1Right ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 12.           ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 12.00         ");
            UIMap.Three ();
            UIMap.AssertNumeric (" 3.            ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 15.00         ");
            UIMap.Seven ();
            UIMap.AssertNumeric (" 7.            ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 105.00        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 105.00        ");
            UIMap.AssertPrinter ("          12.00 ENT↑",
                                 "           3.00   + ",
                                 "           7.00   × ",
                                 "         105.00  ***");

            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.Addition ();
            UIMap.One ();
            UIMap.Zero ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 0.50          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.50          ");
            UIMap.AssertPrinter ("           2.00 ENT↑",
                                 "           3.00   + ",
                                 "          10.00   ÷ ",
                                 "           0.50  ***");

            UIMap.One ();
            UIMap.Six ();
            UIMap.ENTER ();
            UIMap.Four ();
            UIMap.Subtraction ();
            UIMap.Three ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 36.00         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 36.00         ");
            UIMap.AssertPrinter ("          16.00 ENT↑",
                                 "           4.00   - ",
                                 "           3.00   × ",
                                 "          36.00  ***");

            UIMap.One ();
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.Seven ();
            UIMap.Addition ();
            UIMap.Three ();
            UIMap.Addition ();
            UIMap.Two ();
            UIMap.Subtraction ();
            UIMap.Four ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 5.50          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 5.50          ");
            UIMap.AssertPrinter ("          14.00 ENT↑",
                                 "           7.00   + ",
                                 "           3.00   + ",
                                 "           2.00   - ",
                                 "           4.00   ÷ ",
                                 "           5.50  ***");

            UIMap.Two ();
            UIMap.AssertNumeric (" 2.            ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 2.00          ");
            UIMap.Three ();
            UIMap.AssertNumeric (" 3.            ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.AssertPrinter ("           2.00 ENT↑",
                                 "           3.00   + ");

            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.Five ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 9.00          ");
            UIMap.AssertPrinter ("           4.00 ENT↑",
                                 "           5.00   + ");

            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 45.00         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 45.00         ");
            UIMap.AssertPrinter ("                  × ",
                                 "          45.00  ***");

            UIMap.Nine ();
            UIMap.ENTER ();
            UIMap.Eight ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 17.00         ");
            UIMap.Seven ();
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 9.00          ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 153.00        ");
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.Five ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 20.00         ");
            UIMap.Division ();
            UIMap.AssertNumeric (" 7.65          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 7.65          ");
            UIMap.AssertPrinter ("           9.00 ENT↑",
                                 "           8.00   + ",
                                 "           7.00 ENT↑",
                                 "           2.00   + ",
                                 "                  × ",
                                 "           4.00 ENT↑",
                                 "           5.00   × ",
                                 "                  ÷ ",
                                 "           7.65  ***");

            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.Multiplication ();
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.Five ();
            UIMap.Multiplication ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 26.00         ");

            UIMap.One ();
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.Addition ();
            UIMap.One ();
            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.Subtraction ();
            UIMap.Multiplication ();
            UIMap.Nine ();
            UIMap.ENTER ();
            UIMap.Seven ();
            UIMap.Subtraction ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 78.00         ");

            UIMap.One ();
            UIMap.Six ();
            UIMap.Period ();
            UIMap.Three ();
            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.Five ();
            UIMap.Multiplication ();
            UIMap.Sqrt ();
            UIMap.Period ();
            UIMap.Zero ();
            UIMap.Five ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 181.00        ");

            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Seven ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.Subtraction ();
            UIMap.Multiplication ();
            UIMap.One ();
            UIMap.Zero ();
            UIMap.ENTER ();
            UIMap.Five ();
            UIMap.Subtraction ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 4.00          ");

            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.Addition ();
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.Five ();
            UIMap.Addition ();
            UIMap.Multiplication ();
            UIMap.Sqrt ();
            UIMap.Six ();
            UIMap.ENTER ();
            UIMap.Seven ();
            UIMap.Addition ();
            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.Nine ();
            UIMap.Addition ();
            UIMap.Multiplication ();
            UIMap.Sqrt ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 21.57         ");
        }
    }
}
