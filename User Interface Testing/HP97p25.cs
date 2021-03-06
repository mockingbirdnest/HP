﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p25 ()
        {
            // Functions
            UIMap.ManTraceNorm1Left ();

            UIMap.One ();
            UIMap.Four ();
            UIMap.Eight ();
            UIMap.Period ();
            UIMap.Eight ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 148.84        ");

            UIMap.Sqrt ();
            UIMap.AssertNumeric (" 12.20         ");
            UIMap.AssertPrinter ("         148.84   √X",
                                 "          12.20  ***");

            UIMap.Square ();
            UIMap.AssertNumeric (" 148.84        ");
            UIMap.AssertPrinter ("                  X²",
                                 "         148.84  ***");
        }
    }
}
