using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p87p89 ()
        {
            // Setup
            UIMap.DSP ();
            UIMap.Four ();
            UIMap.AssertPrinter ("                DSP4");

            // Adding and Subtracting Time and Angles
            UIMap.Four ();
            UIMap.Five ();
            UIMap.SendKeys (".105076");
            UIMap.AssertNumeric (" 45.105076     ");
            UIMap.ENTER ();
            UIMap.AssertNumeric (" 45.1051       ");
            UIMap.Two ();
            UIMap.Four ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.Nine ();
            UIMap.One ();
            UIMap.Zero ();
            UIMap.Nine ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 24.491095     ");
            UIMap.HMSAddition ();
            UIMap.AssertNumeric (" 70.0002       ");
            UIMap.DSP ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 70.000171     ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 70.000171     ");
            UIMap.AssertPrinter ("      45.105076 ENT↑",
                                 "      24.491095 HMS+",
                                 "                DSP6",
                                 "      70.000171  ***");

            UIMap.SendKeys ("312.3217");
            UIMap.AssertNumeric (" 312.3217      ");
            UIMap.ENTER ();
            UIMap.One ();
            UIMap.Four ();
            UIMap.Two ();
            UIMap.Period ();
            UIMap.Seven ();
            UIMap.Eight ();
            UIMap.AssertNumeric (" 142.78        ");
            UIMap.ToHMS ();
            UIMap.AssertNumeric (" 142.464800    ");
            UIMap.CHS ();
            UIMap.AssertNumeric ("-142.464800    ");
            UIMap.HMSAddition ();
            UIMap.AssertNumeric (" 169.452900    ");
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 169.452900    ");
            UIMap.DSP ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 169.45        ");
            UIMap.AssertPrinter ("     312.321700 ENT↑",
                                 "     142.780000 →HMS",
                                 "                 CHS",
                                 "                HMS+",
                                 "     169.452900  ***",
                                 "                DSP2");

            UIMap.CLx ();
            UIMap.DEG ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.Five ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.Three ();
            UIMap.FromHMS ();
            UIMap.AssertNumeric (" 5.72          ");
            UIMap.One ();
            UIMap.Two ();
            UIMap.Period ();
            UIMap.One ();
            UIMap.Eight ();
            UIMap.FromHMS();
            UIMap.AssertNumeric (" 12.30         ");
            UIMap.Subtraction ();
            UIMap.AssertNumeric ("-6.58          ");
            UIMap.COS ();
            UIMap.AssertNumeric (" 0.99          ");
            UIMap.SendKeys ("15.55");
            UIMap.FromHMS();
            UIMap.AssertNumeric (" 15.92         ");
            UIMap.STO ();
            UIMap.One ();
            UIMap.AssertNumeric (" 15.92         ");
            UIMap.COS ();
            UIMap.AssertNumeric (" 0.96          ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.96          ");
            UIMap.SendKeys ("37.03");
            UIMap.FromHMS();
            UIMap.AssertNumeric (" 37.05         ");
            UIMap.STO ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 37.05         ");
            UIMap.COS ();
            UIMap.AssertNumeric (" 0.80          ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.76          ");
            UIMap.RCL ();
            UIMap.Zero ();
            UIMap.SIN ();
            UIMap.AssertNumeric (" 0.60          ");
            UIMap.RCL ();
            UIMap.One ();
            UIMap.SIN ();
            UIMap.AssertNumeric (" 0.27          ");
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 0.17          ");
            UIMap.Addition ();
            UIMap.AssertNumeric (" 0.93          ");
            UIMap.ArcCOS ();
            UIMap.AssertNumeric (" 21.92         ");
            UIMap.Six ();
            UIMap.Zero ();
            UIMap.Multiplication ();
            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 1315.41       ");
            UIMap.AssertPrinter ("                 CLX",
                                 "                 DEG",
                                 "           5.43 HMS→",
                                 "          12.18 HMS→",
                                 "                  - ",
                                 "                 COS",
                                 "          15.55 HMS→",
                                 "                STO1",
                                 "                 COS",
                                 "                  × ",
                                 "          37.03 HMS→",
                                 "                STO0",
                                 "                 COS",
                                 "                  × ",
                                 "                RCL0",
                                 "                 SIN",
                                 "                RCL1",
                                 "                 SIN",
                                 "                  × ",
                                 "                  + ",
                                 "                COS¹",
                                 "          60.00   × ",
                                 "        1315.41  ***");
        }
    }
}
