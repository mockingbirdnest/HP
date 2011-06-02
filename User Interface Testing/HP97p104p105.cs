using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p104p105 ()
        {
            // Standard Deviation.

            UIMap.CLREG ();
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Six ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.SendKeys ("1200");
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 1.00          ");
            UIMap.Five ();
            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Five ();
            UIMap.ZeroZero ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 2.00          ");
            UIMap.Six ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Four ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.SendKeys ("73");
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Nine ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 4.00          ");
            UIMap.Eight ();
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.SendKeys ("1000");
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.Six ();
            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Seven ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 6.00          ");
            UIMap.XAverage ();
            UIMap.AssertNumeric (" 1475.00       ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 67.83         ");
            UIMap.s ();
            UIMap.AssertNumeric (" 347.49        ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 9.52          ");
            UIMap.AssertPrinter ("                CLRG",
                                 "                 P⇄S",
                                 "          62.00 ENT↑",
                                 "        1200.00   Σ+",
                                 "          58.00 ENT↑",
                                 "        1500.00   Σ+",
                                 "          62.00 ENT↑",
                                 "        1450.00   Σ+",
                                 "          73.00 ENT↑",
                                 "        1950.00   Σ+",
                                 "          84.00 ENT↑",
                                 "        1000.00   Σ+",
                                 "          68.00 ENT↑",
                                 "        1750.00   Σ+",
                                 "                 x̅ ",
                                 "                 X⇄Y",
                                 "                  S ",
                                 "                 X⇄Y");

            UIMap.s ();
            UIMap.AssertNumeric (" 347.49        ");
            UIMap.PExchangeS ();
            UIMap.RCL ();
            UIMap.Nine ();
            UIMap.AssertNumeric (" 6.00          ");
            UIMap.One ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.RCL ();
            UIMap.Nine ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 0.83          ");
            UIMap.Sqrt ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 317.21        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 317.21        ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 9.52          ");
            UIMap.LASTx ();
            UIMap.AssertNumeric (" 0.91          ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 8.69          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 8.69          ");
            UIMap.AssertPrinter ("                  S ",
                                 "                 P⇄S",
                                 "                RCL9",
                                 "           1.00   - ",
                                 "                RCL9",
                                 "                  ÷ ",
                                 "                  √X",
                                 "                  × ",
                                 "         317.21  ***",
                                 "                 X⇄Y",
                                 "                LSTX",
                                 "                  × ",
                                 "           8.69  ***");
        }
    }
}
