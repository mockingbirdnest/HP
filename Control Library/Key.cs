﻿using System;
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
	/// A Key on the keyboard of the HP67 calculator.
	/// </summary>
	public class Key : UserControl
	{

		#region Private Data

		private const double brightnessReduction = 0.78;
		private const int labelsHeight = 27; // This cannot be easily calculated because of overlap.
		private const float sizeReduction = 0.85F;

		private Color fgBackColor;
		private TextAlign fgTextAlign;
		private int fgWidth;
		private Font font;
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

		public Key()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

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

			Font = new Font ("Arial Unicode MS", 8.5F, FontStyle.Bold);

			AutoSize ();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if ( disposing )
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
			this.gLabel = new System.Windows.Forms.Label();
			this.fLabel = new System.Windows.Forms.Label();
			this.button = new System.Windows.Forms.Button();
			this.hButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// gLabel
			// 
			this.gLabel.BackColor = Color.Transparent;
			this.gLabel.Font = new Font("Arial Unicode MS", 8.5F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
			this.gLabel.ForeColor = Color.SkyBlue;
			this.gLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.gLabel.Location = new Point(75, 86);
			this.gLabel.Name = "gLabel";
			this.gLabel.Size = new Size(24, 15);
			this.gLabel.TabIndex = 4;
			this.gLabel.Text = "g";
			// 
			// fLabel
			// 
			this.fLabel.BackColor = Color.Transparent;
			this.fLabel.Font = new Font("Arial Unicode MS", 8.5F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
			this.fLabel.ForeColor = Color.Gold;
			this.fLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.fLabel.Location = new Point(51, 86);
			this.fLabel.Name = "fLabel";
			this.fLabel.Size = new Size(24, 15);
			this.fLabel.TabIndex = 3;
			this.fLabel.Text = "f";
			this.fLabel.TextAlign = ContentAlignment.TopRight;
			// 
			// button
			// 
			this.button.BackColor = Color.Olive;
			this.button.Font = new Font("Arial Unicode MS", 8.5F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
			this.button.ForeColor = Color.White;
			this.button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button.Location = new Point(51, 50);
			this.button.Name = "button";
			this.button.Size = new Size(48, 24);
			this.button.TabIndex = 1;
			this.button.Tag = "34";
			this.button.Text = "key";
			this.button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_MouseUp);
			this.button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_MouseDown);
			// 
			// hButton
			// 
			this.hButton.BackColor = Color.Olive;
			this.hButton.Font = new Font("Arial Unicode MS", 7F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
			this.hButton.Location = new Point(51, 71);
			this.hButton.Name = "hButton";
			this.hButton.Size = new Size(48, 18);
			this.hButton.TabIndex = 2;
			this.hButton.Text = "h";
			this.hButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hButton_MouseUp);
			this.hButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hButton_MouseDown);
			// 
			// Key
			// 
			this.Controls.Add(this.gLabel);
			this.Controls.Add(this.fLabel);
			this.Controls.Add(this.button);
			this.Controls.Add(this.hButton);
			this.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "Key";
			this.Resize += new System.EventHandler(this.Key_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		#region Event Handlers

		private void Key_Resize (object sender, System.EventArgs e)
		{
			Control control = (Control) sender;
        
			FGWidth = control.Size.Width;
			MainWidth = control.Size.Width;
			MainHeight = control.Size.Height - labelsHeight;
		}

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

		#region Private Methods

		private void AutoSize ()
		{
			int x = Math.Min (button.Location.X, fLabel.Location.X);
			int y = button.Location.Y;

			button.Location = new Point
				(button.Location.X - x, button.Location.Y - y);
			hButton.Location = new Point
				(hButton.Location.X - x, hButton.Location.Y - y);
			fLabel.Location = new Point
				(fLabel.Location.X - x, fLabel.Location.Y - y);
			gLabel.Location = new Point
				(gLabel.Location.X - x, gLabel.Location.Y - y);

			this.Size = new Size (Math.Max (mainWidth, fgWidth),
											   fLabel.Location.Y + fLabel.Size.Height);
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
					((int)(((float)fgWidth - ΔWidth - (float)spacing) / 2.0),
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
				}
				else 
				{
					fLabel.Size = new Size (fLabel.Size.Width + ΔWidth,
														   fLabel.Size.Height);
				}
				gLabel.Size = new Size (gLabel.Size.Width + ΔWidth / 2,
													   gLabel.Size.Height);

				AutoSize ();
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
				Font smallFont =
					new Font
						(value.Name,
						value.SizeInPoints * sizeReduction,
						value.Style);

				font = value;
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
					CenterFG();
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
					switch (fgTextAlign) {
						case TextAlign.Centered :
						{
							CenterFG ();
							break;
						}
						case TextAlign.Justified :
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
					CenterFG();
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
					((int)((double)mainBackColor.R * brightnessReduction),
					(int)((double)mainBackColor.G * brightnessReduction),
					(int)((double)mainBackColor.B * brightnessReduction));
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
				button.Location =
					new Point (button.Location.X, button.Location.Y - ΔHeight);
				this.Size = new Size (this.Size.Width, mainHeight + labelsHeight);
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

				AutoSize ();
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