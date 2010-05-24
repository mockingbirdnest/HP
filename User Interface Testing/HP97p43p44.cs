using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p43p44 ()
        {
            // Key in Exponents of Ten
            UIMap.One ();
            UIMap.Five ();
            UIMap.Period ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 15.6          ");
            UIMap.EEX ();
            UIMap.AssertNumeric (" 15.6        00");
            UIMap.One ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 15.6        12");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 1.560000000 13");
            UIMap.Two ();
            UIMap.Five ();
            UIMap.Multiplication ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 3.900000000 14");
            UIMap.AssertPrinter ("        15.6+12 ENT↑",
                                 "          25.00   × ",
                                 " 3.900000000+14  ***");

            UIMap.EEX ();
            UIMap.AssertNumeric (" 1.          00");
            UIMap.Six ();
            UIMap.AssertNumeric (" 1.          06");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 1000000.00    ");
            UIMap.Five ();
            UIMap.Two ();
            UIMap.Division ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 19230.77      ");
            UIMap.AssertPrinter ("          1.+06 ENT↑",
                                 "          52.00   ÷ ",
                                 "       19230.77  ***");

            UIMap.SCI ();
            UIMap.DSP ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 1.923077    04");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1.923077    04");
            UIMap.AssertPrinter ("                 SCI",
                                 "                DSP6",
                                 "    1.923077+04  ***");

            UIMap.CLx ();
            UIMap.AssertNumeric (" 0.000000    00");
            UIMap.FIX ();
            UIMap.DSP ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Six ();
            UIMap.Period ();
            UIMap.Six ();
            UIMap.Two ();
            UIMap.Five ();
            UIMap.EEX ();
            UIMap.AssertNumeric (" 6.625       00");
            UIMap.CHS ();
            UIMap.AssertNumeric (" 6.625      -00");
            UIMap.Two ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 6.625      -27");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 6.625000000-27");
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.Multiplication ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 3.312500000-25");
            UIMap.AssertPrinter ("                 CLX",
                                 "                 FIX",
                                 "                DSP2",
                                 "       6.625-27 ENT↑",
                                 "          50.00   × ",
                                 " 3.312500000-25  ***");
        }
    }
}
