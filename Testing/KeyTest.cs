using Mockingbird.HP.Control_Library;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Mockingbird.HP.Testing
{
	/// <summary>
	/// A test rig for the Key user control.
	/// </summary>
	public class KeyTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid PropertyGrid;
		private Mockingbird.HP.Control_Library.Key KeyUnderTest;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public KeyTest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.KeyUnderTest = new Mockingbird.HP.Control_Library.Key();
			this.SuspendLayout();
			// 
			// PropertyGrid
			// 
			this.PropertyGrid.CommandsVisibleIfAvailable = true;
			this.PropertyGrid.LargeButtons = false;
			this.PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.PropertyGrid.Location = new System.Drawing.Point(8, 8);
			this.PropertyGrid.Name = "PropertyGrid";
			this.PropertyGrid.SelectedObject = this.KeyUnderTest;
			this.PropertyGrid.Size = new System.Drawing.Size(320, 448);
			this.PropertyGrid.TabIndex = 1;
			this.PropertyGrid.Text = "PropertyGrid";
			this.PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// KeyUnderTest
			// 
			this.KeyUnderTest.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.KeyUnderTest.FGTextAlign = TextAlign.Centered;
			this.KeyUnderTest.FGWidth = 48;
			this.KeyUnderTest.FText = "f";
			this.KeyUnderTest.GText = "g";
			this.KeyUnderTest.HText = "h";
			this.KeyUnderTest.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.KeyUnderTest.Location = new System.Drawing.Point(368, 200);
			this.KeyUnderTest.MainBackColor = System.Drawing.Color.Olive;
			this.KeyUnderTest.MainText = "key";
			this.KeyUnderTest.MainWidth = 48;
			this.KeyUnderTest.Name = "KeyUnderTest";
			this.KeyUnderTest.Size = new System.Drawing.Size(48, 51);
			this.KeyUnderTest.TabIndex = 2;
			this.KeyUnderTest.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.LeftMouseUpHandler);
			// 
			// KeyTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 466);
			this.Controls.Add(this.KeyUnderTest);
			this.Controls.Add(this.PropertyGrid);
			this.Name = "KeyTest";
			this.Text = "KeyTest";
			this.ResumeLayout(false);

		}
		#endregion

		private void LeftMouseUpHandler (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			MessageBox.Show ("Left mouse up event handled!");
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            // Do this to enable the fancy new XP styles.
            //Application.EnableVisualStyles ();
			Application.Run(new KeyTest());
		}
	}
}
