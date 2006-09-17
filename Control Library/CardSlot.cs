using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace Mockingbird.HP.Control_Library
{
    public enum CardSlotState
    {
        Unloaded,
        ReadOnly,
        ReadWrite,
        Editable
    }

    /// <summary>
    /// The card slot of an HP calculator.
    /// </summary>
    public class CardSlot : System.Windows.Forms.UserControl
    {

        #region Private Data

        private const int cardSlotHeight = 50;
        private const float sizeIncrease = 1.25F;

        private Pen cornerPen;
        private Point [] cornerSquare;
        private Point [] cornerUpperTriangle;
        private System.Drawing.Font font;
        private System.Drawing.Font largeFont;
        private bool inScaleControl = false;
        private Color loadedColor;
        private SolidBrush loadedColorBrush;
        private int margin;
        private bool richText;
        private CardSlotState state;
        private int textBoxWidth;
        private Color unloadedColor;
        private SolidBrush unloadedColorBrush;

        private System.Windows.Forms.Label [] labels;
        private System.Windows.Forms.TextBoxBase [] textBoxes;
        private System.Windows.Forms.TextBoxBase [] fTextBoxes;
        private System.Windows.Forms.TextBoxBase title;
        internal System.Windows.Forms.Panel panel;
        internal System.Windows.Forms.RichTextBox titleRTFBox;
        internal System.Windows.Forms.TextBox titleTextBox;
        internal System.Windows.Forms.TextBox textBoxA;
        internal System.Windows.Forms.TextBox textBoxB;
        internal System.Windows.Forms.TextBox textBoxC;
        internal System.Windows.Forms.TextBox textBoxD;
        internal System.Windows.Forms.TextBox textBoxE;
        internal System.Windows.Forms.TextBox textBoxfA;
        internal System.Windows.Forms.TextBox textBoxfB;
        internal System.Windows.Forms.TextBox textBoxfC;
        internal System.Windows.Forms.TextBox textBoxfD;
        internal System.Windows.Forms.TextBox textBoxfE;
        internal System.Windows.Forms.Label labelA;
        internal System.Windows.Forms.Label labelB;
        internal System.Windows.Forms.Label labelC;
        internal System.Windows.Forms.Label labelE;
        internal System.Windows.Forms.Label labelD;
        internal System.Windows.Forms.RichTextBox rtfBoxA;
        internal System.Windows.Forms.RichTextBox rtfBoxB;
        internal System.Windows.Forms.RichTextBox rtfBoxC;
        internal System.Windows.Forms.RichTextBox rtfBoxD;
        internal System.Windows.Forms.RichTextBox rtfBoxE;
        internal System.Windows.Forms.RichTextBox rtfBoxfA;
        internal System.Windows.Forms.RichTextBox rtfBoxfB;
        internal System.Windows.Forms.RichTextBox rtfBoxfC;
        internal System.Windows.Forms.RichTextBox rtfBoxfD;
        internal System.Windows.Forms.RichTextBox rtfBoxfE;
        private System.Windows.Forms.PictureBox cornerPictureBox;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors & Destructors

        public CardSlot ()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent ();

            title = titleTextBox;
            labels = new System.Windows.Forms.Label [5] { labelA, labelB, labelC, labelD, labelE };
            textBoxes = new System.Windows.Forms.TextBox [5] { textBoxA, textBoxB, textBoxC, textBoxD, textBoxE };
            fTextBoxes = new System.Windows.Forms.TextBox [5] { textBoxfA, textBoxfB, textBoxfC, textBoxfD, textBoxfE };
            Clear ();

            cornerPen = new Pen (System.Drawing.Color.FromArgb (191, 191, 95));
            loadedColor = System.Drawing.Color.FromArgb (64, 64, 0);
            loadedColorBrush = new SolidBrush (loadedColor);
            unloadedColor = System.Drawing.Color.FromArgb (64, 64, 64);
            unloadedColorBrush = new SolidBrush (unloadedColor);

            cornerSquare =
                new Point [] {
								 new Point (cornerPictureBox.Left, cornerPictureBox.Top),
								 new Point (cornerPictureBox.Left, cornerPictureBox.Bottom),
								 new Point (cornerPictureBox.Right, cornerPictureBox.Bottom),
								 new Point (cornerPictureBox.Right, cornerPictureBox.Top)
							 };
            cornerUpperTriangle =
                new Point [] {
								 new Point (cornerPictureBox.Left, cornerPictureBox.Top),
								 new Point (cornerPictureBox.Left, cornerPictureBox.Bottom),
								 new Point (cornerPictureBox.Right, cornerPictureBox.Top)
							 };

            Font = new System.Drawing.Font
                ("Arial Unicode MS", 7.0F, System.Drawing.FontStyle.Regular);
            TextBoxWidth = 48;
            State = CardSlotState.Unloaded;
            RichText = true;
            RichText = false;
            Margin = 16;
            Card.ReadFromDataset += new Card.DatasetImporterDelegate (ReadFromDataset);
            Card.WriteToDataset += new Card.DatasetExporterDelegate (WriteToDataset);
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
            this.panel = new System.Windows.Forms.Panel ();
            this.cornerPictureBox = new System.Windows.Forms.PictureBox ();
            this.titleRTFBox = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxfB = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxfE = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxfD = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxfC = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxfA = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxE = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxD = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxC = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxB = new System.Windows.Forms.RichTextBox ();
            this.rtfBoxA = new System.Windows.Forms.RichTextBox ();
            this.titleTextBox = new System.Windows.Forms.TextBox ();
            this.textBoxA = new System.Windows.Forms.TextBox ();
            this.textBoxB = new System.Windows.Forms.TextBox ();
            this.textBoxC = new System.Windows.Forms.TextBox ();
            this.textBoxD = new System.Windows.Forms.TextBox ();
            this.textBoxE = new System.Windows.Forms.TextBox ();
            this.textBoxfA = new System.Windows.Forms.TextBox ();
            this.textBoxfB = new System.Windows.Forms.TextBox ();
            this.textBoxfE = new System.Windows.Forms.TextBox ();
            this.textBoxfC = new System.Windows.Forms.TextBox ();
            this.textBoxfD = new System.Windows.Forms.TextBox ();
            this.labelA = new System.Windows.Forms.Label ();
            this.labelB = new System.Windows.Forms.Label ();
            this.labelC = new System.Windows.Forms.Label ();
            this.labelD = new System.Windows.Forms.Label ();
            this.labelE = new System.Windows.Forms.Label ();
            this.panel.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add (this.cornerPictureBox);
            this.panel.Controls.Add (this.titleRTFBox);
            this.panel.Controls.Add (this.rtfBoxfB);
            this.panel.Controls.Add (this.rtfBoxfE);
            this.panel.Controls.Add (this.rtfBoxfD);
            this.panel.Controls.Add (this.rtfBoxfC);
            this.panel.Controls.Add (this.rtfBoxfA);
            this.panel.Controls.Add (this.rtfBoxE);
            this.panel.Controls.Add (this.rtfBoxD);
            this.panel.Controls.Add (this.rtfBoxC);
            this.panel.Controls.Add (this.rtfBoxB);
            this.panel.Controls.Add (this.rtfBoxA);
            this.panel.Controls.Add (this.titleTextBox);
            this.panel.Controls.Add (this.textBoxA);
            this.panel.Controls.Add (this.textBoxB);
            this.panel.Controls.Add (this.textBoxC);
            this.panel.Controls.Add (this.textBoxD);
            this.panel.Controls.Add (this.textBoxE);
            this.panel.Controls.Add (this.textBoxfA);
            this.panel.Controls.Add (this.textBoxfB);
            this.panel.Controls.Add (this.textBoxfE);
            this.panel.Controls.Add (this.textBoxfC);
            this.panel.Controls.Add (this.textBoxfD);
            this.panel.Controls.Add (this.labelA);
            this.panel.Controls.Add (this.labelB);
            this.panel.Controls.Add (this.labelC);
            this.panel.Controls.Add (this.labelD);
            this.panel.Controls.Add (this.labelE);
            this.panel.ForeColor = System.Drawing.Color.Gold;
            this.panel.Location = new System.Drawing.Point (0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size (300, 50);
            this.panel.TabIndex = 0;
            // 
            // cornerPictureBox
            // 
            this.cornerPictureBox.Location = new System.Drawing.Point (0, 0);
            this.cornerPictureBox.Name = "cornerPictureBox";
            this.cornerPictureBox.Size = new System.Drawing.Size (15, 15);
            this.cornerPictureBox.TabIndex = 23;
            this.cornerPictureBox.TabStop = false;
            this.cornerPictureBox.Paint += new System.Windows.Forms.PaintEventHandler (this.cornerPictureBox_Paint);
            // 
            // titleRTFBox
            // 
            this.titleRTFBox.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.titleRTFBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleRTFBox.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.titleRTFBox.ForeColor = System.Drawing.Color.White;
            this.titleRTFBox.Location = new System.Drawing.Point (16, 4);
            this.titleRTFBox.Name = "titleRTFBox";
            this.titleRTFBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.titleRTFBox.Size = new System.Drawing.Size (180, 14);
            this.titleRTFBox.TabIndex = 22;
            this.titleRTFBox.Text = "<TITLE>";
            // 
            // rtfBoxfB
            // 
            this.rtfBoxfB.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxfB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxfB.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxfB.ForeColor = System.Drawing.Color.Gold;
            this.rtfBoxfB.Location = new System.Drawing.Point (72, 18);
            this.rtfBoxfB.Multiline = false;
            this.rtfBoxfB.Name = "rtfBoxfB";
            this.rtfBoxfB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxfB.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxfB.TabIndex = 13;
            this.rtfBoxfB.Text = "<fB>";
            // 
            // rtfBoxfE
            // 
            this.rtfBoxfE.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxfE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxfE.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxfE.ForeColor = System.Drawing.Color.Gold;
            this.rtfBoxfE.Location = new System.Drawing.Point (240, 18);
            this.rtfBoxfE.Multiline = false;
            this.rtfBoxfE.Name = "rtfBoxfE";
            this.rtfBoxfE.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxfE.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxfE.TabIndex = 16;
            this.rtfBoxfE.Text = "<fE>";
            // 
            // rtfBoxfD
            // 
            this.rtfBoxfD.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxfD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxfD.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxfD.ForeColor = System.Drawing.Color.Gold;
            this.rtfBoxfD.Location = new System.Drawing.Point (184, 18);
            this.rtfBoxfD.Multiline = false;
            this.rtfBoxfD.Name = "rtfBoxfD";
            this.rtfBoxfD.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxfD.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxfD.TabIndex = 15;
            this.rtfBoxfD.Text = "<fD>";
            // 
            // rtfBoxfC
            // 
            this.rtfBoxfC.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxfC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxfC.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxfC.ForeColor = System.Drawing.Color.Gold;
            this.rtfBoxfC.Location = new System.Drawing.Point (128, 18);
            this.rtfBoxfC.Multiline = false;
            this.rtfBoxfC.Name = "rtfBoxfC";
            this.rtfBoxfC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxfC.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxfC.TabIndex = 14;
            this.rtfBoxfC.Text = "<fC>";
            // 
            // rtfBoxfA
            // 
            this.rtfBoxfA.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxfA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxfA.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxfA.ForeColor = System.Drawing.Color.Gold;
            this.rtfBoxfA.Location = new System.Drawing.Point (16, 18);
            this.rtfBoxfA.Multiline = false;
            this.rtfBoxfA.Name = "rtfBoxfA";
            this.rtfBoxfA.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxfA.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxfA.TabIndex = 12;
            this.rtfBoxfA.Text = "<fA>";
            // 
            // rtfBoxE
            // 
            this.rtfBoxE.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxE.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxE.ForeColor = System.Drawing.Color.White;
            this.rtfBoxE.Location = new System.Drawing.Point (240, 32);
            this.rtfBoxE.Multiline = false;
            this.rtfBoxE.Name = "rtfBoxE";
            this.rtfBoxE.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxE.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxE.TabIndex = 21;
            this.rtfBoxE.Text = "<E>";
            // 
            // rtfBoxD
            // 
            this.rtfBoxD.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxD.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxD.ForeColor = System.Drawing.Color.White;
            this.rtfBoxD.Location = new System.Drawing.Point (184, 32);
            this.rtfBoxD.Multiline = false;
            this.rtfBoxD.Name = "rtfBoxD";
            this.rtfBoxD.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxD.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxD.TabIndex = 20;
            this.rtfBoxD.Text = "<D>";
            // 
            // rtfBoxC
            // 
            this.rtfBoxC.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxC.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxC.ForeColor = System.Drawing.Color.White;
            this.rtfBoxC.Location = new System.Drawing.Point (128, 32);
            this.rtfBoxC.Multiline = false;
            this.rtfBoxC.Name = "rtfBoxC";
            this.rtfBoxC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxC.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxC.TabIndex = 19;
            this.rtfBoxC.Text = "<C>";
            // 
            // rtfBoxB
            // 
            this.rtfBoxB.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxB.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxB.ForeColor = System.Drawing.Color.White;
            this.rtfBoxB.Location = new System.Drawing.Point (72, 32);
            this.rtfBoxB.Multiline = false;
            this.rtfBoxB.Name = "rtfBoxB";
            this.rtfBoxB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxB.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxB.TabIndex = 18;
            this.rtfBoxB.Text = "<B>";
            // 
            // rtfBoxA
            // 
            this.rtfBoxA.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.rtfBoxA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfBoxA.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.rtfBoxA.ForeColor = System.Drawing.Color.White;
            this.rtfBoxA.Location = new System.Drawing.Point (16, 32);
            this.rtfBoxA.Multiline = false;
            this.rtfBoxA.Name = "rtfBoxA";
            this.rtfBoxA.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtfBoxA.Size = new System.Drawing.Size (48, 13);
            this.rtfBoxA.TabIndex = 17;
            this.rtfBoxA.Text = "<A>";
            // 
            // titleTextBox
            // 
            this.titleTextBox.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.titleTextBox.ForeColor = System.Drawing.Color.White;
            this.titleTextBox.Location = new System.Drawing.Point (16, 4);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size (180, 13);
            this.titleTextBox.TabIndex = 1;
            this.titleTextBox.Text = "<TITLE>";
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxA
            // 
            this.textBoxA.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxA.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxA.ForeColor = System.Drawing.Color.White;
            this.textBoxA.Location = new System.Drawing.Point (16, 32);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size (48, 13);
            this.textBoxA.TabIndex = 7;
            this.textBoxA.Text = "<A>";
            this.textBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxB
            // 
            this.textBoxB.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxB.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxB.ForeColor = System.Drawing.Color.White;
            this.textBoxB.Location = new System.Drawing.Point (72, 32);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size (48, 13);
            this.textBoxB.TabIndex = 8;
            this.textBoxB.Text = "<B>";
            this.textBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxC
            // 
            this.textBoxC.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxC.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxC.ForeColor = System.Drawing.Color.White;
            this.textBoxC.Location = new System.Drawing.Point (128, 32);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size (48, 13);
            this.textBoxC.TabIndex = 9;
            this.textBoxC.Text = "<C>";
            this.textBoxC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxD
            // 
            this.textBoxD.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxD.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxD.ForeColor = System.Drawing.Color.White;
            this.textBoxD.Location = new System.Drawing.Point (184, 32);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size (48, 13);
            this.textBoxD.TabIndex = 10;
            this.textBoxD.Text = "<D>";
            this.textBoxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxE
            // 
            this.textBoxE.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxE.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxE.ForeColor = System.Drawing.Color.White;
            this.textBoxE.Location = new System.Drawing.Point (240, 32);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.Size = new System.Drawing.Size (48, 13);
            this.textBoxE.TabIndex = 11;
            this.textBoxE.Text = "<E>";
            this.textBoxE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxfA
            // 
            this.textBoxfA.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxfA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxfA.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxfA.ForeColor = System.Drawing.Color.Gold;
            this.textBoxfA.Location = new System.Drawing.Point (16, 18);
            this.textBoxfA.Name = "textBoxfA";
            this.textBoxfA.Size = new System.Drawing.Size (48, 13);
            this.textBoxfA.TabIndex = 2;
            this.textBoxfA.Text = "<fA>";
            this.textBoxfA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxfB
            // 
            this.textBoxfB.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxfB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxfB.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxfB.ForeColor = System.Drawing.Color.Gold;
            this.textBoxfB.Location = new System.Drawing.Point (72, 18);
            this.textBoxfB.Name = "textBoxfB";
            this.textBoxfB.Size = new System.Drawing.Size (48, 13);
            this.textBoxfB.TabIndex = 3;
            this.textBoxfB.Text = "<fB>";
            this.textBoxfB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxfE
            // 
            this.textBoxfE.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxfE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxfE.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxfE.ForeColor = System.Drawing.Color.Gold;
            this.textBoxfE.Location = new System.Drawing.Point (240, 18);
            this.textBoxfE.Name = "textBoxfE";
            this.textBoxfE.Size = new System.Drawing.Size (48, 13);
            this.textBoxfE.TabIndex = 6;
            this.textBoxfE.Text = "<fE>";
            this.textBoxfE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxfC
            // 
            this.textBoxfC.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxfC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxfC.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxfC.ForeColor = System.Drawing.Color.Gold;
            this.textBoxfC.Location = new System.Drawing.Point (128, 18);
            this.textBoxfC.Name = "textBoxfC";
            this.textBoxfC.Size = new System.Drawing.Size (48, 13);
            this.textBoxfC.TabIndex = 4;
            this.textBoxfC.Text = "<fC>";
            this.textBoxfC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxfD
            // 
            this.textBoxfD.BackColor = System.Drawing.Color.FromArgb (((System.Byte) (64)), ((System.Byte) (64)), ((System.Byte) (0)));
            this.textBoxfD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxfD.Font = new System.Drawing.Font ("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.textBoxfD.ForeColor = System.Drawing.Color.Gold;
            this.textBoxfD.Location = new System.Drawing.Point (184, 18);
            this.textBoxfD.Name = "textBoxfD";
            this.textBoxfD.Size = new System.Drawing.Size (48, 13);
            this.textBoxfD.TabIndex = 5;
            this.textBoxfD.Text = "<fD>";
            this.textBoxfD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelA
            // 
            this.labelA.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.labelA.ForeColor = System.Drawing.Color.White;
            this.labelA.Location = new System.Drawing.Point (16, 26);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size (48, 18);
            this.labelA.TabIndex = 12;
            this.labelA.Text = "1/x";
            this.labelA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelB
            // 
            this.labelB.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.labelB.ForeColor = System.Drawing.Color.White;
            this.labelB.Location = new System.Drawing.Point (72, 26);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size (48, 18);
            this.labelB.TabIndex = 14;
            this.labelB.Text = "√x̅";
            this.labelB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelC
            // 
            this.labelC.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.labelC.ForeColor = System.Drawing.Color.White;
            this.labelC.Location = new System.Drawing.Point (124, 26);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size (48, 18);
            this.labelC.TabIndex = 13;
            this.labelC.Text = "yˣ";
            this.labelC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelD
            // 
            this.labelD.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.labelD.ForeColor = System.Drawing.Color.White;
            this.labelD.Location = new System.Drawing.Point (184, 26);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size (48, 18);
            this.labelD.TabIndex = 15;
            this.labelD.Text = "R↓";
            this.labelD.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelE
            // 
            this.labelE.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
            this.labelE.ForeColor = System.Drawing.Color.White;
            this.labelE.Location = new System.Drawing.Point (240, 26);
            this.labelE.Name = "labelE";
            this.labelE.Size = new System.Drawing.Size (48, 18);
            this.labelE.TabIndex = 16;
            this.labelE.Text = "x⇄y";
            this.labelE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CardSlot
            // 
            this.Controls.Add (this.panel);
            this.Name = "CardSlot";
            this.Size = new System.Drawing.Size (300, 50);
            this.panel.ResumeLayout (false);
            this.ResumeLayout (false);

        }
        #endregion

        #endregion

        #region Event Handlers

        private void cornerPictureBox_Paint (object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (state == CardSlotState.ReadOnly)
            {
                g.FillPolygon (unloadedColorBrush, cornerUpperTriangle);
                g.DrawLine (
                    cornerPen,
                    cornerPictureBox.Left,
                    cornerPictureBox.Bottom,
                    cornerPictureBox.Right,
                    cornerPictureBox.Top);
            }
            else
            {
                g.FillPolygon (loadedColorBrush, cornerSquare);
            }
        }

        public void ReadFromDataset (CardDataset cds, Reader reader)
        {
            CardDataset.CardRow cr;
            CardDataset.CardSlotRow csr;
            CardDataset.CardSlotRow [] csrs;

            cr = cds.Card [0];
            csrs = cr.GetCardSlotRows ();
            if (csrs.Length > 0)
            {
                csr = csrs [0];
                font = new Font (csr.FontName, csr.FontSize);
                largeFont = new Font (csr.LargeFontName, csr.LargeFontSize);
                Margin = csr.Margin;
                TextBoxWidth = csr.TextBoxWidth;
                RichText = csr.IsRichText;
                if (richText)
                {
                    ThreadSafe.SetRtf (titleRTFBox, csr.RTFTitle);
                    foreach (CardDataset.RTFBoxRow rbr in csr.GetRTFBoxRows ())
                    {
                        if (rbr.Id >= csr.TextBoxCount)
                        {
                            ThreadSafe.SetRtf ((fTextBoxes [rbr.Id - csr.TextBoxCount]), rbr.RTF);
                        }
                        else
                        {
                            ThreadSafe.SetRtf (textBoxes [rbr.Id], rbr.RTF);
                        }
                    }
                }
                else
                {
                    ThreadSafe.SetText (titleTextBox, csr.TextTitle);
                    foreach (CardDataset.TextBoxRow tbr in csr.GetTextBoxRows ())
                    {
                        if (tbr.Id >= csr.TextBoxCount)
                        {
                            ThreadSafe.SetText (fTextBoxes [tbr.Id - csr.TextBoxCount], tbr.Text);
                        }
                        else
                        {
                            ThreadSafe.SetText (textBoxes [tbr.Id], tbr.Text);
                        }
                    }
                }
            }
        }

        public void WriteToDataset (CardDataset cds, CardPart part)
        {
            if (part == CardPart.Program)
            {
                CardDataset.CardSlotRow csr;
                CardDataset.RTFBoxRow rbr;
                CardDataset.TextBoxRow tbr;

                for (int i = 0; i < cds.CardSlot.Count; i++)
                {
                    cds.CardSlot.RemoveCardSlotRow (cds.CardSlot [i]);
                }
                csr = cds.CardSlot.NewCardSlotRow ();
                csr.FontName = font.Name;
                csr.FontSize = font.SizeInPoints;
                csr.LargeFontName = largeFont.Name;
                csr.LargeFontSize = largeFont.SizeInPoints;
                if (richText)
                {
                    csr.RTFTitle = ThreadSafe.GetRtf (titleRTFBox);
                }
                else
                {
                    csr.TextTitle = ThreadSafe.GetText (titleTextBox);
                }
                csr.Margin = margin;
                csr.TextBoxWidth = textBoxWidth;
                csr.IsRichText = richText;
                csr.TextBoxCount = textBoxes.Length;
                Trace.Assert (textBoxes.Length == fTextBoxes.Length);
                csr.CardRow = cds.Card [0];
                cds.CardSlot.AddCardSlotRow (csr);
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    if (richText)
                    {
                        rbr = cds.RTFBox.NewRTFBoxRow ();
                        rbr.RTF = ThreadSafe.GetRtf (textBoxes [i]);
                        rbr.Id = i;
                        rbr.CardSlotRow = csr;
                        cds.RTFBox.AddRTFBoxRow (rbr);
                    }
                    else
                    {
                        tbr = cds.TextBox.NewTextBoxRow ();
                        tbr.Text = ThreadSafe.GetText (textBoxes [i]);
                        tbr.Id = i;
                        tbr.CardSlotRow = csr;
                        cds.TextBox.AddTextBoxRow (tbr);
                    }
                }
                for (int i = 0; i < fTextBoxes.Length; i++)
                {
                    if (richText)
                    {
                        rbr = cds.RTFBox.NewRTFBoxRow ();
                        rbr.RTF = ThreadSafe.GetRtf (fTextBoxes [i]);
                        rbr.Id = i + textBoxes.Length;
                        rbr.CardSlotRow = csr;
                        cds.RTFBox.AddRTFBoxRow (rbr);
                    }
                    else
                    {
                        tbr = cds.TextBox.NewTextBoxRow ();
                        tbr.Text = ThreadSafe.GetText (fTextBoxes [i]);
                        tbr.Id = i + textBoxes.Length;
                        tbr.CardSlotRow = csr;
                        cds.TextBox.AddTextBoxRow (tbr);
                    }
                }
            }
        }

        #endregion

        #region Private & Protected Operations

        private void Clear ()
        {
            ThreadSafe.SetText (titleTextBox, "<TITLE>");
            ThreadSafe.SetText (titleRTFBox, "<TITLE>");
            ThreadSafe.SetText (textBoxA, "<A>");
            ThreadSafe.SetText (textBoxB, "<B>");
            ThreadSafe.SetText (textBoxC, "<C>");
            ThreadSafe.SetText (textBoxD, "<D>");
            ThreadSafe.SetText (textBoxE, "<E>");
            ThreadSafe.SetText (textBoxfA, "<fA>");
            ThreadSafe.SetText (textBoxfB, "<fB>");
            ThreadSafe.SetText (textBoxfC, "<fC>");
            ThreadSafe.SetText (textBoxfD, "<fD>");
            ThreadSafe.SetText (textBoxfE, "<fE>");
            ThreadSafe.SetText (rtfBoxA, "<A>");
            ThreadSafe.SetText (rtfBoxB, "<B>");
            ThreadSafe.SetText (rtfBoxC, "<C>");
            ThreadSafe.SetText (rtfBoxD, "<D>");
            ThreadSafe.SetText (rtfBoxE, "<E>");
            ThreadSafe.SetText (rtfBoxfA, "<fA>");
            ThreadSafe.SetText (rtfBoxfB, "<fB>");
            ThreadSafe.SetText (rtfBoxfC, "<fC>");
            ThreadSafe.SetText (rtfBoxfD, "<fD>");
            ThreadSafe.SetText (rtfBoxfE, "<fE>");
        }

        protected override void OnResize (EventArgs e)
        {
            base.OnResize (e);

            if (inScaleControl)
            {

                // The control is being scaled to adapt to the display resolution.  Do as we are
                // told.
            }
            else if (Size.Height != 50)
            {

                // We are willing to change the width of the card slot, but not its height which is
                // related to the size of the labels, etc.
                Size = new Size (Size.Width, 50);
                Margin = Margin;
            }
        }

        protected override void ScaleControl (SizeF factor, BoundsSpecified specified)
        {
            inScaleControl = true;
            base.ScaleControl (factor, specified);
            inScaleControl = false;
        }

        private void SetEditable (bool editable)
        {
            ThreadSafe.SetReadOnly (title, !editable);
            foreach (System.Windows.Forms.TextBoxBase t in textBoxes)
            {
                ThreadSafe.SetReadOnly (t, !editable);
            }
            foreach (System.Windows.Forms.TextBoxBase t in fTextBoxes)
            {
                ThreadSafe.SetReadOnly (t, !editable);
            }
        }

        private void SetLoaded (bool loaded)
        {
            if (loaded)
            {
                ThreadSafe.SetBackColor (panel, loadedColor);
                ThreadSafe.SetVisible (title, true);
                foreach (System.Windows.Forms.TextBoxBase t in textBoxes)
                {
                    ThreadSafe.SetVisible (t, true);
                }
                foreach (System.Windows.Forms.TextBoxBase t in fTextBoxes)
                {
                    ThreadSafe.SetVisible (t, true);
                }
                foreach (System.Windows.Forms.Label l in labels)
                {
                    ThreadSafe.SetVisible (l, false);
                }
            }
            else
            {
                ThreadSafe.SetVisible (cornerPictureBox, false);
                ThreadSafe.SetBackColor (panel, unloadedColor);
                ThreadSafe.SetVisible (title, false);
                foreach (System.Windows.Forms.TextBoxBase t in textBoxes)
                {
                    ThreadSafe.SetVisible (t, false);
                }
                foreach (System.Windows.Forms.TextBoxBase t in fTextBoxes)
                {
                    ThreadSafe.SetVisible (t, false);
                }
                foreach (System.Windows.Forms.Label l in labels)
                {
                    ThreadSafe.SetVisible (l, true);
                }
            }
        }

        #endregion

        #region Public Properties

        public override Color BackColor
        {
            set
            {
                //ThreadSafe.SetBackColor (base, value);
                base.BackColor = value;
                unloadedColor = value;
                unloadedColorBrush = new SolidBrush (unloadedColor);
                ThreadSafe.SetBackColor (panel, unloadedColor);
            }
        }

        public override System.Drawing.Font Font
        {
            set
            {
                //ThreadSafe.SetFont (base, value);
                base.Font = value;
                font = value;
                largeFont = new System.Drawing.Font
                    (font.Name,
                    font.SizeInPoints * sizeIncrease,
                    System.Drawing.FontStyle.Bold);
                ThreadSafe.SetFont (title, font);
                foreach (System.Windows.Forms.TextBoxBase t in textBoxes)
                {
                    ThreadSafe.SetFont (t, font);
                }
                foreach (System.Windows.Forms.TextBoxBase t in fTextBoxes)
                {
                    ThreadSafe.SetFont (t, font);
                }
                foreach (System.Windows.Forms.Label l in labels)
                {
                    ThreadSafe.SetFont (l, largeFont);
                }
            }
        }

        public new int Margin
        {
            get
            {
                return margin;
            }
            set
            {
                int spacing = (this.Size.Width - 2 * value - 5 * textBoxWidth) / 4;

                margin = value;
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    ThreadSafe.SetLocation (textBoxes [i],
                        new System.Drawing.Point
                            (margin + i * (textBoxWidth + spacing), textBoxes [i].Location.Y));
                }
                for (int i = 0; i < fTextBoxes.Length; i++)
                {
                    ThreadSafe.SetLocation (fTextBoxes [i],
                        new System.Drawing.Point
                            (margin + i * (textBoxWidth + spacing), fTextBoxes [i].Location.Y));
                }
                for (int i = 0; i < labels.Length; i++)
                {
                    ThreadSafe.SetLocation (labels [i],
                        new System.Drawing.Point
                            (margin + i * (textBoxWidth + spacing), labels [i].Location.Y));
                }
            }
        }

        public bool RichText
        {
            get
            {
                return richText;
            }
            set
            {
                string titleText;
                string [] text = new string [5];
                string [] fText = new string [5];

                richText = value;

                // Preserve the contents of the text boxes.
                ThreadSafe.SetVisible (title, false);
                titleText = ThreadSafe.GetText (title);
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    ThreadSafe.SetVisible (textBoxes [i], false);
                    text [i] = ThreadSafe.GetText (textBoxes [i]);
                }
                for (int i = 0; i < fTextBoxes.Length; i++)
                {
                    ThreadSafe.SetVisible (fTextBoxes [i], false);
                    fText [i] = ThreadSafe.GetText (fTextBoxes [i]);
                }
                switch (richText)
                {
                    case false:
                        {
                            title = titleTextBox;
                            textBoxes = new System.Windows.Forms.TextBox [5] { textBoxA, textBoxB, textBoxC, textBoxD, textBoxE };
                            fTextBoxes = new System.Windows.Forms.TextBox [5] { textBoxfA, textBoxfB, textBoxfC, textBoxfD, textBoxfE };
                            break;
                        }
                    case true:
                        {
                            title = titleRTFBox;
                            textBoxes = new System.Windows.Forms.RichTextBox [5] { rtfBoxA, rtfBoxB, rtfBoxC, rtfBoxD, rtfBoxE };
                            fTextBoxes = new System.Windows.Forms.RichTextBox [5] { rtfBoxfA, rtfBoxfB, rtfBoxfC, rtfBoxfD, rtfBoxfE };
                            break;
                        }
                }
                State = State;

                // Restore the text and center it if need be.
                ThreadSafe.SetText (title, titleText);
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    ThreadSafe.SetText (textBoxes [i], text [i]);
                }
                for (int i = 0; i < fTextBoxes.Length; i++)
                {
                    ThreadSafe.SetText (fTextBoxes [i], fText [i]);
                }
                if (richText)
                {
                    ThreadSafe.SelectAll (titleRTFBox);
                    ThreadSafe.SetSelectionAlignment (titleRTFBox, HorizontalAlignment.Center);
                    foreach (System.Windows.Forms.RichTextBox r in textBoxes)
                    {
                        ThreadSafe.SelectAll (r);
                        ThreadSafe.SetSelectionAlignment (r, HorizontalAlignment.Center);
                    }
                    foreach (System.Windows.Forms.RichTextBox r in fTextBoxes)
                    {
                        ThreadSafe.SelectAll (r);
                        ThreadSafe.SetSelectionAlignment (r, HorizontalAlignment.Center);
                    }
                }

                // Finally position the text boxes.
                Margin = Margin;
            }
        }

        public CardSlotState State
        {
            get
            {
                return state;
            }
            set
            {
                switch (value)
                {
                    case CardSlotState.Unloaded:
                        {
                            if (state > CardSlotState.Unloaded)
                            {
                                Clear ();
                            }
                            SetEditable (false);
                            SetLoaded (false);
                            ThreadSafe.SetVisible (cornerPictureBox, false);
                            break;
                        }
                    case CardSlotState.ReadOnly:
                        {
                            SetEditable (false);
                            SetLoaded (true);
                            ThreadSafe.SetVisible (cornerPictureBox, true);
                            break;
                        }
                    case CardSlotState.ReadWrite:
                        {
                            SetEditable (false);
                            SetLoaded (true);
                            ThreadSafe.SetVisible (cornerPictureBox, false);
                            break;
                        }
                    case CardSlotState.Editable:
                        {
                            SetEditable (true);
                            SetLoaded (true);
                            ThreadSafe.SetVisible (cornerPictureBox, false);
                            break;
                        }
                }
                state = value;
            }
        }

        public int TextBoxWidth
        {
            get
            {
                return textBoxWidth;
            }
            set
            {
                int spacing = (this.Size.Width - 2 * margin - 5 * value) / 4;

                textBoxWidth = value;
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    ThreadSafe.SetLocation (textBoxes [i],
                        new System.Drawing.Point
                            (margin + i * (textBoxWidth + spacing), textBoxes [i].Location.Y));
                    ThreadSafe.SetSize (textBoxes [i],
                        new System.Drawing.Size (value, textBoxes [i].Size.Height));
                }
                for (int i = 0; i < fTextBoxes.Length; i++)
                {
                    ThreadSafe.SetLocation (fTextBoxes [i],
                        new System.Drawing.Point
                            (margin + i * (textBoxWidth + spacing), fTextBoxes [i].Location.Y));
                    ThreadSafe.SetSize (fTextBoxes [i],
                        new System.Drawing.Size (value, fTextBoxes [i].Size.Height));
                }
                for (int i = 0; i < labels.Length; i++)
                {
                    ThreadSafe.SetLocation (labels [i],
                        new System.Drawing.Point
                            (margin + i * (textBoxWidth + spacing), labels [i].Location.Y));
                    ThreadSafe.SetSize (labels [i],
                        new System.Drawing.Size (value, labels [i].Size.Height));
                }
            }
        }

        public string Title
        {
            get
            {
                return ThreadSafe.GetText (title);
            }
            set
            {
                ThreadSafe.SetText (title, value);
            }
        }

        public string UnloadedTextA
        {
            get
            {
                return ThreadSafe.GetText (labelA);
            }
            set
            {
                ThreadSafe.SetText (labelA, value);
            }
        }

        public string UnloadedTextB
        {
            get
            {
                return ThreadSafe.GetText (labelB);
            }
            set
            {
                ThreadSafe.SetText (labelB, value);
            }
        }

        public string UnloadedTextC
        {
            get
            {
                return ThreadSafe.GetText (labelC);
            }
            set
            {
                ThreadSafe.SetText (labelC, value);
            }
        }

        public string UnloadedTextD
        {
            get
            {
                return ThreadSafe.GetText (labelD);
            }
            set
            {
                ThreadSafe.SetText (labelD, value);
            }
        }

        public string UnloadedTextE
        {
            get
            {
                return ThreadSafe.GetText (labelE);
            }
            set
            {
                ThreadSafe.SetText (labelE, value);
            }
        }

        #endregion

    }
}
