using HP67_Parser;
using HP67_Persistence;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HP67_Control_Library
{
	public enum CardSlotState
	{
		Unloaded,
		ReadOnly,
		ReadWrite,
		Editable
	}

	/// <summary>
	/// The card slot of the HP67 calculator.
	/// </summary>
	public class CardSlot : System.Windows.Forms.UserControl
	{

		#region Private Data

		private const float sizeIncrease = 1.25F;

		private System.Drawing.Font font;
		private int textBoxWidth;
		private System.Drawing.Font largeFont;
		private int margin;
		private bool richText;
		private CardSlotState state;

		private System.Windows.Forms.Label [] labels;
		private System.Windows.Forms.TextBoxBase [] textBoxes;
		private System.Windows.Forms.TextBoxBase [] fTextBoxes;
		private System.Windows.Forms.TextBoxBase title;

		internal System.Windows.Forms.Panel cornerPanel;
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

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructors & Destructors

		public CardSlot()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			title = titleTextBox;
			labels = new System.Windows.Forms.Label [5]
				{labelA, labelB, labelC, labelD, labelE};
			textBoxes = new System.Windows.Forms.TextBox [5] 
				{textBoxA, textBoxB, textBoxC, textBoxD, textBoxE};
			fTextBoxes = new System.Windows.Forms.TextBox [5]
				{textBoxfA, textBoxfB, textBoxfC, textBoxfD, textBoxfE};
			Clear ();

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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CardSlot));
			this.panel = new System.Windows.Forms.Panel();
			this.rtfBoxfB = new System.Windows.Forms.RichTextBox();
			this.rtfBoxfE = new System.Windows.Forms.RichTextBox();
			this.rtfBoxfD = new System.Windows.Forms.RichTextBox();
			this.rtfBoxfC = new System.Windows.Forms.RichTextBox();
			this.rtfBoxfA = new System.Windows.Forms.RichTextBox();
			this.rtfBoxE = new System.Windows.Forms.RichTextBox();
			this.rtfBoxD = new System.Windows.Forms.RichTextBox();
			this.rtfBoxC = new System.Windows.Forms.RichTextBox();
			this.rtfBoxB = new System.Windows.Forms.RichTextBox();
			this.rtfBoxA = new System.Windows.Forms.RichTextBox();
			this.titleTextBox = new System.Windows.Forms.TextBox();
			this.cornerPanel = new System.Windows.Forms.Panel();
			this.textBoxA = new System.Windows.Forms.TextBox();
			this.textBoxB = new System.Windows.Forms.TextBox();
			this.textBoxC = new System.Windows.Forms.TextBox();
			this.textBoxD = new System.Windows.Forms.TextBox();
			this.textBoxE = new System.Windows.Forms.TextBox();
			this.textBoxfA = new System.Windows.Forms.TextBox();
			this.textBoxfB = new System.Windows.Forms.TextBox();
			this.textBoxfE = new System.Windows.Forms.TextBox();
			this.textBoxfC = new System.Windows.Forms.TextBox();
			this.textBoxfD = new System.Windows.Forms.TextBox();
			this.labelA = new System.Windows.Forms.Label();
			this.labelB = new System.Windows.Forms.Label();
			this.labelC = new System.Windows.Forms.Label();
			this.labelD = new System.Windows.Forms.Label();
			this.labelE = new System.Windows.Forms.Label();
			this.titleRTFBox = new System.Windows.Forms.RichTextBox();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel.Controls.Add(this.titleRTFBox);
			this.panel.Controls.Add(this.rtfBoxfB);
			this.panel.Controls.Add(this.rtfBoxfE);
			this.panel.Controls.Add(this.rtfBoxfD);
			this.panel.Controls.Add(this.rtfBoxfC);
			this.panel.Controls.Add(this.rtfBoxfA);
			this.panel.Controls.Add(this.rtfBoxE);
			this.panel.Controls.Add(this.rtfBoxD);
			this.panel.Controls.Add(this.rtfBoxC);
			this.panel.Controls.Add(this.rtfBoxB);
			this.panel.Controls.Add(this.rtfBoxA);
			this.panel.Controls.Add(this.titleTextBox);
			this.panel.Controls.Add(this.cornerPanel);
			this.panel.Controls.Add(this.textBoxA);
			this.panel.Controls.Add(this.textBoxB);
			this.panel.Controls.Add(this.textBoxC);
			this.panel.Controls.Add(this.textBoxD);
			this.panel.Controls.Add(this.textBoxE);
			this.panel.Controls.Add(this.textBoxfA);
			this.panel.Controls.Add(this.textBoxfB);
			this.panel.Controls.Add(this.textBoxfE);
			this.panel.Controls.Add(this.textBoxfC);
			this.panel.Controls.Add(this.textBoxfD);
			this.panel.Controls.Add(this.labelA);
			this.panel.Controls.Add(this.labelB);
			this.panel.Controls.Add(this.labelC);
			this.panel.Controls.Add(this.labelD);
			this.panel.Controls.Add(this.labelE);
			this.panel.ForeColor = System.Drawing.Color.Gold;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(300, 50);
			this.panel.TabIndex = 0;
			// 
			// rtfBoxfB
			// 
			this.rtfBoxfB.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxfB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxfB.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxfB.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxfB.Location = new System.Drawing.Point(72, 18);
			this.rtfBoxfB.Multiline = false;
			this.rtfBoxfB.Name = "rtfBoxfB";
			this.rtfBoxfB.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxfB.TabIndex = 13;
			this.rtfBoxfB.Text = "<fB>";
			// 
			// rtfBoxfE
			// 
			this.rtfBoxfE.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxfE.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxfE.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxfE.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxfE.Location = new System.Drawing.Point(240, 18);
			this.rtfBoxfE.Multiline = false;
			this.rtfBoxfE.Name = "rtfBoxfE";
			this.rtfBoxfE.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxfE.TabIndex = 16;
			this.rtfBoxfE.Text = "<fE>";
			// 
			// rtfBoxfD
			// 
			this.rtfBoxfD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxfD.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxfD.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxfD.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxfD.Location = new System.Drawing.Point(184, 18);
			this.rtfBoxfD.Multiline = false;
			this.rtfBoxfD.Name = "rtfBoxfD";
			this.rtfBoxfD.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxfD.TabIndex = 15;
			this.rtfBoxfD.Text = "<fD>";
			// 
			// rtfBoxfC
			// 
			this.rtfBoxfC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxfC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxfC.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxfC.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxfC.Location = new System.Drawing.Point(128, 18);
			this.rtfBoxfC.Multiline = false;
			this.rtfBoxfC.Name = "rtfBoxfC";
			this.rtfBoxfC.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxfC.TabIndex = 14;
			this.rtfBoxfC.Text = "<fC>";
			// 
			// rtfBoxfA
			// 
			this.rtfBoxfA.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxfA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxfA.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxfA.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxfA.Location = new System.Drawing.Point(16, 18);
			this.rtfBoxfA.Multiline = false;
			this.rtfBoxfA.Name = "rtfBoxfA";
			this.rtfBoxfA.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxfA.TabIndex = 12;
			this.rtfBoxfA.Text = "<fA>";
			// 
			// rtfBoxE
			// 
			this.rtfBoxE.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxE.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxE.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxE.ForeColor = System.Drawing.Color.White;
			this.rtfBoxE.Location = new System.Drawing.Point(240, 32);
			this.rtfBoxE.Multiline = false;
			this.rtfBoxE.Name = "rtfBoxE";
			this.rtfBoxE.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxE.TabIndex = 21;
			this.rtfBoxE.Text = "<E>";
			// 
			// rtfBoxD
			// 
			this.rtfBoxD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxD.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxD.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxD.ForeColor = System.Drawing.Color.White;
			this.rtfBoxD.Location = new System.Drawing.Point(184, 32);
			this.rtfBoxD.Multiline = false;
			this.rtfBoxD.Name = "rtfBoxD";
			this.rtfBoxD.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxD.TabIndex = 20;
			this.rtfBoxD.Text = "<D>";
			// 
			// rtfBoxC
			// 
			this.rtfBoxC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxC.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxC.ForeColor = System.Drawing.Color.White;
			this.rtfBoxC.Location = new System.Drawing.Point(128, 32);
			this.rtfBoxC.Multiline = false;
			this.rtfBoxC.Name = "rtfBoxC";
			this.rtfBoxC.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxC.TabIndex = 19;
			this.rtfBoxC.Text = "<C>";
			// 
			// rtfBoxB
			// 
			this.rtfBoxB.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxB.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxB.ForeColor = System.Drawing.Color.White;
			this.rtfBoxB.Location = new System.Drawing.Point(72, 32);
			this.rtfBoxB.Multiline = false;
			this.rtfBoxB.Name = "rtfBoxB";
			this.rtfBoxB.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxB.TabIndex = 18;
			this.rtfBoxB.Text = "<B>";
			// 
			// rtfBoxA
			// 
			this.rtfBoxA.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxA.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxA.ForeColor = System.Drawing.Color.White;
			this.rtfBoxA.Location = new System.Drawing.Point(16, 32);
			this.rtfBoxA.Multiline = false;
			this.rtfBoxA.Name = "rtfBoxA";
			this.rtfBoxA.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxA.TabIndex = 17;
			this.rtfBoxA.Text = "<A>";
			// 
			// titleTextBox
			// 
			this.titleTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.titleTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.titleTextBox.ForeColor = System.Drawing.Color.White;
			this.titleTextBox.Location = new System.Drawing.Point(16, 4);
			this.titleTextBox.Name = "titleTextBox";
			this.titleTextBox.Size = new System.Drawing.Size(180, 13);
			this.titleTextBox.TabIndex = 1;
			this.titleTextBox.Text = "<TITLE>";
			this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// cornerPanel
			// 
			this.cornerPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cornerPanel.BackgroundImage")));
			this.cornerPanel.Location = new System.Drawing.Point(0, 0);
			this.cornerPanel.Name = "cornerPanel";
			this.cornerPanel.Size = new System.Drawing.Size(15, 15);
			this.cornerPanel.TabIndex = 0;
			// 
			// textBoxA
			// 
			this.textBoxA.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxA.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxA.ForeColor = System.Drawing.Color.White;
			this.textBoxA.Location = new System.Drawing.Point(16, 32);
			this.textBoxA.Name = "textBoxA";
			this.textBoxA.Size = new System.Drawing.Size(48, 13);
			this.textBoxA.TabIndex = 7;
			this.textBoxA.Text = "<A>";
			this.textBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxB
			// 
			this.textBoxB.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxB.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxB.ForeColor = System.Drawing.Color.White;
			this.textBoxB.Location = new System.Drawing.Point(72, 32);
			this.textBoxB.Name = "textBoxB";
			this.textBoxB.Size = new System.Drawing.Size(48, 13);
			this.textBoxB.TabIndex = 8;
			this.textBoxB.Text = "<B>";
			this.textBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxC
			// 
			this.textBoxC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxC.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxC.ForeColor = System.Drawing.Color.White;
			this.textBoxC.Location = new System.Drawing.Point(128, 32);
			this.textBoxC.Name = "textBoxC";
			this.textBoxC.Size = new System.Drawing.Size(48, 13);
			this.textBoxC.TabIndex = 9;
			this.textBoxC.Text = "<C>";
			this.textBoxC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxD
			// 
			this.textBoxD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxD.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxD.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxD.ForeColor = System.Drawing.Color.White;
			this.textBoxD.Location = new System.Drawing.Point(184, 32);
			this.textBoxD.Name = "textBoxD";
			this.textBoxD.Size = new System.Drawing.Size(48, 13);
			this.textBoxD.TabIndex = 10;
			this.textBoxD.Text = "<D>";
			this.textBoxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxE
			// 
			this.textBoxE.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxE.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxE.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxE.ForeColor = System.Drawing.Color.White;
			this.textBoxE.Location = new System.Drawing.Point(240, 32);
			this.textBoxE.Name = "textBoxE";
			this.textBoxE.Size = new System.Drawing.Size(48, 13);
			this.textBoxE.TabIndex = 11;
			this.textBoxE.Text = "<E>";
			this.textBoxE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxfA
			// 
			this.textBoxfA.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxfA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxfA.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxfA.ForeColor = System.Drawing.Color.Gold;
			this.textBoxfA.Location = new System.Drawing.Point(16, 18);
			this.textBoxfA.Name = "textBoxfA";
			this.textBoxfA.Size = new System.Drawing.Size(48, 13);
			this.textBoxfA.TabIndex = 2;
			this.textBoxfA.Text = "<fA>";
			this.textBoxfA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxfB
			// 
			this.textBoxfB.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxfB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxfB.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxfB.ForeColor = System.Drawing.Color.Gold;
			this.textBoxfB.Location = new System.Drawing.Point(72, 18);
			this.textBoxfB.Name = "textBoxfB";
			this.textBoxfB.Size = new System.Drawing.Size(48, 13);
			this.textBoxfB.TabIndex = 3;
			this.textBoxfB.Text = "<fB>";
			this.textBoxfB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxfE
			// 
			this.textBoxfE.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxfE.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxfE.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxfE.ForeColor = System.Drawing.Color.Gold;
			this.textBoxfE.Location = new System.Drawing.Point(240, 18);
			this.textBoxfE.Name = "textBoxfE";
			this.textBoxfE.Size = new System.Drawing.Size(48, 13);
			this.textBoxfE.TabIndex = 6;
			this.textBoxfE.Text = "<fE>";
			this.textBoxfE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxfC
			// 
			this.textBoxfC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxfC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxfC.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxfC.ForeColor = System.Drawing.Color.Gold;
			this.textBoxfC.Location = new System.Drawing.Point(128, 18);
			this.textBoxfC.Name = "textBoxfC";
			this.textBoxfC.Size = new System.Drawing.Size(48, 13);
			this.textBoxfC.TabIndex = 4;
			this.textBoxfC.Text = "<fC>";
			this.textBoxfC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxfD
			// 
			this.textBoxfD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.textBoxfD.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxfD.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxfD.ForeColor = System.Drawing.Color.Gold;
			this.textBoxfD.Location = new System.Drawing.Point(184, 18);
			this.textBoxfD.Name = "textBoxfD";
			this.textBoxfD.Size = new System.Drawing.Size(48, 13);
			this.textBoxfD.TabIndex = 5;
			this.textBoxfD.Text = "<fD>";
			this.textBoxfD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelA
			// 
			this.labelA.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelA.ForeColor = System.Drawing.Color.White;
			this.labelA.Location = new System.Drawing.Point(16, 26);
			this.labelA.Name = "labelA";
			this.labelA.Size = new System.Drawing.Size(48, 18);
			this.labelA.TabIndex = 12;
			this.labelA.Text = "1/x";
			this.labelA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// labelB
			// 
			this.labelB.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelB.ForeColor = System.Drawing.Color.White;
			this.labelB.Location = new System.Drawing.Point(72, 26);
			this.labelB.Name = "labelB";
			this.labelB.Size = new System.Drawing.Size(48, 18);
			this.labelB.TabIndex = 14;
			this.labelB.Text = "√x̅";
			this.labelB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// labelC
			// 
			this.labelC.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelC.ForeColor = System.Drawing.Color.White;
			this.labelC.Location = new System.Drawing.Point(124, 26);
			this.labelC.Name = "labelC";
			this.labelC.Size = new System.Drawing.Size(48, 18);
			this.labelC.TabIndex = 13;
			this.labelC.Text = "yˣ";
			this.labelC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// labelD
			// 
			this.labelD.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelD.ForeColor = System.Drawing.Color.White;
			this.labelD.Location = new System.Drawing.Point(184, 26);
			this.labelD.Name = "labelD";
			this.labelD.Size = new System.Drawing.Size(48, 18);
			this.labelD.TabIndex = 15;
			this.labelD.Text = "R↓";
			this.labelD.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// labelE
			// 
			this.labelE.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelE.ForeColor = System.Drawing.Color.White;
			this.labelE.Location = new System.Drawing.Point(240, 26);
			this.labelE.Name = "labelE";
			this.labelE.Size = new System.Drawing.Size(48, 18);
			this.labelE.TabIndex = 16;
			this.labelE.Text = "x⇄y";
			this.labelE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// titleRTFBox
			// 
			this.titleRTFBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.titleRTFBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.titleRTFBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.titleRTFBox.ForeColor = System.Drawing.Color.White;
			this.titleRTFBox.Location = new System.Drawing.Point(16, 4);
			this.titleRTFBox.Name = "titleRTFBox";
			this.titleRTFBox.Size = new System.Drawing.Size(180, 13);
			this.titleRTFBox.TabIndex = 22;
			this.titleRTFBox.Text = "<TITLE>";
			// 
			// CardSlot
			// 
			this.Controls.Add(this.panel);
			this.Name = "CardSlot";
			this.Size = new System.Drawing.Size(300, 50);
			this.Resize += new System.EventHandler(this.CardSlot_Resize);
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Event Handlers

		private void CardSlot_Resize(object sender, System.EventArgs e)
		{
			Control control = (Control)sender;
			
			if(control.Size.Height != 50)
			{
				control.Size = new Size(control.Size.Width, 50);
			}
			Margin = Margin;
		}

		public void ReadFromDataset (CardDataset cds, Parser parser)
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
					titleRTFBox.Rtf = csr.RTFTitle;
					foreach (CardDataset.RTFBoxRow rbr in csr.GetRTFBoxRows ()) 
					{
						if (rbr.Id >= csr.TextBoxCount) 
						{
							((RichTextBox) fTextBoxes [rbr.Id - csr.TextBoxCount]).Rtf = rbr.RTF;
						}
						else 
						{
							((RichTextBox) textBoxes [rbr.Id]).Rtf = rbr.RTF;
						}
					}
				}
				else 
				{
					titleTextBox.Text = csr.TextTitle;
					foreach (CardDataset.TextBoxRow tbr in csr.GetTextBoxRows ()) 
					{
						if (tbr.Id >= csr.TextBoxCount) 
						{
							fTextBoxes [tbr.Id - csr.TextBoxCount].Text = tbr.Text;
						}
						else
						{
							textBoxes [tbr.Id].Text = tbr.Text;
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
					csr.RTFTitle = titleRTFBox.Rtf;
				}
				else 
				{
					csr.TextTitle = titleTextBox.Text;
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
						rbr.RTF = ((RichTextBox) textBoxes [i]).Rtf;
						rbr.Id = i;
						rbr.CardSlotRow = csr;
						cds.RTFBox.AddRTFBoxRow (rbr);
					}
					else
					{
						tbr = cds.TextBox.NewTextBoxRow ();
						tbr.Text = textBoxes [i].Text;
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
						rbr.RTF = ((RichTextBox) fTextBoxes [i]).Rtf;
						rbr.Id = i + textBoxes.Length;
						rbr.CardSlotRow = csr;
						cds.RTFBox.AddRTFBoxRow (rbr);
					}
					else
					{
						tbr = cds.TextBox.NewTextBoxRow ();
						tbr.Text = fTextBoxes [i].Text;
						tbr.Id = i + textBoxes.Length;
						tbr.CardSlotRow = csr;
						cds.TextBox.AddTextBoxRow (tbr);
					}
				}
			}
		}
		
		#endregion

		#region Private Operations

		private void Clear ()
		{
			this.titleTextBox.Text = "<TITLE>";
			this.titleRTFBox.Text = "<TITLE>";
			this.textBoxA.Text = "<A>";
			this.textBoxB.Text = "<B>";
			this.textBoxC.Text = "<C>";
			this.textBoxD.Text = "<D>";
			this.textBoxE.Text = "<E>";
			this.textBoxfA.Text = "<fA>";
			this.textBoxfB.Text = "<fB>";
			this.textBoxfC.Text = "<fC>";
			this.textBoxfD.Text = "<fD>";
			this.textBoxfE.Text = "<fE>";
			this.rtfBoxA.Text = "<A>";
			this.rtfBoxB.Text = "<B>";
			this.rtfBoxC.Text = "<C>";
			this.rtfBoxD.Text = "<D>";
			this.rtfBoxE.Text = "<E>";
			this.rtfBoxfA.Text = "<fA>";
			this.rtfBoxfB.Text = "<fB>";
			this.rtfBoxfC.Text = "<fC>";
			this.rtfBoxfD.Text = "<fD>";
			this.rtfBoxfE.Text = "<fE>";
		}

		private void SetEditable (bool editable)
		{
			title.ReadOnly = !editable;
			foreach (System.Windows.Forms.TextBoxBase t in textBoxes)  
			{
				t.ReadOnly = !editable;
			}
			foreach (System.Windows.Forms.TextBoxBase t in fTextBoxes)  
			{
				t.ReadOnly = !editable;
			}
		}

		private void SetLoaded (bool loaded)
		{
			if (loaded) 
			{
				panel.BackColor = System.Drawing.Color.FromArgb (64, 64, 0);
				title.Visible = true;
				foreach (System.Windows.Forms.TextBoxBase t in textBoxes)  
				{
					t.Visible = true;
				}
				foreach (System.Windows.Forms.TextBoxBase t in fTextBoxes)  
				{
					t.Visible = true;
				}
				foreach (System.Windows.Forms.Label l in labels)
				{
					l.Visible = false;
				}
			}
			else
			{
				cornerPanel.Visible = false;
				panel.BackColor = System.Drawing.Color.FromArgb (64, 64, 64);
				title.Visible = false;
				foreach (System.Windows.Forms.TextBoxBase t in textBoxes)  
				{
					t.Visible = false;
				}
				foreach (System.Windows.Forms.TextBoxBase t in fTextBoxes)  
				{
					t.Visible = false;
				}
				foreach (System.Windows.Forms.Label l in labels)
				{
					l.Visible = true;
				}
			}
		}

		#endregion

		#region Public Properties

		public override System.Drawing.Font Font
		{
			get
			{
				return font;
			}
			set
			{
				font = value;
				largeFont = new System.Drawing.Font
					(font.Name,
					font.SizeInPoints * sizeIncrease,
					System.Drawing.FontStyle.Bold);
				title.Font = font;
				foreach (System.Windows.Forms.TextBoxBase t in textBoxes)  
				{
					t.Font = font;
				}
				foreach (System.Windows.Forms.TextBoxBase t in fTextBoxes)
				{
					t.Font = font;
				}
				foreach (System.Windows.Forms.Label l in labels)  
				{
					l.Font = largeFont;
				}
			}
		}

		public int Margin
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
					textBoxes [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), textBoxes [i].Location.Y);
				}
				for (int i = 0; i < fTextBoxes.Length; i++)  
				{
					fTextBoxes [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), fTextBoxes [i].Location.Y);
				}
				for (int i = 0; i < labels.Length; i++)  
				{
					labels [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), labels [i].Location.Y);
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
				title.Visible = false;
				titleText = title.Text;
				for (int i = 0; i < textBoxes.Length; i++) 
				{
					textBoxes [i].Visible = false;
					text [i] = textBoxes [i].Text;
				}
				for (int i = 0; i < fTextBoxes.Length; i++) 
				{
					fTextBoxes [i].Visible = false;
					fText [i] = fTextBoxes [i].Text;
				}
				switch (richText) 
				{
					case false:
					{
						title = titleTextBox;
						textBoxes = new System.Windows.Forms.TextBox [5] 
							{textBoxA, textBoxB, textBoxC, textBoxD, textBoxE};
						fTextBoxes = new System.Windows.Forms.TextBox [5]
							{textBoxfA, textBoxfB, textBoxfC, textBoxfD, textBoxfE};
						break;
					}
					case true:
					{
						title = titleRTFBox;
						textBoxes = new System.Windows.Forms.RichTextBox [5] 
							{rtfBoxA, rtfBoxB, rtfBoxC, rtfBoxD, rtfBoxE};
						fTextBoxes = new System.Windows.Forms.RichTextBox [5]
							{rtfBoxfA, rtfBoxfB, rtfBoxfC, rtfBoxfD, rtfBoxfE};
						break;
					}
				}
				State = State;

				// Restore the text and center it if need be.
				title.Text = titleText;
				for (int i = 0; i < textBoxes.Length; i++) 
				{
					textBoxes [i].Text = text [i];
				}
				for (int i = 0; i < fTextBoxes.Length; i++) 
				{
					fTextBoxes [i].Text = fText [i];
				}
				if (richText) 
				{
					titleRTFBox.SelectAll ();
					titleRTFBox.SelectionAlignment = 
						System.Windows.Forms.HorizontalAlignment.Center;
					foreach (System.Windows.Forms.RichTextBox r in textBoxes) 
					{
						r.SelectAll ();
						r.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
					}
					foreach (System.Windows.Forms.RichTextBox r in fTextBoxes) 
					{
						r.SelectAll ();
						r.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
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
						break;
					}
					case CardSlotState.ReadOnly:
					{
						SetEditable (false);
						SetLoaded (true);
						cornerPanel.Visible = true;
						break;
					}
					case CardSlotState.ReadWrite:
					{
						SetEditable (false);
						SetLoaded (true);
						cornerPanel.Visible = false;
						break;
					}
					case CardSlotState.Editable:
					{
						SetEditable (true);
						SetLoaded (true);
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
					textBoxes [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), textBoxes [i].Location.Y);
					textBoxes [i].Size = new System.Drawing.Size (value, textBoxes [i].Size.Height);
				}
				for (int i = 0; i < fTextBoxes.Length; i++)  
				{
					fTextBoxes [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), fTextBoxes [i].Location.Y);
					fTextBoxes [i].Size = new System.Drawing.Size (value, fTextBoxes [i].Size.Height);
				}
				for (int i = 0; i < labels.Length; i++)  
				{
					labels [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), labels [i].Location.Y);
					labels [i].Size = new System.Drawing.Size (value, labels [i].Size.Height);
				}
			}
		}

		public string Title
		{
			get
			{
				return title.Text;
			}
			set
			{
				title.Text = value;
			}
		}

		#endregion

	}
}
