using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mockingbird.HP.HP97
{
	/// <summary>
	/// The user interface for the HP-97 calculator.
	/// </summary>
	public class HP97 :
#if DESIGN
		Form
#else
		CardCalculator
#endif
	{

		#region Private Data

#if DESIGN
		// Unfortunate, but for the design mode to work we need to replicate the declarations of the
		// controls that occur in parent classes.  Danger!  Double-check what happens here if the
		// UI is edited.

		// BaseCalculator.
        protected Mockingbird.HP.Control_Library.Display display;
		protected Mockingbird.HP.Control_Library.Toggle toggleOffOn;

		// ProgrammableCalculator.
		protected Mockingbird.HP.Control_Library.Toggle toggleWprgmRun;
		protected System.Windows.Forms.ContextMenu contextMenu;
		protected System.Windows.Forms.OpenFileDialog openFileDialog;
		protected System.Windows.Forms.SaveFileDialog saveFileDialog;
		protected System.Drawing.Printing.PrintDocument printDocument;
		protected System.Windows.Forms.MenuItem openMenuItem;
		protected System.Windows.Forms.MenuItem printMenuItem;
		protected System.Windows.Forms.MenuItem saveMenuItem;
		protected System.Windows.Forms.MenuItem saveAsMenuItem;

		// CardCalculator.
		protected Mockingbird.HP.Control_Library.CardSlot cardSlot;
		protected System.Windows.Forms.MenuItem menuSeparator;
		protected System.Windows.Forms.MenuItem rtfMenuItem;
		protected System.Windows.Forms.MenuItem editMenuItem;

		// The designer wants the following event handlers to exist otherwise it loses the
		// associations with the controls.
		private void editMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void openMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void printMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void saveMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void saveAsMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void rtfMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{	
		}

		private void Key_LeftMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		}

		private void Key_LeftMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		}

		private void toggleWprgmRun_ToggleClick(object sender, System.EventArgs e, Mockingbird.HP.Control_Library.TogglePosition position)
		{
		}

		private void toggleOffOn_ToggleClick(object sender, System.EventArgs e, Mockingbird.HP.Control_Library.TogglePosition position)
		{
		}

		private void Calculator_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

		private void Calculator_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}

		private void Calculator_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}
