using System;
using System.Collections;
using System.ComponentModel;
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
		private System.Windows.Forms.Control [] textBoxs;
		private System.Windows.Forms.Control [] fTextBoxs;

		internal System.Windows.Forms.Panel cornerPanel;
		internal System.Windows.Forms.Panel panel;
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
		internal System.Windows.Forms.Label labelC;
		internal System.Windows.Forms.Label labelB;
		internal System.Windows.Forms.Label labelE;
		internal System.Windows.Forms.Label labelD;
		internal System.Windows.Forms.RichTextBox rtfBoxA;
		internal System.Windows.Forms.RichTextBox rtfBoxB;
		internal System.Windows.Forms.RichTextBox rtfBoxC;
		internal System.Windows.Forms.RichTextBox rtfBoxD;
		internal System.Windows.Forms.RichTextBox rtfBoxE;
		internal System.Windows.Forms.RichTextBox rtfBoxFA;
		internal System.Windows.Forms.RichTextBox rtfBoxFB;
		internal System.Windows.Forms.RichTextBox rtfBoxFC;
		internal System.Windows.Forms.RichTextBox rtfBoxFD;
		internal System.Windows.Forms.RichTextBox rtfBoxFE;

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

			labels = new System.Windows.Forms.Label [5]
				{labelA, labelB, labelC, labelD, labelE};
			textBoxs = new System.Windows.Forms.TextBox [5] 
				{textBoxA, textBoxB, textBoxC, textBoxD, textBoxE};
			fTextBoxs = new System.Windows.Forms.TextBox [5]
				{textBoxfA, textBoxfB, textBoxfC, textBoxfD, textBoxfE};

			Font = new System.Drawing.Font
				("Arial Unicode MS", 7.0F, System.Drawing.FontStyle.Regular);
			TextBoxWidth = 48;
			State = CardSlotState.Unloaded;
			RichText = true;
			RichText = false;
			Margin = 16;
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
			this.labelE = new System.Windows.Forms.Label();
			this.labelD = new System.Windows.Forms.Label();
			this.labelB = new System.Windows.Forms.Label();
			this.labelC = new System.Windows.Forms.Label();
			this.labelA = new System.Windows.Forms.Label();
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
			this.rtfBoxA = new System.Windows.Forms.RichTextBox();
			this.rtfBoxB = new System.Windows.Forms.RichTextBox();
			this.rtfBoxC = new System.Windows.Forms.RichTextBox();
			this.rtfBoxD = new System.Windows.Forms.RichTextBox();
			this.rtfBoxE = new System.Windows.Forms.RichTextBox();
			this.rtfBoxFA = new System.Windows.Forms.RichTextBox();
			this.rtfBoxFC = new System.Windows.Forms.RichTextBox();
			this.rtfBoxFD = new System.Windows.Forms.RichTextBox();
			this.rtfBoxFE = new System.Windows.Forms.RichTextBox();
			this.rtfBoxFB = new System.Windows.Forms.RichTextBox();
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
			this.panel.Controls.Add(this.rtfBoxFB);
			this.panel.Controls.Add(this.rtfBoxFE);
			this.panel.Controls.Add(this.rtfBoxFD);
			this.panel.Controls.Add(this.rtfBoxFC);
			this.panel.Controls.Add(this.rtfBoxFA);
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
			this.titleTextBox.Text = "TITLE";
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
			this.textBoxA.Text = "A";
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
			this.textBoxB.Text = "B";
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
			this.textBoxC.Text = "C";
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
			this.textBoxD.Text = "D";
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
			this.textBoxE.Text = "E";
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
			this.textBoxfA.Text = "fA";
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
			this.textBoxfB.Text = "fB";
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
			this.textBoxfE.Text = "fE";
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
			this.textBoxfC.Text = "fC";
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
			this.textBoxfD.Text = "fD";
			this.textBoxfD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.rtfBoxA.Text = "A";
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
			this.rtfBoxB.Text = "B";
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
			this.rtfBoxC.Text = "C";
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
			this.rtfBoxD.Text = "D";
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
			this.rtfBoxE.Text = "E";
			// 
			// rtfBoxFA
			// 
			this.rtfBoxFA.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxFA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxFA.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxFA.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxFA.Location = new System.Drawing.Point(16, 18);
			this.rtfBoxFA.Multiline = false;
			this.rtfBoxFA.Name = "rtfBoxFA";
			this.rtfBoxFA.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxFA.TabIndex = 22;
			this.rtfBoxFA.Text = "fA";
			// 
			// rtfBoxFC
			// 
			this.rtfBoxFC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxFC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxFC.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxFC.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxFC.Location = new System.Drawing.Point(128, 18);
			this.rtfBoxFC.Multiline = false;
			this.rtfBoxFC.Name = "rtfBoxFC";
			this.rtfBoxFC.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxFC.TabIndex = 23;
			this.rtfBoxFC.Text = "fC";
			// 
			// rtfBoxFD
			// 
			this.rtfBoxFD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxFD.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxFD.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxFD.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxFD.Location = new System.Drawing.Point(184, 18);
			this.rtfBoxFD.Multiline = false;
			this.rtfBoxFD.Name = "rtfBoxFD";
			this.rtfBoxFD.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxFD.TabIndex = 24;
			this.rtfBoxFD.Text = "fD";
			// 
			// rtfBoxFE
			// 
			this.rtfBoxFE.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxFE.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxFE.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxFE.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxFE.Location = new System.Drawing.Point(240, 18);
			this.rtfBoxFE.Multiline = false;
			this.rtfBoxFE.Name = "rtfBoxFE";
			this.rtfBoxFE.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxFE.TabIndex = 25;
			this.rtfBoxFE.Text = "fE";
			// 
			// rtfBoxFB
			// 
			this.rtfBoxFB.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rtfBoxFB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfBoxFB.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rtfBoxFB.ForeColor = System.Drawing.Color.Gold;
			this.rtfBoxFB.Location = new System.Drawing.Point(72, 18);
			this.rtfBoxFB.Multiline = false;
			this.rtfBoxFB.Name = "rtfBoxFB";
			this.rtfBoxFB.Size = new System.Drawing.Size(48, 13);
			this.rtfBoxFB.TabIndex = 26;
			this.rtfBoxFB.Text = "fB";
			// 
			// CardSlot
			// 
			this.Controls.Add(this.panel);
			this.Name = "CardSlot";
			this.Size = new System.Drawing.Size(300, 50);
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Operations

		private void SetEditable (bool editable)
		{
			titleTextBox.ReadOnly = !editable;
			foreach (System.Windows.Forms.TextBoxBase t in textBoxs)  
			{
				t.ReadOnly = !editable;
			}
			foreach (System.Windows.Forms.TextBoxBase t in fTextBoxs)  
			{
				t.ReadOnly = !editable;
			}
			if (editable) 
			{
				titleTextBox.Text = "<TITLE>";
				textBoxs [0].Text = "<A>";
				textBoxs [1].Text = "<B>";
				textBoxs [2].Text = "<C>";
				textBoxs [3].Text = "<D>";
				textBoxs [4].Text = "<E>";
				fTextBoxs [0].Text = "<fA>";
				fTextBoxs [1].Text = "<fB>";
				fTextBoxs [2].Text = "<fC>";
				fTextBoxs [3].Text = "<fD>";
				fTextBoxs [4].Text = "<fE>";
			}
		}

		private void SetLoaded (bool loaded)
		{
			if (loaded) 
			{
				panel.BackColor = System.Drawing.Color.FromArgb (64, 64, 0);
				titleTextBox.Visible = true;
				foreach (System.Windows.Forms.TextBoxBase t in textBoxs)  
				{
					t.Visible = true;
				}
				foreach (System.Windows.Forms.TextBoxBase t in fTextBoxs)  
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
				titleTextBox.Visible = false;
				foreach (System.Windows.Forms.TextBoxBase t in textBoxs)  
				{
					t.Visible = false;
				}
				foreach (System.Windows.Forms.TextBoxBase t in fTextBoxs)  
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

		public bool RichText 
		{
			get
			{
				return richText;
			}
			set
			{
				string [] text = new string [5];
				string [] fText = new string [5];

				richText = value;

				// Preserve the contents of the text boxes.
				for (int i = 0; i < textBoxs.Length; i++) 
				{
					textBoxs [i].Visible = false;
					text [i] = textBoxs [i].Text;
				}
				for (int i = 0; i < fTextBoxs.Length; i++) 
				{
					fTextBoxs [i].Visible = false;
					fText [i] = fTextBoxs [i].Text;
				}
				switch (richText) 
				{
					case false:
					{
						textBoxs = new System.Windows.Forms.TextBox [5] 
							{textBoxA, textBoxB, textBoxC, textBoxD, textBoxE};
						fTextBoxs = new System.Windows.Forms.TextBox [5]
							{textBoxfA, textBoxfB, textBoxfC, textBoxfD, textBoxfE};
						break;
					}
					case true:
					{
						textBoxs = new System.Windows.Forms.RichTextBox [5] 
							{rtfBoxA, rtfBoxB, rtfBoxC, rtfBoxD, rtfBoxE};
						fTextBoxs = new System.Windows.Forms.RichTextBox [5]
							{rtfBoxFA, rtfBoxFB, rtfBoxFC, rtfBoxFD, rtfBoxFE};
						break;
					}
				}
				State = State;

				// Finally, restore the text and center it if need be.
				for (int i = 0; i < textBoxs.Length; i++) 
				{
					textBoxs [i].Text = text [i];
				}
				for (int i = 0; i < fTextBoxs.Length; i++) 
				{
					fTextBoxs [i].Text = fText [i];
				}
				if (richText) 
				{
					foreach (System.Windows.Forms.RichTextBox r in textBoxs) 
					{
						r.SelectAll ();
						r.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
					}
					foreach (System.Windows.Forms.RichTextBox r in fTextBoxs) 
					{
						r.SelectAll ();
						r.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center;
					}
				}
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
				state = value;
				switch (state) 
				{
					case CardSlotState.Unloaded:
					{
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
			}
		}

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
				titleTextBox.Font = font;
				foreach (System.Windows.Forms.TextBoxBase t in textBoxs)  
				{
					t.Font = font;
				}
				foreach (System.Windows.Forms.TextBoxBase t in fTextBoxs)
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
				for (int i = 0; i < textBoxs.Length; i++)  
				{
					textBoxs [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), textBoxs [i].Location.Y);
				}
				for (int i = 0; i < fTextBoxs.Length; i++)  
				{
					fTextBoxs [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), fTextBoxs [i].Location.Y);
				}
				for (int i = 0; i < labels.Length; i++)  
				{
					labels [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), labels [i].Location.Y);
				}
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
				for (int i = 0; i < textBoxs.Length; i++)  
				{
					textBoxs [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), textBoxs [i].Location.Y);
					textBoxs [i].Size = new System.Drawing.Size (value, textBoxs [i].Size.Height);
				}
				for (int i = 0; i < fTextBoxs.Length; i++)  
				{
					fTextBoxs [i].Location = new System.Drawing.Point
						(margin + i * (textBoxWidth + spacing), fTextBoxs [i].Location.Y);
					fTextBoxs [i].Size = new System.Drawing.Size (value, fTextBoxs [i].Size.Height);
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
				return titleTextBox.Text;
			}
			set
			{
				titleTextBox.Text = value;
			}
		}

		#endregion

	}
}
