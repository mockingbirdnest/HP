using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mockingbird.HP.Testing
{
	/// <summary>
	/// Summary description for CardTest.
	/// </summary>
	public class CardTest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PropertyGrid PropertyGrid;
		private Mockingbird.HP.Control_Library.CardSlot CardSlotUnderTest;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CardTest()
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
			this.CardSlotUnderTest = new Mockingbird.HP.Control_Library.CardSlot();
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
			this.PropertyGrid.SelectedObject = this.CardSlotUnderTest;
			this.PropertyGrid.Size = new System.Drawing.Size(480, 360);
			this.PropertyGrid.TabIndex = 5;
			this.PropertyGrid.Text = "PropertyGrid";
			this.PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// CardSlotUnderTest
			// 
			this.CardSlotUnderTest.TextBoxWidth = 48;
			this.CardSlotUnderTest.Location = new System.Drawing.Point(112, 392);
			this.CardSlotUnderTest.Margin = 16;
			this.CardSlotUnderTest.Name = "CardSlotUnderTest";
			this.CardSlotUnderTest.Size = new System.Drawing.Size(300, 50);
			this.CardSlotUnderTest.TabIndex = 6;
			// 
			// CardTest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 466);
			this.Controls.Add(this.CardSlotUnderTest);
			this.Controls.Add(this.PropertyGrid);
			this.Name = "CardTest";
			this.Text = "CardTest";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new CardTest());
		}
	}
}
