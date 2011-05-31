using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p101p102 ()
        {
            // Mean

            UIMap.CLREG ();
            UIMap.PExchangeS ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Six ();
            UIMap.ENTER ();
            UIMap.SendKeys ("22");
            UIMap.CHS ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 1.00          ");
            UIMap.OneOne ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Seven ();
            UIMap.CHS ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 2.00          ");
            UIMap.One ();
            UIMap.Four ();
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Five ();
            UIMap.CHS ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.SendKeys ("12");
            UIMap.ENTER ();
            UIMap.Nine ();
            UIMap.CHS ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 4.00          ");
            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.SendKeys ("24");
            UIMap.CHS ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 5.00          ");
            UIMap.Two ();
            UIMap.CHS ();
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.Nine ();
            UIMap.CHS ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 6.00          ");
            UIMap.Nine ();
            UIMap.CHS ();
            UIMap.ENTER ();
            UIMap.SendKeys ("35");
            UIMap.CHS ();
            UIMap.SigmaPlus ();
            UIMap.AssertNumeric (" 7.00          ");
            UIMap.AssertPrinter ("                CLRG",
                                 "                 P⇄S",
                                 "           6.00 ENT↑",
                                 "         -22.00   Σ+",
                                 "          11.00 ENT↑",
                                 "         -17.00   Σ+",
                                 "          14.00 ENT↑",
                                 "         -15.00   Σ+",
                                 "          12.00 ENT↑",
                                 "          -9.00   Σ+",
                                 "           5.00 ENT↑",
                                 "         -24.00   Σ+",
                                 "          -2.00 ENT↑",
                                 "         -29.00   Σ+",
                                 "          -9.00 ENT↑",
                                 "         -35.00   Σ+");

            UIMap.XAverage ();
            UIMap.AssertNumeric ("-21.57         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric ("-21.57         ");
            UIMap.XExchangeY ();
            UIMap.AssertNumeric (" 5.29          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 5.29          ");
            UIMap.AssertPrinter ("                 x̅ ",
                                 "         -21.57  ***",
                                 "                 X⇄Y",
                                 "           5.29  ***");
        }
    }
}
