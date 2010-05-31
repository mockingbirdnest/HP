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
        private void InitializeListBoxState ()
        {
            if (listItems == null)
            {
                listItems = new Dictionary<int, WinListItem> ();
                listItemsAsserted = 0;
            }
        }

        // UI Management.

        public void SendKeys (string s)
        {
            WinClient uIPanelMainClient = UIHP97Window.UIPanelMainWindow.UIPanelMainClient;

            // Click 'panelMain' client
            Mouse.Click (uIPanelMainClient, new Point (1, 1));

            // Need to send in non-Unicode mode to be able to parse the keys.
            Keyboard.SendKeys (uIPanelMainClient,
                               s,
                               ModifierKeys.None,
                               false /*isEncoded*/,
                               false /*isUnicode*/);
        }

        public WinListItem UIItemListItem (int i)
        {
            // Finding the proper item in the list box is too complicated for automatically
            // generated code, as we have to keep track of the number of lines in the list box.
            if (!listItems.ContainsKey (i))
            {
                listItems [i] = new WinListItem (UIHP97Window.UIListBoxWindow);
                #region Search Criteria
                listItems [i].SearchProperties [WinListItem.PropertyNames.Instance] = i.ToString ();
                listItems [i].WindowTitles.Add ("HP-97");
                #endregion
            }
            return listItems [i];
        }

        // Assertions.

        public void AssertNumeric (string s)
        {
            AssertNumericExpectedValues.UINumericTextBoxEditText = s;
            AssertNumeric ();
        }

        public void AssertPrinter (Array lines)
        {
            InitializeListBoxState ();
            listItemsAsserted += lines.Length;
            int listItem = listItemsAsserted < listBoxSize ? listBoxSize - lines.Length + 1 :
                                                             listItemsAsserted - lines.Length + 1;
            foreach (string line in lines)
            {
                Assert.AreEqual (line, UIItemListItem (listItem).DisplayText);
                ++listItem;
            }
        }

        public void AssertPrinter (string s)
        {
            InitializeListBoxState ();
            listItemsAsserted += 1;
            int listItem = listItemsAsserted < listBoxSize ? listBoxSize : listItemsAsserted;
            Assert.AreEqual (s, UIItemListItem (listItem).DisplayText);
        }

        public void AssertPrinter (string s1, string s2)
        {
            string [] lines = new string [] { s1, s2 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3)
        {
            string [] lines = new string [] { s1, s2, s3 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4)
        {
            string [] lines = new string [] { s1, s2, s3, s4 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13, string s14)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13, s14 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13, string s14, string s15)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13, s14, s15 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13, string s14, string s15, string s16)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13, s14, s15, s16 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13, string s14, string s15, string s16,
                                   string s17)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13, s14, s15, s16, s17 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13, string s14, string s15, string s16,
                                   string s17, string s18)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13, s14, s15, s16, s17, s18 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13, string s14, string s15, string s16,
                                   string s17, string s18, string s19)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13, s14, s15, s16, s17, s18, s19 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13, string s14, string s15, string s16,
                                   string s17, string s18, string s19, string s20)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13, s14, s15, s16, s17, s18, s19, s20 };
            AssertPrinter (lines);
        }

        public void AssertPrinter (string s1, string s2, string s3, string s4, string s5, string s6,
                                   string s7, string s8, string s9, string s10, string s11,
                                   string s12, string s13, string s14, string s15, string s16,
                                   string s17, string s18, string s19, string s20, string s21)
        {
            string [] lines = new string [] { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, 
                                              s11, s12, s13, s14, s15, s16, s17, s18, s19, s20,
                                              s21};
            AssertPrinter (lines);
        }

        public void AssertText (string s)
        {
            AssertTextExpectedValues.UIAlphabeticTextBoxEditText = s;
            AssertText ();
        }

        // Menu.

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

        // Composite operations.

        public void ABS ()
        {
            f ();
            YToTheXth ();
        }

        public void CLPRGM ()
        {
            f ();
            Three ();
        }

        public void CLREG ()
        {
            f ();
            Two ();
        }

        public void INT ()
        {
            f ();
            ToPolar ();
        }

        public void FRAC ()
        {
            f ();
            ToRectangular ();
        }

        public void LASTx ()
        {
            f ();
            DSP ();
        }

        public void LOG ()
        {
            f ();
            LN ();
        }

        public void PExchangeS ()
        {
            f ();
            CLx ();
        }

        public void Pi ()
        {
            f ();
            Division ();
        }

        public void PrintReg ()
        {
            f ();
            ENG ();
        }

        public void PrintStack ()
        {
            f ();
            PRINTx ();
        }

        public void RAD ()
        {
            f ();
            CHS ();
        }

        public void RND ()
        {
            f ();
            RTN ();
        }

        public void TenToTheXth ()
        {
            f ();
            Exp ();
        }

        private const int listBoxSize = 7;
        private Dictionary<int, WinListItem> listItems;
        private int listItemsAsserted;
    }
}
