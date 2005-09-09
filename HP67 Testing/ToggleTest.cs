using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace HP67_Testing
{
	/// <summary>
	/// Summary description for ToggleTest.
	/// </summary>
	public class ToggleTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid PropertyGrid;
		private HP67_Control_Library.Toggle ToggleUnderTest;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ToggleTest()
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
			this.ToggleUnderTest = new HP67_Control_Library.Toggle();
			this.SuspendLayout();
			// 
			// PropertyGrid
			// 
			this.PropertyGrid.CommandsVisibleIfAvailable = true;
			this.PropertyGrid.LargeButtons = false;
			this.PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.PropertyGrid.Location = new System.Drawing.Point(8, 8);
			this.PropertyGrid.Name = "PropertyGrid";
			this.PropertyGrid.SelectedObject = this.ToggleUnderTest;
			this.PropertyGrid.Size = new System.Drawing.Size(480, 360);
			this.PropertyGrid.TabIndex = 2;
			this.PropertyGrid.Text = "PropertyGrid";
			this.PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// ToggleUnderTest
			// 
			this.ToggleUnderTest.LeftText = "left";
			this.ToggleUnderTest.LeftWidth = 60;
			this.ToggleUnderTest.Location = new System.Drawing.Point(152, 400);
			this.ToggleUnderTest.MainWidth = 60;
			this.ToggleUnderTest.Name = "ToggleUnderTest";
			this.ToggleUnderTest.RightText = "right";
			this.ToggleUnderTest.RightWidth = 60;
			this.ToggleUnderTest.Size = new System.Drawing.Size(192, 40);
			this.ToggleUnderTest.TabIndex = 3;
			this.ToggleUnderTest.ToggleClick += new HP67_Control_Library.Toggle.ToggleClickEvent(this.ToggleClick);
			// 
			// ToggleTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 466);
			this.Controls.Add(this.ToggleUnderTest);
			this.Controls.Add(this.PropertyGrid);
			this.Name = "ToggleTest";
			this.Text = "ToggleTest";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ToggleTest());
		}

		private void ToggleClick
			(object sender, System.EventArgs e, HP67_Control_Library.Toggle.Position position)
		{
			switch (position) 
			{
				case HP67_Control_Library.Toggle.Position.Left:
				{
					MessageBox.Show ("Now on the left!");
					break;
				}
				case HP67_Control_Library.Toggle.Position.Right:
				{
					MessageBox.Show ("Now on the right!");
					break;
				}
			}
		}
	}
}
