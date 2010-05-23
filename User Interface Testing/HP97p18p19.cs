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
        public void p18p19 ()
        {
            // Your Own Program
            UIMap.TogglePrgmRun ();
            UIMap.CLPRGM ();
            UIMap.LBL ();
            UIMap.A ();
            UIMap.Square ();
            UIMap.Pi ();
            UIMap.Multiplication ();
            UIMap.PRINTx ();
            UIMap.RTN ();
            UIMap.TogglePrgmRun ();

            UIMap.Three ();
            UIMap.Two ();
            UIMap.ZeroZero ();
            UIMap.AssertNumeric (" 3200.         ");

            UIMap.A ();
            UIMap.AssertNumeric (" 32169908.78   ");

            UIMap.Two ();
            UIMap.Three ();
            UIMap.One ();
            UIMap.Zero ();
            UIMap.A ();
            UIMap.AssertNumeric (" 16763852.56   ");

            UIMap.One ();
            UIMap.Nine ();
            UIMap.Five ();
            UIMap.Zero ();
            UIMap.A ();
            UIMap.AssertNumeric (" 11945906.07   ");

            UIMap.Three ();
            UIMap.SendKeys ("22");
            UIMap.Zero ();
            UIMap.A ();
            UIMap.AssertNumeric (" 32573289.27   ");

            UIMap.EditLabels ("SPHERE SURFACE AREA", "d->A");
            UIMap.TogglePrgmRun ();
            UIMap.SaveCard ("p18p19_" + random.Next ());
        }
    }
}
