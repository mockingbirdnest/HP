using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p64p65 ()
        {
            // Storing Numbers
            UIMap.Six ();
            UIMap.Period ();
            UIMap.Zero ();
            UIMap.Two ();
            UIMap.EEX ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.AssertNumeric (" 6.02        23");
            UIMap.STO ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 6.020000000 23");
            UIMap.AssertPrinter ("        6.02+23 STO2");
            UIMap.Square ();
            UIMap.AssertNumeric (" 3.624040000 47");
            UIMap.STO ();
            UIMap.B ();
            UIMap.AssertNumeric (" 3.624040000 47");
            UIMap.AssertPrinter ("                  X²",
                                 "                STOB");

            // Recalling Numbers
            UIMap.RCL ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 6.020000000 23");
            UIMap.AssertPrinter ("                RCL2");
            UIMap.RCL ();
            UIMap.B ();
            UIMap.AssertNumeric (" 3.624040000 47");
            UIMap.AssertPrinter ("                RCLB");
            UIMap.RCL ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 6.020000000 23");
            UIMap.AssertPrinter ("                RCL2");
        }
    }
}
