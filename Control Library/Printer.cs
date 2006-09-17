using Mockingbird.HP.Class_Library;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Mockingbird.HP.Control_Library
{
    /// <summary>
    /// The dot-matrix printer of the HP97 calculator
    /// </summary>
    public class Printer : UserControl, Mockingbird.HP.Class_Library.IPrinter
    {

        #region Private Data

        private enum Column
        {
            Instruction,
            Numeric,
            Step
        }

        private static string defaultTag = new string (' ', symbolicWidth - 3) + "***";
        private const string mantissaExponentSeparator = "";
        private const string stepTemplate = "000  ";
        private const byte keycodeWidth = 10;
        private const byte symbolicWidth = 5;

        private Column lastPrintedColumn;
        private int emptyLinesAtTop;
        private Graphics graphics;
        private int lines = 0;

        private string exponent;
        private Number.Formatter formatter;
        private string mantissa;

        private System.Windows.Forms.ListBox listBox;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors & Destructors

        public Printer ()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent ();

            // A graphic context will prove handy to align text.
            graphics = listBox.CreateGraphics ();

            lastPrintedColumn = Column.Instruction;
            emptyLinesAtTop = lines;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose (bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose ();
                }
            }
            base.Dispose (disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.listBox = new System.Windows.Forms.ListBox ();
            this.SuspendLayout ();
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox.Font = new System.Drawing.Font ("DotMatrix", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.listBox.ItemHeight = 18;
            this.listBox.Location = new System.Drawing.Point (0, 0);
            this.listBox.Name = "listBox";
            this.listBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox.ScrollAlwaysVisible = true;
            this.listBox.Size = new System.Drawing.Size (192, 216);
            this.listBox.TabIndex = 0;
            // 
            // Printer
            // 
            this.Controls.Add (this.listBox);
            this.Name = "Printer";
            this.Size = new System.Drawing.Size (192, 216);
            this.ResumeLayout (false);

        }
        #endregion

        #endregion

        #region Event Handlers

        private void RecordNumeric (string mantissa, string exponent, double value)
        {
            this.mantissa = mantissa;
            this.exponent = exponent;
        }

        #endregion

        #region Overriding Operations

        protected override void OnResize (EventArgs e)
        {
            base.OnResize (e);

            int newLines = listBox.DisplayRectangle.Height / listBox.ItemHeight;

            if (newLines > lines)
            {
                for (int i = 1; i <= newLines - lines; i++)
                {
                    ThreadSafe.ItemsInsert (listBox, 0, "");
                }
            }
            else if (newLines < lines)
            {
                for (int i = 1; i <= lines - newLines; i++)
                {
                    ThreadSafe.ItemsRemoveAt (listBox, 0);
                }
            }
            if (emptyLinesAtTop == lines)
            {
                emptyLinesAtTop = newLines;
            }
            lines = newLines;
        }

        #endregion

        #region Private Operations

        private void Append (string s, HorizontalAlignment alignment)
        {
            int padding;

            for (padding = 1; ; padding++)
            {
                if (graphics.MeasureString (new string (' ', padding) + s, listBox.Font).Width >
                    listBox.DisplayRectangle.Width)
                {
                    padding--;
                    break;
                }
            }

            // If we have empty space at the top of the list, remove it.  This will avoid showing
            // the scroll bar too early.
            if (emptyLinesAtTop > 0)
            {
                ThreadSafe.ItemsRemoveAt (listBox, 0);
                emptyLinesAtTop--;
            }

            switch (alignment)
            {
                case HorizontalAlignment.Center:
                    ThreadSafe.ItemsAdd (listBox, new string (' ', padding / 2) + s);
                    break;
                case HorizontalAlignment.Left:
                    ThreadSafe.ItemsAdd (listBox, s);
                    break;
                case HorizontalAlignment.Right:
                    ThreadSafe.ItemsAdd (listBox, new string (' ', padding) + s);
                    break;
            }
            ThreadSafe.SetTopIndex (listBox, ThreadSafe.GetItemsCount (listBox) - lines);
        }

        private void Replace (string s, int index, HorizontalAlignment alignment)
        {
            int padding;

            for (padding = 1; ; padding++)
            {
                if (graphics.MeasureString (new string (' ', padding) + s, listBox.Font).Width >
                    listBox.DisplayRectangle.Width)
                {
                    padding--;
                    break;
                }
            }

            switch (alignment)
            {
                case HorizontalAlignment.Center:
                    ThreadSafe.ItemsSetItem (listBox, index, new string (' ', padding / 2) + s);
                    break;
                case HorizontalAlignment.Left:
                    ThreadSafe.ItemsSetItem (listBox, index, s);
                    ThreadSafe.ItemsAdd (listBox, s);
                    break;
                case HorizontalAlignment.Right:
                    ThreadSafe.ItemsSetItem (listBox, index, new string (' ', padding) + s);
                    break;
            }
            ThreadSafe.SetTopIndex (listBox, ThreadSafe.GetItemsCount (listBox) - lines);
        }

        private void PrintNumeric (string s)
        {

            // If we try to append spaces, the silly control will strip them.  So we use the
            // default tag, which is made of stars.  If a tag is explicitly inserted by the engine,
            // the default tag will be overwritten and will be invisible to the user.  Otherwise,
            // we'll have just what we want for the final result.
            Append (s + defaultTag, HorizontalAlignment.Right);
            lastPrintedColumn = Column.Numeric;
        }

        #endregion

        #region Public Properties

        public Number.Formatter Formatter
        {
            get
            {
                return formatter;
            }
            set
            {
                formatter = value;
                if (formatter != null)
                {
                    formatter.FormattingChanged += new Number.ChangeEvent (RecordNumeric);
                }
            }
        }

        #endregion

        #region Public Operations

        public void Advance ()
        {
            if (emptyLinesAtTop > 0)
            {
                ThreadSafe.ItemsRemoveAt (listBox, 0);
                emptyLinesAtTop--;
            }
            ThreadSafe.ItemsAdd (listBox, "");
            ThreadSafe.SetTopIndex (listBox, ThreadSafe.GetItemsCount (listBox) - lines);
            lastPrintedColumn = Column.Instruction;
        }

        public void PrintNumeric ()
        {
            PrintNumeric (mantissa + mantissaExponentSeparator + exponent);
        }

        public void PrintNumeric (string mantissa, string exponent)
        {
            PrintNumeric (mantissa + mantissaExponentSeparator + exponent);
        }

        public void PrintStep (int step)
        {
            Trace.Assert (lastPrintedColumn != Column.Step);
            Append (step.ToString (stepTemplate, NumberFormatInfo.InvariantInfo) + defaultTag,
                    HorizontalAlignment.Right);
            lastPrintedColumn = Column.Step;
        }

        public void PrintInstruction (Instruction instruction, bool showKeycodes)
        {
            string s = instruction.TraceableText;

            Trace.Assert (s.Length <= symbolicWidth);
            s = s.PadLeft (symbolicWidth);
            if (showKeycodes)
            {
                s += instruction.Text.PadLeft (keycodeWidth);
            }
            switch (lastPrintedColumn)
            {
                case Column.Numeric:
                case Column.Step:
                    {
                        int count = ThreadSafe.ItemsCount (listBox);
                        string lastItem = (string) ThreadSafe.ItemsGetItem(listBox, count - 1);

                        lastItem = lastItem.Substring (0, lastItem.Length - symbolicWidth) + s;
                        Replace (lastItem.Trim (), count - 1, HorizontalAlignment.Right);
                        break;
                    }
                case Column.Instruction:
                    {
                        Append (s, HorizontalAlignment.Right);
                        break;
                    }
            }
            lastPrintedColumn = Column.Instruction;
        }

        #endregion

    }
}
