using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p106 ()
        {
            // Deleting and Correcting Data.

            // Setup as in p104p105.
            UIMap.ManTraceNorm2Left ();
            UIMap.CLREG ();
            UIMap.PExchangeS ();
            UIMap.Six ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.SendKeys ("1200");
            UIMap.SigmaPlus ();
            UIMap.Five ();
            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Five ();
            UIMap.ZeroZero ();
            UIMap.SigmaPlus ();
            UIMap.Six ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Four ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.SigmaPlus ();
            UIMap.SendKeys ("73");
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Nine ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.SigmaPlus ();
            UIMap.Eight ();
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.SendKeys ("1000");
            UIMap.SigmaPlus ();
            UIMap.Six ();
            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Seven ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.SigmaPlus ();
            UIMap.ManTraceNorm2Right ();

            UIMap.Six ();
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.Zero ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 1200.         ");
            UIMap.SigmaMinus ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.Two ();
            UIMap.One ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Three ();
            UIMap.ZeroZero ();
            UIMap.AssertNumeric (" 1300.         ");
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 6.00          "); 
            UIMap.AssertPrinter ("          62.00 ENT↑",
                                 "        1200.00   Σ-",
                                 "          21.00 ENT↑",
                                 "        1300.00   Σ+");

            UIMap.XAverage ();
            UIMap.AssertNumeric (" 1491.67       ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 61.00         ");
            UIMap.s ();
            UIMap.AssertNumeric (" 333.79        ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 21.60         ");
            UIMap.AssertPrinter ("                 x̅ ",
                                 "                 X⇄Y",
                                 "                  S ",
                                 "                 X⇄Y");
        }
    }
}
