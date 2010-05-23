using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p24 ()
        {
            // Keying In Numbers
            UIMap.ManTraceNorm2Left ();
            UIMap.One ();
            UIMap.Four ();
            UIMap.Eight ();
            UIMap.Period ();
            UIMap.Eight ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 148.84        ");

            // Negative Numbers
            UIMap.CHS ();
            UIMap.AssertNumeric ("-148.84        ");
            UIMap.CHS ();
            UIMap.AssertNumeric (" 148.84        ");

            // Clearing
            UIMap.CLx ();
            UIMap.AssertNumeric (" 0.00          ");
        }
    }
}
