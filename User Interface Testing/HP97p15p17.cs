using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p15p17 ()
        {
            // Running a Prerecorded Program
            UIMap.OpenStandardPacCard ("Calendar Functions.hp67");
            UIMap.ManTraceNorm2Left ();

            UIMap.Zero ();
            UIMap.Nine ();
            UIMap.Period ();
            UIMap.Zero ();
            UIMap.Three ();
            UIMap.One ();
            UIMap.Nine ();
            UIMap.SendKeys ("{NumPad4}{NumPad4}");
            UIMap.AssertNumeric (" 09.031944     ");

            UIMap.A ();
            Thread.Sleep (500);
            UIMap.AssertNumeric (" 2431337.      ");

            UIMap.OneOne ();
            UIMap.Period ();
            UIMap.Two ();
            UIMap.OneOne ();
            UIMap.Nine ();
            UIMap.Seven ();
            UIMap.Five ();
            UIMap.AssertNumeric (" 11.211975     ");

            UIMap.B ();
            /*         Utilities.Delay(2) */
            UIMap.AssertNumeric (" 2442738.      ");

            UIMap.C ();
            /*         Utilities.Delay(2) */
            UIMap.AssertNumeric (" 11401.        ");
        }
    }
}
