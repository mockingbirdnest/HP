using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void TrigonometricsLargeAngles ()
        {
            UIMap.RAD ();
            UIMap.EEX ();
            UIMap.One ();
            UIMap.Zero ();
            UIMap.SIN ();
            UIMap.AssertNumeric ("-0.49          ");
            UIMap.DSP ();
            UIMap.Nine ();
            UIMap.SCI ();
            UIMap.AssertNumeric ("-4.880805565-01");
            UIMap.EEX ();
            UIMap.Two ();
            UIMap.Zero ();
            UIMap.COS ();
            UIMap.AssertNumeric ("-2.877745262-01");
            UIMap.EEX ();
            UIMap.Four ();
            UIMap.Zero ();
            UIMap.TAN ();
            UIMap.AssertNumeric ("-5.020086915-02");
            UIMap.EEX ();
            UIMap.Eight ();
            UIMap.Zero ();
            UIMap.ENTER ();
            UIMap.CHS ();
            UIMap.SIN ();
            UIMap.AssertNumeric ("-9.543913368-01");
        }
    }
}
