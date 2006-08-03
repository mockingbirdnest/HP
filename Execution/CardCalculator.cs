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

		#region Protected & Private Data

		protected Mockingbird.HP.Control_Library.CardSlot cardSlot;
		protected System.Windows.Forms.MenuItem menuSeparator;
		protected System.Windows.Forms.MenuItem rtfMenuItem;
		protected System.Windows.Forms.MenuItem editMenuItem;
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
		protected abstract override void InitializeComponent();
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

		protected void editMenuItem_Click(object sender, System.EventArgs e)
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

		protected void rtfMenuItem_Click(object sender, System.EventArgs e)
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
