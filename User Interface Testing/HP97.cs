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
using System.Runtime.InteropServices;

namespace User_Interface_Testing
{
    /// <summary>
    /// Summary description for HP97
    /// </summary>
    [CodedUITest]
    public partial class HP97
    {
        [DllImport ("user32.dll")]
        internal static extern short GetKeyState (int keyCode);

        public HP97 ()
        {
            Playback.PlaybackSettings.ContinueOnError = true;

            // For some reason this setting doesn't seem to have any effect, so we use a wrapper
            // for SendKeys which sets isUnicode to false.
            Playback.PlaybackSettings.SendKeysAsScanCode = true;

            random = new Random ();
        }

        [TestMethod]
        public void Playground ()
        {

            this.UIMap.GSB ();
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
