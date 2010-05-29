using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p55p57 ()
        {
            // Chain Arithmetic
            UIMap.One ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 16.           ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 16.00         ");
            UIMap.Three ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 30.           ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 46.00         ");
            UIMap.OneOne ();
            UIMap.AssertNumeric (" 11.           ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 57.00         ");
            UIMap.One ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 17.           ");
            UIMap.Addition ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 74.00         ");
            UIMap.AssertPrinter ("          16.00 ENT↑",
                                 "          30.00   + ",
                                 "          11.00   + ",
                                 "          17.00   + ",
                                 "          74.00  ***");

            UIMap.CLx ();
            UIMap.AssertPrinter ("                 CLX");  // Not in the manual.

            UIMap.One ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 16.           ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 16.00         ");
            UIMap.Three ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 30.           ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 30.00         ");
            UIMap.One ();
            UIMap.One ();
            UIMap.AssertNumeric (" 11.           ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 11.00         ");
            UIMap.One ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 17.           ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 28.00         ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 58.00         ");
            UIMap.Addition ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 74.00         ");
            UIMap.AssertPrinter ("          16.00 ENT↑",
                                 "          30.00 ENT↑",
                                 "          11.00 ENT↑",
                                 "          17.00   + ",
                                 "                  + ",
                                 "                  + ",
                                 "          74.00  ***");
        }
    }
}
