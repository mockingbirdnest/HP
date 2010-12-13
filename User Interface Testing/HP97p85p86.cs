using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p85p86 ()
        {
            // Hours, Minutes, Seconds/Decimal Hours Conversions
            UIMap.Two ();
            UIMap.One ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 21.57         ");
            UIMap.DSP ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 21.5700       ");
            UIMap.ToHMS ();
            UIMap.AssertNumeric (" 21.3412       ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 21.3412       ");
            UIMap.AssertPrinter ("          21.57 DSP4",
                                 "                →HMS",
                                 "        21.3412  ***");

            UIMap.SendKeys ("132{DECIMAL}432933");
            UIMap.AssertNumeric (" 132.432933    ");
            UIMap.FromHMS ();
            UIMap.AssertNumeric (" 132.7248      ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 132.7248      ");
            UIMap.AssertPrinter ("     132.432933 HMS→",
                                 "       132.7248  ***");

            UIMap.Four ();
            UIMap.Two ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 42.57         ");
            UIMap.ToHMS ();
            UIMap.AssertNumeric (" 42.3412       ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 42.3412       ");
            UIMap.AssertPrinter ("        42.5700 →HMS",
                                 "        42.3412  ***");

            UIMap.SendKeys ("38.08");
            UIMap.Five ();
            UIMap.Six ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 38.08567      ");
            UIMap.FromHMS ();
            UIMap.AssertNumeric (" 38.1491       ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 38.1491       ");
            UIMap.AssertPrinter ("       38.08567 HMS→",
                                 "        38.1491  ***");
        }
    }
}
