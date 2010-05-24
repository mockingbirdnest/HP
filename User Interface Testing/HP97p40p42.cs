using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p40p42 ()
        {
            // Format of Printed Numbers.
            UIMap.Period ();
            UIMap.ZeroZeroZeroZero ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Four ();
            UIMap.Five ();
            UIMap.Six ();
            UIMap.AssertNumeric (" .0000123456   ");
            UIMap.SCI ();
            UIMap.DSP ();
            UIMap.Three ();
            UIMap.AssertNumeric (" 1.235      -05");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1.235      -05");
            UIMap.AssertPrinter ("    .0000123456  SCI",
                                 "                DSP3",
                                 "       1.235-05  ***");

            UIMap.One ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Four ();
            UIMap.Five ();
            UIMap.Six ();
            UIMap.Seven ();
            UIMap.Eight ();
            UIMap.Nine ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 1234567890.   ");
            UIMap.ENG ();
            UIMap.DSP ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 1.234568    09");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1.234568    09");
            UIMap.AssertPrinter ("    1234567890.  ENG",
                                 "                DSP6",
                                 "    1.234568+09  ***");

            UIMap.ToggleOffOn ();
            UIMap.ToggleOffOn ();
            UIMap.FIX ();
            UIMap.DSP ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Seven ();
            UIMap.Three ();
            UIMap.Five ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.Three ();
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 735.43        ");
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Five ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 500.43        ");
            UIMap.Seven ();
            UIMap.Nine ();
            UIMap.Period ();
            UIMap.Nine ();
            UIMap.Five ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 420.48        ");
            UIMap.Five ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 415.48        ");
            UIMap.One ();
            UIMap.Period ();
            UIMap.FourFour ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 414.04        ");
            UIMap.One ();
            UIMap.Seven ();
            UIMap.Period ();
            UIMap.Eight ();
            UIMap.Three ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 396.21        ");
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 346.21        ");
            UIMap.One ();
            UIMap.Two ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 333.81        ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 333.81        ");
            UIMap.AssertPrinter ("                 FIX",
                                 "                DSP2",
                                 "         735.43 ENT↑",
                                 "         235.00   - ",
                                 "          79.95   - ",
                                 "           5.00   - ",
                                 "           1.44   - ",
                                 "          17.83   - ",
                                 "          50.00   - ",
                                 "          12.40   - ",
                                 "         333.81  ***");

            UIMap.Period ();
            UIMap.ZeroZeroZero ();
            UIMap.Five ();
            UIMap.AssertNumeric (" .0005         ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.17          ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 0.17          ");
            UIMap.AssertPrinter ("          .0005   × ",
                                 "           0.17  ***");
        }
    }
}
