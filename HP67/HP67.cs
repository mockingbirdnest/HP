using HP67_Class_Library;
using HP67_Control_Library;
using HP67_Parser;
using HP67_Persistence;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace HP67
{
	/// <summary>
	/// User interface for the HP67 calculator.
	/// </summary>
	public class HP67 : System.Windows.Forms.Form
	{
		private const string commandOpen = "/open";
		private const string commandPrint = "/print";

		private string fileName = null;
		private Reader reader = null;

		// As much as possible, we hide the execution state in the Execution function.  But
		// some things need the program.  It must only be accessed with proper synchronization,
		// e.g., while holding the IsBusy lock or when in a cross-thread invocation.
		private Program program = null;

		private ExecutionThread executionThread;

		private HP67_Control_Library.Key keyA;
		private HP67_Control_Library.Key keyB;
		private HP67_Control_Library.Key keyC;
		private HP67_Control_Library.Key keyD;
		private HP67_Control_Library.Key keyE;
		private HP67_Control_Library.Key keyΣ;
		private HP67_Control_Library.Key keyGTO;
		private HP67_Control_Library.Key keyDSP;
		private HP67_Control_Library.Key keyi;
		private HP67_Control_Library.Key keySST;
		private HP67_Control_Library.Key keyf;
		private HP67_Control_Library.Key keyg;
		private HP67_Control_Library.Key keySTO;
		private HP67_Control_Library.Key keyRCL;
		private HP67_Control_Library.Key keyh;
		private HP67_Control_Library.Key keyENTER;
		private HP67_Control_Library.Key keyCHS;
		private HP67_Control_Library.Key keyEEX;
		private HP67_Control_Library.Key keyCLx;
		private HP67_Control_Library.Key keyMinus;
		private HP67_Control_Library.Key key7;
		private HP67_Control_Library.Key key8;
		private HP67_Control_Library.Key key9;
		private HP67_Control_Library.Key key4;
		private HP67_Control_Library.Key keyPlus;
		private HP67_Control_Library.Key key5;
		private HP67_Control_Library.Key key6;
		private HP67_Control_Library.Key keyMult;
		private HP67_Control_Library.Key key2;
		private HP67_Control_Library.Key key1;
		private HP67_Control_Library.Key key3;
		private HP67_Control_Library.Key keyDiv;
		private HP67_Control_Library.Key keyRS;
		private HP67_Control_Library.Key key0;
		private HP67_Control_Library.Key keyPeriod;
		private HP67_Control_Library.CardSlot cardSlot;
		private HP67_Control_Library.Toggle toggleOffOn;
		private HP67_Control_Library.Toggle toggleWprgmRun;
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.MenuItem editMenuItem;
		private System.Windows.Forms.MenuItem openMenuItem;
		private System.Windows.Forms.MenuItem printMenuItem;
		private System.Windows.Forms.MenuItem rtfMenuItem;
		private System.Windows.Forms.MenuItem saveMenuItem;
		private System.Windows.Forms.MenuItem saveAsMenuItem;
		private System.Windows.Forms.MenuItem menuSeparator;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HP67 (string [] arguments)
		{
			string caption = Localization.GetString (Localization.IncorrectCommandLineArguments);

			// Required for Windows Form Designer support
			InitializeComponent();

			// Localize the UI.
			editMenuItem.Text = Localization.GetString (Localization.EditMenuItem);
			openMenuItem.Text = Localization.GetString (Localization.OpenMenuItem);
			printMenuItem.Text = Localization.GetString (Localization.PrintMenuItem);
			rtfMenuItem.Text = Localization.GetString (Localization.RtfMenuItem);
			saveMenuItem.Text = Localization.GetString (Localization.SaveMenuItem);
			saveAsMenuItem.Text = Localization.GetString (Localization.SaveAsMenuItem);

			// Initialize the UI.
			Unbusy ();
			UpdateCardSlot (/* alreadyLocked */ true);

			// Read the parser tables.
			reader = new Reader ("HP67_Parser.Parser", "CGT");

			// Create the execution thread and wait until it is ready to process requests.
			executionThread =
				new ExecutionThread
					(this,
					reader,
					new ExecutionThread.CrossThreadUINotification (CrossThreadNotifyUI),
					out program);

			// Now see if we were called from the command line with arguments.
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
						HP67_Closing (null, null);
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

			// Power on.
			executionThread.PowerOn.Set ();
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
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HP67));
			this.cardSlot = new HP67_Control_Library.CardSlot();
			this.toggleOffOn = new HP67_Control_Library.Toggle();
			this.toggleWprgmRun = new HP67_Control_Library.Toggle();
			this.keyA = new HP67_Control_Library.Key();
			this.keyf = new HP67_Control_Library.Key();
			this.keySST = new HP67_Control_Library.Key();
			this.keyi = new HP67_Control_Library.Key();
			this.keyDSP = new HP67_Control_Library.Key();
			this.keyGTO = new HP67_Control_Library.Key();
			this.keyΣ = new HP67_Control_Library.Key();
			this.keyE = new HP67_Control_Library.Key();
			this.keyD = new HP67_Control_Library.Key();
			this.keyC = new HP67_Control_Library.Key();
			this.keyB = new HP67_Control_Library.Key();
			this.keyENTER = new HP67_Control_Library.Key();
			this.keyEEX = new HP67_Control_Library.Key();
			this.keyCLx = new HP67_Control_Library.Key();
			this.keyCHS = new HP67_Control_Library.Key();
			this.keyh = new HP67_Control_Library.Key();
			this.keyRCL = new HP67_Control_Library.Key();
			this.keySTO = new HP67_Control_Library.Key();
			this.keyg = new HP67_Control_Library.Key();
			this.key8 = new HP67_Control_Library.Key();
			this.keyRS = new HP67_Control_Library.Key();
			this.keyPeriod = new HP67_Control_Library.Key();
			this.key0 = new HP67_Control_Library.Key();
			this.key9 = new HP67_Control_Library.Key();
			this.key3 = new HP67_Control_Library.Key();
			this.key2 = new HP67_Control_Library.Key();
			this.key1 = new HP67_Control_Library.Key();
			this.key6 = new HP67_Control_Library.Key();
			this.key5 = new HP67_Control_Library.Key();
			this.key4 = new HP67_Control_Library.Key();
			this.key7 = new HP67_Control_Library.Key();
			this.keyMinus = new HP67_Control_Library.Key();
			this.keyDiv = new HP67_Control_Library.Key();
			this.keyMult = new HP67_Control_Library.Key();
			this.keyPlus = new HP67_Control_Library.Key();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.openMenuItem = new System.Windows.Forms.MenuItem();
			this.saveMenuItem = new System.Windows.Forms.MenuItem();
			this.saveAsMenuItem = new System.Windows.Forms.MenuItem();
			this.printMenuItem = new System.Windows.Forms.MenuItem();
			this.menuSeparator = new System.Windows.Forms.MenuItem();
			this.editMenuItem = new System.Windows.Forms.MenuItem();
			this.rtfMenuItem = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.SuspendLayout();
			// 
			// cardSlot
			// 
			this.cardSlot.Location = new System.Drawing.Point(8, 80);
			this.cardSlot.Margin = 8;
			this.cardSlot.Name = "cardSlot";
			this.cardSlot.RichText = false;
			this.cardSlot.Size = new System.Drawing.Size(288, 50);
			this.cardSlot.State = HP67_Control_Library.CardSlotState.Unloaded;
			this.cardSlot.TabIndex = 1;
			this.cardSlot.TextBoxWidth = 48;
			this.cardSlot.Title = "<TITLE>";
			// 
			// toggleOffOn
			// 
			this.toggleOffOn.LeftText = "OFF";
			this.toggleOffOn.LeftWidth = 30;
			this.toggleOffOn.Location = new System.Drawing.Point(8, 56);
			this.toggleOffOn.MainWidth = 50;
			this.toggleOffOn.Name = "toggleOffOn";
			this.toggleOffOn.Position = HP67_Control_Library.TogglePosition.Right;
			this.toggleOffOn.RightText = "ON";
			this.toggleOffOn.RightWidth = 30;
			this.toggleOffOn.Size = new System.Drawing.Size(110, 16);
			this.toggleOffOn.TabIndex = 2;
			this.toggleOffOn.ToggleClick += new HP67_Control_Library.Toggle.ToggleClickEvent(this.toggleOffOn_ToggleClick);
			// 
			// toggleWprgmRun
			// 
			this.toggleWprgmRun.LeftText = "W/PRGM";
			this.toggleWprgmRun.LeftWidth = 60;
			this.toggleWprgmRun.Location = new System.Drawing.Point(160, 56);
			this.toggleWprgmRun.MainWidth = 50;
			this.toggleWprgmRun.Name = "toggleWprgmRun";
			this.toggleWprgmRun.Position = HP67_Control_Library.TogglePosition.Right;
			this.toggleWprgmRun.RightText = "RUN";
			this.toggleWprgmRun.RightWidth = 30;
			this.toggleWprgmRun.Size = new System.Drawing.Size(140, 16);
			this.toggleWprgmRun.TabIndex = 3;
			this.toggleWprgmRun.ToggleClick += new HP67_Control_Library.Toggle.ToggleClickEvent(this.toggleWprgmRun_ToggleClick);
			// 
			// keyA
			// 
			this.keyA.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyA.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyA.FGWidth = 48;
			this.keyA.FText = "a";
			this.keyA.GText = "";
			this.keyA.HText = "";
			this.keyA.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyA.Location = new System.Drawing.Point(16, 136);
			this.keyA.MainBackColor = System.Drawing.Color.Olive;
			this.keyA.MainForeColor = System.Drawing.Color.White;
			this.keyA.MainText = "A";
			this.keyA.MainWidth = 48;
			this.keyA.Name = "keyA";
			this.keyA.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.A};
			this.keyA.Size = new System.Drawing.Size(48, 51);
			this.keyA.TabIndex = 1;
			this.keyA.Tag = "11";
			this.keyA.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyA.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyf
			// 
			this.keyf.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyf.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyf.FGWidth = 48;
			this.keyf.FText = "";
			this.keyf.GText = "";
			this.keyf.HText = "";
			this.keyf.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyf.Location = new System.Drawing.Point(16, 248);
			this.keyf.MainBackColor = System.Drawing.Color.Gold;
			this.keyf.MainForeColor = System.Drawing.Color.Black;
			this.keyf.MainText = "f";
			this.keyf.MainWidth = 48;
			this.keyf.Name = "keyf";
			this.keyf.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.F};
			this.keyf.Size = new System.Drawing.Size(48, 51);
			this.keyf.TabIndex = 11;
			this.keyf.Tag = "31";
			this.keyf.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyf.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keySST
			// 
			this.keySST.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySST.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keySST.FGWidth = 48;
			this.keySST.FText = "LBL";
			this.keySST.GText = "f";
			this.keySST.HText = "BST";
			this.keySST.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySST.Location = new System.Drawing.Point(240, 192);
			this.keySST.MainBackColor = System.Drawing.Color.Olive;
			this.keySST.MainForeColor = System.Drawing.Color.White;
			this.keySST.MainText = "SST";
			this.keySST.MainWidth = 48;
			this.keySST.Name = "keySST";
			this.keySST.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySST.Size = new System.Drawing.Size(48, 51);
			this.keySST.TabIndex = 10;
			this.keySST.Tag = "25";
			this.keySST.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keySST.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyi
			// 
			this.keyi.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyi.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyi.FGWidth = 48;
			this.keyi.FText = "RND";
			this.keyi.GText = "";
			this.keyi.HText = "x⇆I";
			this.keyi.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyi.Location = new System.Drawing.Point(184, 192);
			this.keyi.MainBackColor = System.Drawing.Color.Olive;
			this.keyi.MainForeColor = System.Drawing.Color.White;
			this.keyi.MainText = "(i)";
			this.keyi.MainWidth = 48;
			this.keyi.Name = "keyi";
			this.keyi.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyi.Size = new System.Drawing.Size(48, 51);
			this.keyi.TabIndex = 9;
			this.keyi.Tag = "24";
			this.keyi.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyi.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyDSP
			// 
			this.keyDSP.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyDSP.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyDSP.FGWidth = 48;
			this.keyDSP.FText = "FIX";
			this.keyDSP.GText = "SCI";
			this.keyDSP.HText = "ENG";
			this.keyDSP.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyDSP.Location = new System.Drawing.Point(128, 192);
			this.keyDSP.MainBackColor = System.Drawing.Color.Olive;
			this.keyDSP.MainForeColor = System.Drawing.Color.White;
			this.keyDSP.MainText = "DSP";
			this.keyDSP.MainWidth = 48;
			this.keyDSP.Name = "keyDSP";
			this.keyDSP.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyDSP.Size = new System.Drawing.Size(48, 51);
			this.keyDSP.TabIndex = 8;
			this.keyDSP.Tag = "23";
			this.keyDSP.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyDSP.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyGTO
			// 
			this.keyGTO.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyGTO.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyGTO.FGWidth = 48;
			this.keyGTO.FText = "GSB";
			this.keyGTO.GText = "f";
			this.keyGTO.HText = "RTN";
			this.keyGTO.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyGTO.Location = new System.Drawing.Point(72, 192);
			this.keyGTO.MainBackColor = System.Drawing.Color.Olive;
			this.keyGTO.MainForeColor = System.Drawing.Color.White;
			this.keyGTO.MainText = "GTO";
			this.keyGTO.MainWidth = 48;
			this.keyGTO.Name = "keyGTO";
			this.keyGTO.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyGTO.Size = new System.Drawing.Size(48, 51);
			this.keyGTO.TabIndex = 7;
			this.keyGTO.Tag = "22";
			this.keyGTO.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyGTO.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyΣ
			// 
			this.keyΣ.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyΣ.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyΣ.FGWidth = 48;
			this.keyΣ.FText = "x̄";
			this.keyΣ.GText = "s";
			this.keyΣ.HText = "Σ-";
			this.keyΣ.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyΣ.Location = new System.Drawing.Point(16, 192);
			this.keyΣ.MainBackColor = System.Drawing.Color.Olive;
			this.keyΣ.MainForeColor = System.Drawing.Color.White;
			this.keyΣ.MainText = "Σ+";
			this.keyΣ.MainWidth = 48;
			this.keyΣ.Name = "keyΣ";
			this.keyΣ.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyΣ.Size = new System.Drawing.Size(48, 51);
			this.keyΣ.TabIndex = 6;
			this.keyΣ.Tag = "21";
			this.keyΣ.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyΣ.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyE
			// 
			this.keyE.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyE.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyE.FGWidth = 48;
			this.keyE.FText = "e";
			this.keyE.GText = "";
			this.keyE.HText = "";
			this.keyE.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyE.Location = new System.Drawing.Point(240, 136);
			this.keyE.MainBackColor = System.Drawing.Color.Olive;
			this.keyE.MainForeColor = System.Drawing.Color.White;
			this.keyE.MainText = "E";
			this.keyE.MainWidth = 48;
			this.keyE.Name = "keyE";
			this.keyE.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.E};
			this.keyE.Size = new System.Drawing.Size(48, 51);
			this.keyE.TabIndex = 5;
			this.keyE.Tag = "15";
			this.keyE.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyE.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyD
			// 
			this.keyD.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyD.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyD.FGWidth = 48;
			this.keyD.FText = "d";
			this.keyD.GText = "";
			this.keyD.HText = "";
			this.keyD.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyD.Location = new System.Drawing.Point(184, 136);
			this.keyD.MainBackColor = System.Drawing.Color.Olive;
			this.keyD.MainForeColor = System.Drawing.Color.White;
			this.keyD.MainText = "D";
			this.keyD.MainWidth = 48;
			this.keyD.Name = "keyD";
			this.keyD.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D};
			this.keyD.Size = new System.Drawing.Size(48, 51);
			this.keyD.TabIndex = 4;
			this.keyD.Tag = "14";
			this.keyD.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyD.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyC
			// 
			this.keyC.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyC.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyC.FGWidth = 48;
			this.keyC.FText = "c";
			this.keyC.GText = "";
			this.keyC.HText = "";
			this.keyC.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyC.Location = new System.Drawing.Point(128, 136);
			this.keyC.MainBackColor = System.Drawing.Color.Olive;
			this.keyC.MainForeColor = System.Drawing.Color.White;
			this.keyC.MainText = "C";
			this.keyC.MainWidth = 48;
			this.keyC.Name = "keyC";
			this.keyC.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.C};
			this.keyC.Size = new System.Drawing.Size(48, 51);
			this.keyC.TabIndex = 3;
			this.keyC.Tag = "13";
			this.keyC.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyC.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyB
			// 
			this.keyB.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyB.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyB.FGWidth = 48;
			this.keyB.FText = "b";
			this.keyB.GText = "";
			this.keyB.HText = "";
			this.keyB.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyB.Location = new System.Drawing.Point(72, 136);
			this.keyB.MainBackColor = System.Drawing.Color.Olive;
			this.keyB.MainForeColor = System.Drawing.Color.White;
			this.keyB.MainText = "B";
			this.keyB.MainWidth = 48;
			this.keyB.Name = "keyB";
			this.keyB.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.B};
			this.keyB.Size = new System.Drawing.Size(48, 51);
			this.keyB.TabIndex = 2;
			this.keyB.Tag = "12";
			this.keyB.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyB.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyENTER
			// 
			this.keyENTER.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyENTER.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.keyENTER.FGWidth = 120;
			this.keyENTER.FText = "W/DATA";
			this.keyENTER.GText = "MERGE";
			this.keyENTER.HText = "DEG";
			this.keyENTER.HTextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.keyENTER.Location = new System.Drawing.Point(8, 304);
			this.keyENTER.MainBackColor = System.Drawing.Color.Olive;
			this.keyENTER.MainForeColor = System.Drawing.Color.White;
			this.keyENTER.MainText = "ENTER ↑";
			this.keyENTER.MainWidth = 104;
			this.keyENTER.Name = "keyENTER";
			this.keyENTER.Shortcuts = new System.Windows.Forms.Keys[] {
																		  System.Windows.Forms.Keys.Enter};
			this.keyENTER.Size = new System.Drawing.Size(120, 51);
			this.keyENTER.TabIndex = 16;
			this.keyENTER.Tag = "41";
			this.keyENTER.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyENTER.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyEEX
			// 
			this.keyEEX.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyEEX.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyEEX.FGWidth = 48;
			this.keyEEX.FText = "CL REG";
			this.keyEEX.GText = "";
			this.keyEEX.HText = "GRD";
			this.keyEEX.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyEEX.Location = new System.Drawing.Point(184, 304);
			this.keyEEX.MainBackColor = System.Drawing.Color.Olive;
			this.keyEEX.MainForeColor = System.Drawing.Color.White;
			this.keyEEX.MainText = "EEX";
			this.keyEEX.MainWidth = 48;
			this.keyEEX.Name = "keyEEX";
			this.keyEEX.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyEEX.Size = new System.Drawing.Size(48, 51);
			this.keyEEX.TabIndex = 18;
			this.keyEEX.Tag = "43";
			this.keyEEX.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyEEX.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyCLx
			// 
			this.keyCLx.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyCLx.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyCLx.FGWidth = 64;
			this.keyCLx.FText = "CL PRGM";
			this.keyCLx.GText = "";
			this.keyCLx.HText = "DEL";
			this.keyCLx.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyCLx.Location = new System.Drawing.Point(232, 304);
			this.keyCLx.MainBackColor = System.Drawing.Color.Olive;
			this.keyCLx.MainForeColor = System.Drawing.Color.White;
			this.keyCLx.MainText = "CLx";
			this.keyCLx.MainWidth = 48;
			this.keyCLx.Name = "keyCLx";
			this.keyCLx.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyCLx.Size = new System.Drawing.Size(64, 51);
			this.keyCLx.TabIndex = 19;
			this.keyCLx.Tag = "44";
			this.keyCLx.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyCLx.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyCHS
			// 
			this.keyCHS.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyCHS.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyCHS.FGWidth = 48;
			this.keyCHS.FText = "P⇆S";
			this.keyCHS.GText = "";
			this.keyCHS.HText = "RAD";
			this.keyCHS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyCHS.Location = new System.Drawing.Point(128, 304);
			this.keyCHS.MainBackColor = System.Drawing.Color.Olive;
			this.keyCHS.MainForeColor = System.Drawing.Color.White;
			this.keyCHS.MainText = "CHS";
			this.keyCHS.MainWidth = 48;
			this.keyCHS.Name = "keyCHS";
			this.keyCHS.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyCHS.Size = new System.Drawing.Size(48, 51);
			this.keyCHS.TabIndex = 17;
			this.keyCHS.Tag = "42";
			this.keyCHS.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyCHS.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyh
			// 
			this.keyh.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyh.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyh.FGWidth = 48;
			this.keyh.FText = "";
			this.keyh.GText = "";
			this.keyh.HText = "";
			this.keyh.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyh.Location = new System.Drawing.Point(240, 248);
			this.keyh.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(32)), ((System.Byte)(32)), ((System.Byte)(32)));
			this.keyh.MainForeColor = System.Drawing.Color.White;
			this.keyh.MainText = "h";
			this.keyh.MainWidth = 48;
			this.keyh.Name = "keyh";
			this.keyh.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.H};
			this.keyh.Size = new System.Drawing.Size(48, 51);
			this.keyh.TabIndex = 15;
			this.keyh.Tag = "35";
			this.keyh.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyh.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyRCL
			// 
			this.keyRCL.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRCL.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyRCL.FGWidth = 48;
			this.keyRCL.FText = "ISZ";
			this.keyRCL.GText = "(i)";
			this.keyRCL.HText = "RC I";
			this.keyRCL.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyRCL.Location = new System.Drawing.Point(184, 248);
			this.keyRCL.MainBackColor = System.Drawing.Color.Olive;
			this.keyRCL.MainForeColor = System.Drawing.Color.White;
			this.keyRCL.MainText = "RCL";
			this.keyRCL.MainWidth = 48;
			this.keyRCL.Name = "keyRCL";
			this.keyRCL.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyRCL.Size = new System.Drawing.Size(48, 51);
			this.keyRCL.TabIndex = 14;
			this.keyRCL.Tag = "34";
			this.keyRCL.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyRCL.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keySTO
			// 
			this.keySTO.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySTO.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keySTO.FGWidth = 48;
			this.keySTO.FText = "DSZ";
			this.keySTO.GText = "(i)";
			this.keySTO.HText = "ST I";
			this.keySTO.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySTO.Location = new System.Drawing.Point(128, 248);
			this.keySTO.MainBackColor = System.Drawing.Color.Olive;
			this.keySTO.MainForeColor = System.Drawing.Color.White;
			this.keySTO.MainText = "STO";
			this.keySTO.MainWidth = 48;
			this.keySTO.Name = "keySTO";
			this.keySTO.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySTO.Size = new System.Drawing.Size(48, 51);
			this.keySTO.TabIndex = 13;
			this.keySTO.Tag = "33";
			this.keySTO.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keySTO.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyg
			// 
			this.keyg.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyg.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.keyg.FGWidth = 48;
			this.keyg.FText = "";
			this.keyg.GText = "";
			this.keyg.HText = "";
			this.keyg.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyg.Location = new System.Drawing.Point(72, 248);
			this.keyg.MainBackColor = System.Drawing.Color.SkyBlue;
			this.keyg.MainForeColor = System.Drawing.Color.Black;
			this.keyg.MainText = "g";
			this.keyg.MainWidth = 48;
			this.keyg.Name = "keyg";
			this.keyg.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.G};
			this.keyg.Size = new System.Drawing.Size(48, 51);
			this.keyg.TabIndex = 12;
			this.keyg.Tag = "32";
			this.keyg.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyg.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key8
			// 
			this.key8.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key8.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.key8.FGWidth = 56;
			this.key8.FText = "LOG";
			this.key8.GText = "10 ̽";
			this.key8.HText = "R↓";
			this.key8.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key8.Location = new System.Drawing.Point(152, 360);
			this.key8.MainBackColor = System.Drawing.Color.LightYellow;
			this.key8.MainForeColor = System.Drawing.Color.Black;
			this.key8.MainText = "8";
			this.key8.MainWidth = 56;
			this.key8.Name = "key8";
			this.key8.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D8,
																	  System.Windows.Forms.Keys.NumPad8};
			this.key8.Size = new System.Drawing.Size(56, 51);
			this.key8.TabIndex = 22;
			this.key8.Tag = "53";
			this.key8.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key8.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyRS
			// 
			this.keyRS.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRS.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.keyRS.FGWidth = 56;
			this.keyRS.FText = "–x–";
			this.keyRS.GText = "STK";
			this.keyRS.HText = "SPACE";
			this.keyRS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyRS.Location = new System.Drawing.Point(232, 528);
			this.keyRS.MainBackColor = System.Drawing.Color.LightYellow;
			this.keyRS.MainForeColor = System.Drawing.Color.Black;
			this.keyRS.MainText = "R/S";
			this.keyRS.MainWidth = 56;
			this.keyRS.Name = "keyRS";
			this.keyRS.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyRS.Size = new System.Drawing.Size(56, 51);
			this.keyRS.TabIndex = 35;
			this.keyRS.Tag = "84";
			this.keyRS.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyRS.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyPeriod
			// 
			this.keyPeriod.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPeriod.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.keyPeriod.FGWidth = 72;
			this.keyPeriod.FText = "INT";
			this.keyPeriod.GText = "FRAC";
			this.keyPeriod.HText = "H.MS+";
			this.keyPeriod.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyPeriod.Location = new System.Drawing.Point(144, 528);
			this.keyPeriod.MainBackColor = System.Drawing.Color.LightYellow;
			this.keyPeriod.MainForeColor = System.Drawing.Color.Black;
			this.keyPeriod.MainText = " ・";
			this.keyPeriod.MainWidth = 56;
			this.keyPeriod.Name = "keyPeriod";
			this.keyPeriod.Shortcuts = new System.Windows.Forms.Keys[] {
																		   System.Windows.Forms.Keys.Decimal};
			this.keyPeriod.Size = new System.Drawing.Size(72, 51);
			this.keyPeriod.TabIndex = 34;
			this.keyPeriod.Tag = "83";
			this.keyPeriod.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyPeriod.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key0
			// 
			this.key0.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key0.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.key0.FGWidth = 56;
			this.key0.FText = "%";
			this.key0.GText = "%CH";
			this.key0.HText = "LST x";
			this.key0.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key0.Location = new System.Drawing.Point(72, 528);
			this.key0.MainBackColor = System.Drawing.Color.LightYellow;
			this.key0.MainForeColor = System.Drawing.Color.Black;
			this.key0.MainText = "0";
			this.key0.MainWidth = 56;
			this.key0.Name = "key0";
			this.key0.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D0,
																	  System.Windows.Forms.Keys.NumPad0};
			this.key0.Size = new System.Drawing.Size(56, 51);
			this.key0.TabIndex = 33;
			this.key0.Tag = "82";
			this.key0.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key0.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key9
			// 
			this.key9.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key9.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.key9.FGWidth = 56;
			this.key9.FText = "√x̅";
			this.key9.GText = "x²";
			this.key9.HText = "R↑";
			this.key9.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key9.Location = new System.Drawing.Point(232, 360);
			this.key9.MainBackColor = System.Drawing.Color.LightYellow;
			this.key9.MainForeColor = System.Drawing.Color.Black;
			this.key9.MainText = "9";
			this.key9.MainWidth = 56;
			this.key9.Name = "key9";
			this.key9.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D9,
																	  System.Windows.Forms.Keys.NumPad9};
			this.key9.Size = new System.Drawing.Size(56, 51);
			this.key9.TabIndex = 23;
			this.key9.Tag = "54";
			this.key9.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key9.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key3
			// 
			this.key3.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key3.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key3.FGWidth = 56;
			this.key3.FText = "H⇄";
			this.key3.GText = "H.MS";
			this.key3.HText = "REG";
			this.key3.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key3.Location = new System.Drawing.Point(232, 472);
			this.key3.MainBackColor = System.Drawing.Color.LightYellow;
			this.key3.MainForeColor = System.Drawing.Color.Black;
			this.key3.MainText = "3";
			this.key3.MainWidth = 56;
			this.key3.Name = "key3";
			this.key3.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D3,
																	  System.Windows.Forms.Keys.NumPad3};
			this.key3.Size = new System.Drawing.Size(56, 51);
			this.key3.TabIndex = 31;
			this.key3.Tag = "74";
			this.key3.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key3.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key2
			// 
			this.key2.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key2.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key2.FGWidth = 56;
			this.key2.FText = "D⇄";
			this.key2.GText = "R";
			this.key2.HText = "π";
			this.key2.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key2.Location = new System.Drawing.Point(152, 472);
			this.key2.MainBackColor = System.Drawing.Color.LightYellow;
			this.key2.MainForeColor = System.Drawing.Color.Black;
			this.key2.MainText = "2";
			this.key2.MainWidth = 56;
			this.key2.Name = "key2";
			this.key2.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D2,
																	  System.Windows.Forms.Keys.NumPad2};
			this.key2.Size = new System.Drawing.Size(56, 51);
			this.key2.TabIndex = 30;
			this.key2.Tag = "73";
			this.key2.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key2.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key1
			// 
			this.key1.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key1.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key1.FGWidth = 56;
			this.key1.FText = "R⇄";
			this.key1.GText = "P";
			this.key1.HText = "PAUSE";
			this.key1.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key1.Location = new System.Drawing.Point(72, 472);
			this.key1.MainBackColor = System.Drawing.Color.LightYellow;
			this.key1.MainForeColor = System.Drawing.Color.Black;
			this.key1.MainText = "1";
			this.key1.MainWidth = 56;
			this.key1.Name = "key1";
			this.key1.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D1,
																	  System.Windows.Forms.Keys.NumPad1};
			this.key1.Size = new System.Drawing.Size(56, 51);
			this.key1.TabIndex = 29;
			this.key1.Tag = "72";
			this.key1.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key1.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key6
			// 
			this.key6.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key6.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key6.FGWidth = 56;
			this.key6.FText = "TAN";
			this.key6.GText = "⁻¹";
			this.key6.HText = "ABS";
			this.key6.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key6.Location = new System.Drawing.Point(232, 416);
			this.key6.MainBackColor = System.Drawing.Color.LightYellow;
			this.key6.MainForeColor = System.Drawing.Color.Black;
			this.key6.MainText = "6";
			this.key6.MainWidth = 56;
			this.key6.Name = "key6";
			this.key6.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D6,
																	  System.Windows.Forms.Keys.NumPad6};
			this.key6.Size = new System.Drawing.Size(56, 51);
			this.key6.TabIndex = 27;
			this.key6.Tag = "64";
			this.key6.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key6.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key5
			// 
			this.key5.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key5.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key5.FGWidth = 56;
			this.key5.FText = "COS";
			this.key5.GText = "⁻¹";
			this.key5.HText = "y ̽";
			this.key5.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key5.Location = new System.Drawing.Point(152, 416);
			this.key5.MainBackColor = System.Drawing.Color.LightYellow;
			this.key5.MainForeColor = System.Drawing.Color.Black;
			this.key5.MainText = "5";
			this.key5.MainWidth = 56;
			this.key5.Name = "key5";
			this.key5.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D5,
																	  System.Windows.Forms.Keys.NumPad5};
			this.key5.Size = new System.Drawing.Size(56, 51);
			this.key5.TabIndex = 26;
			this.key5.Tag = "63";
			this.key5.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key5.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key4
			// 
			this.key4.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key4.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key4.FGWidth = 56;
			this.key4.FText = "SIN";
			this.key4.GText = "⁻¹";
			this.key4.HText = "1/x";
			this.key4.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key4.Location = new System.Drawing.Point(72, 416);
			this.key4.MainBackColor = System.Drawing.Color.LightYellow;
			this.key4.MainForeColor = System.Drawing.Color.Black;
			this.key4.MainText = "4";
			this.key4.MainWidth = 56;
			this.key4.Name = "key4";
			this.key4.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D4,
																	  System.Windows.Forms.Keys.NumPad4};
			this.key4.Size = new System.Drawing.Size(56, 51);
			this.key4.TabIndex = 25;
			this.key4.Tag = "62";
			this.key4.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key4.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// key7
			// 
			this.key7.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key7.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.key7.FGWidth = 56;
			this.key7.FText = "LN";
			this.key7.GText = "e ̽";
			this.key7.HText = "x⇆y";
			this.key7.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key7.Location = new System.Drawing.Point(72, 360);
			this.key7.MainBackColor = System.Drawing.Color.LightYellow;
			this.key7.MainForeColor = System.Drawing.Color.Black;
			this.key7.MainText = "7";
			this.key7.MainWidth = 56;
			this.key7.Name = "key7";
			this.key7.Shortcuts = new System.Windows.Forms.Keys[] {
																	  System.Windows.Forms.Keys.D7,
																	  System.Windows.Forms.Keys.NumPad7};
			this.key7.Size = new System.Drawing.Size(56, 51);
			this.key7.TabIndex = 21;
			this.key7.Tag = "52";
			this.key7.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.key7.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyMinus
			// 
			this.keyMinus.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyMinus.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.keyMinus.FGWidth = 48;
			this.keyMinus.FText = "x=0";
			this.keyMinus.GText = "x=y";
			this.keyMinus.HText = "SF";
			this.keyMinus.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyMinus.Location = new System.Drawing.Point(8, 360);
			this.keyMinus.MainBackColor = System.Drawing.Color.Olive;
			this.keyMinus.MainForeColor = System.Drawing.Color.White;
			this.keyMinus.MainText = "–";
			this.keyMinus.MainWidth = 32;
			this.keyMinus.Name = "keyMinus";
			this.keyMinus.Shortcuts = new System.Windows.Forms.Keys[] {
																		  System.Windows.Forms.Keys.Subtract};
			this.keyMinus.Size = new System.Drawing.Size(48, 51);
			this.keyMinus.TabIndex = 20;
			this.keyMinus.Tag = "51";
			this.keyMinus.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyMinus.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyDiv
			// 
			this.keyDiv.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyDiv.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.keyDiv.FGWidth = 48;
			this.keyDiv.FText = "x>0";
			this.keyDiv.GText = "x>y";
			this.keyDiv.HText = "N!";
			this.keyDiv.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyDiv.Location = new System.Drawing.Point(8, 528);
			this.keyDiv.MainBackColor = System.Drawing.Color.Olive;
			this.keyDiv.MainForeColor = System.Drawing.Color.White;
			this.keyDiv.MainText = "÷";
			this.keyDiv.MainWidth = 32;
			this.keyDiv.Name = "keyDiv";
			this.keyDiv.Shortcuts = new System.Windows.Forms.Keys[] {
																		System.Windows.Forms.Keys.Divide};
			this.keyDiv.Size = new System.Drawing.Size(48, 51);
			this.keyDiv.TabIndex = 32;
			this.keyDiv.Tag = "81";
			this.keyDiv.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyDiv.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyMult
			// 
			this.keyMult.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyMult.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.keyMult.FGWidth = 48;
			this.keyMult.FText = "x<0";
			this.keyMult.GText = "x≤y";
			this.keyMult.HText = "F?";
			this.keyMult.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyMult.Location = new System.Drawing.Point(8, 472);
			this.keyMult.MainBackColor = System.Drawing.Color.Olive;
			this.keyMult.MainForeColor = System.Drawing.Color.White;
			this.keyMult.MainText = "×";
			this.keyMult.MainWidth = 32;
			this.keyMult.Name = "keyMult";
			this.keyMult.Shortcuts = new System.Windows.Forms.Keys[] {
																		 System.Windows.Forms.Keys.Multiply};
			this.keyMult.Size = new System.Drawing.Size(48, 51);
			this.keyMult.TabIndex = 28;
			this.keyMult.Tag = "71";
			this.keyMult.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyMult.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// keyPlus
			// 
			this.keyPlus.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPlus.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.keyPlus.FGWidth = 48;
			this.keyPlus.FText = "x≠0";
			this.keyPlus.GText = "x≠y";
			this.keyPlus.HText = "CF";
			this.keyPlus.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyPlus.Location = new System.Drawing.Point(8, 416);
			this.keyPlus.MainBackColor = System.Drawing.Color.Olive;
			this.keyPlus.MainForeColor = System.Drawing.Color.White;
			this.keyPlus.MainText = "+";
			this.keyPlus.MainWidth = 32;
			this.keyPlus.Name = "keyPlus";
			this.keyPlus.Shortcuts = new System.Windows.Forms.Keys[] {
																		 System.Windows.Forms.Keys.Add};
			this.keyPlus.Size = new System.Drawing.Size(48, 51);
			this.keyPlus.TabIndex = 24;
			this.keyPlus.Tag = "61";
			this.keyPlus.LeftMouseUp += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseUp);
			this.keyPlus.LeftMouseDown += new HP67_Control_Library.Key.KeystrokeEvent(this.LeftMouseDown);
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.openMenuItem,
																						this.saveMenuItem,
																						this.saveAsMenuItem,
																						this.printMenuItem,
																						this.menuSeparator,
																						this.editMenuItem,
																						this.rtfMenuItem});
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
			// HP67
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.ClientSize = new System.Drawing.Size(304, 590);
			this.ContextMenu = this.contextMenu;
			this.Controls.Add(this.keyPlus);
			this.Controls.Add(this.keyMult);
			this.Controls.Add(this.keyDiv);
			this.Controls.Add(this.keyMinus);
			this.Controls.Add(this.key7);
			this.Controls.Add(this.key4);
			this.Controls.Add(this.key5);
			this.Controls.Add(this.key6);
			this.Controls.Add(this.key1);
			this.Controls.Add(this.key2);
			this.Controls.Add(this.key3);
			this.Controls.Add(this.key9);
			this.Controls.Add(this.key0);
			this.Controls.Add(this.keyPeriod);
			this.Controls.Add(this.keyRS);
			this.Controls.Add(this.key8);
			this.Controls.Add(this.keyg);
			this.Controls.Add(this.keySTO);
			this.Controls.Add(this.keyRCL);
			this.Controls.Add(this.keyh);
			this.Controls.Add(this.keyCHS);
			this.Controls.Add(this.keyCLx);
			this.Controls.Add(this.keyEEX);
			this.Controls.Add(this.keyENTER);
			this.Controls.Add(this.keyB);
			this.Controls.Add(this.keyC);
			this.Controls.Add(this.keyD);
			this.Controls.Add(this.keyE);
			this.Controls.Add(this.keyΣ);
			this.Controls.Add(this.keyGTO);
			this.Controls.Add(this.keyDSP);
			this.Controls.Add(this.keyi);
			this.Controls.Add(this.keySST);
			this.Controls.Add(this.keyf);
			this.Controls.Add(this.keyA);
			this.Controls.Add(this.toggleWprgmRun);
			this.Controls.Add(this.toggleOffOn);
			this.Controls.Add(this.cardSlot);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(312, 624);
			this.MinimumSize = new System.Drawing.Size(312, 624);
			this.Name = "HP67";
			this.Text = "HP67";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HP67_KeyDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.HP67_Closing);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HP67_KeyUp);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main (string [] arguments) 
		{
			try 
			{
				Application.Run (new HP67 (arguments));
			}
			catch (Shutdown)
			{
			}
		}

		#region Command Execution

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
					UpdateCardSlot (/* alreadyLocked */ true);
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

				if (stream != null) {
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

		private bool Save (bool alreadyLocked, bool saveAs, CardPart part, ref string name)
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

		public EngineMode CrossThreadNotifyUI (bool busy) 
		{
			if (busy) 
			{
				Busy ();
				return EngineMode.Run;
			}
			else 
			{
				return Unbusy ();
			}
		}

		public bool CrossThreadSaveDataAs () 
		{
			string name = null;

			return Save (/* alreadyLocked */ true, /* saveAs */ true, CardPart.Data, ref name);
		}

		#endregion

		#region UI Utilities

		private void Busy () 
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

		private EngineMode Unbusy () 
		{
			printMenuItem.Enabled = true;

			// Make sure that the state of the card slot reflects the state of the program memory.
			// We can access the program without synchronization, because we only come here through
			// a cross-thread invocation or at startup, and therefore the two threads are
			// synchronized.
			UpdateCardSlot (/* alreadyLocked */ true);
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

		private void HP67_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			executionThread.Abort ();
		}

		private void HP67_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// If a key event is received when the user is not editing the card slot, we look for
			// a key that has the corresponding code as one of its shortcuts, and we send it a
			// mouse event.
			if (cardSlot.State < CardSlotState.Editable || ! cardSlot.ContainsFocus) 
			{
				foreach (Control c in this.Controls) 
				{
					if (c.GetType () == typeof (Key)) 
					{
						foreach (Keys k in ((Key) c).Shortcuts) 
						{
							if (k == e.KeyCode) 
							{
								LeftMouseDown
									((Key) c, new MouseEventArgs (MouseButtons.Left, 0, 0, 0, 0));
							}
						}
					}
				}
			}
		}

		private void HP67_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (cardSlot.State < CardSlotState.Editable || ! cardSlot.ContainsFocus) 
			{
				foreach (Control c in this.Controls) 
				{
					if (c.GetType () == typeof (Key)) 
					{
						foreach (Keys k in ((Key) c).Shortcuts) 
						{
							if (k == e.KeyCode) 
							{
								LeftMouseUp
									((Key) c, new MouseEventArgs (MouseButtons.Left, 0, 0, 0, 0));
							}
						}
					}
				}
			}
		}

		private void LeftMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			// Queue a keystroke, and notify the execution thread that its queue is not empty.
			executionThread.Enqueue
				(new Keystroke ((System.Windows.Forms.Control) sender, e, KeystrokeMotion.Down));
		}

		private void LeftMouseUp (object sender, System.Windows.Forms.MouseEventArgs e)
		{

			// Queue a keystroke, and notify the execution thread that its queue is not empty.
			executionThread.Enqueue
				(new Keystroke ((System.Windows.Forms.Control) sender, e, KeystrokeMotion.Up));
		}

		private void printDocument_PrintPage(object sender,
			System.Drawing.Printing.PrintPageEventArgs e)
		{
			program.PrintOnePage (e, new Font ("Arial Unicode MS", 10));
		}

		private void toggleOffOn_ToggleClick (object sender,
			System.EventArgs e,
			HP67_Control_Library.TogglePosition position)
		{
			switch (toggleOffOn.Position)
			{
				case TogglePosition.Left :
					// OFF.  We abort the execution thread and start a new one.  We leave it in the
					// state where its display is black and it doesn't accept keystrokes.
					Busy ();
					executionThread.Reset (out program); 
					UpdateCardSlot (/* alreadyLocked */ false);
					break;
				case TogglePosition.Right :
					// ON.  First, we cancel any key typed when the power was off.  Then we enqueue
					// a dummy keystroke to cause the execution thread to set the display mode.
					// Finally we release the execution thread.
					executionThread.Clear ();
					executionThread.Enqueue (Keystroke.Noop);
					executionThread.PowerOn.Set ();
					break;
			}		
		}

		private void toggleWprgmRun_ToggleClick (object sender,
			System.EventArgs e,
			HP67_Control_Library.TogglePosition position)
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
