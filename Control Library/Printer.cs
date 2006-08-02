using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Mockingbird.HP.Control_Library
{
	/// <summary>
	/// The dot-matrix printer of the HP97 calculator
	/// </summary>
	public class Printer : System.Windows.Forms.UserControl
	{

		#region Private Data

		private System.Windows.Forms.ListBox listBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructors & Destructors

		public Printer ()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent

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
					components.Dispose( );
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
			this.listBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBox
			// 
			this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listBox.BackColor = System.Drawing.Color.WhiteSmoke;
			this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listBox.Font = new System.Drawing.Font("DotMatrix", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listBox.ItemHeight = 18;
			this.listBox.Items.AddRange(new object[] {
														 "1ABCDEFGHIJKLMNOPQRSTUVWXYZ",
														 "3",
														 "4",
														 "5",
														 "6",
														 "7",
														 "8",
														 "9",
														 "0",
														 "1",
														 "2",
														 "3",
														 "4",
														 "5",
														 "6",
														 "7",
														 "8",
														 "9",
														 "0",
														 "1"});
			this.listBox.Location = new System.Drawing.Point(0, 0);
			this.listBox.Name = "listBox";
			this.listBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.listBox.ScrollAlwaysVisible = true;
			this.listBox.Size = new System.Drawing.Size(192, 216);
			this.listBox.TabIndex = 0;
			// 
			// Printer
			// 
			this.Controls.Add(this.listBox);
			this.Name = "Printer";
			this.Size = new System.Drawing.Size(192, 216);
			this.ResumeLayout(false);

		}
		#endregion


	}
}
