using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.Execution
{
	/// <summary>
	/// Abstract base class for magnetic card calculators.
	/// </summary>
	public abstract class CardCalculator : ProgrammableCalculator
	{

		#region Private Data

		private Mockingbird.HP.Control_Library.CardSlot cardSlot;
		private System.Windows.Forms.MenuItem menuSeparator;
		private System.Windows.Forms.MenuItem rtfMenuItem;
		private System.Windows.Forms.MenuItem editMenuItem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructors & Destructors
		
		public CardCalculator (string [] argument, CalculatorModel model) :
			base (argument, model)
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		protected override void InitializeComponent()
		{
			base.InitializeComponent ();
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager (typeof (CardCalculator));
			this.cardSlot = new Mockingbird.HP.Control_Library.CardSlot();
			this.menuSeparator = new System.Windows.Forms.MenuItem();
			this.editMenuItem = new System.Windows.Forms.MenuItem();
			this.rtfMenuItem = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// cardSlot
			// 
			this.cardSlot.Location = new System.Drawing.Point(8, 80);
			this.cardSlot.Margin = 8;
			this.cardSlot.Name = "cardSlot";
			this.cardSlot.RichText = false;
			this.cardSlot.Size = new System.Drawing.Size(288, 50);
			this.cardSlot.State = Mockingbird.HP.Control_Library.CardSlotState.Unloaded;
			this.cardSlot.TabIndex = 1;
			this.cardSlot.TextBoxWidth = 48;
			this.cardSlot.Title = "<TITLE>";
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuSeparator,
																						this.editMenuItem,
																						this.rtfMenuItem});
			// 
			// menuSeparator
			// 
			this.menuSeparator.Index = 4;
			this.menuSeparator.Text = "-";
			// 
			// editMenuItem
			// 
			this.editMenuItem.Index = 5;
			this.editMenuItem.Text = "&Edit Labels";
			this.editMenuItem.Click += new System.EventHandler(this.editMenuItem_Click);
			// 
			// rtfMenuItem
			// 
			this.rtfMenuItem.Index = 6;
			this.rtfMenuItem.Text = "&Rich Text";
			this.rtfMenuItem.Click += new System.EventHandler(this.rtfMenuItem_Click);
			// 
			// CardCalculator
			// 
			this.Controls.Add(this.cardSlot);
			this.ResumeLayout(false);
		}
		#endregion
		
		#endregion

		#region Overriding Operations

		protected override bool KeyEventsPreempted 
		{
			get 
			{
				return cardSlot.State >= CardSlotState.Editable && cardSlot.ContainsFocus;
			}
		}

		protected override void PowerOff () 
		{
			// OFF.  We abort the execution thread and start a new one.  We leave it in the
			// state where its display is black and it doesn't accept keystrokes.
			BusyUI ();
			executionThread.Reset (out program); 
			UpdateCardSlot (/* alreadyLocked */ false);
		}

		protected override void UpdateUI (bool alreadyLocked) 
		{
			UpdateCardSlot (alreadyLocked);
		}

		#endregion

		#region Cross-Thread Operations

		public bool CrossThreadMerge () 
		{
			string name;

			if (openFileDialog.ShowDialog () == DialogResult.OK)
			{
				name = openFileDialog.FileName;
				return Open (/* alreadyLocked */ true, /* merge */ true, ref name);
			}
			else 
			{
				return false;
			}
		}

		public bool CrossThreadSaveDataAs () 
		{
			string name = null;

			return Save (/* alreadyLocked */ true, /* saveAs */ true, CardPart.Data, ref name);
		}	
		
		#endregion

		#region UI Utilities

		void UpdateCardSlot (bool alreadyLocked) 
		{
			bool wasUnloaded = (cardSlot.State == CardSlotState.Unloaded);

			// Make sure that the state of the card slot reflects the state of the program memory.
			if (! alreadyLocked) 
			{
				Monitor.Enter (executionThread.IsBusy);
			}
			try 
			{
				if ((program == null) || (program.IsEmpty))
				{
					cardSlot.State = CardSlotState.Unloaded;
					editMenuItem.Enabled = false;
					rtfMenuItem.Enabled = false;
				}
				else if (fileName != null &&
					((File.GetAttributes (fileName) &  FileAttributes.ReadOnly) != 0))
				{
					cardSlot.State = CardSlotState.ReadOnly;
					editMenuItem.Enabled = false;
					rtfMenuItem.Enabled = false;
				}
				else 
				{
					cardSlot.State = CardSlotState.ReadWrite;
					editMenuItem.Enabled = true;
					rtfMenuItem.Enabled = true;
				}
			}
			finally 
			{
				if (! alreadyLocked) 
				{
					Monitor.Exit (executionThread.IsBusy);
				}

				// If the program was just cleared, clear the current file name.  This ensures that
				// the next program won't be stupidly saved on the previous card.
				if (! wasUnloaded && cardSlot.State == CardSlotState.Unloaded) 
				{
					fileName = null;
				}
			}
		}

		#endregion
		
		#region UI Event Handlers

		private void editMenuItem_Click(object sender, System.EventArgs e)
		{
			if (cardSlot.State != CardSlotState.Unloaded) 
			{
				bool isChecked = ((MenuItem) sender).Checked;
				isChecked = ! isChecked;
				((MenuItem) sender).Checked = isChecked;
				if (isChecked) 
				{
					cardSlot.State = CardSlotState.Editable;
				}
				else
				{
					UpdateCardSlot (/* alreadyLocked */ false);
				}
			}
		}

		private void rtfMenuItem_Click(object sender, System.EventArgs e)
		{
			if (cardSlot.State != CardSlotState.Unloaded) 
			{
				bool isChecked = ((MenuItem) sender).Checked;
				isChecked = ! isChecked;
				((MenuItem) sender).Checked = isChecked;
				cardSlot.RichText = isChecked;
			}
		}

		#endregion

	}
}
