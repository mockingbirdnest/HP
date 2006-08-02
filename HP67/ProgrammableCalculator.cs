using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Parser;
using Mockingbird.HP.Persistence;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Mockingbird.HP.HP67
{
	/// <summary>
	/// Abstract base class for programmable calculators.
	/// </summary>
	public abstract class ProgrammableCalculator : BaseCalculator
	{

		#region Protected & Private Data

		private const string commandOpen = "/open";
		private const string commandPrint = "/print";

		protected string fileName = null;

		// As much as possible, we hide the execution state in the Execution function.  But
		// some things need the program.  It must only be accessed with proper synchronization,
		// e.g., while holding the IsBusy lock or when in a cross-thread invocation.
		protected Program program = null;

		private Mockingbird.HP.Control_Library.Toggle toggleWprgmRun;
		protected System.Windows.Forms.ContextMenu contextMenu;
		protected System.Windows.Forms.OpenFileDialog openFileDialog;
		protected System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Drawing.Printing.PrintDocument printDocument;
		protected System.Windows.Forms.MenuItem openMenuItem;
		protected System.Windows.Forms.MenuItem printMenuItem;
		protected System.Windows.Forms.MenuItem saveMenuItem;
		protected System.Windows.Forms.MenuItem saveAsMenuItem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructors & Destructors

		public ProgrammableCalculator (string [] argument, CalculatorModel model) :
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
		protected override void InitializeComponent ()
		{
			base.InitializeComponent ();
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager (typeof (ProgrammableCalculator));
			this.toggleWprgmRun = new Mockingbird.HP.Control_Library.Toggle();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.openMenuItem = new System.Windows.Forms.MenuItem();
			this.saveMenuItem = new System.Windows.Forms.MenuItem();
			this.saveAsMenuItem = new System.Windows.Forms.MenuItem();
			this.printMenuItem = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.SuspendLayout();
			// 
			// toggleWprgmRun
			// 
			this.toggleWprgmRun.LeftText = "W/PRGM";
			this.toggleWprgmRun.LeftWidth = 60;
			this.toggleWprgmRun.Location = new System.Drawing.Point(160, 56);
			this.toggleWprgmRun.MainWidth = 50;
			this.toggleWprgmRun.Name = "toggleWprgmRun";
			this.toggleWprgmRun.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
			this.toggleWprgmRun.RightText = "RUN";
			this.toggleWprgmRun.RightWidth = 30;
			this.toggleWprgmRun.Size = new System.Drawing.Size(140, 16);
			this.toggleWprgmRun.TabIndex = 3;
			this.toggleWprgmRun.ToggleClick += new Mockingbird.HP.Control_Library.Toggle.ToggleClickEvent(this.toggleWprgmRun_ToggleClick);
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.openMenuItem,
																						this.saveMenuItem,
																						this.saveAsMenuItem,
																						this.printMenuItem});
			// 
			// openMenuItem
			// 
			this.openMenuItem.Index = 0;
			this.openMenuItem.Text = "&Open...";
			this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
			// 
			// saveMenuItem
			// 
			this.saveMenuItem.Index = 1;
			this.saveMenuItem.Text = "&Save";
			this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
			// 
			// saveAsMenuItem
			// 
			this.saveAsMenuItem.Index = 2;
			this.saveAsMenuItem.Text = "Save &As...";
			this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
			// 
			// printMenuItem
			// 
			this.printMenuItem.Index = 3;
			this.printMenuItem.Text = "Print";
			this.printMenuItem.Click += new System.EventHandler(this.printMenuItem_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "HP67 Card Files (*.hp67)|*.hp67|All files (*.*)|*.*";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "HP67 Card Files (*.hp67)|*.hp67|All files (*.*)|*.*";
			// 
			// printDocument
			// 
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
			// 
			// ProgrammableCalculator
			// 
			this.ContextMenu = this.contextMenu;
			this.Controls.Add(this.toggleWprgmRun);
			this.ResumeLayout(false);

			// Localize the UI.
			openMenuItem.Text = Localization.GetString (Localization.OpenMenuItem);
			printMenuItem.Text = Localization.GetString (Localization.PrintMenuItem);
			saveMenuItem.Text = Localization.GetString (Localization.SaveMenuItem);
			saveAsMenuItem.Text = Localization.GetString (Localization.SaveAsMenuItem);
		}
		#endregion

		#endregion
			
		#region Abstract Operations

		protected abstract void UpdateUI (bool alreadyLocked);

		#endregion

		#region Overriding Operations

		protected override void BusyUI () 
		{

			// Disabling the menu items makes it clear to the user which operations are forbidden
			// while the program runs.  It is doesn't help thread-safety, though: it could be
			// possible for a print operation to start, followed immediately by the execution of a
			// program, in which case both would proceed in parallel.  Thread safety is achieved by
			// locking the operations that must access the execution data structures.
			openMenuItem.Enabled = false;
			printMenuItem.Enabled = false;
			saveMenuItem.Enabled = false;
			saveAsMenuItem.Enabled = false;
		}

		protected override ExecutionThread CreateExecutionThread () 
		{
			return new ExecutionThread
				(this,
				reader,
				new ExecutionThread.CrossThreadUINotification (CrossThreadNotifyUI),
				out program);
		}

		public override EngineMode CrossThreadNotifyUI (bool busy) 
		{
			if (busy) 
			{
				BusyUI ();
				return EngineMode.Run;
			}
			else 
			{
				return UnbusyUIAndGetEngineMode ();
			}
		}

		protected override void ProcessCommandLine (string [] arguments)
		{
			string caption = Localization.GetString (Localization.IncorrectCommandLineArguments);

			switch (arguments.Length) 
			{
				case 0 :
					break;
				case 2 :
					if (arguments [0] == commandOpen) 
					{
						fileName = arguments [1];
						Open (/* alreadyLocked */ true, /* merge */ false, ref fileName);
					}
					else if (arguments [0] == commandPrint) 
					{
						Print (arguments [1]);

						// For some reason Close and Application.Exit won't have an effect here
						// (maybe because we are in the constructor?).  So I am calling the cleanup
						// code by hand, and raising an exception to get out of the constructor.
						Calculator_Closing (null, null);
						throw new Shutdown ();
					}
					else
					{
						MessageBox.Show (string.Format (
							Localization.GetString (Localization.IncorrectCommand),
							arguments [0],
							commandOpen,
							commandPrint),
							caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;
				default :
					MessageBox.Show (string.Format (
						Localization.GetString (Localization.IncorrectArgumentCount),
						arguments.Length.ToString (), 0, 2),
						caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}
		}

		protected override void UnbusyUI () 
		{
			UnbusyUIAndGetEngineMode ();
		}

		#endregion

		#region Command Execution Utilities

		public bool Open (bool alreadyLocked, bool merge, ref string name) 
		{
			bool status = false;
			FileStream stream = null;

			try 
			{
				stream = new FileStream (name, FileMode.Open, FileAccess.Read);

				if (! alreadyLocked) 
				{
					Monitor.Enter (executionThread.IsBusy);
				}
				try 
				{
					if (merge) 
					{
						status = Card.Merge (stream, reader);
					}
					else 
					{
						status = Card.Read (stream, reader);
					}
					UpdateUI (/* alreadyLocked */ true);
				}
				finally 
				{
					if (! alreadyLocked) 
					{
						Monitor.Exit (executionThread.IsBusy);
					}
				}

				if (! status) 
				{
					name = null;
				}
				stream.Close ();
				return status;
			}
			catch (FileNotFoundException)
			{
				string text = string.Format (
					Localization.GetString (Localization.CannotOpenFile),
					name);
				string caption = Localization.GetString (Localization.FileNotFound);

				if (stream != null) 
				{
					stream.Close ();
				}
				MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			catch (Exception ex) 
			{
				string text = string.Format (
					Localization.GetString (Localization.ExceptionOpeningFile),
					name,
					ex.Message);
				string caption = Localization.GetString (Localization.ErrorDuringOpen);

				if (stream != null) 
				{
					stream.Close ();
				}
				MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		public void Print (string name) 
		{
			Open (/* alreadyLocked */ false, /* merge */ false, ref name);
			printMenuItem_Click (null, null);
		}

		protected bool Save (bool alreadyLocked, bool saveAs, CardPart part, ref string name)
		{
			bool fileIsNullOrReadOnly;
			bool fileIsReadOnly;
			bool mustShowDialog = saveAs;
			bool status = false;
			FileStream stream = null;

			// If we don't have a currently open file, or if it is read-only, or if this is a
			// Save As, we bring up the menu.  We keep doing so until either the user cancels the
			// operation, or selects a writeable or nonexistent file.
			for (;;) 
			{
				fileIsReadOnly = File.Exists (name) &&
					((File.GetAttributes (name) &  FileAttributes.ReadOnly) != 0);
				fileIsNullOrReadOnly = (name == null || fileIsReadOnly);
				if (! mustShowDialog && ! fileIsNullOrReadOnly)
				{
					break;
				}
				if (fileIsNullOrReadOnly) 
				{
					saveFileDialog.FileName = Localization.GetString (Localization.UntitledFileName);
				}
				else 
				{
					saveFileDialog.FileName = name;
				}
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					name = saveFileDialog.FileName;
					mustShowDialog = false;
				}
				else 
				{
					return false;
				}
			}

			// Now do the actual write to the card.  Use OpenOrCreate so as to be able to read the
			// part of the file that we won't overwrite.
			try 
			{
				stream = new FileStream (name, FileMode.OpenOrCreate);
				
				if (! alreadyLocked) 
				{
					Monitor.Enter (executionThread.IsBusy);
				}
				try 
				{
					status = Card.Write (stream, part);
				}
				finally 
				{
					if (! alreadyLocked) 
					{
						Monitor.Exit (executionThread.IsBusy);
					}
				}

				stream.Close ();
				return status;
			}
			catch (Exception ex) 
			{
				string text = string.Format (
					Localization.GetString (Localization.ExceptionSavingFile),
					name,
					ex.Message);
				string caption = Localization.GetString (Localization.ErrorDuringSave);

				if (stream != null) 
				{
					stream.Close ();
				}
				MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		#endregion

		#region UI Utilities

		protected EngineMode UnbusyUIAndGetEngineMode () 
		{
			printMenuItem.Enabled = true;

			// Make sure that the state of the UI reflects the state of the program memory.  We can
			// access the program without synchronization, because we only come here through a
			// cross-thread invocation or at startup, and therefore the two threads are
			// synchronized.
			UpdateUI (/* alreadyLocked */ true);
			switch (toggleWprgmRun.Position)
			{
				case TogglePosition.Left :

					// W/PRGM, can only save.
					openMenuItem.Enabled = false;
					saveMenuItem.Enabled = true;
					saveAsMenuItem.Enabled = true;
					return EngineMode.WriteProgram;

				case TogglePosition.Right :

					// RUN, can only open.
					openMenuItem.Enabled = true;
					saveMenuItem.Enabled = false;
					saveAsMenuItem.Enabled = false;
					return EngineMode.Run;

				default :
					return EngineMode.Run; // To make the compiler happy.
			}
		}

		#endregion

		#region UI Event Handlers

		private void printDocument_PrintPage(object sender,
			System.Drawing.Printing.PrintPageEventArgs e)
		{
			program.PrintOnePage (e, new Font ("Arial Unicode MS", 10));
		}

		private void toggleWprgmRun_ToggleClick (object sender,
			System.EventArgs e,
			Mockingbird.HP.Control_Library.TogglePosition position)
		{

			// Changes to this toggle are actually delayed until the end of the current execution.
			// If the execution thread is idle, we are going to be able to grab the lock and
			// proceed immediately.  If it is busy, we won't be able to grab the lock, and we will
			// return without doing anything.  That's not a problem because the execution thread
			// will update the menus as soon as the current computation finishes.
			if (Monitor.TryEnter (executionThread.IsBusy)) 
			{
				try
				{

					// One of the things we want to do is change the display mode, and that can
					// only be done by the execution thread.  So force it to go through its loop
					// once by sending a no-op keystroke.  We know that the execution thread is 
					// idle, so this won't have nasty effects like interrupting the current
					// computation.
					executionThread.Enqueue (Keystroke.Noop);
				}
				finally 
				{
					Monitor.Exit (executionThread.IsBusy);
				}
			}
		}

		private void openMenuItem_Click (object sender, System.EventArgs e)
		{
			if (openFileDialog.ShowDialog () == DialogResult.OK)
			{
				fileName = openFileDialog.FileName;
				Open (/* alreadyLocked */ false, /* merge */ false, ref fileName);
			}			
		}

		private void saveMenuItem_Click(object sender, System.EventArgs e)
		{
			Save (/* alreadyLocked */ false, /* saveAs */ false, CardPart.Program, ref fileName);
		}

		private void saveAsMenuItem_Click (object sender, System.EventArgs e)
		{
			Save (/* alreadyLocked */ false, /* saveAs */ true, CardPart.Program, ref fileName);
		}

		private void printMenuItem_Click(object sender, System.EventArgs e)
		{
			lock (executionThread.IsBusy) 
			{
				printDocument.Print ();
			}
		}

		#endregion

	}
}
