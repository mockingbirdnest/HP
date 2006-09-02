using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Mockingbird.HP.Control_Library
{
    public enum TogglePosition
    {
        Left,
        Center,
        Right
    }

    /// <summary>
    /// Sliding switch to toggle between modes of an HP calculator.
    /// </summary>
    public class Toggle : System.Windows.Forms.UserControl
    {

        #region Private Data

        private const int marginWidth = 2;
        private const double reductionFactor = 0.4;

        private System.Drawing.Color backColor;
        private System.Drawing.Font font;
        private System.Drawing.Color foreColor;
        private bool isBinary;
        private TogglePosition position;
        private bool userControlTesting;

        private bool mouseDown = false;
        private bool mouseHasDragged;

        internal Button button;
        internal Label rightLabel;
        internal Label centerLabel;
        internal Label leftLabel;
        internal Panel panel;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Event Definitions

        public delegate void ToggleEvent (object sender, TogglePosition position);
        public event ToggleEvent ToggleMoved;

        #endregion

        #region Constructors & Destructors

        public Toggle ()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent ();

            isBinary = false;
            position = TogglePosition.Left;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (Toggle));
            this.button = new System.Windows.Forms.Button ();
            this.rightLabel = new System.Windows.Forms.Label ();
            this.leftLabel = new System.Windows.Forms.Label ();
            this.panel = new System.Windows.Forms.Panel ();
            this.centerLabel = new System.Windows.Forms.Label ();
            this.SuspendLayout ();
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (50)))), ((int) (((byte) (50)))), ((int) (((byte) (50)))));
            this.button.BackgroundImage = ((System.Drawing.Image) (resources.GetObject ("button.BackgroundImage")));
            this.button.Location = new System.Drawing.Point (58, 20);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size (24, 8);
            this.button.TabIndex = 5;
            this.button.UseVisualStyleBackColor = false;
            this.button.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler (this.button_PreviewKeyDown);
            this.button.Click += new System.EventHandler (this.button_Click);
            this.button.MouseDown += new System.Windows.Forms.MouseEventHandler (this.button_MouseDown);
            this.button.MouseMove += new System.Windows.Forms.MouseEventHandler (this.button_MouseMove);
            this.button.MouseUp += new System.Windows.Forms.MouseEventHandler (this.button_MouseUp);
            // 
            // rightLabel
            // 
            this.rightLabel.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.rightLabel.Font = new System.Drawing.Font ("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rightLabel.ForeColor = System.Drawing.Color.White;
            this.rightLabel.Location = new System.Drawing.Point (120, 16);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size (56, 16);
            this.rightLabel.TabIndex = 4;
            this.rightLabel.Text = "right";
            this.rightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leftLabel
            // 
            this.leftLabel.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.leftLabel.Font = new System.Drawing.Font ("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.leftLabel.ForeColor = System.Drawing.Color.White;
            this.leftLabel.Location = new System.Drawing.Point (0, 16);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size (56, 16);
            this.leftLabel.TabIndex = 1;
            this.leftLabel.Text = "left";
            this.leftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Black;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Location = new System.Drawing.Point (56, 18);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size (64, 12);
            this.panel.TabIndex = 6;
            // 
            // centerLabel
            // 
            this.centerLabel.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.centerLabel.Font = new System.Drawing.Font ("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.centerLabel.ForeColor = System.Drawing.Color.White;
            this.centerLabel.Location = new System.Drawing.Point (56, 0);
            this.centerLabel.Name = "centerLabel";
            this.centerLabel.Size = new System.Drawing.Size (64, 16);
            this.centerLabel.TabIndex = 7;
            this.centerLabel.Text = "center";
            this.centerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Toggle
            // 
            this.Controls.Add (this.centerLabel);
            this.Controls.Add (this.button);
            this.Controls.Add (this.rightLabel);
            this.Controls.Add (this.leftLabel);
            this.Controls.Add (this.panel);
            this.Name = "Toggle";
            this.Size = new System.Drawing.Size (192, 34);
            this.ResumeLayout (false);

        }
        #endregion

        #endregion

        #region Event Handlers

        private void button_Click (object sender, System.EventArgs e)
        {

            // If the toggle is binary, in addition to support dragging we support clicking on the
            // button to move it to the "other" position.  However, we don't do this if the button
            // has already been dragged: say that the user moved the button to the other position
            // and then back to the original one.  It would be unpleasant for the mouse-up event to
            // trigger a toggle move.
            if (isBinary && !mouseHasDragged)
            {
                switch (position)
                {
                    case TogglePosition.Left:
                        Position = TogglePosition.Right;
                        break;
                    case TogglePosition.Right:
                        Position = TogglePosition.Left;
                        break;
                }
            }
        }

        private void button_MouseDown (object sender, MouseEventArgs e)
        {

            // Note that e.Location is relative to the coordinate system of the button.
            mouseDown = true;
            mouseHasDragged = false;
            Trace.WriteLineIf (userControlTesting,
                "panel.X=" + panel.Location.X + " panel.Width=" + panel.Width);
        }

        private void button_MouseMove (object sender, MouseEventArgs e)
        {
            int x = button.Location.X + e.X;
            int x1;
            int x2;

            if (!mouseDown)
            {
                return;
            }

            Trace.WriteLineIf (userControlTesting,
                "event.X=" + e.X +
                " button.X=" + button.Location.X);

            if (isBinary)
            {
                x1 = panel.Location.X + panel.Width / 2;
                switch (position)
                {
                    case TogglePosition.Left:
                        {
                            if (x > x1)
                            {
                                Position = TogglePosition.Right;
                                mouseHasDragged = true;
                            }
                            break;
                        }
                    case TogglePosition.Right:
                        {
                            if (x < x1)
                            {
                                Position = TogglePosition.Left;
                                mouseHasDragged = true;
                            }
                            break;
                        }
                }
            }
            else
            {
                x1 = panel.Location.X + panel.Width / 3;
                x2 = panel.Location.X + 2 * panel.Width / 3;
                switch (position)
                {
                    case TogglePosition.Left:
                        {
                            if (x > x2)
                            {
                                Position = TogglePosition.Right;
                                mouseHasDragged = true;
                            }
                            else if (x > x1)
                            {
                                Position = TogglePosition.Center;
                                mouseHasDragged = true;
                            }
                            break;
                        }
                    case TogglePosition.Center:
                        {
                            if (x > x2)
                            {
                                Position = TogglePosition.Right;
                            }
                            else if (x < x1)
                            {
                                Position = TogglePosition.Left;
                            }
                            break;
                        }
                    case TogglePosition.Right:
                        {
                            if (x < x1)
                            {
                                Position = TogglePosition.Left;
                                mouseHasDragged = true;
                            }
                            else if (x < x2)
                            {
                                Position = TogglePosition.Center;
                                mouseHasDragged = true;
                            }
                            break;
                        }
                }
            }
        }

        private void button_MouseUp (object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        #endregion

        #region Private Methods

        private void AdjustSize ()
        {
            int x = leftLabel.Location.X;
            int yMax = Math.Max (Math.Max (leftLabel.Location.Y + leftLabel.Height,
                                            rightLabel.Location.Y + rightLabel.Height),
                            centerLabel.Location.Y + centerLabel.Height);
            int yMin = Math.Min (Math.Min (leftLabel.Location.Y, rightLabel.Location.Y),
                            centerLabel.Location.Y);

            leftLabel.Location = new Point
                (leftLabel.Location.X - x, leftLabel.Location.Y - yMin);
            panel.Location = new Point
                (panel.Location.X - x, panel.Location.Y - yMin);
            button.Location = new Point
                (button.Location.X - x, button.Location.Y - yMin);
            centerLabel.Location = new Point
                (centerLabel.Location.X - x, centerLabel.Location.Y - yMin);
            rightLabel.Location = new Point
                (rightLabel.Location.X - x, rightLabel.Location.Y - yMin);

            this.Size = new Size
                (leftLabel.Size.Width + panel.Size.Width + rightLabel.Size.Width, yMax - yMin);
        }

        #endregion

        #region Public Properties

        public new System.Drawing.Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
                leftLabel.BackColor = backColor;
                centerLabel.BackColor = backColor;
                rightLabel.BackColor = backColor;
            }
        }

        public string CenterText
        {
            get
            {
                return centerLabel.Text;
            }
            set
            {
                bool wasBinary = centerLabel.Text == "";
                int Δy = 0;

                centerLabel.Text = value;
                isBinary = centerLabel.Text == "";
                if (wasBinary && !isBinary)
                {
                    Δy = centerLabel.Height;
                    centerLabel.Visible = true;
                }
                else if (!wasBinary && isBinary)
                {
                    Δy = -centerLabel.Height;
                    centerLabel.Visible = false;
                }
                if (Δy != 0)
                {
                    leftLabel.Location = new Point (leftLabel.Location.X,
                                                    leftLabel.Location.Y + Δy);
                    button.Location = new Point (button.Location.X, button.Location.Y + Δy);
                    panel.Location = new Point (panel.Location.X, panel.Location.Y + Δy);
                    rightLabel.Location = new Point (rightLabel.Location.X,
                                                    rightLabel.Location.Y + Δy);
                    Size = new Size (Size.Width, Size.Height + Δy);
                }
            }
        }

        public override System.Drawing.Font Font
        {
            set
            {
                base.Font = value;
                font = value;
                leftLabel.Font = font;
                centerLabel.Font = font;
                rightLabel.Font = font;
            }
        }

        public override System.Drawing.Color ForeColor
        {
            set
            {
                base.ForeColor = value;
                foreColor = value;
                leftLabel.ForeColor = foreColor;
                centerLabel.ForeColor = foreColor;
                rightLabel.ForeColor = foreColor;
            }
        }

        public string LeftText
        {
            get
            {
                return leftLabel.Text;
            }
            set
            {
                leftLabel.Text = value;
            }
        }

        public int LeftWidth
        {
            get
            {
                return leftLabel.Size.Width;
            }
            set
            {
                int ΔWidth = value - leftLabel.Size.Width;

                leftLabel.Size = new Size (value, leftLabel.Size.Height);
                button.Location = new Point
                    (button.Location.X + ΔWidth, button.Location.Y);
                panel.Location = new Point
                    (panel.Location.X + ΔWidth, panel.Location.Y);
                centerLabel.Location = new Point
                    (centerLabel.Location.X + ΔWidth, centerLabel.Location.Y);
                rightLabel.Location = new Point
                    (rightLabel.Location.X + ΔWidth, rightLabel.Location.Y);

                AdjustSize ();
            }
        }

        public int MainWidth
        {
            get
            {
                return panel.Width;
            }
            set
            {
                int ΔWidth = value - panel.Size.Width;

                panel.Size = new Size (value, panel.Height);
                centerLabel.Size = new Size (value, centerLabel.Height);
                button.Size = new Size ((int) (value * reductionFactor), button.Height);
                if (position == TogglePosition.Right)
                {
                    button.Location = new Point
                        (panel.Location.X + panel.Width - button.Width - marginWidth,
                        button.Location.Y);
                }
                rightLabel.Location = new Point
                    (rightLabel.Location.X + ΔWidth, rightLabel.Location.Y);

                AdjustSize ();
            }
        }

        public TogglePosition Position
        {
            get
            {
                return position;
            }
            set
            {
                bool mustNotify = position != value;

                position = value;
                switch (position)
                {
                    case TogglePosition.Left:
                        {
                            button.Location = new Point
                                (panel.Location.X + marginWidth,
                                button.Location.Y);
                            break;
                        }
                    case TogglePosition.Center:
                        {
                            button.Location = new Point
                                (panel.Location.X + (panel.Width - button.Width) / 2,
                                button.Location.Y);
                            break;
                        }
                    case TogglePosition.Right:
                        {
                            button.Location = new Point
                                (panel.Location.X + panel.Width - button.Width - marginWidth,
                                button.Location.Y);
                            break;
                        }
                }
                if (mustNotify && ToggleMoved != null)
                {
                    ToggleMoved (this, position);
                }
            }
        }

        public string RightText
        {
            get
            {
                return rightLabel.Text;
            }
            set
            {
                rightLabel.Text = value;
            }
        }

        public int RightWidth
        {
            get
            {
                return rightLabel.Size.Width;
            }
            set
            {
                rightLabel.Size = new Size (value, rightLabel.Height);
                AdjustSize ();
            }
        }

        #endregion

    }
}
