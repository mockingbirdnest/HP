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

		#region Private Data

		private const float sizeIncrease = 1.25F;

		private System.Drawing.Font font;
		private int labelWidth;
		private System.Drawing.Font largeFont;
		private bool loaded;
		private int margin;
		private bool readOnly;

		private System.Windows.Forms.Label [] labels;
		private System.Windows.Forms.Label [] fLabels;

		internal System.Windows.Forms.Panel cornerPanel;
		internal System.Windows.Forms.Panel panel;
		internal System.Windows.Forms.Label titleLabel;
		internal System.Windows.Forms.Label ALabel;
		internal System.Windows.Forms.Label BLabel;
		internal System.Windows.Forms.Label CLabel;
		internal System.Windows.Forms.Label DLabel;
		internal System.Windows.Forms.Label ELabel;
		internal System.Windows.Forms.Label fALabel;
		internal System.Windows.Forms.Label fBLabel;
		internal System.Windows.Forms.Label fCLabel;
		internal System.Windows.Forms.Label fDLabel;
		internal System.Windows.Forms.Label fELabel;

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
			fLabels = new System.Windows.Forms.Label [5]
				{fALabel, fBLabel, fCLabel, fDLabel, fELabel};

			loaded = false;
			Font = new System.Drawing.Font
				("Arial Unicode MS", 7.0F, System.Drawing.FontStyle.Regular);
			LabelWidth = 48;
			Loaded = loaded;
			Margin = 16;
			ReadOnly = true;
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
			this.BLabel = new System.Windows.Forms.Label();
			this.ELabel = new System.Windows.Forms.Label();
			this.CLabel = new System.Windows.Forms.Label();
			this.DLabel = new System.Windows.Forms.Label();
			this.ALabel = new System.Windows.Forms.Label();
			this.fBLabel = new System.Windows.Forms.Label();
			this.fELabel = new System.Windows.Forms.Label();
			this.fCLabel = new System.Windows.Forms.Label();
			this.fDLabel = new System.Windows.Forms.Label();
			this.fALabel = new System.Windows.Forms.Label();
			this.titleLabel = new System.Windows.Forms.Label();
			this.cornerPanel = new System.Windows.Forms.Panel();
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
			this.panel.Controls.Add(this.fBLabel);
			this.panel.Controls.Add(this.fELabel);
			this.panel.Controls.Add(this.fCLabel);
			this.panel.Controls.Add(this.fDLabel);
			this.panel.Controls.Add(this.fALabel);
			this.panel.Controls.Add(this.titleLabel);
			this.panel.Controls.Add(this.cornerPanel);
			this.panel.Controls.Add(this.ALabel);
			this.panel.Controls.Add(this.BLabel);
			this.panel.Controls.Add(this.CLabel);
			this.panel.Controls.Add(this.DLabel);
			this.panel.Controls.Add(this.ELabel);
			this.panel.ForeColor = System.Drawing.Color.Gold;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(300, 50);
			this.panel.TabIndex = 0;
			// 
			// BLabel
			// 
			this.BLabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BLabel.ForeColor = System.Drawing.Color.White;
			this.BLabel.Location = new System.Drawing.Point(72, 26);
			this.BLabel.Name = "BLabel";
			this.BLabel.Size = new System.Drawing.Size(48, 20);
			this.BLabel.TabIndex = 8;
			this.BLabel.Text = "B";
			this.BLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// ELabel
			// 
			this.ELabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ELabel.ForeColor = System.Drawing.Color.White;
			this.ELabel.Location = new System.Drawing.Point(240, 26);
			this.ELabel.Name = "ELabel";
			this.ELabel.Size = new System.Drawing.Size(48, 20);
			this.ELabel.TabIndex = 11;
			this.ELabel.Text = "E";
			this.ELabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// CLabel
			// 
			this.CLabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CLabel.ForeColor = System.Drawing.Color.White;
			this.CLabel.Location = new System.Drawing.Point(128, 26);
			this.CLabel.Name = "CLabel";
			this.CLabel.Size = new System.Drawing.Size(48, 20);
			this.CLabel.TabIndex = 9;
			this.CLabel.Text = "C";
			this.CLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// DLabel
			// 
			this.DLabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DLabel.ForeColor = System.Drawing.Color.White;
			this.DLabel.Location = new System.Drawing.Point(184, 26);
			this.DLabel.Name = "DLabel";
			this.DLabel.Size = new System.Drawing.Size(48, 20);
			this.DLabel.TabIndex = 10;
			this.DLabel.Text = "D";
			this.DLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// ALabel
			// 
			this.ALabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ALabel.ForeColor = System.Drawing.Color.White;
			this.ALabel.Location = new System.Drawing.Point(16, 26);
			this.ALabel.Name = "ALabel";
			this.ALabel.Size = new System.Drawing.Size(48, 20);
			this.ALabel.TabIndex = 7;
			this.ALabel.Text = "A";
			this.ALabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// fBLabel
			// 
			this.fBLabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fBLabel.ForeColor = System.Drawing.Color.Gold;
			this.fBLabel.Location = new System.Drawing.Point(72, 24);
			this.fBLabel.Name = "fBLabel";
			this.fBLabel.Size = new System.Drawing.Size(48, 8);
			this.fBLabel.TabIndex = 3;
			this.fBLabel.Text = "fB";
			this.fBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fELabel
			// 
			this.fELabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fELabel.ForeColor = System.Drawing.Color.Gold;
			this.fELabel.Location = new System.Drawing.Point(240, 24);
			this.fELabel.Name = "fELabel";
			this.fELabel.Size = new System.Drawing.Size(48, 8);
			this.fELabel.TabIndex = 6;
			this.fELabel.Text = "fE";
			this.fELabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fCLabel
			// 
			this.fCLabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fCLabel.ForeColor = System.Drawing.Color.Gold;
			this.fCLabel.Location = new System.Drawing.Point(128, 24);
			this.fCLabel.Name = "fCLabel";
			this.fCLabel.Size = new System.Drawing.Size(48, 8);
			this.fCLabel.TabIndex = 4;
			this.fCLabel.Text = "fC";
			this.fCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fDLabel
			// 
			this.fDLabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fDLabel.ForeColor = System.Drawing.Color.Gold;
			this.fDLabel.Location = new System.Drawing.Point(184, 24);
			this.fDLabel.Name = "fDLabel";
			this.fDLabel.Size = new System.Drawing.Size(48, 8);
			this.fDLabel.TabIndex = 5;
			this.fDLabel.Text = "fD";
			this.fDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fALabel
			// 
			this.fALabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.fALabel.ForeColor = System.Drawing.Color.Gold;
			this.fALabel.Location = new System.Drawing.Point(16, 24);
			this.fALabel.Name = "fALabel";
			this.fALabel.Size = new System.Drawing.Size(48, 8);
			this.fALabel.TabIndex = 2;
			this.fALabel.Text = "fA";
			this.fALabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// titleLabel
			// 
			this.titleLabel.Font = new System.Drawing.Font("Arial Unicode MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.Color.White;
			this.titleLabel.Location = new System.Drawing.Point(16, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(180, 8);
			this.titleLabel.TabIndex = 1;
			this.titleLabel.Text = "TITLE";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cornerPanel
			// 
			this.cornerPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cornerPanel.BackgroundImage")));
			this.cornerPanel.Location = new System.Drawing.Point(0, 0);
			this.cornerPanel.Name = "cornerPanel";
			this.cornerPanel.Size = new System.Drawing.Size(15, 15);
			this.cornerPanel.TabIndex = 0;
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
				titleLabel.Font = font;
				foreach (System.Windows.Forms.Label l in labels)  
				{
					if (loaded) 
					{
						l.Font = font;
					}
					else
					{
						l.Font = largeFont;
					}
				}
				foreach (System.Windows.Forms.Label l in fLabels)
				{
					l.Font = font;
				}
			}
		}

		public int LabelWidth
		{
			get
			{
				return labelWidth;
			}
			set
			{
				int spacing = (this.Size.Width - 2 * margin - 5 * value) / 4;

				labelWidth = value;
				for (int i = 0; i < labels.Length; i++)  
				{
					labels [i].Location = new System.Drawing.Point
						(margin + i * (labelWidth + spacing), labels [i].Location.Y);
					labels [i].Size = new System.Drawing.Size (value, labels [i].Size.Height);
				}
				for (int i = 0; i < fLabels.Length; i++)  
				{
					fLabels [i].Location = new System.Drawing.Point
						(margin + i * (labelWidth + spacing), fLabels [i].Location.Y);
					fLabels [i].Size = new System.Drawing.Size (value, fLabels [i].Size.Height);
				}
			}
		}

		public bool Loaded
		{
			get
			{
				return loaded;
			}
			set
			{
				loaded = value;
				if (loaded) 
				{
					ReadOnly = readOnly;
					panel.BackColor = System.Drawing.Color.FromArgb (64, 64, 0);
					titleLabel.Visible = true;
					foreach (System.Windows.Forms.Label l in fLabels)  
					{
						l.Visible = true;
					}
					foreach (System.Windows.Forms.Label l in labels)  
					{
						l.Font = font;
					}
					ALabel.Text = "A";
					BLabel.Text = "B";
					CLabel.Text = "C";
					DLabel.Text = "D";
					ELabel.Text = "E";
				}
				else
				{
					cornerPanel.Visible = false;
					panel.BackColor = System.Drawing.Color.FromArgb (64, 64, 64);
					titleLabel.Visible = false;
					foreach (System.Windows.Forms.Label l in fLabels)  
					{
						l.Visible = false;
					}
					foreach (System.Windows.Forms.Label l in labels)  
					{
						l.Font = largeFont;
					}
					ALabel.Text = "1/x";
					BLabel.Text = "√x̅";
					CLabel.Text = "yˣ";
					DLabel.Text = "R↓";
					ELabel.Text = "x⇄y";
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
				int spacing = (this.Size.Width - 2 * value - 5 * labelWidth) / 4;

				margin = value;
				for (int i = 0; i < labels.Length; i++)  
				{
					labels [i].Location = new System.Drawing.Point
						(margin + i * (labelWidth + spacing), labels [i].Location.Y);
				}
				for (int i = 0; i < fLabels.Length; i++)  
				{
					fLabels [i].Location = new System.Drawing.Point
						(margin + i * (labelWidth + spacing), fLabels [i].Location.Y);
				}
			}
		}

		public bool ReadOnly
		{
			get
			{
				return readOnly;
			}
			set
			{
				readOnly = value;
				if (loaded) 
				{
					cornerPanel.Visible = readOnly;
				}
			}
		}

		public string Title
		{
			get
			{
				return titleLabel.Text;
			}
			set
			{
				titleLabel.Text = value;
			}
		}

		#endregion

	}
}
