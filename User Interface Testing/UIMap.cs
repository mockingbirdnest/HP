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
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;

    public partial class UIMap
    {
        public void AssertNumeric (string s)
        {
            AssertNumericExpectedValues.UINumericTextBoxEditText = s;
            AssertNumeric ();
        }

        public void AssertPrinter (string s)
        {
            AssertPrinterLine0ExpectedValues.UIItemListItemDisplayText = s;
            AssertPrinterLine0 ();
        }

        public void AssertPrinter (string s1, string s2)
        {
            AssertPrinterLine0ExpectedValues.UIItemListItemDisplayText = s2;
            AssertPrinterLine0 ();
            AssertPrinterLine1ExpectedValues.UIItemListItem1DisplayText = s1;
            AssertPrinterLine1 ();
        }

        public void EditLabels (string title,
                               string labelA)
        {
            EditLabelsParams.UITitleTextBoxEditText = title;
            EditLabelsParams.UITextBoxAEditText = labelA;
            EditLabels ();
        }

        public void OpenStandardPacCard (string name)
        {
            OpenStandardPacCardParams.UIFilenameComboBoxEditableItem = name;
            OpenStandardPacCard ();
        }

        public void SaveCard (string name)
        {
            SaveCardParams.UIFilenameComboBoxEditableItem = name;
            SaveCard ();
        }
        public void SendKeys (string s)
        {
            WinClient uIPanelMainClient = UIHP97Window.UIPanelMainWindow.UIPanelMainClient;

            // Click 'panelMain' client
            Mouse.Click (uIPanelMainClient, new Point (1, 1));

            Keyboard.SendKeys (uIPanelMainClient,
                               s,
                               ModifierKeys.None,
                               false /*isEncoded*/,
                               false /*isUnicode*/);
        }

        public void CLPRGM ()
        {
            f ();
            Three ();
        }

        public void LOG ()
        {
            f ();
            LN ();
        }
        public void Pi ()
        {
            f ();
            Division ();
        }

        public void TenToTheXth ()
        {
            f ();
            Exp ();
        }
    }
}