#endif

		private Mockingbird.HP.Control_Library.Toggle toggleManNorm;
		private Mockingbird.HP.Control_Library.Key keyE;
		private Mockingbird.HP.Control_Library.Key keyB;
		private Mockingbird.HP.Control_Library.Key keyA;
		private Mockingbird.HP.Control_Library.Key keyD;
		private Mockingbird.HP.Control_Library.Key keyF;
		private Mockingbird.HP.Control_Library.Key keyC;
		private Mockingbird.HP.Control_Library.Key keyToPolar;
		private Mockingbird.HP.Control_Library.Key keyLN;
		private Mockingbird.HP.Control_Library.Key keyEToTheXth;
		private Mockingbird.HP.Control_Library.Key keyRTN;
		private Mockingbird.HP.Control_Library.Key keyGTO;
		private Mockingbird.HP.Control_Library.Key keySST;
		private Mockingbird.HP.Control_Library.Key keyGSB;
		private Mockingbird.HP.Control_Library.Key keyBST;
		private Mockingbird.HP.Control_Library.Key keyLBL;
		private Mockingbird.HP.Control_Library.Key keySqrt;
		private Mockingbird.HP.Control_Library.Key keyReciprocal;
		private Mockingbird.HP.Control_Library.Key keyΣ;
		private Mockingbird.HP.Control_Library.Key keySquare;
		private Mockingbird.HP.Control_Library.Key keyPercent;
		private Mockingbird.HP.Control_Library.Key keyRS;
		private Mockingbird.HP.Control_Library.Key keyToRectangular;
		private Mockingbird.HP.Control_Library.Key keyCOS;
		private Mockingbird.HP.Control_Library.Key keyI;
		private Mockingbird.HP.Control_Library.Key keyTAN;
		private Mockingbird.HP.Control_Library.Key keySubI;
		private Mockingbird.HP.Control_Library.Key keySIN;
		private Mockingbird.HP.Control_Library.Key keyRCL;
		private Mockingbird.HP.Control_Library.Key keySTO;
		private Mockingbird.HP.Control_Library.Key keyYToTheXth;
		private Mockingbird.HP.Control_Library.Key keyPRINTx;
		private Mockingbird.HP.Control_Library.Key keyENG;
		private Mockingbird.HP.Control_Library.Key keySCI;
		private Mockingbird.HP.Control_Library.Key keyCHS;
		private Mockingbird.HP.Control_Library.Key keyFIX;
		private Mockingbird.HP.Control_Library.Key keyENTER;
		private Mockingbird.HP.Control_Library.Key keyEEX;
		private Mockingbird.HP.Control_Library.Key keyPlus;
		private Mockingbird.HP.Control_Library.Key keyDSP;
		private Mockingbird.HP.Control_Library.Key keyPeriod;
		private Mockingbird.HP.Control_Library.Key keyMult;
		private Mockingbird.HP.Control_Library.Key keySub;
		private Mockingbird.HP.Control_Library.Key keyDiv;
		private Mockingbird.HP.Control_Library.Key key6;
		private Mockingbird.HP.Control_Library.Key key3;
		private Mockingbird.HP.Control_Library.Key key9;
		private Mockingbird.HP.Control_Library.Key key5;
		private Mockingbird.HP.Control_Library.Key key2;
		private Mockingbird.HP.Control_Library.Key key8;
		private Mockingbird.HP.Control_Library.Key key4;
		private Mockingbird.HP.Control_Library.Key key1;
		private Mockingbird.HP.Control_Library.Key key7;
		private Mockingbird.HP.Control_Library.Key keyXExchangeY;
		private Mockingbird.HP.Control_Library.Key keyCLx;
		private Mockingbird.HP.Control_Library.Key keyRDown;
		private Mockingbird.HP.Control_Library.Key key0;
		private Mockingbird.HP.Control_Library.Printer printer;
		private System.Windows.Forms.Button buttonPrinter;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Label labelPrint;
		private System.Windows.Forms.GroupBox groupBoxCard;
		private System.Windows.Forms.Label labelTrace;
		private System.Windows.Forms.Panel panelDisplay;
		private System.Windows.Forms.PictureBox pictureBoxLineRight;
		private System.Windows.Forms.PictureBox pictureBoxLineCenter;
		private System.Windows.Forms.PictureBox pictureBoxLineLeft;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructors & Desctructors

		public HP97 (string [] arguments) : base (arguments, CalculatorModel.HP97)
		{
		}

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
		protected override void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (HP97));
            this.printer = new Mockingbird.HP.Control_Library.Printer ();
            this.panelMain = new System.Windows.Forms.Panel ();
            this.labelPrint = new System.Windows.Forms.Label ();
            this.pictureBoxLineRight = new System.Windows.Forms.PictureBox ();
            this.pictureBoxLineCenter = new System.Windows.Forms.PictureBox ();
            this.pictureBoxLineLeft = new System.Windows.Forms.PictureBox ();
            this.keyPRINTx = new Mockingbird.HP.Control_Library.Key ();
            this.keyENG = new Mockingbird.HP.Control_Library.Key ();
            this.keySCI = new Mockingbird.HP.Control_Library.Key ();
            this.keyCHS = new Mockingbird.HP.Control_Library.Key ();
            this.keyFIX = new Mockingbird.HP.Control_Library.Key ();
            this.keyENTER = new Mockingbird.HP.Control_Library.Key ();
            this.keyEEX = new Mockingbird.HP.Control_Library.Key ();
            this.keyPlus = new Mockingbird.HP.Control_Library.Key ();
            this.keyDSP = new Mockingbird.HP.Control_Library.Key ();
            this.keyPeriod = new Mockingbird.HP.Control_Library.Key ();
            this.keyMult = new Mockingbird.HP.Control_Library.Key ();
            this.keySub = new Mockingbird.HP.Control_Library.Key ();
            this.keyDiv = new Mockingbird.HP.Control_Library.Key ();
            this.key6 = new Mockingbird.HP.Control_Library.Key ();
            this.key3 = new Mockingbird.HP.Control_Library.Key ();
            this.key9 = new Mockingbird.HP.Control_Library.Key ();
            this.key5 = new Mockingbird.HP.Control_Library.Key ();
            this.key2 = new Mockingbird.HP.Control_Library.Key ();
            this.key8 = new Mockingbird.HP.Control_Library.Key ();
            this.key4 = new Mockingbird.HP.Control_Library.Key ();
            this.key1 = new Mockingbird.HP.Control_Library.Key ();
            this.key7 = new Mockingbird.HP.Control_Library.Key ();
            this.keyXExchangeY = new Mockingbird.HP.Control_Library.Key ();
            this.keyCLx = new Mockingbird.HP.Control_Library.Key ();
            this.keyRDown = new Mockingbird.HP.Control_Library.Key ();
            this.key0 = new Mockingbird.HP.Control_Library.Key ();
            this.keySqrt = new Mockingbird.HP.Control_Library.Key ();
            this.keyReciprocal = new Mockingbird.HP.Control_Library.Key ();
            this.keyΣ = new Mockingbird.HP.Control_Library.Key ();
            this.keySquare = new Mockingbird.HP.Control_Library.Key ();
            this.keyPercent = new Mockingbird.HP.Control_Library.Key ();
            this.keyRS = new Mockingbird.HP.Control_Library.Key ();
            this.keyToRectangular = new Mockingbird.HP.Control_Library.Key ();
            this.keyCOS = new Mockingbird.HP.Control_Library.Key ();
            this.keyI = new Mockingbird.HP.Control_Library.Key ();
            this.keyTAN = new Mockingbird.HP.Control_Library.Key ();
            this.keySubI = new Mockingbird.HP.Control_Library.Key ();
            this.keySIN = new Mockingbird.HP.Control_Library.Key ();
            this.keyToPolar = new Mockingbird.HP.Control_Library.Key ();
            this.keyLN = new Mockingbird.HP.Control_Library.Key ();
            this.keyRCL = new Mockingbird.HP.Control_Library.Key ();
            this.keyEToTheXth = new Mockingbird.HP.Control_Library.Key ();
            this.keySTO = new Mockingbird.HP.Control_Library.Key ();
            this.keyYToTheXth = new Mockingbird.HP.Control_Library.Key ();
            this.groupBoxCard = new System.Windows.Forms.GroupBox ();
            this.cardSlot = new Mockingbird.HP.Control_Library.CardSlot ();
            this.toggleManNorm = new Mockingbird.HP.Control_Library.Toggle ();
            this.keyE = new Mockingbird.HP.Control_Library.Key ();
            this.toggleOffOn = new Mockingbird.HP.Control_Library.Toggle ();
            this.toggleWprgmRun = new Mockingbird.HP.Control_Library.Toggle ();
            this.keyB = new Mockingbird.HP.Control_Library.Key ();
            this.keyA = new Mockingbird.HP.Control_Library.Key ();
            this.labelTrace = new System.Windows.Forms.Label ();
            this.keyD = new Mockingbird.HP.Control_Library.Key ();
            this.keyC = new Mockingbird.HP.Control_Library.Key ();
            this.keyF = new Mockingbird.HP.Control_Library.Key ();
            this.keyRTN = new Mockingbird.HP.Control_Library.Key ();
            this.keyGTO = new Mockingbird.HP.Control_Library.Key ();
            this.keySST = new Mockingbird.HP.Control_Library.Key ();
            this.keyGSB = new Mockingbird.HP.Control_Library.Key ();
            this.keyBST = new Mockingbird.HP.Control_Library.Key ();
            this.keyLBL = new Mockingbird.HP.Control_Library.Key ();
            this.contextMenu = new System.Windows.Forms.ContextMenu ();
            this.openMenuItem = new System.Windows.Forms.MenuItem ();
            this.saveMenuItem = new System.Windows.Forms.MenuItem ();
            this.saveAsMenuItem = new System.Windows.Forms.MenuItem ();
            this.printMenuItem = new System.Windows.Forms.MenuItem ();
            this.menuSeparator = new System.Windows.Forms.MenuItem ();
            this.editMenuItem = new System.Windows.Forms.MenuItem ();
            this.rtfMenuItem = new System.Windows.Forms.MenuItem ();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog ();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog ();
            this.printDocument = new System.Drawing.Printing.PrintDocument ();
            this.display = new Mockingbird.HP.Control_Library.Display ();
            this.panelDisplay = new System.Windows.Forms.Panel ();
            this.buttonPrinter = new System.Windows.Forms.Button ();
            this.panelMain.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxLineRight)).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxLineCenter)).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxLineLeft)).BeginInit ();
            this.groupBoxCard.SuspendLayout ();
            this.panelDisplay.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // printer
            // 
            this.printer.Location = new System.Drawing.Point (520, 0);
            this.printer.Name = "printer";
            this.printer.Size = new System.Drawing.Size (248, 208);
            this.printer.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add (this.labelPrint);
            this.panelMain.Controls.Add (this.pictureBoxLineRight);
            this.panelMain.Controls.Add (this.pictureBoxLineCenter);
            this.panelMain.Controls.Add (this.pictureBoxLineLeft);
            this.panelMain.Controls.Add (this.keyPRINTx);
            this.panelMain.Controls.Add (this.keyENG);
            this.panelMain.Controls.Add (this.keySCI);
            this.panelMain.Controls.Add (this.keyCHS);
            this.panelMain.Controls.Add (this.keyFIX);
            this.panelMain.Controls.Add (this.keyENTER);
            this.panelMain.Controls.Add (this.keyEEX);
            this.panelMain.Controls.Add (this.keyPlus);
            this.panelMain.Controls.Add (this.keyDSP);
            this.panelMain.Controls.Add (this.keyPeriod);
            this.panelMain.Controls.Add (this.keyMult);
            this.panelMain.Controls.Add (this.keySub);
            this.panelMain.Controls.Add (this.keyDiv);
            this.panelMain.Controls.Add (this.key6);
            this.panelMain.Controls.Add (this.key3);
            this.panelMain.Controls.Add (this.key9);
            this.panelMain.Controls.Add (this.key5);
            this.panelMain.Controls.Add (this.key2);
            this.panelMain.Controls.Add (this.key8);
            this.panelMain.Controls.Add (this.key4);
            this.panelMain.Controls.Add (this.key1);
            this.panelMain.Controls.Add (this.key7);
            this.panelMain.Controls.Add (this.keyXExchangeY);
            this.panelMain.Controls.Add (this.keyCLx);
            this.panelMain.Controls.Add (this.keyRDown);
            this.panelMain.Controls.Add (this.key0);
            this.panelMain.Controls.Add (this.keySqrt);
            this.panelMain.Controls.Add (this.keyReciprocal);
            this.panelMain.Controls.Add (this.keyΣ);
            this.panelMain.Controls.Add (this.keySquare);
            this.panelMain.Controls.Add (this.keyPercent);
            this.panelMain.Controls.Add (this.keyRS);
            this.panelMain.Controls.Add (this.keyToRectangular);
            this.panelMain.Controls.Add (this.keyCOS);
            this.panelMain.Controls.Add (this.keyI);
            this.panelMain.Controls.Add (this.keyTAN);
            this.panelMain.Controls.Add (this.keySubI);
            this.panelMain.Controls.Add (this.keySIN);
            this.panelMain.Controls.Add (this.keyToPolar);
            this.panelMain.Controls.Add (this.keyLN);
            this.panelMain.Controls.Add (this.keyRCL);
            this.panelMain.Controls.Add (this.keyEToTheXth);
            this.panelMain.Controls.Add (this.keySTO);
            this.panelMain.Controls.Add (this.keyYToTheXth);
            this.panelMain.Controls.Add (this.groupBoxCard);
            this.panelMain.Controls.Add (this.keyRTN);
            this.panelMain.Controls.Add (this.keyGTO);
            this.panelMain.Controls.Add (this.keySST);
            this.panelMain.Controls.Add (this.keyGSB);
            this.panelMain.Controls.Add (this.keyBST);
            this.panelMain.Controls.Add (this.keyLBL);
            this.panelMain.Location = new System.Drawing.Point (8, 200);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size (804, 432);
            this.panelMain.TabIndex = 2;
            // 
            // labelPrint
            // 
            this.labelPrint.AutoSize = true;
            this.labelPrint.Font = new System.Drawing.Font ("Arial Unicode MS", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelPrint.ForeColor = System.Drawing.Color.Gold;
            this.labelPrint.Location = new System.Drawing.Point (374, 58);
            this.labelPrint.Name = "labelPrint";
            this.labelPrint.Size = new System.Drawing.Size (53, 16);
            this.labelPrint.TabIndex = 66;
            this.labelPrint.Text = "PRINT:";
            // 
            // pictureBoxLineRight
            // 
            this.pictureBoxLineRight.BackColor = System.Drawing.Color.Gold;
            this.pictureBoxLineRight.Location = new System.Drawing.Point (619, 66);
            this.pictureBoxLineRight.Name = "pictureBoxLineRight";
            this.pictureBoxLineRight.Size = new System.Drawing.Size (77, 2);
            this.pictureBoxLineRight.TabIndex = 65;
            this.pictureBoxLineRight.TabStop = false;
            // 
            // pictureBoxLineCenter
            // 
            this.pictureBoxLineCenter.BackColor = System.Drawing.Color.Gold;
            this.pictureBoxLineCenter.Location = new System.Drawing.Point (544, 66);
            this.pictureBoxLineCenter.Name = "pictureBoxLineCenter";
            this.pictureBoxLineCenter.Size = new System.Drawing.Size (37, 2);
            this.pictureBoxLineCenter.TabIndex = 64;
            this.pictureBoxLineCenter.TabStop = false;
            // 
            // pictureBoxLineLeft
            // 
            this.pictureBoxLineLeft.BackColor = System.Drawing.Color.Gold;
            this.pictureBoxLineLeft.Location = new System.Drawing.Point (466, 66);
            this.pictureBoxLineLeft.Name = "pictureBoxLineLeft";
            this.pictureBoxLineLeft.Size = new System.Drawing.Size (31, 2);
            this.pictureBoxLineLeft.TabIndex = 63;
            this.pictureBoxLineLeft.TabStop = false;
            // 
            // keyPRINTx
            // 
            this.keyPRINTx.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPRINTx.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPRINTx.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyPRINTx.FGWidth = 144;
            this.keyPRINTx.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyPRINTx.FText = "STACK";
            this.keyPRINTx.GText = "";
            this.keyPRINTx.HText = "";
            this.keyPRINTx.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyPRINTx.Location = new System.Drawing.Point (648, 10);
            this.keyPRINTx.MainBackColor = System.Drawing.Color.Olive;
            this.keyPRINTx.MainForeColor = System.Drawing.Color.White;
            this.keyPRINTx.MainHeight = 36;
            this.keyPRINTx.MainText = "PRINT x";
            this.keyPRINTx.MainWidth = 144;
            this.keyPRINTx.Name = "keyPRINTx";
            this.keyPRINTx.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyPRINTx.Size = new System.Drawing.Size (144, 63);
            this.keyPRINTx.TabIndex = 62;
            this.keyPRINTx.Tag = "97-14";
            this.keyPRINTx.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyPRINTx.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyENG
            // 
            this.keyENG.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyENG.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyENG.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyENG.FGWidth = 64;
            this.keyENG.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyENG.FText = "REG";
            this.keyENG.GText = "";
            this.keyENG.HText = "";
            this.keyENG.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyENG.Location = new System.Drawing.Point (568, 10);
            this.keyENG.MainBackColor = System.Drawing.Color.Olive;
            this.keyENG.MainForeColor = System.Drawing.Color.White;
            this.keyENG.MainHeight = 36;
            this.keyENG.MainText = "ENG";
            this.keyENG.MainWidth = 64;
            this.keyENG.Name = "keyENG";
            this.keyENG.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyENG.Size = new System.Drawing.Size (64, 63);
            this.keyENG.TabIndex = 61;
            this.keyENG.Tag = "97-13";
            this.keyENG.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyENG.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySCI
            // 
            this.keySCI.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySCI.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySCI.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySCI.FGWidth = 64;
            this.keySCI.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keySCI.FText = "PRGM";
            this.keySCI.GText = "";
            this.keySCI.HText = "";
            this.keySCI.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySCI.Location = new System.Drawing.Point (488, 10);
            this.keySCI.MainBackColor = System.Drawing.Color.Olive;
            this.keySCI.MainForeColor = System.Drawing.Color.White;
            this.keySCI.MainHeight = 36;
            this.keySCI.MainText = "SCI";
            this.keySCI.MainWidth = 64;
            this.keySCI.Name = "keySCI";
            this.keySCI.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySCI.Size = new System.Drawing.Size (64, 63);
            this.keySCI.TabIndex = 60;
            this.keySCI.Tag = "97-12";
            this.keySCI.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySCI.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyCHS
            // 
            this.keyCHS.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyCHS.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyCHS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyCHS.FGWidth = 64;
            this.keyCHS.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyCHS.FText = "RAD";
            this.keyCHS.GText = "";
            this.keyCHS.HText = "";
            this.keyCHS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyCHS.Location = new System.Drawing.Point (568, 81);
            this.keyCHS.MainBackColor = System.Drawing.Color.Olive;
            this.keyCHS.MainForeColor = System.Drawing.Color.White;
            this.keyCHS.MainHeight = 36;
            this.keyCHS.MainText = "CHS";
            this.keyCHS.MainWidth = 64;
            this.keyCHS.Name = "keyCHS";
            this.keyCHS.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyCHS.Size = new System.Drawing.Size (64, 63);
            this.keyCHS.TabIndex = 59;
            this.keyCHS.Tag = "97-22";
            this.keyCHS.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyCHS.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyFIX
            // 
            this.keyFIX.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyFIX.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyFIX.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyFIX.FGWidth = 64;
            this.keyFIX.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyFIX.FText = "SPACE";
            this.keyFIX.GText = "";
            this.keyFIX.HText = "";
            this.keyFIX.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyFIX.Location = new System.Drawing.Point (408, 10);
            this.keyFIX.MainBackColor = System.Drawing.Color.Olive;
            this.keyFIX.MainForeColor = System.Drawing.Color.White;
            this.keyFIX.MainHeight = 36;
            this.keyFIX.MainText = "FIX";
            this.keyFIX.MainWidth = 64;
            this.keyFIX.Name = "keyFIX";
            this.keyFIX.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyFIX.Size = new System.Drawing.Size (64, 63);
            this.keyFIX.TabIndex = 58;
            this.keyFIX.Tag = "97-11";
            this.keyFIX.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyFIX.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyENTER
            // 
            this.keyENTER.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyENTER.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyENTER.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyENTER.FGWidth = 144;
            this.keyENTER.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyENTER.FText = "DEG";
            this.keyENTER.GText = "";
            this.keyENTER.HText = "";
            this.keyENTER.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyENTER.Location = new System.Drawing.Point (408, 81);
            this.keyENTER.MainBackColor = System.Drawing.Color.Olive;
            this.keyENTER.MainForeColor = System.Drawing.Color.White;
            this.keyENTER.MainHeight = 36;
            this.keyENTER.MainText = "ENTER ↑";
            this.keyENTER.MainWidth = 144;
            this.keyENTER.Name = "keyENTER";
            this.keyENTER.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Return};
            this.keyENTER.Size = new System.Drawing.Size (144, 63);
            this.keyENTER.TabIndex = 57;
            this.keyENTER.Tag = "97-21";
            this.keyENTER.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyENTER.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyEEX
            // 
            this.keyEEX.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyEEX.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyEEX.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyEEX.FGWidth = 64;
            this.keyEEX.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyEEX.FText = "GRD";
            this.keyEEX.GText = "";
            this.keyEEX.HText = "";
            this.keyEEX.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyEEX.Location = new System.Drawing.Point (648, 81);
            this.keyEEX.MainBackColor = System.Drawing.Color.Olive;
            this.keyEEX.MainForeColor = System.Drawing.Color.White;
            this.keyEEX.MainHeight = 36;
            this.keyEEX.MainText = "EEX";
            this.keyEEX.MainWidth = 64;
            this.keyEEX.Name = "keyEEX";
            this.keyEEX.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyEEX.Size = new System.Drawing.Size (64, 63);
            this.keyEEX.TabIndex = 56;
            this.keyEEX.Tag = "97-23";
            this.keyEEX.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyEEX.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyPlus
            // 
            this.keyPlus.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPlus.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPlus.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyPlus.FGWidth = 64;
            this.keyPlus.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyPlus.FText = "H.MS+";
            this.keyPlus.GText = "";
            this.keyPlus.HText = "";
            this.keyPlus.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyPlus.Location = new System.Drawing.Point (728, 294);
            this.keyPlus.MainBackColor = System.Drawing.Color.Olive;
            this.keyPlus.MainForeColor = System.Drawing.Color.White;
            this.keyPlus.MainHeight = 106;
            this.keyPlus.MainText = "+";
            this.keyPlus.MainWidth = 64;
            this.keyPlus.Name = "keyPlus";
            this.keyPlus.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Add};
            this.keyPlus.Size = new System.Drawing.Size (64, 133);
            this.keyPlus.TabIndex = 55;
            this.keyPlus.Tag = "97-55";
            this.keyPlus.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyPlus.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyDSP
            // 
            this.keyDSP.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyDSP.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyDSP.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyDSP.FGWidth = 64;
            this.keyDSP.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyDSP.FText = "LAST x";
            this.keyDSP.GText = "";
            this.keyDSP.HText = "";
            this.keyDSP.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyDSP.Location = new System.Drawing.Point (648, 364);
            this.keyDSP.MainBackColor = System.Drawing.Color.LightYellow;
            this.keyDSP.MainForeColor = System.Drawing.Color.Black;
            this.keyDSP.MainHeight = 36;
            this.keyDSP.MainText = "DSP";
            this.keyDSP.MainWidth = 64;
            this.keyDSP.Name = "keyDSP";
            this.keyDSP.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyDSP.Size = new System.Drawing.Size (64, 63);
            this.keyDSP.TabIndex = 54;
            this.keyDSP.Tag = "97-63";
            this.keyDSP.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyDSP.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyPeriod
            // 
            this.keyPeriod.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPeriod.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPeriod.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyPeriod.FGWidth = 64;
            this.keyPeriod.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyPeriod.FText = "MERGE";
            this.keyPeriod.GText = "";
            this.keyPeriod.HText = "";
            this.keyPeriod.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyPeriod.Location = new System.Drawing.Point (568, 364);
            this.keyPeriod.MainBackColor = System.Drawing.Color.LightYellow;
            this.keyPeriod.MainForeColor = System.Drawing.Color.Black;
            this.keyPeriod.MainHeight = 36;
            this.keyPeriod.MainText = " ・";
            this.keyPeriod.MainWidth = 64;
            this.keyPeriod.Name = "keyPeriod";
            this.keyPeriod.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Decimal};
            this.keyPeriod.Size = new System.Drawing.Size (64, 63);
            this.keyPeriod.TabIndex = 53;
            this.keyPeriod.Tag = "97-62";
            this.keyPeriod.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyPeriod.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyMult
            // 
            this.keyMult.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyMult.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyMult.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyMult.FGWidth = 64;
            this.keyMult.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyMult.FText = "x≤y?";
            this.keyMult.GText = "";
            this.keyMult.HText = "";
            this.keyMult.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyMult.Location = new System.Drawing.Point (728, 152);
            this.keyMult.MainBackColor = System.Drawing.Color.Olive;
            this.keyMult.MainForeColor = System.Drawing.Color.White;
            this.keyMult.MainHeight = 36;
            this.keyMult.MainText = "×";
            this.keyMult.MainWidth = 64;
            this.keyMult.Name = "keyMult";
            this.keyMult.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Multiply};
            this.keyMult.Size = new System.Drawing.Size (64, 63);
            this.keyMult.TabIndex = 52;
            this.keyMult.Tag = "97-35";
            this.keyMult.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyMult.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySub
            // 
            this.keySub.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySub.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySub.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySub.FGWidth = 64;
            this.keySub.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keySub.FText = "x<0?";
            this.keySub.GText = "";
            this.keySub.HText = "";
            this.keySub.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySub.Location = new System.Drawing.Point (728, 223);
            this.keySub.MainBackColor = System.Drawing.Color.Olive;
            this.keySub.MainForeColor = System.Drawing.Color.White;
            this.keySub.MainHeight = 36;
            this.keySub.MainText = "-";
            this.keySub.MainWidth = 64;
            this.keySub.Name = "keySub";
            this.keySub.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Subtract};
            this.keySub.Size = new System.Drawing.Size (64, 63);
            this.keySub.TabIndex = 51;
            this.keySub.Tag = "97-45";
            this.keySub.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySub.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyDiv
            // 
            this.keyDiv.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyDiv.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyDiv.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyDiv.FGWidth = 64;
            this.keyDiv.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyDiv.FText = "π";
            this.keyDiv.GText = "";
            this.keyDiv.HText = "";
            this.keyDiv.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyDiv.Location = new System.Drawing.Point (728, 81);
            this.keyDiv.MainBackColor = System.Drawing.Color.Olive;
            this.keyDiv.MainForeColor = System.Drawing.Color.White;
            this.keyDiv.MainHeight = 36;
            this.keyDiv.MainText = "÷";
            this.keyDiv.MainWidth = 64;
            this.keyDiv.Name = "keyDiv";
            this.keyDiv.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Divide};
            this.keyDiv.Size = new System.Drawing.Size (64, 63);
            this.keyDiv.TabIndex = 50;
            this.keyDiv.Tag = "97-24";
            this.keyDiv.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyDiv.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key6
            // 
            this.key6.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key6.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key6.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key6.FGWidth = 64;
            this.key6.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key6.FText = "x>0?";
            this.key6.GText = "";
            this.key6.HText = "";
            this.key6.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key6.Location = new System.Drawing.Point (648, 223);
            this.key6.MainBackColor = System.Drawing.Color.LightYellow;
            this.key6.MainForeColor = System.Drawing.Color.Black;
            this.key6.MainHeight = 36;
            this.key6.MainText = "6";
            this.key6.MainWidth = 64;
            this.key6.Name = "key6";
            this.key6.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D6,
        System.Windows.Forms.Keys.NumPad6};
            this.key6.Size = new System.Drawing.Size (64, 63);
            this.key6.TabIndex = 49;
            this.key6.Tag = "97-44";
            this.key6.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key6.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key3
            // 
            this.key3.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key3.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key3.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key3.FGWidth = 64;
            this.key3.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key3.FText = "CL PGRM";
            this.key3.GText = "";
            this.key3.HText = "";
            this.key3.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key3.Location = new System.Drawing.Point (648, 294);
            this.key3.MainBackColor = System.Drawing.Color.LightYellow;
            this.key3.MainForeColor = System.Drawing.Color.Black;
            this.key3.MainHeight = 36;
            this.key3.MainText = "3";
            this.key3.MainWidth = 64;
            this.key3.Name = "key3";
            this.key3.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D3,
        System.Windows.Forms.Keys.NumPad3};
            this.key3.Size = new System.Drawing.Size (64, 63);
            this.key3.TabIndex = 48;
            this.key3.Tag = "97-54";
            this.key3.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key3.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key9
            // 
            this.key9.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key9.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key9.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key9.FGWidth = 64;
            this.key9.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key9.FText = "x>y?";
            this.key9.GText = "";
            this.key9.HText = "";
            this.key9.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key9.Location = new System.Drawing.Point (648, 152);
            this.key9.MainBackColor = System.Drawing.Color.LightYellow;
            this.key9.MainForeColor = System.Drawing.Color.Black;
            this.key9.MainHeight = 36;
            this.key9.MainText = "9";
            this.key9.MainWidth = 64;
            this.key9.Name = "key9";
            this.key9.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D9,
        System.Windows.Forms.Keys.NumPad9};
            this.key9.Size = new System.Drawing.Size (64, 63);
            this.key9.TabIndex = 47;
            this.key9.Tag = "97-34";
            this.key9.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key9.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key5
            // 
            this.key5.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key5.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key5.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key5.FGWidth = 64;
            this.key5.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key5.FText = "x=0?";
            this.key5.GText = "";
            this.key5.HText = "";
            this.key5.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key5.Location = new System.Drawing.Point (568, 223);
            this.key5.MainBackColor = System.Drawing.Color.LightYellow;
            this.key5.MainForeColor = System.Drawing.Color.Black;
            this.key5.MainHeight = 36;
            this.key5.MainText = "5";
            this.key5.MainWidth = 64;
            this.key5.Name = "key5";
            this.key5.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D5,
        System.Windows.Forms.Keys.NumPad5};
            this.key5.Size = new System.Drawing.Size (64, 63);
            this.key5.TabIndex = 46;
            this.key5.Tag = "97-43";
            this.key5.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key5.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key2
            // 
            this.key2.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key2.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key2.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key2.FGWidth = 64;
            this.key2.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key2.FText = "CL REG";
            this.key2.GText = "";
            this.key2.HText = "";
            this.key2.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key2.Location = new System.Drawing.Point (568, 294);
            this.key2.MainBackColor = System.Drawing.Color.LightYellow;
            this.key2.MainForeColor = System.Drawing.Color.Black;
            this.key2.MainHeight = 36;
            this.key2.MainText = "2";
            this.key2.MainWidth = 64;
            this.key2.Name = "key2";
            this.key2.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D2,
        System.Windows.Forms.Keys.NumPad2};
            this.key2.Size = new System.Drawing.Size (64, 63);
            this.key2.TabIndex = 45;
            this.key2.Tag = "97-53";
            this.key2.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key2.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key8
            // 
            this.key8.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key8.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key8.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key8.FGWidth = 64;
            this.key8.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key8.FText = "x=y?";
            this.key8.GText = "";
            this.key8.HText = "";
            this.key8.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key8.Location = new System.Drawing.Point (568, 152);
            this.key8.MainBackColor = System.Drawing.Color.LightYellow;
            this.key8.MainForeColor = System.Drawing.Color.Black;
            this.key8.MainHeight = 36;
            this.key8.MainText = "8";
            this.key8.MainWidth = 64;
            this.key8.Name = "key8";
            this.key8.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D8,
        System.Windows.Forms.Keys.NumPad8};
            this.key8.Size = new System.Drawing.Size (64, 63);
            this.key8.TabIndex = 44;
            this.key8.Tag = "97-33";
            this.key8.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key8.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key4
            // 
            this.key4.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key4.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key4.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key4.FGWidth = 64;
            this.key4.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key4.FText = "x≠0?";
            this.key4.GText = "";
            this.key4.HText = "";
            this.key4.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key4.Location = new System.Drawing.Point (488, 223);
            this.key4.MainBackColor = System.Drawing.Color.LightYellow;
            this.key4.MainForeColor = System.Drawing.Color.Black;
            this.key4.MainHeight = 36;
            this.key4.MainText = "4";
            this.key4.MainWidth = 64;
            this.key4.Name = "key4";
            this.key4.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D4,
        System.Windows.Forms.Keys.NumPad4};
            this.key4.Size = new System.Drawing.Size (64, 63);
            this.key4.TabIndex = 43;
            this.key4.Tag = "97-42";
            this.key4.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key4.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key1
            // 
            this.key1.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key1.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key1.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key1.FGWidth = 64;
            this.key1.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key1.FText = "DEL";
            this.key1.GText = "";
            this.key1.HText = "";
            this.key1.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key1.Location = new System.Drawing.Point (488, 294);
            this.key1.MainBackColor = System.Drawing.Color.LightYellow;
            this.key1.MainForeColor = System.Drawing.Color.Black;
            this.key1.MainHeight = 36;
            this.key1.MainText = "1";
            this.key1.MainWidth = 64;
            this.key1.Name = "key1";
            this.key1.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D1,
        System.Windows.Forms.Keys.NumPad1};
            this.key1.Size = new System.Drawing.Size (64, 63);
            this.key1.TabIndex = 42;
            this.key1.Tag = "97-52";
            this.key1.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key1.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key7
            // 
            this.key7.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key7.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key7.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key7.FGWidth = 64;
            this.key7.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key7.FText = "x≠y?";
            this.key7.GText = "";
            this.key7.HText = "";
            this.key7.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key7.Location = new System.Drawing.Point (488, 152);
            this.key7.MainBackColor = System.Drawing.Color.LightYellow;
            this.key7.MainForeColor = System.Drawing.Color.Black;
            this.key7.MainHeight = 36;
            this.key7.MainText = "7";
            this.key7.MainWidth = 64;
            this.key7.Name = "key7";
            this.key7.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D7,
        System.Windows.Forms.Keys.NumPad7};
            this.key7.Size = new System.Drawing.Size (64, 63);
            this.key7.TabIndex = 41;
            this.key7.Tag = "97-32";
            this.key7.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key7.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyXExchangeY
            // 
            this.keyXExchangeY.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyXExchangeY.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyXExchangeY.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyXExchangeY.FGWidth = 64;
            this.keyXExchangeY.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyXExchangeY.FText = "x⇄I";
            this.keyXExchangeY.GText = "";
            this.keyXExchangeY.HText = "";
            this.keyXExchangeY.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyXExchangeY.Location = new System.Drawing.Point (408, 223);
            this.keyXExchangeY.MainBackColor = System.Drawing.Color.Olive;
            this.keyXExchangeY.MainForeColor = System.Drawing.Color.White;
            this.keyXExchangeY.MainHeight = 36;
            this.keyXExchangeY.MainText = "x⇄y";
            this.keyXExchangeY.MainWidth = 64;
            this.keyXExchangeY.Name = "keyXExchangeY";
            this.keyXExchangeY.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyXExchangeY.Size = new System.Drawing.Size (64, 63);
            this.keyXExchangeY.TabIndex = 40;
            this.keyXExchangeY.Tag = "97-41";
            this.keyXExchangeY.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyXExchangeY.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyCLx
            // 
            this.keyCLx.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyCLx.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyCLx.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyCLx.FGWidth = 64;
            this.keyCLx.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyCLx.FText = "P⇄S";
            this.keyCLx.GText = "";
            this.keyCLx.HText = "";
            this.keyCLx.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyCLx.Location = new System.Drawing.Point (408, 294);
            this.keyCLx.MainBackColor = System.Drawing.Color.Olive;
            this.keyCLx.MainForeColor = System.Drawing.Color.White;
            this.keyCLx.MainHeight = 36;
            this.keyCLx.MainText = "CL x";
            this.keyCLx.MainWidth = 64;
            this.keyCLx.Name = "keyCLx";
            this.keyCLx.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyCLx.Size = new System.Drawing.Size (64, 63);
            this.keyCLx.TabIndex = 39;
            this.keyCLx.Tag = "97-51";
            this.keyCLx.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyCLx.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyRDown
            // 
            this.keyRDown.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRDown.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRDown.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyRDown.FGWidth = 64;
            this.keyRDown.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyRDown.FText = "R↑";
            this.keyRDown.GText = "";
            this.keyRDown.HText = "";
            this.keyRDown.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyRDown.Location = new System.Drawing.Point (408, 152);
            this.keyRDown.MainBackColor = System.Drawing.Color.Olive;
            this.keyRDown.MainForeColor = System.Drawing.Color.White;
            this.keyRDown.MainHeight = 36;
            this.keyRDown.MainText = "R↓";
            this.keyRDown.MainWidth = 64;
            this.keyRDown.Name = "keyRDown";
            this.keyRDown.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyRDown.Size = new System.Drawing.Size (64, 63);
            this.keyRDown.TabIndex = 38;
            this.keyRDown.Tag = "97-31";
            this.keyRDown.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyRDown.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key0
            // 
            this.key0.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key0.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key0.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key0.FGWidth = 144;
            this.key0.Font = new System.Drawing.Font ("Arial Unicode MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.key0.FText = "WRITE DATA";
            this.key0.GText = "";
            this.key0.HText = "";
            this.key0.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key0.Location = new System.Drawing.Point (408, 364);
            this.key0.MainBackColor = System.Drawing.Color.LightYellow;
            this.key0.MainForeColor = System.Drawing.Color.Black;
            this.key0.MainHeight = 36;
            this.key0.MainText = "0";
            this.key0.MainWidth = 144;
            this.key0.Name = "key0";
            this.key0.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D0,
        System.Windows.Forms.Keys.NumPad0};
            this.key0.Size = new System.Drawing.Size (144, 63);
            this.key0.TabIndex = 37;
            this.key0.Tag = "97-61";
            this.key0.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key0.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySqrt
            // 
            this.keySqrt.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySqrt.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySqrt.FGWidth = 48;
            this.keySqrt.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keySqrt.FText = "S";
            this.keySqrt.GText = "";
            this.keySqrt.HText = "";
            this.keySqrt.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySqrt.Location = new System.Drawing.Point (192, 376);
            this.keySqrt.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySqrt.MainForeColor = System.Drawing.Color.White;
            this.keySqrt.MainHeight = 24;
            this.keySqrt.MainText = "√x̅";
            this.keySqrt.MainWidth = 48;
            this.keySqrt.Name = "keySqrt";
            this.keySqrt.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySqrt.Size = new System.Drawing.Size (48, 51);
            this.keySqrt.TabIndex = 34;
            this.keySqrt.Tag = "9754";
            this.keySqrt.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySqrt.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyReciprocal
            // 
            this.keyReciprocal.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyReciprocal.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyReciprocal.FGWidth = 48;
            this.keyReciprocal.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyReciprocal.FText = "N!";
            this.keyReciprocal.GText = "";
            this.keyReciprocal.HText = "";
            this.keyReciprocal.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyReciprocal.Location = new System.Drawing.Point (80, 376);
            this.keyReciprocal.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyReciprocal.MainForeColor = System.Drawing.Color.White;
            this.keyReciprocal.MainHeight = 24;
            this.keyReciprocal.MainText = "1/x";
            this.keyReciprocal.MainWidth = 48;
            this.keyReciprocal.Name = "keyReciprocal";
            this.keyReciprocal.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyReciprocal.Size = new System.Drawing.Size (48, 51);
            this.keyReciprocal.TabIndex = 32;
            this.keyReciprocal.Tag = "9752";
            this.keyReciprocal.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyReciprocal.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyΣ
            // 
            this.keyΣ.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyΣ.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyΣ.FGWidth = 48;
            this.keyΣ.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyΣ.FText = "Σ-";
            this.keyΣ.GText = "";
            this.keyΣ.HText = "";
            this.keyΣ.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyΣ.Location = new System.Drawing.Point (304, 376);
            this.keyΣ.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyΣ.MainForeColor = System.Drawing.Color.White;
            this.keyΣ.MainHeight = 24;
            this.keyΣ.MainText = "Σ+";
            this.keyΣ.MainWidth = 48;
            this.keyΣ.Name = "keyΣ";
            this.keyΣ.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.keyΣ.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyΣ.Size = new System.Drawing.Size (48, 51);
            this.keyΣ.TabIndex = 35;
            this.keyΣ.Tag = "9756";
            this.keyΣ.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyΣ.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySquare
            // 
            this.keySquare.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySquare.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySquare.FGWidth = 48;
            this.keySquare.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keySquare.FText = "x̅";
            this.keySquare.GText = "";
            this.keySquare.HText = "";
            this.keySquare.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySquare.Location = new System.Drawing.Point (136, 376);
            this.keySquare.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySquare.MainForeColor = System.Drawing.Color.White;
            this.keySquare.MainHeight = 24;
            this.keySquare.MainText = "x²";
            this.keySquare.MainWidth = 48;
            this.keySquare.Name = "keySquare";
            this.keySquare.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySquare.Size = new System.Drawing.Size (48, 51);
            this.keySquare.TabIndex = 33;
            this.keySquare.Tag = "9753";
            this.keySquare.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySquare.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyPercent
            // 
            this.keyPercent.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPercent.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyPercent.FGWidth = 48;
            this.keyPercent.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyPercent.FText = "%CH";
            this.keyPercent.GText = "";
            this.keyPercent.HText = "";
            this.keyPercent.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyPercent.Location = new System.Drawing.Point (248, 376);
            this.keyPercent.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPercent.MainForeColor = System.Drawing.Color.White;
            this.keyPercent.MainHeight = 24;
            this.keyPercent.MainText = "%";
            this.keyPercent.MainWidth = 48;
            this.keyPercent.Name = "keyPercent";
            this.keyPercent.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyPercent.Size = new System.Drawing.Size (48, 51);
            this.keyPercent.TabIndex = 36;
            this.keyPercent.Tag = "9755";
            this.keyPercent.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyPercent.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyRS
            // 
            this.keyRS.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyRS.FGWidth = 48;
            this.keyRS.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyRS.FText = "PAUSE";
            this.keyRS.GText = "";
            this.keyRS.HText = "";
            this.keyRS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyRS.Location = new System.Drawing.Point (24, 376);
            this.keyRS.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRS.MainForeColor = System.Drawing.Color.White;
            this.keyRS.MainHeight = 24;
            this.keyRS.MainText = "R/S";
            this.keyRS.MainWidth = 48;
            this.keyRS.Name = "keyRS";
            this.keyRS.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyRS.Size = new System.Drawing.Size (48, 51);
            this.keyRS.TabIndex = 31;
            this.keyRS.Tag = "9751";
            this.keyRS.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyRS.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyToRectangular
            // 
            this.keyToRectangular.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyToRectangular.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyToRectangular.FGWidth = 48;
            this.keyToRectangular.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyToRectangular.FText = "FRAC";
            this.keyToRectangular.GText = "";
            this.keyToRectangular.HText = "";
            this.keyToRectangular.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyToRectangular.Location = new System.Drawing.Point (192, 320);
            this.keyToRectangular.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyToRectangular.MainForeColor = System.Drawing.Color.White;
            this.keyToRectangular.MainHeight = 24;
            this.keyToRectangular.MainText = "→R";
            this.keyToRectangular.MainWidth = 48;
            this.keyToRectangular.Name = "keyToRectangular";
            this.keyToRectangular.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyToRectangular.Size = new System.Drawing.Size (48, 51);
            this.keyToRectangular.TabIndex = 28;
            this.keyToRectangular.Tag = "9744";
            this.keyToRectangular.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyToRectangular.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyCOS
            // 
            this.keyCOS.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyCOS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyCOS.FGWidth = 48;
            this.keyCOS.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyCOS.FText = "COS⁻¹";
            this.keyCOS.GText = "";
            this.keyCOS.HText = "";
            this.keyCOS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyCOS.Location = new System.Drawing.Point (80, 320);
            this.keyCOS.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyCOS.MainForeColor = System.Drawing.Color.White;
            this.keyCOS.MainHeight = 24;
            this.keyCOS.MainText = "COS";
            this.keyCOS.MainWidth = 48;
            this.keyCOS.Name = "keyCOS";
            this.keyCOS.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyCOS.Size = new System.Drawing.Size (48, 51);
            this.keyCOS.TabIndex = 26;
            this.keyCOS.Tag = "9742";
            this.keyCOS.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyCOS.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyI
            // 
            this.keyI.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyI.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyI.FGWidth = 48;
            this.keyI.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyI.FText = "R→D";
            this.keyI.GText = "";
            this.keyI.HText = "";
            this.keyI.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyI.Location = new System.Drawing.Point (304, 320);
            this.keyI.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyI.MainForeColor = System.Drawing.Color.White;
            this.keyI.MainHeight = 24;
            this.keyI.MainText = "I";
            this.keyI.MainWidth = 48;
            this.keyI.Name = "keyI";
            this.keyI.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyI.Size = new System.Drawing.Size (48, 51);
            this.keyI.TabIndex = 29;
            this.keyI.Tag = "9746";
            this.keyI.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyI.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyTAN
            // 
            this.keyTAN.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyTAN.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyTAN.FGWidth = 48;
            this.keyTAN.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyTAN.FText = "TAN⁻¹";
            this.keyTAN.GText = "";
            this.keyTAN.HText = "";
            this.keyTAN.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyTAN.Location = new System.Drawing.Point (136, 320);
            this.keyTAN.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyTAN.MainForeColor = System.Drawing.Color.White;
            this.keyTAN.MainHeight = 24;
            this.keyTAN.MainText = "TAN";
            this.keyTAN.MainWidth = 48;
            this.keyTAN.Name = "keyTAN";
            this.keyTAN.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyTAN.Size = new System.Drawing.Size (48, 51);
            this.keyTAN.TabIndex = 27;
            this.keyTAN.Tag = "9743";
            this.keyTAN.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyTAN.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySubI
            // 
            this.keySubI.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySubI.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySubI.FGWidth = 48;
            this.keySubI.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keySubI.FText = "D→R";
            this.keySubI.GText = "";
            this.keySubI.HText = "";
            this.keySubI.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySubI.Location = new System.Drawing.Point (248, 320);
            this.keySubI.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySubI.MainForeColor = System.Drawing.Color.White;
            this.keySubI.MainHeight = 24;
            this.keySubI.MainText = "(i)";
            this.keySubI.MainWidth = 48;
            this.keySubI.Name = "keySubI";
            this.keySubI.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySubI.Size = new System.Drawing.Size (48, 51);
            this.keySubI.TabIndex = 30;
            this.keySubI.Tag = "9745";
            this.keySubI.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySubI.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySIN
            // 
            this.keySIN.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySIN.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySIN.FGWidth = 48;
            this.keySIN.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keySIN.FText = "SIN⁻¹";
            this.keySIN.GText = "";
            this.keySIN.HText = "";
            this.keySIN.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySIN.Location = new System.Drawing.Point (24, 320);
            this.keySIN.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySIN.MainForeColor = System.Drawing.Color.White;
            this.keySIN.MainHeight = 24;
            this.keySIN.MainText = "SIN";
            this.keySIN.MainWidth = 48;
            this.keySIN.Name = "keySIN";
            this.keySIN.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySIN.Size = new System.Drawing.Size (48, 51);
            this.keySIN.TabIndex = 25;
            this.keySIN.Tag = "9741";
            this.keySIN.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySIN.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyToPolar
            // 
            this.keyToPolar.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyToPolar.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyToPolar.FGWidth = 48;
            this.keyToPolar.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyToPolar.FText = "INT";
            this.keyToPolar.GText = "";
            this.keyToPolar.HText = "";
            this.keyToPolar.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyToPolar.Location = new System.Drawing.Point (192, 264);
            this.keyToPolar.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyToPolar.MainForeColor = System.Drawing.Color.White;
            this.keyToPolar.MainHeight = 24;
            this.keyToPolar.MainText = "→P";
            this.keyToPolar.MainWidth = 48;
            this.keyToPolar.Name = "keyToPolar";
            this.keyToPolar.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyToPolar.Size = new System.Drawing.Size (48, 51);
            this.keyToPolar.TabIndex = 22;
            this.keyToPolar.Tag = "9734";
            this.keyToPolar.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyToPolar.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyLN
            // 
            this.keyLN.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyLN.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyLN.FGWidth = 48;
            this.keyLN.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyLN.FText = "LOG";
            this.keyLN.GText = "";
            this.keyLN.HText = "";
            this.keyLN.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyLN.Location = new System.Drawing.Point (80, 264);
            this.keyLN.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyLN.MainForeColor = System.Drawing.Color.White;
            this.keyLN.MainHeight = 24;
            this.keyLN.MainText = "LN";
            this.keyLN.MainWidth = 48;
            this.keyLN.Name = "keyLN";
            this.keyLN.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyLN.Size = new System.Drawing.Size (48, 51);
            this.keyLN.TabIndex = 20;
            this.keyLN.Tag = "9732";
            this.keyLN.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyLN.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyRCL
            // 
            this.keyRCL.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRCL.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyRCL.FGWidth = 48;
            this.keyRCL.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyRCL.FText = "H.MS→";
            this.keyRCL.GText = "";
            this.keyRCL.HText = "";
            this.keyRCL.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyRCL.Location = new System.Drawing.Point (304, 264);
            this.keyRCL.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRCL.MainForeColor = System.Drawing.Color.White;
            this.keyRCL.MainHeight = 24;
            this.keyRCL.MainText = "RCL";
            this.keyRCL.MainWidth = 48;
            this.keyRCL.Name = "keyRCL";
            this.keyRCL.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyRCL.Size = new System.Drawing.Size (48, 51);
            this.keyRCL.TabIndex = 23;
            this.keyRCL.Tag = "9736";
            this.keyRCL.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyRCL.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyEToTheXth
            // 
            this.keyEToTheXth.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyEToTheXth.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyEToTheXth.FGWidth = 48;
            this.keyEToTheXth.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyEToTheXth.FText = "10 ̽";
            this.keyEToTheXth.GText = "";
            this.keyEToTheXth.HText = "";
            this.keyEToTheXth.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyEToTheXth.Location = new System.Drawing.Point (136, 264);
            this.keyEToTheXth.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyEToTheXth.MainForeColor = System.Drawing.Color.White;
            this.keyEToTheXth.MainHeight = 24;
            this.keyEToTheXth.MainText = "e ̽";
            this.keyEToTheXth.MainWidth = 48;
            this.keyEToTheXth.Name = "keyEToTheXth";
            this.keyEToTheXth.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyEToTheXth.Size = new System.Drawing.Size (48, 51);
            this.keyEToTheXth.TabIndex = 21;
            this.keyEToTheXth.Tag = "9733";
            this.keyEToTheXth.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyEToTheXth.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySTO
            // 
            this.keySTO.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySTO.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySTO.FGWidth = 48;
            this.keySTO.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keySTO.FText = "→H.MS";
            this.keySTO.GText = "";
            this.keySTO.HText = "";
            this.keySTO.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySTO.Location = new System.Drawing.Point (248, 264);
            this.keySTO.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySTO.MainForeColor = System.Drawing.Color.White;
            this.keySTO.MainHeight = 24;
            this.keySTO.MainText = "STO";
            this.keySTO.MainWidth = 48;
            this.keySTO.Name = "keySTO";
            this.keySTO.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySTO.Size = new System.Drawing.Size (48, 51);
            this.keySTO.TabIndex = 24;
            this.keySTO.Tag = "9735";
            this.keySTO.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySTO.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyYToTheXth
            // 
            this.keyYToTheXth.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyYToTheXth.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyYToTheXth.FGWidth = 48;
            this.keyYToTheXth.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyYToTheXth.FText = "ABS";
            this.keyYToTheXth.GText = "";
            this.keyYToTheXth.HText = "";
            this.keyYToTheXth.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyYToTheXth.Location = new System.Drawing.Point (24, 264);
            this.keyYToTheXth.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyYToTheXth.MainForeColor = System.Drawing.Color.White;
            this.keyYToTheXth.MainHeight = 24;
            this.keyYToTheXth.MainText = "y ̽";
            this.keyYToTheXth.MainWidth = 48;
            this.keyYToTheXth.Name = "keyYToTheXth";
            this.keyYToTheXth.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyYToTheXth.Size = new System.Drawing.Size (48, 51);
            this.keyYToTheXth.TabIndex = 19;
            this.keyYToTheXth.Tag = "9731";
            this.keyYToTheXth.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyYToTheXth.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // groupBoxCard
            // 
            this.groupBoxCard.Controls.Add (this.cardSlot);
            this.groupBoxCard.Controls.Add (this.toggleManNorm);
            this.groupBoxCard.Controls.Add (this.keyE);
            this.groupBoxCard.Controls.Add (this.toggleOffOn);
            this.groupBoxCard.Controls.Add (this.toggleWprgmRun);
            this.groupBoxCard.Controls.Add (this.keyB);
            this.groupBoxCard.Controls.Add (this.keyA);
            this.groupBoxCard.Controls.Add (this.labelTrace);
            this.groupBoxCard.Controls.Add (this.keyD);
            this.groupBoxCard.Controls.Add (this.keyC);
            this.groupBoxCard.Controls.Add (this.keyF);
            this.groupBoxCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxCard.Location = new System.Drawing.Point (8, 4);
            this.groupBoxCard.Name = "groupBoxCard";
            this.groupBoxCard.Size = new System.Drawing.Size (352, 200);
            this.groupBoxCard.TabIndex = 12;
            this.groupBoxCard.TabStop = false;
            // 
            // cardSlot
            // 
            this.cardSlot.Location = new System.Drawing.Point (8, 92);
            this.cardSlot.Name = "cardSlot";
            this.cardSlot.RichText = false;
            this.cardSlot.Size = new System.Drawing.Size (288, 50);
            this.cardSlot.State = Mockingbird.HP.Control_Library.CardSlotState.Unloaded;
            this.cardSlot.TabIndex = 12;
            this.cardSlot.TextBoxWidth = 48;
            this.cardSlot.Title = "<TITLE>";
            this.cardSlot.UnloadedTextA = "1/x";
            this.cardSlot.UnloadedTextB = "√x̅";
            this.cardSlot.UnloadedTextC = "yˣ";
            this.cardSlot.UnloadedTextD = "R↓";
            this.cardSlot.UnloadedTextE = "x⇄y";
            // 
            // toggleManNorm
            // 
            this.toggleManNorm.LeftText = "MAN";
            this.toggleManNorm.LeftWidth = 60;
            this.toggleManNorm.Location = new System.Drawing.Point (186, 34);
            this.toggleManNorm.MainWidth = 50;
            this.toggleManNorm.Name = "toggleManNorm";
            this.toggleManNorm.Position = Mockingbird.HP.Control_Library.TogglePosition.Left;
            this.toggleManNorm.RightText = "NORM";
            this.toggleManNorm.RightWidth = 50;
            this.toggleManNorm.Size = new System.Drawing.Size (160, 16);
            this.toggleManNorm.TabIndex = 1;
            // 
            // keyE
            // 
            this.keyE.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyE.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyE.FGWidth = 48;
            this.keyE.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyE.FText = "e";
            this.keyE.GText = "";
            this.keyE.HText = "";
            this.keyE.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyE.Location = new System.Drawing.Point (240, 148);
            this.keyE.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyE.MainForeColor = System.Drawing.Color.White;
            this.keyE.MainHeight = 24;
            this.keyE.MainText = "E";
            this.keyE.MainWidth = 48;
            this.keyE.Name = "keyE";
            this.keyE.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.E};
            this.keyE.Size = new System.Drawing.Size (48, 51);
            this.keyE.TabIndex = 11;
            this.keyE.Tag = "9715";
            this.keyE.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyE.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // toggleOffOn
            // 
            this.toggleOffOn.LeftText = "OFF";
            this.toggleOffOn.LeftWidth = 30;
            this.toggleOffOn.Location = new System.Drawing.Point (8, 34);
            this.toggleOffOn.MainWidth = 50;
            this.toggleOffOn.Name = "toggleOffOn";
            this.toggleOffOn.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
            this.toggleOffOn.RightText = "ON";
            this.toggleOffOn.RightWidth = 30;
            this.toggleOffOn.Size = new System.Drawing.Size (110, 16);
            this.toggleOffOn.TabIndex = 2;
            this.toggleOffOn.ToggleClick += new Mockingbird.HP.Control_Library.Toggle.ToggleClickEvent (this.toggleOffOn_ToggleClick);
            // 
            // toggleWprgmRun
            // 
            this.toggleWprgmRun.LeftText = "PRGM";
            this.toggleWprgmRun.LeftWidth = 60;
            this.toggleWprgmRun.Location = new System.Drawing.Point (186, 58);
            this.toggleWprgmRun.MainWidth = 50;
            this.toggleWprgmRun.Name = "toggleWprgmRun";
            this.toggleWprgmRun.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
            this.toggleWprgmRun.RightText = "RUN";
            this.toggleWprgmRun.RightWidth = 30;
            this.toggleWprgmRun.Size = new System.Drawing.Size (140, 16);
            this.toggleWprgmRun.TabIndex = 13;
            this.toggleWprgmRun.ToggleClick += new Mockingbird.HP.Control_Library.Toggle.ToggleClickEvent (this.toggleWprgmRun_ToggleClick);
            // 
            // keyB
            // 
            this.keyB.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyB.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyB.FGWidth = 48;
            this.keyB.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyB.FText = "b";
            this.keyB.GText = "";
            this.keyB.HText = "";
            this.keyB.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyB.Location = new System.Drawing.Point (72, 148);
            this.keyB.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyB.MainForeColor = System.Drawing.Color.White;
            this.keyB.MainHeight = 24;
            this.keyB.MainText = "B";
            this.keyB.MainWidth = 48;
            this.keyB.Name = "keyB";
            this.keyB.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.B};
            this.keyB.Size = new System.Drawing.Size (48, 51);
            this.keyB.TabIndex = 6;
            this.keyB.Tag = "9712";
            this.keyB.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyB.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyA
            // 
            this.keyA.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyA.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyA.FGWidth = 48;
            this.keyA.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyA.FText = "a";
            this.keyA.GText = "";
            this.keyA.HText = "";
            this.keyA.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyA.Location = new System.Drawing.Point (16, 148);
            this.keyA.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyA.MainForeColor = System.Drawing.Color.White;
            this.keyA.MainHeight = 24;
            this.keyA.MainText = "A";
            this.keyA.MainWidth = 48;
            this.keyA.Name = "keyA";
            this.keyA.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.A};
            this.keyA.Size = new System.Drawing.Size (48, 51);
            this.keyA.TabIndex = 5;
            this.keyA.Tag = "9711";
            this.keyA.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyA.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // labelTrace
            // 
            this.labelTrace.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.labelTrace.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelTrace.ForeColor = System.Drawing.Color.White;
            this.labelTrace.Location = new System.Drawing.Point (243, 18);
            this.labelTrace.Name = "labelTrace";
            this.labelTrace.Size = new System.Drawing.Size (56, 16);
            this.labelTrace.TabIndex = 4;
            this.labelTrace.Text = "TRACE";
            this.labelTrace.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // keyD
            // 
            this.keyD.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyD.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyD.FGWidth = 48;
            this.keyD.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyD.FText = "d";
            this.keyD.GText = "";
            this.keyD.HText = "";
            this.keyD.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyD.Location = new System.Drawing.Point (184, 148);
            this.keyD.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyD.MainForeColor = System.Drawing.Color.White;
            this.keyD.MainHeight = 24;
            this.keyD.MainText = "D";
            this.keyD.MainWidth = 48;
            this.keyD.Name = "keyD";
            this.keyD.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D};
            this.keyD.Size = new System.Drawing.Size (48, 51);
            this.keyD.TabIndex = 8;
            this.keyD.Tag = "9714";
            this.keyD.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyD.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyC
            // 
            this.keyC.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyC.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyC.FGWidth = 48;
            this.keyC.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyC.FText = "c";
            this.keyC.GText = "";
            this.keyC.HText = "";
            this.keyC.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyC.Location = new System.Drawing.Point (128, 148);
            this.keyC.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyC.MainForeColor = System.Drawing.Color.White;
            this.keyC.MainHeight = 24;
            this.keyC.MainText = "C";
            this.keyC.MainWidth = 48;
            this.keyC.Name = "keyC";
            this.keyC.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.C};
            this.keyC.Size = new System.Drawing.Size (48, 51);
            this.keyC.TabIndex = 7;
            this.keyC.Tag = "9713";
            this.keyC.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyC.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyF
            // 
            this.keyF.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyF.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyF.FGWidth = 48;
            this.keyF.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyF.FText = "";
            this.keyF.GText = "";
            this.keyF.HText = "";
            this.keyF.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyF.Location = new System.Drawing.Point (296, 148);
            this.keyF.MainBackColor = System.Drawing.Color.Gold;
            this.keyF.MainForeColor = System.Drawing.Color.Black;
            this.keyF.MainHeight = 24;
            this.keyF.MainText = "f";
            this.keyF.MainWidth = 48;
            this.keyF.Name = "keyF";
            this.keyF.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.F};
            this.keyF.Size = new System.Drawing.Size (48, 51);
            this.keyF.TabIndex = 9;
            this.keyF.Tag = "9716";
            this.keyF.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyF.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyRTN
            // 
            this.keyRTN.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRTN.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyRTN.FGWidth = 48;
            this.keyRTN.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyRTN.FText = "RND";
            this.keyRTN.GText = "";
            this.keyRTN.HText = "";
            this.keyRTN.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyRTN.Location = new System.Drawing.Point (192, 208);
            this.keyRTN.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRTN.MainForeColor = System.Drawing.Color.White;
            this.keyRTN.MainHeight = 24;
            this.keyRTN.MainText = "RTN";
            this.keyRTN.MainWidth = 48;
            this.keyRTN.Name = "keyRTN";
            this.keyRTN.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyRTN.Size = new System.Drawing.Size (48, 51);
            this.keyRTN.TabIndex = 16;
            this.keyRTN.Tag = "9724";
            this.keyRTN.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyRTN.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyGTO
            // 
            this.keyGTO.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyGTO.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyGTO.FGWidth = 48;
            this.keyGTO.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyGTO.FText = "CLF";
            this.keyGTO.GText = "";
            this.keyGTO.HText = "";
            this.keyGTO.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyGTO.Location = new System.Drawing.Point (80, 208);
            this.keyGTO.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyGTO.MainForeColor = System.Drawing.Color.White;
            this.keyGTO.MainHeight = 24;
            this.keyGTO.MainText = "GTO";
            this.keyGTO.MainWidth = 48;
            this.keyGTO.Name = "keyGTO";
            this.keyGTO.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyGTO.Size = new System.Drawing.Size (48, 51);
            this.keyGTO.TabIndex = 14;
            this.keyGTO.Tag = "9722";
            this.keyGTO.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyGTO.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySST
            // 
            this.keySST.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySST.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySST.FGWidth = 48;
            this.keySST.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keySST.FText = "ISZ";
            this.keySST.GText = "";
            this.keySST.HText = "";
            this.keySST.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySST.Location = new System.Drawing.Point (304, 208);
            this.keySST.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySST.MainForeColor = System.Drawing.Color.White;
            this.keySST.MainHeight = 24;
            this.keySST.MainText = "SST";
            this.keySST.MainWidth = 48;
            this.keySST.Name = "keySST";
            this.keySST.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySST.Size = new System.Drawing.Size (48, 51);
            this.keySST.TabIndex = 17;
            this.keySST.Tag = "9726";
            this.keySST.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySST.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyGSB
            // 
            this.keyGSB.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyGSB.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyGSB.FGWidth = 48;
            this.keyGSB.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyGSB.FText = "F?";
            this.keyGSB.GText = "";
            this.keyGSB.HText = "";
            this.keyGSB.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyGSB.Location = new System.Drawing.Point (136, 208);
            this.keyGSB.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyGSB.MainForeColor = System.Drawing.Color.White;
            this.keyGSB.MainHeight = 24;
            this.keyGSB.MainText = "GSB";
            this.keyGSB.MainWidth = 48;
            this.keyGSB.Name = "keyGSB";
            this.keyGSB.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyGSB.Size = new System.Drawing.Size (48, 51);
            this.keyGSB.TabIndex = 15;
            this.keyGSB.Tag = "9723";
            this.keyGSB.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyGSB.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyBST
            // 
            this.keyBST.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyBST.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyBST.FGWidth = 48;
            this.keyBST.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyBST.FText = "DSZ";
            this.keyBST.GText = "";
            this.keyBST.HText = "";
            this.keyBST.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyBST.Location = new System.Drawing.Point (248, 208);
            this.keyBST.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyBST.MainForeColor = System.Drawing.Color.White;
            this.keyBST.MainHeight = 24;
            this.keyBST.MainText = "BST";
            this.keyBST.MainWidth = 48;
            this.keyBST.Name = "keyBST";
            this.keyBST.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyBST.Size = new System.Drawing.Size (48, 51);
            this.keyBST.TabIndex = 18;
            this.keyBST.Tag = "9725";
            this.keyBST.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyBST.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyLBL
            // 
            this.keyLBL.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyLBL.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyLBL.FGWidth = 48;
            this.keyLBL.Font = new System.Drawing.Font ("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.keyLBL.FText = "STF";
            this.keyLBL.GText = "";
            this.keyLBL.HText = "";
            this.keyLBL.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyLBL.Location = new System.Drawing.Point (24, 208);
            this.keyLBL.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyLBL.MainForeColor = System.Drawing.Color.White;
            this.keyLBL.MainHeight = 24;
            this.keyLBL.MainText = "LBL";
            this.keyLBL.MainWidth = 48;
            this.keyLBL.Name = "keyLBL";
            this.keyLBL.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyLBL.Size = new System.Drawing.Size (48, 51);
            this.keyLBL.TabIndex = 13;
            this.keyLBL.Tag = "9721";
            this.keyLBL.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyLBL.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange (new System.Windows.Forms.MenuItem [] {
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
            this.openMenuItem.Click += new System.EventHandler (this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Index = 1;
            this.saveMenuItem.Text = "&Save";
            this.saveMenuItem.Click += new System.EventHandler (this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Index = 2;
            this.saveAsMenuItem.Text = "Save &As...";
            this.saveAsMenuItem.Click += new System.EventHandler (this.saveAsMenuItem_Click);
            // 
            // printMenuItem
            // 
            this.printMenuItem.Index = 3;
            this.printMenuItem.Text = "Print";
            this.printMenuItem.Click += new System.EventHandler (this.printMenuItem_Click);
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
            this.editMenuItem.Click += new System.EventHandler (this.editMenuItem_Click);
            // 
            // rtfMenuItem
            // 
            this.rtfMenuItem.Index = 6;
            this.rtfMenuItem.Text = "&Rich Text";
            this.rtfMenuItem.Click += new System.EventHandler (this.rtfMenuItem_Click);
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
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler (this.printDocument_PrintPage);
            // 
            // display
            // 
            this.display.Font = new System.Drawing.Font ("Quartz", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.display.ForeColor = System.Drawing.Color.Red;
            this.display.Location = new System.Drawing.Point (120, 8);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size (376, 48);
            this.display.TabIndex = 0;
            this.display.Value = 0;
            // 
            // panelDisplay
            // 
            this.panelDisplay.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.panelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDisplay.Controls.Add (this.display);
            this.panelDisplay.Location = new System.Drawing.Point (8, 136);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size (504, 64);
            this.panelDisplay.TabIndex = 4;
            // 
            // buttonPrinter
            // 
            this.buttonPrinter.Location = new System.Drawing.Point (776, 136);
            this.buttonPrinter.Name = "buttonPrinter";
            this.buttonPrinter.Size = new System.Drawing.Size (36, 56);
            this.buttonPrinter.TabIndex = 5;
            // 
            // HP97
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size (820, 638);
            this.ContextMenu = this.contextMenu;
            this.Controls.Add (this.buttonPrinter);
            this.Controls.Add (this.panelDisplay);
            this.Controls.Add (this.panelMain);
            this.Controls.Add (this.printer);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject ("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size (828, 672);
            this.MinimumSize = new System.Drawing.Size (828, 672);
            this.Name = "HP97";
            this.Text = "HP97";
            this.Closing += new System.ComponentModel.CancelEventHandler (this.Calculator_Closing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler (this.Calculator_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler (this.Calculator_KeyDown);
            this.panelMain.ResumeLayout (false);
            this.panelMain.PerformLayout ();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxLineRight)).EndInit ();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxLineCenter)).EndInit ();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxLineLeft)).EndInit ();
            this.groupBoxCard.ResumeLayout (false);
            this.panelDisplay.ResumeLayout (false);
            this.ResumeLayout (false);

		}
		#endregion

		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main (string [] arguments) 
		{
			try 
			{
			Application.Run(new HP97 (arguments));
			}
			catch (Shutdown)
			{
			}
		}

	}
}
