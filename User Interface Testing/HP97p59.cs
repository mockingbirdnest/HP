using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p59 ()
        {
            // Recovering from Mistakes
            UIMap.One ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 12.           ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 12.00         ");
            UIMap.Three ();
            UIMap.Period ();
            UIMap.One ();
            UIMap.Five ();
            UIMap.Seven ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 3.80          ");
            UIMap.LASTx ();
            UIMap.AssertNumeric (" 3.16          ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 12.00         ");
            UIMap.Two ();
            UIMap.Period ();
            UIMap.One ();
            UIMap.Five ();
            UIMap.Seven ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 5.56          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 5.56          ");
            UIMap.AssertPrinter ("          12.00 ENT↑",
                                 "          3.157   ÷ ",
                                 "                LSTX",
                                 "                  × ", 
                                 "          2.157   ÷ ",
                                 "           5.56  ***");
        }
    }
}
