﻿using System;
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
using System.Runtime.InteropServices;


namespace User_Interface_Testing
{
    /// <summary>
    /// Summary description for HP97
    /// </summary>
    [CodedUITest]
    public class HP97
    {
        [DllImport ("user32.dll")]
        internal static extern short GetKeyState (int keyCode);

        public HP97 ()
        {
            // For some reason this setting doesn't seem to have any effect, so we use a wrapper
            // for SendKeys which sets isUnicode to false.
            Playback.PlaybackSettings.SendKeysAsScanCode = true;

            random = new Random ();
        }

        [TestMethod]
        public void p14 ()
        {
            UIMap.ManTraceNorm2Left ();

            UIMap.Five ();
            UIMap.ENTER ();
            UIMap.Six ();
            UIMap.Addition ();
            UIMap.AssertNumeric (" 11.00         ");

            UIMap.Eight ();
            UIMap.ENTER ();
            UIMap.Two ();
            UIMap.Division ();
            UIMap.AssertNumeric (" 4.00          ");

            UIMap.Seven ();
            UIMap.ENTER ();
            UIMap.Four ();
            UIMap.Subtraction ();
            UIMap.AssertNumeric (" 3.00          ");

            UIMap.Nine ();
            UIMap.ENTER ();
            UIMap.Eight ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 72.00         ");

            UIMap.Five ();
            UIMap.Reciprocal ();
            UIMap.AssertNumeric (" 0.20          ");

            UIMap.Three ();
            UIMap.Zero ();
            UIMap.SIN ();
            UIMap.AssertNumeric (" 0.50          ");

            UIMap.ManTraceNorm2Right ();

            UIMap.Three ();
            UIMap.Two ();
            UIMap.ZeroZero ();
            UIMap.AssertNumeric (" 3200.         ");

            UIMap.Square ();
            UIMap.AssertNumeric (" 10240000.00   ");
            UIMap.AssertPrinter ("        3200.00   X²");

            UIMap.Pi ();
            UIMap.AssertNumeric (" 3.14          ");
            UIMap.AssertPrinter ("                  Pi");

            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 32169908.78   ");
            UIMap.AssertPrinter ("                  × ");

            UIMap.PRINTx ();
            UIMap.AssertNumeric (" 32169908.78   ");
            UIMap.AssertPrinter ("    32169908.78  ***");
        }

        [TestMethod]
        public void p15p17 ()
        {
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

        [TestMethod]
        public void p18p19 ()
        {
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

        [TestMethod]
        public void Playground ()
        {
        }

        #region Additional test attributes

        //Use TestInitialize to run code before running each test 
        [TestInitialize ()]
        public void MyTestInitialize ()
        {
            this.UIMap.Launch ();

            // Make sure NumLock is on, otherwise sending {NumPad} keys doesn't have the right
            // effect.  Only do this after the application has started, otherwise we have no
            // control to send the key to.
            bool numLock = GetKeyState ((int) System.Windows.Forms.Keys.NumLock) != 0;
            if (!numLock)
            {
                UIMap.SendKeys ("{NumLock}");
            }
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup ()]
        public void MyTestCleanup ()
        {
            this.UIMap.Close ();
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap ();
                }

                return this.map;
            }
        }

        private UIMap map;

        private Random random;
    }
}
