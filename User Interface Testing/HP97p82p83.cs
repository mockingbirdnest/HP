using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p82p83 ()
        {
            // Percentages
            UIMap.SendKeys ("1500{ENTER}");
            UIMap.AssertNumeric (" 1500.00       ");
            UIMap.Six ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 6.5           ");
            UIMap.Percent ();
            UIMap.AssertNumeric (" 97.50         ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 97.50         ");
            UIMap.AssertPrinter ("        1500.00 ENT↑",
                                 "           6.50   % ",
                                 "          97.50  ***");

            UIMap.Addition ();
            UIMap.AssertNumeric (" 1597.50       ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1597.50       ");
            UIMap.AssertPrinter ("                  + ",
                                 "        1597.50  ***");

            // Percent of Change
            UIMap.Seven ();
            UIMap.Zero ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 70.00         ");
            UIMap.Two ();
            UIMap.Four ();
            UIMap.Zero ();
            UIMap.PercentChange ();
            UIMap.AssertNumeric (" 242.86        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 242.86        ");
            UIMap.AssertPrinter ("          70.00 ENT↑",
                                 "         240.00  %CH",
                                 "         242.86  ***");
        }
    }
}
