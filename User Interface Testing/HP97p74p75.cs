using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p74p75 ()
        {
            // Storage Register Overflow
            UIMap.Seven ();
            UIMap.Period ();
            UIMap.Three ();
            UIMap.Three ();
            UIMap.AssertNumeric (" 7.33          ");
            UIMap.EEX ();
            UIMap.Five ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 7.33        52");
            UIMap.STO ();
            UIMap.One ();
            UIMap.AssertNumeric (" 7.330000000 52");
            UIMap.EEX ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 1.          50");
            UIMap.STO ();
            UIMap.Multiplication ();
            UIMap.One ();
            UIMap.AssertText (" Error         ");
            UIMap.AssertPrinter ("        7.33+52 STO1",
                                 "          1.+50 ST×1",
                                 "               ERROR");

            UIMap.CLx ();
            UIMap.AssertNumeric (" 1.000000000 50");
            UIMap.RCL ();
            UIMap.One ();
            UIMap.AssertNumeric (" 7.330000000 52");
            UIMap.AssertPrinter ("                RCL1");
        }
    }
}
