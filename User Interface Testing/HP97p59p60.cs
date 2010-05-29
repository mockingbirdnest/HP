using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p59p60 ()
        {
            // Recovering a Number for Calculation
            UIMap.Seven ();
            UIMap.Period ();
            UIMap.Three ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 7.32          ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 7.32          ");
            UIMap.Three ();
            UIMap.Period ();
            UIMap.Six ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.One ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Three ();
            UIMap.One ();
            UIMap.AssertNumeric (" 3.650112331   ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 10.97         ");
            UIMap.LASTx ();
            UIMap.AssertNumeric (" 3.65          ");
            UIMap.Division ();
            UIMap.AssertNumeric (" 3.01          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 3.01          ");
            UIMap.AssertPrinter ("           7.32 ENT↑",
                                 "    3.650112331   + ",
                                 "                LSTX",
                                 "                  ÷ ",
                                 "           3.01  ***");
        }
    }
}
