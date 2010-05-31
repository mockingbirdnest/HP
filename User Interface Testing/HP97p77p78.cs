using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p77p78 ()
        {
            // Number Alteration Keys

            // Rounding a Number
            UIMap.One ();
            UIMap.Six();
            UIMap.Period();
            UIMap.Three ();
            UIMap.Eight ();
            UIMap.Seven ();
            UIMap.Zero ();
            UIMap.Six ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 16.387064     ");
            UIMap.DSP ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 16.39         ");
            UIMap.RND ();
            UIMap.AssertNumeric (" 16.39         ");
            UIMap.DSP ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 16.390000     ");
            UIMap.LASTx ();
            UIMap.AssertNumeric (" 16.387064     ");
            UIMap.DSP ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 16.39         ");
            UIMap.AssertPrinter ("      16.387064 DSP2",
                                 "                 RND",
                                 "                DSP6",
                                 "                LSTX",
                                 "                DSP2");

            // Absolute Value
            UIMap.Three ();
            UIMap.CHS ();
            UIMap.AssertNumeric ("-3.            ");
            UIMap.ABS ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.ABS ();
            UIMap.AssertNumeric (" 3.00          ");
            UIMap.AssertPrinter ("          -3.00  ABS",
                                 "                 ABS");   
         
            // Integer Portion of a Number
            UIMap.One ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.Five ();
            UIMap.Six ();
            UIMap.AssertNumeric (" 123.456       ");
            UIMap.INT ();
            UIMap.AssertNumeric (" 123.00        ");
            UIMap.AssertPrinter ("        123.456  INT");

            // Fractional Portion of a Number
            UIMap.LASTx ();
            UIMap.AssertNumeric (" 123.46        ");
            UIMap.FRAC ();
            UIMap.AssertNumeric (" 0.46          ");
            UIMap.AssertPrinter ("                LSTX",
                                 "                 FRC");
        }
    }
}
