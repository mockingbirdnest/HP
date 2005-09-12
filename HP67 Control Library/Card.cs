using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HP67_Control_Library
{
	/// <summary>
	/// A card shown on the card window of the HP67 calculator.
	/// </summary>
	public class Card : System.Windows.Forms.UserControl
	{
		public enum Column 
		{
			A,
			B,
			C,
			D,
			E
		}

		public enum State
		{
			Unloaded,
			ReadOnly,
			ReadWrite,
			Editable
		}

		#region Private Data

		private const float sizeIncrease = 1.25F;

		private System.Drawing.Font font;
		private int textBoxWidth;
		private System.Drawing.Font largeFont;
		private int margin;
		private State state;

		private System.Windows.Forms.Label [] labels;
		private System.Windows.Forms.TextBox [] textBoxs;
		private System.Windows.Forms.TextBox [] fTextBoxs;

		internal System.Windows.Forms.Panel cornerPanel;
		internal System.Windows.Forms.Panel panel;
		internal System.Windows.Forms.TextBox titleTextBox;
		internal System.Windows.Forms.TextBox ATextBox;
		internal System.Windows.Forms.TextBox BTextBox;
		internal System.Windows.Forms.TextBox CTextBox;
		internal System.Windows.Forms.TextBox DTextBox;
		internal System.Windows.Forms.TextBox ETextBox;
		internal System.Windows.Forms.TextBox fATextBox;
		internal System.Windows.Forms.TextBox fBTextBox;
		internal System.Windows.Forms.TextBox fCTextBox;
		internal System.Windows.Forms.TextBox fDTextBox;
		internal System.Windows.Forms.TextBox fETextBox;
		internal System.Windows.Forms.Label ALabel;
		internal System.Windows.Forms.Label CLabel;
		internal System.Windows.Forms.Label BLabel;
		internal System.Windows.Forms.Label ELabel;
		internal System.Windows.Forms.Label DLabel;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructors & Destructors

		public Card()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			labels = new System.Windows.Forms.Label [5]
				{ALabel, BLabel, CLabel, DLabel, ELabel};
			textBoxs = new System.Windows.Forms.TextBox [5] 
				{ATextBox, BTextBox, CTextBox, DTextBox, ETextBox};
			fTextBoxs = new System.Windows.Forms.TextBox [5]
				{fATextBox, fBTextBox, fCTextBox, fDTextBox, fETextBox};

			Font = new System.Drawing.Font
				("Arial Unicode MS", 7.0F, System.Drawing.FontStyle.Regular);
			TextBoxWidth = 48;
			CardState = State.Unloaded;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Card));
			this.panel = new System.Windows.Forms.Panel();
			this.ELabel = new System.Windows.Forms.Label();
			this.DLabel = new System.Windows.Forms.Label();
			this.BLabel = new System.Windows.Forms.Label();
			this.CLabel = new System.Windows.Forms.Label();
			this.ALabel = new System.Windows.Forms.Label();
			this.titleTextBox = new System.Windows.Forms.TextBox();
			this.cornerPanel = new System.Windows.Forms.Panel();
			this.ATextBox = new System.Windows.Forms.TextBox();
			this.BTextBox = new System.Windows.Forms.TextBox();
			this.CTextBox = new System.Windows.Forms.TextBox();
			this.DTextBox = new System.Windows.Forms.TextBox();
			this.ETextBox = new System.Windows.Forms.TextBox();
			this.fATextBox = new System.Windows.Forms.TextBox();
			this.fBTextBox = new System.Windows.Forms.TextBox();
			this.fETextBox = new System.Windows.Forms.TextBox();
			this.fCTextBox = new System.Windows.Forms.TextBox();
			this.fDTextBox = new System.Windows.Forms.TextBox();
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
			this.panel.Controls.Add(this.ELabel);
			this.panel.Controls.Add(this.DLabel);
			this.panel.Controls.Add(this.BLabel);
			this.panel.Controls.Add(this.CLabel);
			this.panel.Controls.Add(this.ALabel);
			this.panel.Controls.Add(this.titleTextBox);
			this.panel.Controls.Add(this.cornerPanel);
			this.panel.Controls.Add(this.ATextBox);
			this.panel.Controls.Add(this.BTextBox);
			this.panel.Controls.Add(this.CTextBox);
			this.panel.Controls.Add(this.DTextBox);
			this.panel.Controls.Add(this.ETextBox);
			this.panel.Controls.Add(this.fATextBox);
			this.panel.Controls.Add(this.fBTextBox);
			this.panel.Controls.Add(this.fETextBox);
			this.panel.Controls.Add(this.fCTextBox);
			this.panel.Controls.Add(this.fDTextBox);
			this.panel.ForeColor = System.Drawing.Color.Gold;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(300, 50);
			this.panel.TabIndex = 0;
			// 
			// ELabel
			// 
			this.ELabel.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ELabel.ForeColor = System.Drawing.Color.White;
			this.ELabel.Location = new System.Drawing.Point(240, 26);
			this.ELabel.Name = "ELabel";
			this.ELabel.Size = new System.Drawing.Size(48, 18);
			this.ELabel.TabIndex = 16;
			this.ELabel.Text = "x⇄y";
			this.ELabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// DLabel
			// 
			this.DLabel.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DLabel.ForeColor = System.Drawing.Color.White;
			this.DLabel.Location = new System.Drawing.Point(184, 26);
			this.DLabel.Name = "DLabel";
			this.DLabel.Size = new System.Drawing.Size(48, 18);
			this.DLabel.TabIndex = 15;
			this.DLabel.Text = "R↓";
			this.DLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// BLabel
			// 
			this.BLabel.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BLabel.ForeColor = System.Drawing.Color.White;
			this.BLabel.Location = new System.Drawing.Point(72, 26);
			this.BLabel.Name = "BLabel";
			this.BLabel.Size = new System.Drawing.Size(48, 18);
			this.BLabel.TabIndex = 14;
			this.BLabel.Text = "√x̅";
			this.BLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// CLabel
			// 
			this.CLabel.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CLabel.ForeColor = System.Drawing.Color.White;
			this.CLabel.Location = new System.Drawing.Point(124, 26);
			this.CLabel.Name = "CLabel";
			this.CLabel.Size = new System.Drawing.Size(48, 18);
			this.CLabel.TabIndex = 13;
			this.CLabel.Text = "yˣ";
			this.CLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// ALabel
			// 
			this.ALabel.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ALabel.ForeColor = System.Drawing.Color.White;
			this.ALabel.Location = new System.Drawing.Point(16, 26);
			this.ALabel.Name = "ALabel";
			this.ALabel.Size = new System.Drawing.Size(48, 18);
			this.ALabel.TabIndex = 12;
			this.ALabel.Text = "1/x";
			this.ALabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
			// ATextBox
			// 
			this.ATextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.ATextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ATextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ATextBox.ForeColor = System.Drawing.Color.White;
			this.ATextBox.Location = new System.Drawing.Point(16, 32);
			this.ATextBox.Name = "ATextBox";
			this.ATextBox.Size = new System.Drawing.Size(48, 13);
			this.ATextBox.TabIndex = 7;
			this.ATextBox.Text = "A";
			this.ATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// BTextBox
			// 
			this.BTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.BTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.BTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BTextBox.ForeColor = System.Drawing.Color.White;
			this.BTextBox.Location = new System.Drawing.Point(72, 32);
			this.BTextBox.Name = "BTextBox";
			this.BTextBox.Size = new System.Drawing.Size(48, 13);
			this.BTextBox.TabIndex = 8;
			this.BTextBox.Text = "B";
			this.BTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// CTextBox
			// 
			this.CTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.CTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.CTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CTextBox.ForeColor = System.Drawing.Color.White;
			this.CTextBox.Location = new System.Drawing.Point(128, 32);
			this.CTextBox.Name = "CTextBox";
			this.CTextBox.Size = new System.Drawing.Size(48, 13);
			this.CTextBox.TabIndex = 9;
			this.CTextBox.Text = "C";
			this.CTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// DTextBox
			// 
			this.DTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.DTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DTextBox.ForeColor = System.Drawing.Color.White;
			this.DTextBox.Location = new System.Drawing.Point(184, 32);
			this.DTextBox.Name = "DTextBox";
			this.DTextBox.Size = new System.Drawing.Size(48, 13);
			this.DTextBox.TabIndex = 10;
			this.DTextBox.Text = "D";
			this.DTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ETextBox
			// 
			this.ETextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.ETextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ETextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ETextBox.ForeColor = System.Drawing.Color.White;
			this.ETextBox.Location = new System.Drawing.Point(240, 32);
			this.ETextBox.Name = "ETextBox";
			this.ETextBox.Size = new System.Drawing.Size(48, 13);
			this.ETextBox.TabIndex = 11;
			this.ETextBox.Text = "E";
			this.ETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// fATextBox
			// 
			this.fATextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.fATextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fATextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fATextBox.ForeColor = System.Drawing.Color.Gold;
			this.fATextBox.Location = new System.Drawing.Point(16, 18);
			this.fATextBox.Name = "fATextBox";
			this.fATextBox.Size = new System.Drawing.Size(48, 13);
			this.fATextBox.TabIndex = 2;
			this.fATextBox.Text = "fA";
			this.fATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// fBTextBox
			// 
			this.fBTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.fBTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fBTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fBTextBox.ForeColor = System.Drawing.Color.Gold;
			this.fBTextBox.Location = new System.Drawing.Point(72, 18);
			this.fBTextBox.Name = "fBTextBox";
			this.fBTextBox.Size = new System.Drawing.Size(48, 13);
			this.fBTextBox.TabIndex = 3;
			this.fBTextBox.Text = "fB";
			this.fBTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// fETextBox
			// 
			this.fETextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.fETextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fETextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fETextBox.ForeColor = System.Drawing.Color.Gold;
			this.fETextBox.Location = new System.Drawing.Point(240, 18);
			this.fETextBox.Name = "fETextBox";
			this.fETextBox.Size = new System.Drawing.Size(48, 13);
			this.fETextBox.TabIndex = 6;
			this.fETextBox.Text = "fE";
			this.fETextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// fCTextBox
			// 
			this.fCTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.fCTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fCTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fCTextBox.ForeColor = System.Drawing.Color.Gold;
			this.fCTextBox.Location = new System.Drawing.Point(128, 18);
			this.fCTextBox.Name = "fCTextBox";
			this.fCTextBox.Size = new System.Drawing.Size(48, 13);
			this.fCTextBox.TabIndex = 4;
			this.fCTextBox.Text = "fC";
			this.fCTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// fDTextBox
			// 
			this.fDTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.fDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fDTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fDTextBox.ForeColor = System.Drawing.Color.Gold;
			this.fDTextBox.Location = new System.Drawing.Point(184, 18);
			this.fDTextBox.Name = "fDTextBox";
			this.fDTextBox.Size = new System.Drawing.Size(48, 13);
			this.fDTextBox.TabIndex = 5;
			this.fDTextBox.Text = "fD";
			this.fDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Card
			// 
			this.Controls.Add(this.panel);
			this.Name = "Card";
			this.Size = new System.Drawing.Size(300, 50);
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Operations

		private void SetEditable (bool editable)
		{
			titleTextBox.ReadOnly = !editable;
			foreach (System.Windows.Forms.TextBox t in textBoxs)  
			{
				t.ReadOnly = !editable;
			}
			foreach (System.Windows.Forms.TextBox t in fTextBoxs)  
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

		private void SetLoaded (bool editable)
		{
			if (editable) 
			{
				panel.BackColor = System.Drawing.Color.FromArgb (64, 64, 0);
				titleTextBox.Visible = true;
				foreach (System.Windows.Forms.TextBox t in textBoxs)  
				{
					t.Visible = true;
				}
				foreach (System.Windows.Forms.TextBox t in fTextBoxs)  
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
				foreach (System.Windows.Forms.TextBox t in textBoxs)  
				{
					t.Visible = false;
				}
				foreach (System.Windows.Forms.TextBox t in fTextBoxs)  
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

		public State CardState 
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
					case State.Unloaded:
					{
						SetEditable (false);
						SetLoaded (false);
						break;
					}
					case State.ReadOnly:
					{
						SetEditable (false);
						SetLoaded (true);
						cornerPanel.Visible = true;
						break;
					}
					case State.ReadWrite:
					{
						SetEditable (false);
						SetLoaded (true);
						cornerPanel.Visible = false;
						break;
					}
					case State.Editable:
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
				foreach (System.Windows.Forms.TextBox t in textBoxs)  
				{
					t.Font = font;
				}
				foreach (System.Windows.Forms.TextBox t in fTextBoxs)
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
