using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void PrintXOfUnformattedNumber ()
        {
            UIMap.One ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.PRINTx ();
            UIMap.AssertPrinter ("           123.  ***");
        }
    }
}
