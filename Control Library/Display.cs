using Mockingbird.HP.Class_Library;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Control_Library
{
    public enum DisplayMode
    {
        Alphabetic,
        Instruction,
        Numeric
    }

    /// <summary>
    /// The LED display for an HP calculator.
    /// </summary>
    public class Display : UserControl, Class_Library.IDisplay
    {
        #region Private Data

        private const double heightFactor = 1.85;

        private const string mantissaSignPlaceholder = " "; // Must have length mantissaSignLength.
        private const string mantissaExponentSeparator = "";
        private const string stepTemplate = " 000";

        private const int instructionFirst = 3;
        private const int instructionLength = 11;
        private const int fullLength = 15;

        private static char period = NumberFormatInfo.InvariantInfo.NumberDecimalSeparator [0];

        private System.Windows.Forms.TextBox alphabeticTextBox;
        private System.Windows.Forms.TextBox instructionTextBox;
        private System.Windows.Forms.TextBox numericTextBox;

        private Font font;
        private int height;
        private bool inScaleControl = false;
        private bool isBlurred;
        private DisplayMode mode;
        private Random random;

        private Number.Formatter formatter;
        private Number.Formatter randomFormatter;

        public event ImmediateKeystrokeEvent AcceptKeystroke;
        public event ImmediateKeystrokeEvent CompleteKeystrokes;
        public event TimedKeystrokeEvent WaitForKeystroke;

        #endregion

        #region Event Handlers

        public delegate void DisplayStateChangeEvent (object sender);
        public delegate void ImmediateKeystrokeEvent ();
        public delegate bool TimedKeystrokeEvent (int ms);

        #endregion

        #region Constructors & Destructors

        public Display ()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent ();

            random = new Random ();
            randomFormatter = new Number.Formatter (9, Number.DisplayFormat.Scientific);

            // Make the control non-selectable, otherwise the application will select its
            // text at startup.
            SetStyle (ControlStyles.Selectable, false);
            UpdateStyles ();

            Mode = DisplayMode.Numeric;

            randomFormatter.FormattingChanged += new Number.ChangeEvent (ShowText);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose (bool disposing)
        {
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code
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
            this.ResumeLayout (false);

        }

        #endregion

        #endregion

        #region Event Handlers

        private void ShowNumeric (string mantissa, string exponent, double value)
        {
            ThreadSafe.SetText (numericTextBox, mantissa + mantissaExponentSeparator + exponent);
        }

        private void ShowText (string mantissa, string exponent, double value)
        {
            ThreadSafe.SetText (alphabeticTextBox, mantissa + mantissaExponentSeparator + exponent);
        }

        #endregion

        #region Overriding Operations

        protected override void OnResize (EventArgs e)
        {
            base.OnResize (e);

            if (inScaleControl)
            {

                // The control is being scaled to adapt to the display resolution.  Do as we are
                // told.
            }
            else if (Size.Height != height)
            {

                // We are willing to change the width of the display, but not its height which is
                // determined by the font size.
                Size = new Size (Size.Width, height);
                ThreadSafe.SetSize (alphabeticTextBox, Size);
                ThreadSafe.SetSize (instructionTextBox, Size);
                ThreadSafe.SetSize (numericTextBox, Size);
            }
        }

        protected override void ScaleControl (SizeF factor, BoundsSpecified specified)
        {
            inScaleControl = true;
            base.ScaleControl (factor, specified);
            inScaleControl = false;
        }

        #endregion

        #region Public Properties

        public override Font Font
        {
            set
            {
                //ThreadSafe.SetFont (base, value);
                base.Font = value;
                font = value;
                ThreadSafe.SetFont (alphabeticTextBox, font);
                ThreadSafe.SetFont (instructionTextBox, font);
                ThreadSafe.SetFont (numericTextBox, font);
                height = (int) (font.SizeInPoints * heightFactor);
                Size = new Size (Size.Width, height);
            }
        }

        public Number.Formatter Formatter
        {
            set
            {
                formatter = value;
                formatter.FormattingChanged += new Number.ChangeEvent (ShowNumeric);
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

        #endregion

        #region Public Operations

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
            string textWithPeriod = ThreadSafe.GetText (numericTextBox);
            string textWithoutPeriod = textWithPeriod.Replace (period, ' ');
            string [] texts = new String [] { textWithoutPeriod, textWithPeriod };

            Mode = DisplayMode.Numeric;
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        ThreadSafe.SetText (numericTextBox, texts [j]);
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
                ThreadSafe.SetText (numericTextBox, textWithPeriod);
            }
        }

        public void ShowBlur ()
        {
            double r = 2.0 * random.NextDouble () - 1.0;

            Mode = DisplayMode.Alphabetic;
            isBlurred = true;
            randomFormatter.Value = r;
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
                stepImage + instruction.PadLeft (instructionLength));
        }

        public void ShowMemory (int address, double register, int ms)
        {
            string addressImage = address.ToString ();
            string numericText = ThreadSafe.GetText (numericTextBox);

            Mode = DisplayMode.Numeric;
            try
            {
                ThreadSafe.SetText (numericTextBox, addressImage.PadLeft (fullLength));
                ThreadSafe.Update (this);
                Thread.Sleep (ms);
                formatter.Value = register;
                ThreadSafe.Update (this);
                Thread.Sleep (ms);
            }
            finally
            {
                // Restore the value here to protect against exceptions.
                ThreadSafe.SetText (numericTextBox, numericText);
            }
        }

        public void ShowNumeric (string mantissa, string exponent)
        {
            ThreadSafe.SetText (numericTextBox, mantissa + mantissaExponentSeparator + exponent);
        }

        public void ShowText (string text, int msOn, int msOff)
        {
            string s = mantissaSignPlaceholder + text;

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
