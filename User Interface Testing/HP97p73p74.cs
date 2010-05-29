using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p73p74 ()
        {
            // Storage Register Arithmetic
            UIMap.Two ();
            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.Seven ();
            UIMap.Addition ();
            UIMap.One ();
            UIMap.Nine ();
            UIMap.Addition ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 94.00         ");
            UIMap.Five ();
            UIMap.Five ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 5170.00       ");
            UIMap.STO ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 5170.00       ");
            UIMap.Two ();
            UIMap.Percent ();
            UIMap.AssertNumeric (" 103.40        ");
            UIMap.STO ();
            UIMap.Subtraction ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 103.40        ");
            UIMap.AssertPrinter ("          25.00 ENT↑",
                                 "          27.00   + ",
                                 "          19.00   + ",
                                 "          23.00   + ",
                                 "          55.00   × ",
                                 "                STO5",
                                 "           2.00   % ",
                                 "                ST-5");

            UIMap.Two ();
            UIMap.Six ();
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.Eight ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 54.00         ");
            UIMap.Five ();
            UIMap.Seven ();
            UIMap.Period ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 3105.00       ");
            UIMap.STO ();
            UIMap.Addition ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 3105.00       ");
            UIMap.Three ();
            UIMap.Percent ();
            UIMap.AssertNumeric (" 93.15         ");
            UIMap.STO ();
            UIMap.Subtraction ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 93.15         ");
            UIMap.RCL ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 8078.45       ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 8078.45       ");
            UIMap.AssertPrinter ("          26.00 ENT↑",
                                 "          28.00   + ",
                                 "          57.50   × ",
                                 "                ST+5",
                                 "           3.00   % ",
                                 "                ST-5",
                                 "                RCL5",
                                 "        8078.45  ***");
        }
    }
}
