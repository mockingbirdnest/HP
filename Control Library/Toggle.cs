using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HP67_Control_Library
{
	public enum TogglePosition 
	{
		Left,
		Right
	}

	/// <summary>
	/// Sliding switch to toggle between modes of the HP67 calculator.
	/// </summary>
	public class Toggle : System.Windows.Forms.UserControl
	{

		#region Private Data

		private const int marginWidth = 2;
		private const double reductionFactor = 0.4;

		private System.Drawing.Color backColor;
		private System.Drawing.Font font;
		private System.Drawing.Color foreColor;
		private TogglePosition position;

		internal System.Windows.Forms.Button button;
		internal System.Windows.Forms.Label rightLabel;
		internal System.Windows.Forms.Label leftLabel;
		internal System.Windows.Forms.Panel panel;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		#region Event Definitions

		public delegate void ToggleClickEvent
			(object sender, System.EventArgs e, TogglePosition position);
		public event ToggleClickEvent ToggleClick;

		#endregion

		#region Constructors & Destructors

		public Toggle()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			position = TogglePosition.Left;

			LeftWidth = 60;
			RightWidth = 60;
			MainWidth = 60;

			RightText = "right";
			LeftText = "left";

			rightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			leftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

			BackColor = System.Drawing.Color.FromArgb (64, 64, 64);
			ForeColor = System.Drawing.Color.FromKnownColor
				(System.Drawing.KnownColor.White);

			Font = new System.Drawing.Font ("Arial Unicode MS", 8.5F, System.Drawing.FontStyle.Bold);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose (bool disposing)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Toggle));
			this.button = new System.Windows.Forms.Button();
			this.rightLabel = new System.Windows.Forms.Label();
			this.leftLabel = new System.Windows.Forms.Label();
			this.panel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// button
			// 
			this.button.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(50)), ((System.Byte)(50)), ((System.Byte)(50)));
			this.button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button.BackgroundImage")));
			this.button.Location = new System.Drawing.Point(58, 4);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(24, 8);
			this.button.TabIndex = 5;
			this.button.Click += new System.EventHandler(this.button_Click);
			// 
			// rightLabel
			// 
			this.rightLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.rightLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rightLabel.ForeColor = System.Drawing.Color.White;
			this.rightLabel.Location = new System.Drawing.Point(120, 0);
			this.rightLabel.Name = "rightLabel";
			this.rightLabel.Size = new System.Drawing.Size(56, 16);
			this.rightLabel.TabIndex = 4;
			// 
			// leftLabel
			// 
			this.leftLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.leftLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.leftLabel.ForeColor = System.Drawing.Color.White;
			this.leftLabel.Location = new System.Drawing.Point(0, 0);
			this.leftLabel.Name = "leftLabel";
			this.leftLabel.Size = new System.Drawing.Size(56, 16);
			this.leftLabel.TabIndex = 1;
			this.leftLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.Color.Black;
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel.Location = new System.Drawing.Point(56, 2);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(64, 12);
			this.panel.TabIndex = 6;
			// 
			// Toggle
			// 
			this.Controls.Add(this.button);
			this.Controls.Add(this.rightLabel);
			this.Controls.Add(this.leftLabel);
			this.Controls.Add(this.panel);
			this.Name = "Toggle";
			this.Size = new System.Drawing.Size(192, 24);
			this.ResumeLayout(false);

		}
		#endregion

		#region Event Handlers

		private void button_Click(object sender, System.EventArgs e)
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
			if (ToggleClick != null) 
			{
				ToggleClick (sender, e, position);
			}
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
				rightLabel.BackColor = backColor;
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
				leftLabel.Font = font;
				rightLabel.Font = font;
			}
		}

		public override System.Drawing.Color ForeColor
		{
			get
			{
				return foreColor;
			}
			set 
			{
				foreColor = value;
				leftLabel.ForeColor = foreColor;
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

				leftLabel.Size = new System.Drawing.Size (value, leftLabel.Size.Height);
				button.Location = new System.Drawing.Point
					(button.Location.X + ΔWidth, button.Location.Y);
				panel.Location = new System.Drawing.Point
					(panel.Location.X + ΔWidth, panel.Location.Y);
				rightLabel.Location = new System.Drawing.Point
					(rightLabel.Location.X + ΔWidth, rightLabel.Location.Y);

				AutoSize ();
			}
		}

		public int MainWidth
		{
			get
			{
				return panel.Size.Width;
			}
			set 
			{
				int ΔWidth = value - panel.Size.Width;

				panel.Size = new System.Drawing.Size (value, panel.Size.Height);
				button.Size = new System.Drawing.Size
					((int)(value * reductionFactor), button.Size.Height);
				if (position == TogglePosition.Right) 
				{
					button.Location = new System.Drawing.Point
						(panel.Location.X + panel.Size.Width - button.Size.Width - marginWidth,
						button.Location.Y);
				}
				rightLabel.Location = new System.Drawing.Point
					(rightLabel.Location.X + ΔWidth, rightLabel.Location.Y);

				AutoSize ();
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
				position = value;
				switch (position) 
				{
					case TogglePosition.Right:
					{
						button.Location = new System.Drawing.Point
							(panel.Location.X + panel.Size.Width - button.Size.Width - marginWidth,
							button.Location.Y);
						break;
					}
					case TogglePosition.Left:
					{
						button.Location = new System.Drawing.Point
							(panel.Location.X + marginWidth,
							button.Location.Y);
						break;
					}
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
				rightLabel.Size = new System.Drawing.Size (value, rightLabel.Size.Height);
				AutoSize ();
			}
		}

		#endregion

		#region Private Methods

		private void AutoSize ()
		{
			int x = leftLabel.Location.X;
			int y = leftLabel.Location.Y;

			leftLabel.Location = new System.Drawing.Point
				(leftLabel.Location.X - x, leftLabel.Location.Y - y);
			panel.Location = new System.Drawing.Point
				(panel.Location.X - x, panel.Location.Y - y);
			button.Location = new System.Drawing.Point
				(button.Location.X - x, button.Location.Y - y);
			rightLabel.Location = new System.Drawing.Point
				(rightLabel.Location.X - x, rightLabel.Location.Y - y);

			this.Size = new System.Drawing.Size 
				(leftLabel.Size.Width + panel.Size.Width + rightLabel.Size.Width,
				leftLabel.Location.Y + leftLabel.Size.Height);
		}

		#endregion

	}
}
