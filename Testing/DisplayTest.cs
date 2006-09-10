using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Testing
{
	/// <summary>
	/// Summary description for DisplayTest.
	/// </summary>
	public class DisplayTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid PropertyGrid;
		private Mockingbird.HP.Control_Library.Display DisplayUnderTest;
        private Mockingbird.HP.Class_Library.Number.Formatter formatter;
        private Mockingbird.HP.Class_Library.Number.Validater validater;
		private System.Windows.Forms.NumericUpDown numericUpDown;
		private System.Windows.Forms.Label labelDigits;
		private System.Windows.Forms.RadioButton radioButtonScientific;
		private System.Windows.Forms.RadioButton radioButtonFixed;
		private System.Windows.Forms.RadioButton radioButtonEngineering;
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.Button digit7;
		private System.Windows.Forms.Button digit8;
		private System.Windows.Forms.Button digit5;
		private System.Windows.Forms.Button digit4;
		private System.Windows.Forms.Button digit9;
		private System.Windows.Forms.Button period;
		private System.Windows.Forms.Button digit0;
		private System.Windows.Forms.Button digit1;
		private System.Windows.Forms.Button digit2;
		private System.Windows.Forms.Button digit3;
		private System.Windows.Forms.Button digit6;
		private System.Windows.Forms.Button chs;
		private System.Windows.Forms.Button eex;
		private System.Windows.Forms.Button done;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DisplayTest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            formatter = new Mockingbird.HP.Class_Library.Number.Formatter
                (2, Mockingbird.HP.Class_Library.Number.DisplayFormat.Fixed);
            validater = new Mockingbird.HP.Class_Library.Number.Validater ();
            validater.ExponentChanged +=
                new Mockingbird.HP.Class_Library.Number.ChangeEvent (NumberChangeEvent);
            validater.MantissaChanged +=
                new Mockingbird.HP.Class_Library.Number.ChangeEvent (NumberChangeEvent);
            validater.NumberDone +=
                new Mockingbird.HP.Class_Library.Number.ChangeEvent (NumberDoneEvent);
            validater.NumberStarted +=
                new Mockingbird.HP.Class_Library.Number.ChangeEvent (NumberChangeEvent);
            DisplayUnderTest.Formatter = formatter;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.DisplayUnderTest = new Mockingbird.HP.Control_Library.Display();
			this.numericUpDown = new System.Windows.Forms.NumericUpDown();
			this.labelDigits = new System.Windows.Forms.Label();
			this.radioButtonScientific = new System.Windows.Forms.RadioButton();
			this.radioButtonFixed = new System.Windows.Forms.RadioButton();
			this.radioButtonEngineering = new System.Windows.Forms.RadioButton();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.digit7 = new System.Windows.Forms.Button();
			this.period = new System.Windows.Forms.Button();
			this.digit0 = new System.Windows.Forms.Button();
			this.digit1 = new System.Windows.Forms.Button();
			this.digit2 = new System.Windows.Forms.Button();
			this.digit3 = new System.Windows.Forms.Button();
			this.digit6 = new System.Windows.Forms.Button();
			this.digit5 = new System.Windows.Forms.Button();
			this.digit4 = new System.Windows.Forms.Button();
			this.digit9 = new System.Windows.Forms.Button();
			this.digit8 = new System.Windows.Forms.Button();
			this.chs = new System.Windows.Forms.Button();
			this.eex = new System.Windows.Forms.Button();
			this.done = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// PropertyGrid
			// 
			this.PropertyGrid.CommandsVisibleIfAvailable = true;
			this.PropertyGrid.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.PropertyGrid.LargeButtons = false;
			this.PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.PropertyGrid.Location = new System.Drawing.Point(8, 8);
			this.PropertyGrid.Name = "PropertyGrid";
			this.PropertyGrid.SelectedObject = this.DisplayUnderTest;
			this.PropertyGrid.Size = new System.Drawing.Size(480, 360);
			this.PropertyGrid.TabIndex = 4;
			this.PropertyGrid.Text = "PropertyGrid";
			this.PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// DisplayUnderTest
			// 
			this.DisplayUnderTest.Font = new System.Drawing.Font("Quartz", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DisplayUnderTest.ForeColor = System.Drawing.Color.Red;
			this.DisplayUnderTest.Location = new System.Drawing.Point(104, 384);
			this.DisplayUnderTest.Name = "DisplayUnderTest";
			this.DisplayUnderTest.Size = new System.Drawing.Size(310, 40);
			this.DisplayUnderTest.TabIndex = 5;
			// 
			// numericUpDown
			// 
			this.numericUpDown.Location = new System.Drawing.Point(400, 504);
			this.numericUpDown.Maximum = new System.Decimal(new int[] {
																		  9,
																		  0,
																		  0,
																		  0});
			this.numericUpDown.Name = "numericUpDown";
			this.numericUpDown.Size = new System.Drawing.Size(40, 20);
			this.numericUpDown.TabIndex = 6;
			this.numericUpDown.Value = new System.Decimal(new int[] {
																		2,
																		0,
																		0,
																		0});
			this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
			// 
			// labelDigits
			// 
			this.labelDigits.Location = new System.Drawing.Point(400, 480);
			this.labelDigits.Name = "labelDigits";
			this.labelDigits.Size = new System.Drawing.Size(40, 16);
			this.labelDigits.TabIndex = 7;
			this.labelDigits.Text = "Digits";
			this.labelDigits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// radioButtonScientific
			// 
			this.radioButtonScientific.Location = new System.Drawing.Point(8, 64);
			this.radioButtonScientific.Name = "radioButtonScientific";
			this.radioButtonScientific.Size = new System.Drawing.Size(90, 24);
			this.radioButtonScientific.TabIndex = 2;
			this.radioButtonScientific.Text = "Scientific";
			this.radioButtonScientific.CheckedChanged += new System.EventHandler(this.radioButtonScientific_CheckedChanged);
			// 
			// radioButtonFixed
			// 
			this.radioButtonFixed.Checked = true;
			this.radioButtonFixed.Location = new System.Drawing.Point(8, 40);
			this.radioButtonFixed.Name = "radioButtonFixed";
			this.radioButtonFixed.Size = new System.Drawing.Size(90, 24);
			this.radioButtonFixed.TabIndex = 1;
			this.radioButtonFixed.TabStop = true;
			this.radioButtonFixed.Text = "Fixed";
			this.radioButtonFixed.CheckedChanged += new System.EventHandler(this.radioButtonFixed_CheckedChanged);
			// 
			// radioButtonEngineering
			// 
			this.radioButtonEngineering.Location = new System.Drawing.Point(8, 16);
			this.radioButtonEngineering.Name = "radioButtonEngineering";
			this.radioButtonEngineering.Size = new System.Drawing.Size(90, 24);
			this.radioButtonEngineering.TabIndex = 0;
			this.radioButtonEngineering.Text = "Engineering";
			this.radioButtonEngineering.CheckedChanged += new System.EventHandler(this.radioButtonEngineering_CheckedChanged);
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.radioButtonScientific);
			this.groupBox.Controls.Add(this.radioButtonFixed);
			this.groupBox.Controls.Add(this.radioButtonEngineering);
			this.groupBox.Location = new System.Drawing.Point(280, 432);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(104, 96);
			this.groupBox.TabIndex = 8;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Format";
			// 
			// digit7
			// 
			this.digit7.Location = new System.Drawing.Point(112, 440);
			this.digit7.Name = "digit7";
			this.digit7.Size = new System.Drawing.Size(24, 24);
			this.digit7.TabIndex = 9;
			this.digit7.Tag = "7";
			this.digit7.Text = "7";
			this.digit7.Click += new System.EventHandler(this.digit_Click);
			// 
			// period
			// 
			this.period.Location = new System.Drawing.Point(240, 504);
			this.period.Name = "period";
			this.period.Size = new System.Drawing.Size(24, 24);
			this.period.TabIndex = 10;
			this.period.Text = ".";
			this.period.Click += new System.EventHandler(this.period_Click);
			// 
			// digit0
			// 
			this.digit0.Location = new System.Drawing.Point(208, 504);
			this.digit0.Name = "digit0";
			this.digit0.Size = new System.Drawing.Size(24, 24);
			this.digit0.TabIndex = 11;
			this.digit0.Tag = "0";
			this.digit0.Text = "0";
			this.digit0.Click += new System.EventHandler(this.digit_Click);
			// 
			// digit1
			// 
			this.digit1.Location = new System.Drawing.Point(176, 504);
			this.digit1.Name = "digit1";
			this.digit1.Size = new System.Drawing.Size(24, 24);
			this.digit1.TabIndex = 12;
			this.digit1.Tag = "1";
			this.digit1.Text = "1";
			this.digit1.Click += new System.EventHandler(this.digit_Click);
			// 
			// digit2
			// 
			this.digit2.Location = new System.Drawing.Point(144, 504);
			this.digit2.Name = "digit2";
			this.digit2.Size = new System.Drawing.Size(24, 24);
			this.digit2.TabIndex = 13;
			this.digit2.Tag = "2";
			this.digit2.Text = "2";
			this.digit2.Click += new System.EventHandler(this.digit_Click);
			// 
			// digit3
			// 
			this.digit3.Location = new System.Drawing.Point(112, 504);
			this.digit3.Name = "digit3";
			this.digit3.Size = new System.Drawing.Size(24, 24);
			this.digit3.TabIndex = 14;
			this.digit3.Tag = "3";
			this.digit3.Text = "3";
			this.digit3.Click += new System.EventHandler(this.digit_Click);
			// 
			// digit6
			// 
			this.digit6.Location = new System.Drawing.Point(176, 472);
			this.digit6.Name = "digit6";
			this.digit6.Size = new System.Drawing.Size(24, 24);
			this.digit6.TabIndex = 15;
			this.digit6.Tag = "6";
			this.digit6.Text = "6";
			this.digit6.Click += new System.EventHandler(this.digit_Click);
			// 
			// digit5
			// 
			this.digit5.Location = new System.Drawing.Point(144, 472);
			this.digit5.Name = "digit5";
			this.digit5.Size = new System.Drawing.Size(24, 24);
			this.digit5.TabIndex = 16;
			this.digit5.Tag = "5";
			this.digit5.Text = "5";
			this.digit5.Click += new System.EventHandler(this.digit_Click);
			// 
			// digit4
			// 
			this.digit4.Location = new System.Drawing.Point(112, 472);
			this.digit4.Name = "digit4";
			this.digit4.Size = new System.Drawing.Size(24, 24);
			this.digit4.TabIndex = 17;
			this.digit4.Tag = "4";
			this.digit4.Text = "4";
			this.digit4.Click += new System.EventHandler(this.digit_Click);
			// 
			// digit9
			// 
			this.digit9.Location = new System.Drawing.Point(176, 440);
			this.digit9.Name = "digit9";
			this.digit9.Size = new System.Drawing.Size(24, 24);
			this.digit9.TabIndex = 18;
			this.digit9.Tag = "9";
			this.digit9.Text = "9";
			this.digit9.Click += new System.EventHandler(this.digit_Click);
			// 
			// digit8
			// 
			this.digit8.Location = new System.Drawing.Point(144, 440);
			this.digit8.Name = "digit8";
			this.digit8.Size = new System.Drawing.Size(24, 24);
			this.digit8.TabIndex = 19;
			this.digit8.Tag = "8";
			this.digit8.Text = "8";
			this.digit8.Click += new System.EventHandler(this.digit_Click);
			// 
			// chs
			// 
			this.chs.Location = new System.Drawing.Point(208, 472);
			this.chs.Name = "chs";
			this.chs.Size = new System.Drawing.Size(56, 24);
			this.chs.TabIndex = 20;
			this.chs.Text = "CHS";
			this.chs.Click += new System.EventHandler(this.chs_Click);
			// 
			// eex
			// 
			this.eex.Location = new System.Drawing.Point(208, 440);
			this.eex.Name = "eex";
			this.eex.Size = new System.Drawing.Size(56, 24);
			this.eex.TabIndex = 21;
			this.eex.Text = "EEX";
			this.eex.Click += new System.EventHandler(this.eex_Click);
			// 
			// done
			// 
			this.done.Location = new System.Drawing.Point(392, 440);
			this.done.Name = "done";
			this.done.Size = new System.Drawing.Size(48, 24);
			this.done.TabIndex = 22;
			this.done.Text = "Done";
			this.done.Click += new System.EventHandler(this.done_Click);
			// 
			// DisplayTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 542);
			this.Controls.Add(this.done);
			this.Controls.Add(this.eex);
			this.Controls.Add(this.chs);
			this.Controls.Add(this.digit8);
			this.Controls.Add(this.digit9);
			this.Controls.Add(this.digit4);
			this.Controls.Add(this.digit5);
			this.Controls.Add(this.digit6);
			this.Controls.Add(this.digit3);
			this.Controls.Add(this.digit2);
			this.Controls.Add(this.digit1);
			this.Controls.Add(this.digit0);
			this.Controls.Add(this.period);
			this.Controls.Add(this.digit7);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.labelDigits);
			this.Controls.Add(this.numericUpDown);
			this.Controls.Add(this.DisplayUnderTest);
			this.Controls.Add(this.PropertyGrid);
			this.Name = "DisplayTest";
			this.Text = "DisplayTest";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
			this.groupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new DisplayTest());
		}

        private void NumberChangeEvent (string mantissa, string exponent, double value)
        {
            DisplayUnderTest.ShowNumeric (mantissa, exponent);
        }

        private void NumberDoneEvent (string mantissa, string exponent, double value)
        {
            formatter.Value = value;
        }

        private void numericUpDown_ValueChanged (object sender, System.EventArgs e)
		{
			formatter.Digits = (byte) numericUpDown.Value;
		}

		private void radioButtonEngineering_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButtonEngineering.Checked) 
			{
				formatter.Format = Mockingbird.HP.Class_Library.Number.DisplayFormat.Engineering;
			}
		}

		private void radioButtonFixed_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButtonFixed.Checked) 
			{
				formatter.Format = Mockingbird.HP.Class_Library.Number.DisplayFormat.Fixed;
			}
		}

		private void radioButtonScientific_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButtonScientific.Checked) 
			{
				formatter.Format = Mockingbird.HP.Class_Library.Number.DisplayFormat.Scientific;
			}
		}

		private void digit_Click(object sender, System.EventArgs e)
		{
			validater.EnterDigit (byte.Parse ((string) ((Button) sender).Tag));
		}

		private void eex_Click(object sender, System.EventArgs e)
		{
			validater.EnterExponent ();
		}

		private void chs_Click(object sender, System.EventArgs e)
		{
			bool changeSignDone;
			validater.ChangeSign (out changeSignDone);
		}

		private void period_Click(object sender, System.EventArgs e)
		{
			validater.EnterPeriod ();
		}

		private void done_Click(object sender, System.EventArgs e)
		{
			validater.DoneEntering ();		
			PropertyGrid.Refresh ();
		}

	}
}
