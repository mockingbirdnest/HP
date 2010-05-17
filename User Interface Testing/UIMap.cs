namespace User_Interface_Testing
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    public partial class UIMap
    {
        public void AssertNumeric(string s)
        {
            AssertNumericExpectedValues.UINumericTextBoxEditText = s;
            AssertNumeric();
        }

        public void AssertPrinter(string s)
        {
            AssertPrinterLine0ExpectedValues.UIItemListItemDisplayText = s;
            AssertPrinterLine0();
        }

        public void Pi()
        {
            F();
            Division();
        }
    }
}
