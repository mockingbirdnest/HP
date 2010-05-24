using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace User_Interface_Testing
{
    public partial class HP97
    {
        [TestMethod]
        public void p35p39 ()
        {
            // Printer and Display Control
            UIMap.Two ();
            UIMap.ENTER ();
            UIMap.Three ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 6.00          ");

            // Display Number Changes
            UIMap.ManTraceNorm2Left ();
            UIMap.ToggleOffOn ();
            UIMap.ToggleOffOn ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.DSP ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 0.0000        ");
            UIMap.DSP ();
            UIMap.Nine ();
            UIMap.AssertNumeric (" 0.000000000   ");
            UIMap.DSP ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 0.00          ");

            // Scientific Notation Display
            UIMap.ToggleOffOn ();
            UIMap.ToggleOffOn ();
            UIMap.AssertNumeric (" 0.00          ");
            UIMap.One ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.Five ();
            UIMap.Six ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 123.4567      ");
            UIMap.SCI ();
            UIMap.AssertNumeric (" 1.23        02");
            UIMap.DSP ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 1.2346      02");
            UIMap.DSP ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 1.2345670   02");
            UIMap.DSP ();
            UIMap.Nine ();
            UIMap.AssertNumeric (" 1.234567000 02");
            UIMap.DSP ();
            UIMap.Four ();
            UIMap.AssertNumeric (" 1.2346      02");

            // Fixed Point Display.
            UIMap.One ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Period ();
            UIMap.Four ();
            UIMap.Five ();
            UIMap.Six ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 123.4567      ");
            UIMap.FIX ();
            UIMap.AssertNumeric (" 123.4567      ");
            UIMap.DSP ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 123.          ");
            UIMap.DSP ();
            UIMap.Seven ();
            UIMap.AssertNumeric (" 123.4567000   ");
            UIMap.DSP ();
            UIMap.One ();
            UIMap.AssertNumeric (" 123.5         ");
            UIMap.DSP ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 123.46        ");

            // Engineering Notation Display
            UIMap.Period ();
            UIMap.ZeroZeroZeroZero ();
            UIMap.One ();
            UIMap.Two ();
            UIMap.Three ();
            UIMap.Four ();
            UIMap.Five ();
            UIMap.AssertNumeric (" .000012345    ");
            UIMap.ENG ();
            UIMap.AssertNumeric (" 12.3       -06");
            UIMap.DSP ();
            UIMap.Three ();
            UIMap.AssertNumeric (" 12.35      -06");
            UIMap.DSP ();
            UIMap.Nine ();
            UIMap.AssertNumeric (" 12.34500000-06");
            UIMap.DSP ();
            UIMap.Zero ();
            UIMap.AssertNumeric (" 10.        -06");
            UIMap.DSP ();
            UIMap.Two ();
            UIMap.AssertNumeric (" 12.3       -06");
            UIMap.One ();
            UIMap.Zero ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 123        -06");
            UIMap.One ();
            UIMap.Zero ();
            UIMap.Multiplication ();
            UIMap.AssertNumeric (" 1.23       -03");
        }
    }
}
