using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p45 ()
        {
            // Error Display
            UIMap.Four ();
            UIMap.CHS ();
            UIMap.AssertNumeric ("-4.            ");
            UIMap.Sqrt ();
            UIMap.AssertText (" Error         ");
            UIMap.AssertPrinter ("          -4.00   √X",
                                 "               ERROR");
            UIMap.CLx ();
            UIMap.AssertNumeric ("-4.00          ");
        }
    }
}
