using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace HP67_Testing
{
	/// <summary>
	/// Summary description for DisplayTest.
	/// </summary>
	public class DisplayTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid PropertyGrid;
		private HP67_Control_Library.Display DisplayUnderTest;
		private System.Windows.Forms.NumericUpDown numericUpDown;
		private System.Windows.Forms.Label labelDigits;
		private System.Windows.Forms.RadioButton radioButtonScientific;
		private System.Windows.Forms.RadioButton radioButtonFixed;
		private System.Windows.Forms.RadioButton radioButtonEngineering;
		private System.Windows.Forms.GroupBox groupBox;
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

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.DisplayUnderTest = new HP67_Control_Library.Display();
			this.numericUpDown = new System.Windows.Forms.NumericUpDown();
			this.labelDigits = new System.Windows.Forms.Label();
			this.radioButtonScientific = new System.Windows.Forms.RadioButton();
			this.radioButtonFixed = new System.Windows.Forms.RadioButton();
			this.radioButtonEngineering = new System.Windows.Forms.RadioButton();
			this.groupBox = new System.Windows.Forms.GroupBox();
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
			this.DisplayUnderTest.Font = new System.Drawing.Font("Quartz", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DisplayUnderTest.ForeColor = System.Drawing.Color.Red;
			this.DisplayUnderTest.Location = new System.Drawing.Point(72, 392);
			this.DisplayUnderTest.Name = "DisplayUnderTest";
			this.DisplayUnderTest.Size = new System.Drawing.Size(310, 50);
			this.DisplayUnderTest.TabIndex = 5;
			this.DisplayUnderTest.Value = 0;
			// 
			// numericUpDown
			// 
			this.numericUpDown.Location = new System.Drawing.Point(16, 400);
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
			this.labelDigits.Location = new System.Drawing.Point(16, 384);
			this.labelDigits.Name = "labelDigits";
			this.labelDigits.Size = new System.Drawing.Size(40, 16);
			this.labelDigits.TabIndex = 7;
			this.labelDigits.Text = "Digits";
			this.labelDigits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// radioButtonScientific
			// 
			this.radioButtonScientific.Location = new System.Drawing.Point(8, 56);
			this.radioButtonScientific.Name = "radioButtonScientific";
			this.radioButtonScientific.Size = new System.Drawing.Size(90, 24);
			this.radioButtonScientific.TabIndex = 2;
			this.radioButtonScientific.Text = "Scientific";
			this.radioButtonScientific.CheckedChanged += new System.EventHandler(this.radioButtonScientific_CheckedChanged);
			// 
			// radioButtonFixed
			// 
			this.radioButtonFixed.Checked = true;
			this.radioButtonFixed.Location = new System.Drawing.Point(8, 32);
			this.radioButtonFixed.Name = "radioButtonFixed";
			this.radioButtonFixed.Size = new System.Drawing.Size(90, 24);
			this.radioButtonFixed.TabIndex = 1;
			this.radioButtonFixed.TabStop = true;
			this.radioButtonFixed.Text = "Fixed";
			this.radioButtonFixed.CheckedChanged += new System.EventHandler(this.radioButtonFixed_CheckedChanged);
			// 
			// radioButtonEngineering
			// 
			this.radioButtonEngineering.Location = new System.Drawing.Point(8, 8);
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
			this.groupBox.Location = new System.Drawing.Point(376, 368);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(104, 88);
			this.groupBox.TabIndex = 8;
			this.groupBox.TabStop = false;
			// 
			// DisplayTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 466);
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

		private void numericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			DisplayUnderTest.Digits = (byte) numericUpDown.Value;
		}

		private void radioButtonEngineering_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButtonEngineering.Checked) 
			{
				DisplayUnderTest.Format = HP67_Control_Library.DisplayFormat.Engineering;
			}
		}

		private void radioButtonFixed_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButtonFixed.Checked) 
			{
				DisplayUnderTest.Format = HP67_Control_Library.DisplayFormat.Fixed;
			}
		}

		private void radioButtonScientific_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButtonScientific.Checked) 
			{
				DisplayUnderTest.Format = HP67_Control_Library.DisplayFormat.Scientific;
			}
		}
	}
}
