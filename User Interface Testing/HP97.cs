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
    /// <summary>
    /// Summary description for HP97
    /// </summary>
    [CodedUITest]
    public class HP97
    {
        public HP97()
        {
        }

        [TestMethod]
        public void p14()
        {
            UIMap.ManTraceNorm2Left();

            UIMap.Five();
            UIMap.ENTER();
            UIMap.Six();
            UIMap.Addition();
            UIMap.AssertNumeric(" 11.00         ");

            UIMap.Eight();
            UIMap.ENTER();
            UIMap.Two();
            UIMap.Division();
            UIMap.AssertNumeric(" 4.00          ");

            UIMap.Seven();
            UIMap.ENTER();
            UIMap.Four();
            UIMap.Subtraction();
            UIMap.AssertNumeric(" 3.00          ");

            UIMap.Nine();
            UIMap.ENTER();
            UIMap.Eight();
            UIMap.Multiplication();
            UIMap.AssertNumeric(" 72.00         ");

            UIMap.Five();
            UIMap.Reciprocal();
            UIMap.AssertNumeric(" 0.20          ");

            UIMap.Three();
            UIMap.Zero();
            UIMap.SIN();
            UIMap.AssertNumeric(" 0.50          ");

            UIMap.ManTraceNorm2Right();

            UIMap.Three();
            UIMap.Two();
            UIMap.ZeroZero();
            UIMap.AssertNumeric(" 3200.         ");

            UIMap.Square();
            UIMap.AssertNumeric(" 10240000.00   ");
            UIMap.AssertPrinter("        3200.00   X²");

            UIMap.Pi();
            UIMap.AssertNumeric(" 3.14          ");
            UIMap.AssertPrinter("                  Pi");

            UIMap.Multiplication();
            UIMap.AssertNumeric(" 32169908.78   ");
            UIMap.AssertPrinter("                  × ");

            UIMap.PRINTx();
            UIMap.AssertNumeric(" 32169908.78   ");
            UIMap.AssertPrinter("    32169908.78  ***");
        }

        [TestMethod]
        public void p15p17()
        {
            UIMap.OpenStandardPacCard("Calendar Functions.hp67");
            UIMap.ManTraceNorm2Left();

            UIMap.Zero();
            UIMap.Nine();
            UIMap.Period();
            UIMap.Zero();
            UIMap.Three();
            UIMap.One();
            UIMap.Nine();
            UIMap.FourFour();
            UIMap.AssertNumeric(" 09.031944     ");

            UIMap.A();
            Thread.Sleep(500);
            UIMap.AssertNumeric(" 2431337.      ");

            UIMap.OneOne();
            UIMap.Period();
            UIMap.Two();
            UIMap.OneOne();
            UIMap.Nine();
            UIMap.Seven();
            UIMap.Five();
            UIMap.AssertNumeric(" 11.211975     ");

            UIMap.B();
            /*         Utilities.Delay(2) */
            UIMap.AssertNumeric(" 2442738.      ");

            UIMap.C();
            /*         Utilities.Delay(2) */
            UIMap.AssertNumeric(" 11401.        ");
        }
        
        [TestMethod]
        public void Playground()
        {
        }
        #region Additional test attributes

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.UIMap.Launch();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            this.UIMap.Close();
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
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
