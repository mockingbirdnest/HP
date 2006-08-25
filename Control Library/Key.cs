using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Mockingbird.HP.Control_Library
{
    public enum TextAlign
    {
        Centered,
        Justified
    }

    /// <summary>
    /// A Key on the keyboard of an HP calculator.
    /// </summary>
    public class Key : UserControl
    {

        #region Private Data

        private const double brightnessReduction = 0.78;
        private const float sizeReduction = 0.85F;

        private Color fgBackColor;
        private TextAlign fgTextAlign;
        private int fgWidth;
        private Font font;
        private bool inAdjustSize = false;
        private Keys [] shortcuts;
        private Color mainBackColor;
        private int mainHeight;
        private int mainWidth;

        internal System.Windows.Forms.Label gLabel;
        internal System.Windows.Forms.Label fLabel;
        internal System.Windows.Forms.Button button;
        internal System.Windows.Forms.Button hButton;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Event Definitions

        public delegate void KeystrokeEvent (object sender, System.Windows.Forms.MouseEventArgs e);
        public event KeystrokeEvent LeftMouseDown;
        public event KeystrokeEvent LeftMouseUp;

        #endregion

        #region Constructors & Destructors

        public Key ()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent ();

            fgTextAlign = TextAlign.Justified;
            fgWidth = button.Size.Width;
            shortcuts = new Keys [0];
            mainHeight = button.Height;
            mainWidth = button.Width;

            FText = "f";
            GText = "g";
            HText = "h";
            MainText = "key";

            FGTextAlign = TextAlign.Centered;
            HTextAlign = ContentAlignment.MiddleCenter;

            FGBackColor = Color.FromArgb (64, 64, 64);
            MainBackColor = Color.FromKnownColor
                (KnownColor.Olive);
            fLabel.ForeColor = Color.FromKnownColor
                (KnownColor.Gold);
            gLabel.ForeColor = Color.FromKnownColor
                (KnownColor.SkyBlue);

            AdjustSize ();
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
            this.gLabel = new System.Windows.Forms.Label ();
            this.fLabel = new System.Windows.Forms.Label ();
            this.button = new System.Windows.Forms.Button ();
            this.hButton = new System.Windows.Forms.Button ();
            this.SuspendLayout ();
            // 
            // gLabel
            // 
            this.gLabel.BackColor = System.Drawing.Color.Transparent;
            this.gLabel.Font = new System.Drawing.Font ("Arial Unicode MS", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.gLabel.ForeColor = System.Drawing.Color.SkyBlue;
            this.gLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gLabel.Location = new System.Drawing.Point (75, 86);
            this.gLabel.Name = "gLabel";
            this.gLabel.Size = new System.Drawing.Size (24, 15);
            this.gLabel.TabIndex = 4;
            this.gLabel.Text = "g";
            // 
            // fLabel
            // 
            this.fLabel.BackColor = System.Drawing.Color.Transparent;
            this.fLabel.Font = new System.Drawing.Font ("Arial Unicode MS", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.fLabel.ForeColor = System.Drawing.Color.Gold;
            this.fLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fLabel.Location = new System.Drawing.Point (51, 86);
            this.fLabel.Name = "fLabel";
            this.fLabel.Size = new System.Drawing.Size (24, 15);
            this.fLabel.TabIndex = 3;
            this.fLabel.Text = "f";
            this.fLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.Olive;
            this.button.Font = new System.Drawing.Font ("Arial Unicode MS", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button.ForeColor = System.Drawing.Color.White;
            this.button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button.Location = new System.Drawing.Point (51, 50);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size (48, 24);
            this.button.TabIndex = 1;
            this.button.Tag = "34";
            this.button.Text = "key";
            this.button.UseVisualStyleBackColor = false;
            this.button.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler (this.button_PreviewKeyDown);
            this.button.MouseDown += new System.Windows.Forms.MouseEventHandler (this.button_MouseDown);
            this.button.MouseUp += new System.Windows.Forms.MouseEventHandler (this.button_MouseUp);
            // 
            // hButton
            // 
            this.hButton.BackColor = System.Drawing.Color.Olive;
            this.hButton.Font = new System.Drawing.Font ("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.hButton.Location = new System.Drawing.Point (51, 71);
            this.hButton.Name = "hButton";
            this.hButton.Size = new System.Drawing.Size (48, 18);
            this.hButton.TabIndex = 2;
            this.hButton.Text = "h";
            this.hButton.UseVisualStyleBackColor = false;
            this.hButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler (this.hButton_PreviewKeyDown);
            this.hButton.MouseDown += new System.Windows.Forms.MouseEventHandler (this.hButton_MouseDown);
            this.hButton.MouseUp += new System.Windows.Forms.MouseEventHandler (this.hButton_MouseUp);
            // 
            // Key
            // 
            this.Controls.Add (this.gLabel);
            this.Controls.Add (this.fLabel);
            this.Controls.Add (this.button);
            this.Controls.Add (this.hButton);
            this.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Name = "Key";
            this.ResumeLayout (false);

        }
        #endregion

        #endregion

        #region Event Handlers

        private void hButton_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                button_MouseDown (sender, e);
            }
        }

        private void hButton_MouseUp (object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                button_MouseUp (sender, e);
            }
        }

        private void hButton_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void button_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                hButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                if (LeftMouseDown != null)
                {
                    LeftMouseDown (this, e);
                }
            }
        }

        private void button_MouseUp (object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                hButton.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                if (LeftMouseUp != null)
                {
                    LeftMouseUp (this, e);
                }
            }
        }

        private void button_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        #endregion

        #region Private Properties

        private bool HasG
        {
            get
            {
                return gLabel.Text != "";
            }
        }

        #endregion

        #region Private & Protected Methods

        private void AdjustSize ()
        {

            // Adjust the size of the control to maintain the invariant that the component controls
            // "just touch" the border.  This only happens when some specific property of the
            // control (e.g., MainHeight) is changed.  It doesn't affect the height of the hButton
            // or of the labels.
            int x = Math.Min (button.Location.X, fLabel.Location.X);
            int y = button.Location.Y;

            button.Location = new Point (button.Location.X - x, button.Location.Y - y);
            hButton.Location = new Point (hButton.Location.X - x, hButton.Location.Y - y);
            fLabel.Location = new Point (fLabel.Location.X - x, fLabel.Location.Y - y);
            gLabel.Location = new Point (gLabel.Location.X - x, gLabel.Location.Y - y);

            inAdjustSize = true;
            Size = new Size (Math.Max (fgWidth, mainWidth),
                            fLabel.Location.Y + fLabel.Size.Height);
            inAdjustSize = false;

            Trace.Assert (button.Location.Y == 0);
            Trace.Assert (button.Size.Width == hButton.Size.Width);
            Trace.Assert (fLabel.Location.X == 0);
            Trace.Assert (fLabel.Size.Width == gLabel.Location.X);
            Trace.Assert (fLabel.Location.Y == gLabel.Location.Y);
            Trace.Assert (gLabel.Location.X + gLabel.Size.Width == Size.Width);
        }

        private void CenterFG ()
        {
            float ΔWidth = gLabel.CreateGraphics ().
                                MeasureString (gLabel.Text, gLabel.Font).Width -
                           fLabel.CreateGraphics ().
                                MeasureString (fLabel.Text, fLabel.Font).Width;
            int spacing = gLabel.Location.X - (fLabel.Location.X + fLabel.Size.Width);

            Trace.Assert (spacing == 0);
            if (HasG)
            {

                // Adjust the widths so as to center the text.
                fLabel.Size = new Size
                    ((int) (((float) fgWidth - ΔWidth - (float) spacing) / 2.0),
                     fLabel.Size.Height);
                gLabel.Size = new Size
                    (fgWidth - fLabel.Size.Width - spacing,
                     gLabel.Size.Height);
                gLabel.Location = new Point
                    (fLabel.Location.X + fgWidth - gLabel.Size.Width,
                     gLabel.Location.Y);

                // Now set the alignments.
                fLabel.TextAlign = ContentAlignment.TopRight;
                gLabel.TextAlign = ContentAlignment.TopLeft;
            }
            else
            {
                fLabel.TextAlign = ContentAlignment.TopCenter;
            }
        }

        private void JustifyFG ()
        {
            int spacing = gLabel.Location.X - (fLabel.Location.X + fLabel.Size.Width);

            Trace.Assert (spacing == 0);
            if (HasG)
            {

                // Make sure the two labels have the same width.
                fLabel.Size = new Size
                    ((fgWidth - spacing) / 2,
                     fLabel.Size.Height);
                gLabel.Size = new Size
                    (fgWidth - fLabel.Size.Width - spacing,
                     gLabel.Size.Height);
                gLabel.Location = new Point
                    (fLabel.Location.X + fgWidth - gLabel.Size.Width,
                     gLabel.Location.Y);

                // Now set the alignments.
                fLabel.TextAlign = ContentAlignment.TopLeft;
                gLabel.TextAlign = ContentAlignment.TopRight;
            }
            else
            {
                fLabel.TextAlign = ContentAlignment.TopCenter;
            }
        }

        protected override void OnResize (EventArgs e)
        {
            // Note that the forms have a non-default AutoScaleMode, so we use the .Net 2.0 scaling
            // system, and therefore we never land here when scaling.
            base.OnResize (e);

            int oldWidth = Math.Max (fgWidth, mainWidth);
            int oldHeight = fLabel.Location.Y + fLabel.Size.Height;

            if (inAdjustSize)
            {

                // We may land here when called from Adjust size, but then we expect the new size
                // to be "just what we want".
                Debug.Assert (oldWidth == Size.Width && oldHeight == Size.Height);
            }
            else if (oldWidth != Size.Width || oldHeight != Size.Height)
            {
                // Otherwise, it means that someone is trying to resize the control, and that's a
                // no-no: you have to change the properties to make this happen.
                Size = new Size (oldWidth, oldHeight);
            }
        }

        #endregion

        #region Public Properties

        public Color FGBackColor
        {
            get
            {
                return fgBackColor;
            }
            set
            {
                fgBackColor = value;
                fLabel.BackColor = fgBackColor;
                gLabel.BackColor = fgBackColor;
            }
        }

        public TextAlign FGTextAlign
        {
            get
            {
                return fgTextAlign;
            }
            set
            {
                if (value != fgTextAlign)
                {
                    fgTextAlign = value;
                    switch (value)
                    {
                        case TextAlign.Centered:
                            {
                                CenterFG ();
                                break;
                            }
                        case TextAlign.Justified:
                            {
                                JustifyFG ();
                                break;
                            }
                    }
                }
            }
        }

        public int FGWidth
        {
            get
            {
                return fgWidth;
            }
            set
            {
                // Don't allow it to get too narrow, or the bottom of hButton will show.
                value = Math.Max (value, mainWidth);

                int ΔWidth = value - fgWidth;

                fgWidth = value;
                fLabel.Location = new Point (fLabel.Location.X - ΔWidth / 2,
                                                            fLabel.Location.Y);
                if (HasG)
                {
                    fLabel.Size = new Size (fLabel.Size.Width + ΔWidth / 2,
                                                           fLabel.Size.Height);
                    gLabel.Size = new Size (gLabel.Size.Width + ΔWidth / 2,
                                                        gLabel.Size.Height);
                }
                else
                {
                    gLabel.Location = new Point (gLabel.Location.X + ΔWidth / 2,
                                                gLabel.Location.Y);
                    fLabel.Size = new Size (fLabel.Size.Width + ΔWidth,
                                                           fLabel.Size.Height);
                }

                AdjustSize ();
            }
        }

        public override Font Font
        {
            set
            {
                Font smallFont;

                base.Font = value;
                font = value;
                smallFont = new Font (font.Name,
                                        font.SizeInPoints * sizeReduction,
                                        font.Style);
                button.Font = font;
                fLabel.Font = smallFont;
                gLabel.Font = smallFont;
                hButton.Font = smallFont;
            }
        }

        public string FText
        {
            get
            {
                return fLabel.Text;
            }
            set
            {
                if (value == "")
                {

                    // Clearing the F label also clears the G label by default.
                    GText = "";
                }
                fLabel.Text = value;
                if (fgTextAlign == TextAlign.Centered)
                {
                    CenterFG ();
                }
            }
        }

        public string GText
        {
            get
            {
                return gLabel.Text;
            }
            set
            {
                if (HasG && (value == ""))
                {
                    // Widen the F label and hide the G label.
                    gLabel.Text = value;
                    fLabel.Size = new Size (fgWidth,
                                                           gLabel.Size.Height);
                    gLabel.Location = new Point (fLabel.Location.X + fgWidth,
                                                                gLabel.Location.Y);
                    gLabel.Size = new Size (0, gLabel.Size.Height);
                    fLabel.TextAlign = ContentAlignment.TopCenter;
                    gLabel.Visible = false;
                }
                else if (!HasG && (value != ""))
                {
                    gLabel.Text = value;
                    switch (fgTextAlign)
                    {
                        case TextAlign.Centered:
                            {
                                CenterFG ();
                                break;
                            }
                        case TextAlign.Justified:
                            {
                                JustifyFG ();
                                break;
                            }
                    }
                    fLabel.TextAlign = ContentAlignment.TopRight; // Is that correct?
                    gLabel.Visible = true;
                }
                gLabel.Text = value;
                if (fgTextAlign == TextAlign.Centered)
                {
                    CenterFG ();
                }
            }
        }

        public string HText
        {
            get
            {
                return hButton.Text;
            }
            set
            {
                hButton.Text = value;
            }
        }

        public ContentAlignment HTextAlign
        {
            get
            {
                return hButton.TextAlign;
            }
            set
            {
                hButton.TextAlign = value;
            }
        }

        public Color MainBackColor
        {
            get
            {
                return mainBackColor;
            }
            set
            {
                mainBackColor = value;
                button.BackColor = mainBackColor;
                hButton.BackColor = Color.FromArgb
                    ((int) ((double) mainBackColor.R * brightnessReduction),
                    (int) ((double) mainBackColor.G * brightnessReduction),
                    (int) ((double) mainBackColor.B * brightnessReduction));
            }
        }

        public Color MainForeColor
        {
            get
            {
                return button.ForeColor;
            }
            set
            {
                button.ForeColor = value;
            }
        }

        public int MainHeight
        {
            get
            {
                return mainHeight;
            }
            set
            {
                int ΔHeight = value - mainHeight;

                mainHeight = value;
                button.Size = new Size (button.Size.Width, mainHeight);
                button.Location = new Point (button.Location.X, button.Location.Y - ΔHeight);
                AdjustSize ();
            }
        }

        public string MainText // Would love to call it Text, but that confuses PropertyGrid.
        {
            get
            {
                return button.Text;
            }
            set
            {
                button.Text = value;
            }
        }

        public int MainWidth
        {
            get
            {
                return mainWidth;
            }
            set
            {
                int ΔWidth = value - mainWidth;

                mainWidth = value;
                button.Size = new Size (mainWidth, button.Size.Height);
                button.Location = new Point (button.Location.X - ΔWidth / 2,
                    button.Location.Y);
                hButton.Size = new Size (mainWidth, hButton.Size.Height);
                hButton.Location = new Point (hButton.Location.X - ΔWidth / 2,
                    hButton.Location.Y);

                if (fgWidth < mainWidth)
                {
                    FGWidth = mainWidth;
                }

                AdjustSize ();
            }
        }

        public Keys [] Shortcuts
        {
            get
            {
                return shortcuts;
            }
            set
            {
                shortcuts = value;
            }
        }

        #endregion

    }
}
