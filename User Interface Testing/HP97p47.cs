using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p47 ()
        {
            // The Stack

            // Initial Display
            UIMap.PrintStack ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.AssertPrinter ("                PRST",
                                 "",
                                 "           0.00   T ",
                                 "           0.00   Z ",
                                 "           0.00   Y ",
                                 "           0.00   X ",
                                 "");
        }
    }
}
