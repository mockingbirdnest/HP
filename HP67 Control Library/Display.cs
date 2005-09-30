using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace HP67_Control_Library
{
	public enum DisplayFormat
	{
		Engineering,
		Fixed,
		Scientific
	}

	/// <summary>
	/// The LED display for the HP67 calculator.
	/// </summary>
	public class Display : System.Windows.Forms.UserControl
	{

		#region Private Data

		private const int mantissaSignFirst = 0;
		private const int mantissaSignLength = 1;
		private const int mantissaFirst = 1;
		private const int mantissaLength = 11;
		private const int exponentSignFirst = 12;
		private const int exponentSignLength = 1;
		private const int exponentFirst = 13;
		private const int exponentLength = 2;
		private const double overflowLimit = 9.999999999E99;
		private const double underflowLimit = 1.0E-99;

		private double currentMantissa;
		private byte digits;
		private string engMantissaTemplate1;
		private string engMantissaTemplate10;
		private string engMantissaTemplate100;
		private string exponentTemplate = " 00;-00";
		private string fixMantissaTemplate;
		private string fixUnderflowOverflowMantissaTemplate = " 0.000000000;-0.000000000";
		private DisplayFormat format;
		private string negativeOverflow = "-9.999999999 99";
		private bool overflows;
		private double overflowValue;
		private string positiveOverflow = " 9.999999999 99";
		private string sciMantissaTemplate;

		internal System.Windows.Forms.TextBox textBox;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructors & Destructors

		public Display()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			Digits = 2;
			Format = DisplayFormat.Fixed;
			Value = 0.0;
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
					components.Dispose();
				}
			}
			base.Dispose (disposing);
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.BackColor = System.Drawing.Color.Black;
			this.textBox.Font = new System.Drawing.Font("Quartz", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox.ForeColor = System.Drawing.Color.Red;
			this.textBox.Location = new System.Drawing.Point(0, 0);
			this.textBox.Name = "textBox";
			this.textBox.ReadOnly = true;
			this.textBox.Size = new System.Drawing.Size(300, 40);
			this.textBox.TabIndex = 0;
			this.textBox.Text = "0.00";
			this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
			this.textBox.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
			// 
			// Display
			// 
			this.Controls.Add(this.textBox);
			this.Font = new System.Drawing.Font("Quartz", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.Red;
			this.Name = "Display";
			this.Size = new System.Drawing.Size(300, 40);
			this.Resize += new System.EventHandler(this.Display_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		#region Event Handlers

		private void Display_Resize(object sender, System.EventArgs e)
		{
			Control control = (Control)sender;
        
			if(control.Size.Height != 40)
			{
				control.Size = new Size(control.Size.Width, 40);
			}
		}

		// This stuff is intended to prevent selection of the text.  It doesn't work 100% of the
		// time, but it's good enough in practice.  At any rate, setting the Value property clean
		// things up.

		private void textBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			textBox.Enabled = false;
		}

		private void textBox_MouseLeave(object sender, System.EventArgs e)
		{
			textBox.Enabled = true;
		}

		#endregion

		#region Private Properties

		private sbyte Exponent 
		{
			get
			{
				string exponent = Text.Substring 
					(exponentSignFirst, exponentSignLength + exponentLength).Trim ();
				if (exponent.Length == 0) 
				{
					return 0;
				}
				else
				{
					return sbyte.Parse (exponent);
				}
			}
			set
			{
				if (value == 0 && format == DisplayFormat.Fixed) 
				{
					Text =
						Text.Substring (mantissaSignFirst, mantissaSignLength + mantissaLength) +
						new String (' ', exponentSignLength + exponentLength);
				}
				else
				{
					string exponent = value.ToString
						(exponentTemplate, NumberFormatInfo.InvariantInfo);

					Text =
						Text.Substring (mantissaSignFirst, mantissaSignLength + mantissaLength) +
						exponent;
				}
			}
		}

		private new string Text 
		{
			get
			{
				string s = textBox.Text;
				return s.PadRight (exponentFirst + exponentLength);
			}
			set
			{
				textBox.Text = value.PadRight (exponentFirst + exponentLength);
			}
		}

		#endregion

		#region Private Operations

		private void SetMantissa (double to, bool fixedUnderflowOverflow) 
		{
			string mantissa = "Useless initialization required by the compiler";
				
			switch (format) 
			{
				case DisplayFormat.Engineering:
				{
					double absTo = Math.Abs (to);

					if (absTo < 10.0) 
					{
						mantissa = to.ToString
							(engMantissaTemplate1, NumberFormatInfo.InvariantInfo);
					}
					else if (absTo < 100.0)
					{
						mantissa = to.ToString
							(engMantissaTemplate10, NumberFormatInfo.InvariantInfo);
					}
					else
					{
						Trace.Assert (absTo < 1000.0);
						mantissa = to.ToString
							(engMantissaTemplate100, NumberFormatInfo.InvariantInfo);
					}
					break;
				}
				case DisplayFormat.Fixed:
				{
					if (fixedUnderflowOverflow) 
					{
						mantissa = to.ToString
							(fixUnderflowOverflowMantissaTemplate, NumberFormatInfo.InvariantInfo);
					}
					else
					{
						mantissa = to.ToString
							(fixMantissaTemplate, NumberFormatInfo.InvariantInfo);
						mantissa = mantissa.Substring
							(mantissaSignFirst, mantissaSignLength + mantissaLength);
					};
					break;
				}
				case DisplayFormat.Scientific:
				{
					mantissa = to.ToString
						(sciMantissaTemplate, NumberFormatInfo.InvariantInfo);
					break;
				}
			}

			Text = 
				mantissa +
				Text.Substring (exponentSignFirst, exponentSignLength + exponentLength);
			currentMantissa = to;
		}

		#endregion

		#region Public Properties

		public byte Digits
		{
			set
			{
				string zeros;
				string blanks;

				Trace.Assert (value <= 9);
				digits = value;
				blanks = new String (' ', 9 - value);

				if (value == 0) 
				{
					// Make sure that we don't lose the period when the count is 0.
					fixMantissaTemplate = " 0\\." + blanks + ";-0\\." + blanks;
				}
				else 
				{
					zeros = new String ('0', value);
					fixMantissaTemplate = " 0." + zeros + blanks + ";-0." + zeros + blanks;
				}

				// Engineering is weird because the Digits is the total number of digits
				// displayed minus 1, regardless of the position of the decimal point.  Produce
				// three templates corresponding to the three orders of magnitude of the mantissa
				// in this format.
				if (value <= 1)
				{
					engMantissaTemplate10 = " 00\\." + blanks + ";-00\\." + blanks;
				}
				else 
				{
					zeros = new String ('0', value - 1);
					engMantissaTemplate10 = " 00." + zeros + blanks + ";-00." + zeros + blanks;					
				}

				if (value <= 2)
				{
					engMantissaTemplate100 = " 000\\." + blanks + ";-000\\." + blanks;
				}
				else 
				{
					zeros = new String ('0', value - 2);
					engMantissaTemplate100 = " 000." + zeros + blanks + ";-000." + zeros + blanks;					
				}

				engMantissaTemplate1 = fixMantissaTemplate;
				sciMantissaTemplate = fixMantissaTemplate;
				Value = Value;
			}
		}

		public DisplayFormat Format
		{
			set
			{
				format = value;
				Value = Value;
			}
		}

		public double Value 
		{
			get
			{
				if (overflows) 
				{
					return overflowValue;
				}
				else 
				{
					return currentMantissa * Math.Pow (10, Exponent);
				}
			}
			set
			{
				double absValue = Math.Abs (value);
				sbyte exponent;
				bool fixedUnderflowOverflow;
				double log10;
				double mantissa;

				// Not needed, unless the event handling mucked things up...
				textBox.Enabled = true;

				// Deal with possible underflow or overflow.
				overflows = false;
				if (absValue > overflowLimit) 
				{
					if (value > 0.0) 
					{
						Text = positiveOverflow;
						overflowValue = double.PositiveInfinity;
					}
					else 
					{
						Text = negativeOverflow;
						overflowValue = double.NegativeInfinity;
					}
					overflows = true;
					return;
				}

				if (absValue < underflowLimit)
				{
					exponent = 0;
					value = 0;
				}
				else
				{

					// Compute the exponent in base 10, so that the mantissa has one digit before
					// the decimal point.
					log10 = Math.Log10 (absValue);
					if (log10 >= 0.0) 
					{
						exponent = (sbyte) Math.Floor (log10);
					}
					else
					{
						exponent = (sbyte) (-Math.Ceiling (-log10));
					}
				}

				// Adjust the computed exponent based on the display format, and determine if the
				// fixed format underflows or overflows.
				fixedUnderflowOverflow = false;
				switch (format) 
				{
					case DisplayFormat.Engineering:
					{
						if (exponent % 3 != 0) 
						{
							exponent = (sbyte) (exponent - (exponent % 3) - (exponent >= 0 ? 0: 3));
						}
						break;
					}
					case DisplayFormat.Fixed:
					{
						if (exponent < -digits - 1 || exponent > 9) 
						{
							fixedUnderflowOverflow = true;
						}
						else if (exponent == -digits - 1) 
						{
							// A subtlety here.  If digits is, say, 2, the values ±0.005 round to
							// ±0.01, but the values ±0.004 underflow.
							if (absValue < 0.5 * Math.Pow (10, -digits)) 
							{
								fixedUnderflowOverflow = true;
							}
						}
						if (! fixedUnderflowOverflow)
						{
							exponent = 0;
						}
						break;
					}
					case DisplayFormat.Scientific:
					{
						break;
					}
				}

				// Display the appropriate exponent and mantissa using the current digit format and 
				// count.
				Exponent = exponent;
				mantissa = value / Math.Pow (10, exponent);
				SetMantissa (mantissa, fixedUnderflowOverflow);
			}
		}

		#endregion

	}
}
