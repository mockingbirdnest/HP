using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void PrintXStartup ()
        {
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.AssertPrinter ("           0.00  ***");
        }
    }
}
