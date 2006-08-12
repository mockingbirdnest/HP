using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Control_Library
{
    public enum DisplayFormat
    {
        Engineering,
        Fixed,
        Scientific
    }

    public enum DisplayMode
    {
        Alphabetic,
        Instruction,
        Numeric
    }

    /// <summary>
    /// The LED display for an HP calculator.
    /// </summary>
    public class Display : System.Windows.Forms.UserControl
    {

        #region Private Data

        private const int mantissaSignFirst = 0;
        private const int mantissaSignLength = 1;
        private const int mantissaFirst = 1;
        private const int mantissaLength = 11;
        private const int exponentSignFirst = 12;
        private const int exponentSignLength = 1;
        private const int exponentFirst = 13;
        private const int exponentLength = 2;
        private const string exponentTemplate = " 00;-00";
        private const string fixUnderflowOverflowMantissaTemplate = " 0.000000000;-0.000000000";
        private const double heightFactor = 1.85;
        private const int instructionFirst = 3;
        private const int instructionLength = 11;
        private const string negativeOverflow = "-9.999999999 99";
        private const double overflowLimit = 9.999999999E99;
        private const string period = ".";
        private const string positiveOverflow = " 9.999999999 99";
        private const string randomChars = "0123456789ACFHNU";
        private const string randomSign = " -";
        private const int stepFirst = 0;
        private const int stepLength = 3;
        private const string stepTemplate = "000";
        private const int textLength = 15;
        private const double underflowLimit = 1.0E-99;

        private bool enteringExponent;
        private bool enteringMantissa;
        private bool enteringNumber;
        private bool hasAPeriod;
        private bool isBlurred;
        private bool userControlTesting;

        private double currentMantissa;
        private byte digits;
        private string engMantissaTemplate1;
        private string engMantissaTemplate10;
        private string engMantissaTemplate100;
        private string fixMantissaTemplate;
        private DisplayFormat format;
        private int height;
        private DisplayMode mode;
        private bool overflows;
        private double overflowValue;
        private string sciMantissaTemplate;

        private System.Windows.Forms.TextBox alphabeticTextBox;
        private System.Windows.Forms.TextBox instructionTextBox;
        private System.Windows.Forms.TextBox numericTextBox;

        private Font font;
        private Random random;

        #endregion

        #region Event Definitions

        public delegate void DisplayStateChangeEvent (object sender);
        public delegate void ImmediateKeystrokeEvent ();
        public delegate bool TimedKeystrokeEvent (int ms);

        public event ImmediateKeystrokeEvent AcceptKeystroke;
        public event ImmediateKeystrokeEvent CompleteKeystrokes;
        public event TimedKeystrokeEvent WaitForKeystroke;
        public event DisplayStateChangeEvent EnteringNumber;

        #endregion

        #region Constructors & Destructors

        public Display ()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent ();

            string [] appSettingsUserControlTesting =
                System.Configuration.ConfigurationManager.AppSettings.GetValues
                    ("UserControlTesting");

            if (appSettingsUserControlTesting == null)
            {
                userControlTesting = false;
            }
            else
            {
                userControlTesting = bool.Parse (appSettingsUserControlTesting [0]);
            }

            random = new Random ();

            // Make the control non-selectable, otherwise the application will select its
            // text at startup.
            SetStyle (ControlStyles.Selectable, false);
            UpdateStyles ();

            enteringExponent = false;
            enteringMantissa = false;
            enteringNumber = false;
            hasAPeriod = false;

            Digits = 2;
            Font = new System.Drawing.Font ("Quartz",
                                            21.75F,
                                            System.Drawing.FontStyle.Regular,
                                            System.Drawing.GraphicsUnit.Point,
                                            0);
            Format = DisplayFormat.Fixed;
            Mode = DisplayMode.Numeric;
            Value = 0.0;

            Card.ReadFromDataset += new Card.DatasetImporterDelegate (ReadFromDataset);
            Card.WriteToDataset += new Card.DatasetExporterDelegate (WriteToDataset);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose (bool disposing)
        {
            base.Dispose (disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.numericTextBox = new System.Windows.Forms.TextBox ();
            this.instructionTextBox = new System.Windows.Forms.TextBox ();
            this.alphabeticTextBox = new System.Windows.Forms.TextBox ();
            this.SuspendLayout ();
            // 
            // numericTextBox
            // 
            this.numericTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.numericTextBox.BackColor = System.Drawing.Color.Black;
            this.numericTextBox.Font = new System.Drawing.Font ("Quartz", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.numericTextBox.ForeColor = System.Drawing.Color.Red;
            this.numericTextBox.Location = new System.Drawing.Point (0, 0);
            this.numericTextBox.Name = "numericTextBox";
            this.numericTextBox.ReadOnly = true;
            this.numericTextBox.Size = new System.Drawing.Size (300, 40);
            this.numericTextBox.TabIndex = 0;
            this.numericTextBox.Text = "0.00";
            this.numericTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler (this.textBox_MouseDown);
            this.numericTextBox.MouseLeave += new System.EventHandler (this.textBox_MouseLeave);
            // 
            // instructionTextBox
            // 
            this.instructionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.instructionTextBox.BackColor = System.Drawing.Color.Black;
            this.instructionTextBox.Font = new System.Drawing.Font ("Quartz", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.instructionTextBox.ForeColor = System.Drawing.Color.Red;
            this.instructionTextBox.Location = new System.Drawing.Point (0, 0);
            this.instructionTextBox.Name = "instructionTextBox";
            this.instructionTextBox.ReadOnly = true;
            this.instructionTextBox.Size = new System.Drawing.Size (300, 40);
            this.instructionTextBox.TabIndex = 1;
            this.instructionTextBox.Text = "Instruction";
            this.instructionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.instructionTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler (this.textBox_MouseDown);
            // 
            // alphabeticTextBox
            // 
            this.alphabeticTextBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.alphabeticTextBox.BackColor = System.Drawing.Color.Black;
            this.alphabeticTextBox.Font = new System.Drawing.Font ("Quartz", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.alphabeticTextBox.ForeColor = System.Drawing.Color.Red;
            this.alphabeticTextBox.Location = new System.Drawing.Point (0, 0);
            this.alphabeticTextBox.Name = "alphabeticTextBox";
            this.alphabeticTextBox.ReadOnly = true;
            this.alphabeticTextBox.Size = new System.Drawing.Size (300, 40);
            this.alphabeticTextBox.TabIndex = 2;
            this.alphabeticTextBox.Text = "Alphabetic";
            this.alphabeticTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Display
            // 
            this.Controls.Add (this.alphabeticTextBox);
            this.Controls.Add (this.numericTextBox);
            this.Controls.Add (this.instructionTextBox);
            this.Font = new System.Drawing.Font ("Quartz", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "Display";
            this.Size = new System.Drawing.Size (300, 40);
            this.Resize += new System.EventHandler (this.Display_Resize);
            this.ResumeLayout (false);

        }
        #endregion

        #endregion

        #region Event Handlers

        private void Display_Resize (object sender, System.EventArgs e)
        {
            if (Size.Height != height)
            {
                Size = new Size (Size.Width, height);
                ThreadSafe.SetSize (alphabeticTextBox, Size);
                ThreadSafe.SetSize (instructionTextBox, Size);
                ThreadSafe.SetSize (numericTextBox, Size);
            }
        }

        // This stuff is intended to prevent selection of the text.  It doesn't work 100% of the
        // time, but it's good enough in practice.  At any rate, setting the Value property clean
        // things up.

        private void textBox_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ThreadSafe.SetEnabled (alphabeticTextBox, false);
            ThreadSafe.SetEnabled (instructionTextBox, false);
            ThreadSafe.SetEnabled (numericTextBox, false);
        }

        private void textBox_MouseLeave (object sender, System.EventArgs e)
        {
            ThreadSafe.SetEnabled (alphabeticTextBox, true);
            ThreadSafe.SetEnabled (instructionTextBox, true);
            ThreadSafe.SetEnabled (numericTextBox, true);
        }

        public void ReadFromDataset (CardDataset cds, Reader reader)
        {
            CardDataset.CardRow cr;
            CardDataset.DisplayRow dr;
            CardDataset.DisplayRow [] drs;

            cr = cds.Card [0];
            drs = cr.GetDisplayRows ();
            if (drs.Length > 0)
            {
                dr = drs [0];
                Digits = dr.Digits;
                Format = (DisplayFormat) Enum.Parse (typeof (DisplayFormat), dr.Format);
            }
        }

        public void WriteToDataset (CardDataset cds, CardPart part)
        {
            if (part == CardPart.Program)
            {
                CardDataset.DisplayRow dr;

                for (int i = 0; i < cds.Display.Count; i++)
                {
                    cds.Display.RemoveDisplayRow (cds.Display [i]);
                }
                dr = cds.Display.NewDisplayRow ();
                dr.Digits = digits;
                dr.Format = format.ToString ();
                dr.CardRow = cds.Card [0];
                cds.Display.AddDisplayRow (dr);
            }
        }

        #endregion

        #region Private Properties

        private sbyte Exponent
        {
            get
            {
                string exponent = NumericText.Substring
                    (exponentSignFirst, exponentSignLength + exponentLength).Trim ();
                if (exponent.Length == 0)
                {
                    return 0;
                }
                else
                {
                    return sbyte.Parse (exponent);
                }
            }
            set
            {
                if (value == 0 && format == DisplayFormat.Fixed)
                {
                    NumericText =
                        NumericText.Substring (mantissaSignFirst, mantissaSignLength + mantissaLength) +
                        new String (' ', exponentSignLength + exponentLength);
                }
                else
                {
                    string exponent = value.ToString
                        (exponentTemplate, NumberFormatInfo.InvariantInfo);

                    NumericText =
                        NumericText.Substring (mantissaSignFirst, mantissaSignLength + mantissaLength) +
                        exponent;
                }
            }
        }

        private string NumericText
        {
            get
            {
                string s = ThreadSafe.GetText (numericTextBox);
                return s.PadRight (exponentFirst + exponentLength);
            }
            set
            {
                ThreadSafe.SetText (numericTextBox, value.PadRight (exponentFirst + exponentLength));
            }
        }

        #endregion

        #region Private Operations

        private void ReplaceExponentWithoutSign (string exponent)
        {
            string text = NumericText;

            NumericText = text.Substring
                (mantissaSignFirst, mantissaSignLength + mantissaLength + exponentSignLength) +
                exponent;
        }

        private void ReplaceExponentWithSign (string exponent)
        {
            string text = NumericText;

            NumericText = text.Substring (mantissaSignFirst, mantissaSignLength + mantissaLength) +
                exponent;
        }

        private void ReplaceExponentSign (char sign)
        {
            string text = NumericText;

            NumericText = text.Substring (mantissaSignFirst, mantissaSignLength + mantissaLength) +
                sign +
                text.Substring (exponentFirst, exponentLength);
        }

        private void ReplaceMantissaSign (char sign)
        {
            string text = NumericText;

            NumericText = sign + text.Substring
                (mantissaFirst, mantissaLength + exponentSignLength + exponentLength);
        }

        private void ReplaceMantissaWithoutSign (string mantissa)
        {
            string text = NumericText;

            NumericText = text.Substring (mantissaSignFirst, mantissaSignLength) +
                mantissa.PadRight (mantissaLength) +
                text.Substring (exponentSignFirst, exponentSignLength + exponentLength);
        }

        private void ReplaceMantissaWithSign (string mantissa)
        {
            string text = NumericText;

            NumericText = mantissa.PadRight (mantissaSignLength + mantissaLength) +
                text.Substring (exponentSignFirst, exponentSignLength + exponentLength);
        }

        private void SetMantissa (double to, bool fixedUnderflowOverflow)
        {
            string mantissa = "Useless initialization required by the compiler";

            switch (format)
            {
                case DisplayFormat.Engineering:
                    {
                        double absTo = Math.Abs (to);

                        if (absTo < 10.0)
                        {
                            mantissa = to.ToString
                                (engMantissaTemplate1, NumberFormatInfo.InvariantInfo);
                        }
                        else if (absTo < 100.0)
                        {
                            mantissa = to.ToString
                                (engMantissaTemplate10, NumberFormatInfo.InvariantInfo);
                        }
                        else
                        {
                            Trace.Assert (absTo < 1000.0);
                            mantissa = to.ToString
                                (engMantissaTemplate100, NumberFormatInfo.InvariantInfo);
                        }
                        break;
                    }
                case DisplayFormat.Fixed:
                    {
                        if (fixedUnderflowOverflow)
                        {
                            mantissa = to.ToString
                                (fixUnderflowOverflowMantissaTemplate, NumberFormatInfo.InvariantInfo);
                        }
                        else
                        {
                            mantissa = to.ToString
                                (fixMantissaTemplate, NumberFormatInfo.InvariantInfo);
                            mantissa = mantissa.Substring
                                (mantissaSignFirst, mantissaSignLength + mantissaLength);
                        };
                        break;
                    }
                case DisplayFormat.Scientific:
                    {
                        mantissa = to.ToString
                            (sciMantissaTemplate, NumberFormatInfo.InvariantInfo);
                        break;
                    }
            }

            ReplaceMantissaWithSign (mantissa);
            currentMantissa = to;
        }

        private void StartEnteringNumber ()
        {
            if (EnteringNumber != null)
            {
                // Notify whoever is interested that we are starting to enter a number.
                EnteringNumber (this);
            }
            enteringNumber = true;
            enteringMantissa = true;
            enteringExponent = false;
            hasAPeriod = false;
            ReplaceExponentWithSign (new String (' ', exponentSignLength + exponentLength));
        }

        #endregion

        #region Public Properties

        public byte Digits
        {
            set
            {
                string zeros;
                string blanks;

                Trace.Assert (value <= 9);
                digits = value;
                blanks = new String (' ', 9 - value);

                if (value == 0)
                {
                    // Make sure that we don't lose the period when the count is 0.
                    fixMantissaTemplate = " 0\\." + blanks + ";-0\\." + blanks;
                }
                else
                {
                    zeros = new String ('0', value);
                    fixMantissaTemplate = " 0." + zeros + blanks + ";-0." + zeros + blanks;
                }

                // Engineering is weird because the Digits is the total number of digits
                // displayed minus 1, regardless of the position of the decimal point.  Produce
                // three templates corresponding to the three orders of magnitude of the mantissa
                // in this format.
                if (value <= 1)
                {
                    engMantissaTemplate10 = " 00\\." + blanks + ";-00\\." + blanks;
                }
                else
                {
                    zeros = new String ('0', value - 1);
                    engMantissaTemplate10 = " 00." + zeros + blanks + ";-00." + zeros + blanks;
                }

                if (value <= 2)
                {
                    engMantissaTemplate100 = " 000\\." + blanks + ";-000\\." + blanks;
                }
                else
                {
                    zeros = new String ('0', value - 2);
                    engMantissaTemplate100 = " 000." + zeros + blanks + ";-000." + zeros + blanks;
                }

                engMantissaTemplate1 = fixMantissaTemplate;
                sciMantissaTemplate = fixMantissaTemplate;
                Value = Value;
            }
        }

        public override Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
                height = (int) (font.SizeInPoints * heightFactor);
                ThreadSafe.SetFont (alphabeticTextBox, font);
                ThreadSafe.SetFont (instructionTextBox, font);
                ThreadSafe.SetFont (numericTextBox, font);
                Size = new Size (Size.Width, height);
            }
        }

        public DisplayFormat Format
        {
            set
            {
                format = value;
                Value = Value;
            }
        }

        public bool IsBlurred
        {
            get
            {
                return isBlurred;
            }
        }

        public DisplayMode Mode
        {
            set
            {
                if (mode != value)
                {
                    mode = value;
                    switch (mode)
                    {
                        case DisplayMode.Alphabetic:
                            ThreadSafe.BringToFront (alphabeticTextBox);
                            break;
                        case DisplayMode.Instruction:
                            ThreadSafe.BringToFront (instructionTextBox);
                            break;
                        case DisplayMode.Numeric:
                            ThreadSafe.BringToFront (numericTextBox);
                            break;
                    }
                }
                isBlurred = false;
            }
        }

        public double Value
        {
            get
            {
                // In normal operation, calling value terminates the operation of entering a
                // number.  However, if we are debugging the control, we want the termination to
                // happen explicitly.  This introduces some coupling, but that's managed through
                // the configuration file.
                if (!userControlTesting)
                {
                    DoneEntering ();
                }

                if (overflows)
                {
                    return overflowValue;
                }
                else
                {
                    return currentMantissa * Math.Pow (10, Exponent);
                }
            }
            set
            {
                double absValue = Math.Abs (value);
                sbyte exponent;
                bool fixedUnderflowOverflow;
                double log10;
                double mantissa;

                DoneEntering ();

                // Not needed, unless the event handling mucked things up...
                ThreadSafe.SetEnabled (numericTextBox, true);

                // Deal with possible underflow or overflow.
                overflows = false;
                if (absValue > overflowLimit)
                {
                    if (value > 0.0)
                    {
                        NumericText = positiveOverflow;
                        overflowValue = double.PositiveInfinity;
                    }
                    else
                    {
                        NumericText = negativeOverflow;
                        overflowValue = double.NegativeInfinity;
                    }
                    overflows = true;
                    return;
                }

                if (absValue < underflowLimit)
                {
                    exponent = 0;
                    value = 0;
                }
                else
                {

                    // Compute the exponent in base 10, so that the mantissa has one digit before
                    // the decimal point.
                    log10 = Math.Log10 (absValue);
                    if (log10 >= 0.0)
                    {
                        exponent = (sbyte) Math.Floor (log10);
                    }
                    else
                    {
                        exponent = (sbyte) (-Math.Ceiling (-log10));
                    }
                }

                // Adjust the computed exponent based on the display format, and determine if the
                // fixed format underflows or overflows.
                fixedUnderflowOverflow = false;
                switch (format)
                {
                    case DisplayFormat.Engineering:
                        {
                            if (exponent % 3 != 0)
                            {
                                exponent = (sbyte) (exponent - (exponent % 3) - (exponent >= 0 ? 0 : 3));
                            }
                            break;
                        }
                    case DisplayFormat.Fixed:
                        {
                            if (exponent < -digits - 1 || exponent > 9)
                            {
                                fixedUnderflowOverflow = true;
                            }
                            else if (exponent == -digits - 1)
                            {
                                // A subtlety here.  If digits is, say, 2, the values �0.005 round to
                                // �0.01, but the values �0.004 underflow.
                                if (absValue < 0.5 * Math.Pow (10, -digits))
                                {
                                    fixedUnderflowOverflow = true;
                                }
                            }
                            if (!fixedUnderflowOverflow)
                            {
                                exponent = 0;
                            }
                            break;
                        }
                    case DisplayFormat.Scientific:
                        {
                            break;
                        }
                }

                // Display the appropriate exponent and mantissa using the current digit format and 
                // count.
                Exponent = exponent;
                mantissa = value / Math.Pow (10, exponent);
                SetMantissa (mantissa, fixedUnderflowOverflow);
            }
        }

        #endregion

        #region Public Operations

        public void ChangeSign (out bool done)
        {
            char sign;

            // Apologies: this is not ideal.  The CHS key can be used either (1) when entering a
            // number, in the mantissa or the exponent or (2) when a number has been entered, as
            // a normal transformation.  This method is only concerned with entering numbers, so
            // if it detects that we are not entering a number it sets done to false to indicate
            // that it didn't do its duty.  Clients will have to cope.
            if (enteringNumber)
            {
                if (enteringMantissa)
                {
                    sign = NumericText.Substring (mantissaSignFirst, mantissaSignLength) [0];
                }
                else
                {
                    Trace.Assert (enteringExponent);
                    sign = NumericText.Substring (exponentSignFirst, exponentSignLength) [0];
                }
                switch (sign)
                {
                    case ' ':
                        sign = '-';
                        break;
                    case '-':
                        sign = ' ';
                        break;
                    default:
                        Trace.Assert (false);
                        break;
                }
                if (enteringMantissa)
                {
                    currentMantissa = -currentMantissa;
                    ReplaceMantissaSign (sign);
                }
                else
                {
                    Trace.Assert (enteringExponent);
                    ReplaceExponentSign (sign);
                }
                done = true;
            }
            else
            {
                done = false;
            }
        }

        public void DoneEntering ()
        {
            if (enteringNumber)
            {
                enteringNumber = false;
                Value = Value;
            }
        }

        public void EnterDigit (byte b)
        {
            string d = b.ToString ().Trim ();
            string exponent;
            string mantissa;

            if (enteringNumber && enteringExponent)
            {
                exponent = NumericText.Substring
                    (exponentSignFirst + exponentSignLength, exponentLength).Trim ();
                if (exponent.Length == exponentLength)
                {
                    exponent = exponent.Substring (1, exponentLength - 1) + d;
                }
                else
                {
                    exponent += d;
                }
                ReplaceExponentWithoutSign (exponent);
            }
            else
            {
                if (!enteringNumber)
                {
                    StartEnteringNumber ();
                    mantissa = " " + d + period;
                }
                else
                {
                    Trace.Assert (enteringMantissa);
                    mantissa = NumericText.Substring
                        (mantissaSignFirst, mantissaSignLength + mantissaLength).TrimEnd (null);
                    if (mantissa.Length == mantissaSignLength + mantissaLength)
                    {
                        // Extraneous digits are simply ignored.
                        return;
                    }
                    if (hasAPeriod)
                    {
                        mantissa += d;
                    }
                    else
                    {
                        Trace.Assert (mantissa [mantissa.Length - 1] == period [0]);
                        mantissa = mantissa.Substring (0, mantissa.Length - 1) + d + period;
                    }
                }
                currentMantissa = double.Parse (mantissa, NumberFormatInfo.InvariantInfo);
                ReplaceMantissaWithSign (mantissa);
            }
        }

        public void EnterExponent ()
        {
            if (!enteringNumber)
            {
                EnterDigit (1);
                EnterPeriod ();
            }
            Trace.Assert (enteringNumber);
            if (!enteringExponent)
            {
                const byte exponent = 0;

                enteringMantissa = false;
                enteringExponent = true;
                ReplaceExponentWithSign (exponent.ToString
                    (exponentTemplate, NumberFormatInfo.InvariantInfo));
            }
        }

        public void EnterPeriod ()
        {
            if (!enteringNumber)
            {
                StartEnteringNumber ();
                ReplaceMantissaWithSign (" " + period);
            }
            hasAPeriod = true;
        }

        public void Pause (int ms)
        {
            ThreadSafe.Update (this);
            Thread.Sleep (ms);
        }

        public void PauseAndAcceptKeystrokes (int ms)
        {
            Mode = DisplayMode.Numeric;
            ThreadSafe.Update (this);
            while (WaitForKeystroke != null & WaitForKeystroke (ms))
            {
                if (AcceptKeystroke != null)
                {
                    AcceptKeystroke ();
                }
                ThreadSafe.Update (this);
            }
            if (CompleteKeystrokes != null)
            {
                CompleteKeystrokes ();
            }
        }

        public void PauseAndBlink (int ms)
        {
            int interval = ms / 16;
            string period = NumberFormatInfo.InvariantInfo.NumberDecimalSeparator;
            string textWithPeriod = NumericText;
            string textWithoutPeriod =
                textWithPeriod.Replace (period, new String (' ', period.Length));
            string [] texts = new String [] { textWithoutPeriod, textWithPeriod };

            Mode = DisplayMode.Numeric;
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        NumericText = texts [j];
                        ThreadSafe.Update (this);

                        // Most of the time the following call will just be equivalent to
                        // Thread.Sleep.  However, typing a key during PauseAndBlink causes the
                        // current computation to stop.  We detect this by calling WaitForKeystroke.
                        if (WaitForKeystroke != null && WaitForKeystroke (interval))
                        {
                            throw new Interrupt ();
                        }
                    }
                }
            }
            finally
            {
                // Restore the original text here to protect against exceptions.
                NumericText = textWithPeriod;
            }
        }

        public void Round ()
        {
            string text = NumericText;

            currentMantissa =
                double.Parse (
                    text.Substring (mantissaSignFirst, mantissaSignLength + mantissaLength),
                    NumberFormatInfo.InvariantInfo);
        }

        public void ShowBlur ()
        {
            byte [] b = new byte [mantissaSignLength + mantissaLength +
                                    exponentSignLength + exponentLength];
            char [] c = new char [mantissaSignLength + mantissaLength +
                                    exponentSignLength + exponentLength];
            int i;

            Mode = DisplayMode.Alphabetic;
            isBlurred = true;
            random.NextBytes (b);
            i = 0;
            while (i < mantissaSignLength)
            {
                c [i] = randomSign [b [i] % 2];
                i++;
            }
            while (i < mantissaSignLength + mantissaLength)
            {
                c [i] = randomChars [b [i] % 16];
                i++;
            }
            while (i < mantissaSignLength + mantissaLength + exponentSignLength)
            {
                c [i] = randomSign [b [i] % 2];
                i++;
            }
            while (i < mantissaSignLength + mantissaLength + exponentSignLength + exponentLength)
            {
                c [i] = randomChars [b [i] % 16];
                i++;
            }
            ThreadSafe.SetText (alphabeticTextBox, new string (c));
        }

        public void ShowInstruction (string instruction, int step, bool setMode)
        {
            string stepImage = step.ToString
                (stepTemplate, NumberFormatInfo.InvariantInfo);

            if (setMode)
            {
                Mode = DisplayMode.Instruction;
            }
            ThreadSafe.SetText (instructionTextBox,
                new string (' ', mantissaSignLength) +
                stepImage + instruction.PadLeft (instructionLength));
        }

        public void ShowMemory (int address, double register, int ms)
        {
            string addressImage = address.ToString ();
            double savedValue = Value;

            Mode = DisplayMode.Numeric;
            try
            {
                ThreadSafe.SetText (numericTextBox,
                    addressImage.PadLeft
                    (mantissaSignLength + mantissaLength + exponentSignLength + exponentLength));
                ThreadSafe.Update (this);
                Thread.Sleep (ms);
                Value = register;
                ThreadSafe.Update (this);
                Thread.Sleep (ms);
            }
            finally
            {
                // Restore the value here to protect against exceptions.
                Value = savedValue;
            }
        }

        public void ShowText (string text, int msOn, int msOff)
        {
            string s = new string (' ', mantissaSignLength) +
                        text.PadRight (textLength - mantissaSignLength);

            Mode = DisplayMode.Alphabetic;
            if (msOn > 0)
            {
                ThreadSafe.SetText (alphabeticTextBox, s);
                ThreadSafe.Update (this);
                Thread.Sleep (msOn);
            }
            if (msOff > 0)
            {
                ThreadSafe.SetText (alphabeticTextBox, "");
                ThreadSafe.Update (this);
                Thread.Sleep (msOff);
            }
            ThreadSafe.SetText (alphabeticTextBox, s);
        }

        #endregion

    }
}
