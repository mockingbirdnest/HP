using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p44 ()
        {
            // Calculator Overflow
            UIMap.CLx ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.EEX ();
            UIMap.Four ();
            UIMap.Nine ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 1.000000000 49");
            UIMap.EEX ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 1.000000000 99");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1.000000000 99");
            UIMap.AssertPrinter ("                 CLX",
                                 "          1.+49 ENT↑",
                                 "          1.+50   × ",
                                 " 1.000000000+99  ***");

            UIMap.One ();
            UIMap.Zero ();
            UIMap.Zero ();
            UIMap.Multiplication ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 9.999999999 99");
            UIMap.AssertPrinter (" 9.999999999+99  ***");
        }
    }
}
