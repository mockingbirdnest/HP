﻿namespace User_Interface_Testing
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
        public void InitializeListBoxState ()
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
                listItems [i].SearchProperties [WinListItem.PropertyNames.Instance] = i.ToString();
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

        public void AssertPrinter (string s)
        {
            InitializeListBoxState ();
            listItemsAsserted += 1;
            int listItem = listItemsAsserted < listBoxSize ? listBoxSize : listItemsAsserted;
            Assert.AreEqual (s, UIItemListItem (listItem).DisplayText);
        }

        public void AssertPrinter (string s1, string s2)
        {
            InitializeListBoxState ();
            listItemsAsserted += 2;
            int listItem = listItemsAsserted < listBoxSize ? listBoxSize : listItemsAsserted;
            Assert.AreEqual (s2, UIItemListItem (listItem).DisplayText);
            Assert.AreEqual (s1, UIItemListItem (listItem - 1).DisplayText);
        }

        public void AssertPrinter (string s1, string s2, string s3)
        {
            InitializeListBoxState ();
            listItemsAsserted += 3;
            int listItem = listItemsAsserted < listBoxSize ? listBoxSize : listItemsAsserted;
            Assert.AreEqual (s3, UIItemListItem (listItem).DisplayText);
            Assert.AreEqual (s2, UIItemListItem (listItem - 1).DisplayText);
            Assert.AreEqual (s1, UIItemListItem (listItem - 2).DisplayText);
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

        private const int listBoxSize = 7;
        private Dictionary<int, WinListItem> listItems;
        private int listItemsAsserted;
    }
}
