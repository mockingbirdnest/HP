using Mockingbird.HP.Control_Library;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mockingbird.HP.HP97
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class HP97 : System.Windows.Forms.Form
	{
		private Mockingbird.HP.Control_Library.CardSlot cardSlot;
		private Mockingbird.HP.Control_Library.Toggle toggleManNorm;
		private Mockingbird.HP.Control_Library.Key keyE;
		private Mockingbird.HP.Control_Library.Toggle toggleOffOn;
		private Mockingbird.HP.Control_Library.Toggle togglePrgmRun;
		private Mockingbird.HP.Control_Library.Key keyB;
		private Mockingbird.HP.Control_Library.Key keyA;
		private Mockingbird.HP.Control_Library.Key keyD;
		private Mockingbird.HP.Control_Library.Key keyF;
		private Mockingbird.HP.Control_Library.Key keyC;
		private Mockingbird.HP.Control_Library.Display display;
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
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Label labelPrint;
		private System.Windows.Forms.GroupBox groupBoxCard;
		private System.Windows.Forms.Label labelTrace;
		private System.Windows.Forms.Panel panelDisplay;
		private System.Windows.Forms.PictureBox pictureBoxLineRight;
		private System.Windows.Forms.PictureBox pictureBoxLineCenter;
		private System.Windows.Forms.PictureBox pictureBoxLineLeft;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HP97()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
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

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.printer = new Mockingbird.HP.Control_Library.Printer();
			this.panelMain = new System.Windows.Forms.Panel();
			this.labelPrint = new System.Windows.Forms.Label();
			this.pictureBoxLineRight = new System.Windows.Forms.PictureBox();
			this.pictureBoxLineCenter = new System.Windows.Forms.PictureBox();
			this.pictureBoxLineLeft = new System.Windows.Forms.PictureBox();
			this.keyPRINTx = new Mockingbird.HP.Control_Library.Key();
			this.keyENG = new Mockingbird.HP.Control_Library.Key();
			this.keySCI = new Mockingbird.HP.Control_Library.Key();
			this.keyCHS = new Mockingbird.HP.Control_Library.Key();
			this.keyFIX = new Mockingbird.HP.Control_Library.Key();
			this.keyENTER = new Mockingbird.HP.Control_Library.Key();
			this.keyEEX = new Mockingbird.HP.Control_Library.Key();
			this.keyPlus = new Mockingbird.HP.Control_Library.Key();
			this.keyDSP = new Mockingbird.HP.Control_Library.Key();
			this.keyPeriod = new Mockingbird.HP.Control_Library.Key();
			this.keyMult = new Mockingbird.HP.Control_Library.Key();
			this.keySub = new Mockingbird.HP.Control_Library.Key();
			this.keyDiv = new Mockingbird.HP.Control_Library.Key();
			this.key6 = new Mockingbird.HP.Control_Library.Key();
			this.key3 = new Mockingbird.HP.Control_Library.Key();
			this.key9 = new Mockingbird.HP.Control_Library.Key();
			this.key5 = new Mockingbird.HP.Control_Library.Key();
			this.key2 = new Mockingbird.HP.Control_Library.Key();
			this.key8 = new Mockingbird.HP.Control_Library.Key();
			this.key4 = new Mockingbird.HP.Control_Library.Key();
			this.key1 = new Mockingbird.HP.Control_Library.Key();
			this.key7 = new Mockingbird.HP.Control_Library.Key();
			this.keyXExchangeY = new Mockingbird.HP.Control_Library.Key();
			this.keyCLx = new Mockingbird.HP.Control_Library.Key();
			this.keyRDown = new Mockingbird.HP.Control_Library.Key();
			this.key0 = new Mockingbird.HP.Control_Library.Key();
			this.keySqrt = new Mockingbird.HP.Control_Library.Key();
			this.keyReciprocal = new Mockingbird.HP.Control_Library.Key();
			this.keyΣ = new Mockingbird.HP.Control_Library.Key();
			this.keySquare = new Mockingbird.HP.Control_Library.Key();
			this.keyPercent = new Mockingbird.HP.Control_Library.Key();
			this.keyRS = new Mockingbird.HP.Control_Library.Key();
			this.keyToRectangular = new Mockingbird.HP.Control_Library.Key();
			this.keyCOS = new Mockingbird.HP.Control_Library.Key();
			this.keyI = new Mockingbird.HP.Control_Library.Key();
			this.keyTAN = new Mockingbird.HP.Control_Library.Key();
			this.keySubI = new Mockingbird.HP.Control_Library.Key();
			this.keySIN = new Mockingbird.HP.Control_Library.Key();
			this.keyToPolar = new Mockingbird.HP.Control_Library.Key();
			this.keyLN = new Mockingbird.HP.Control_Library.Key();
			this.keyRCL = new Mockingbird.HP.Control_Library.Key();
			this.keyEToTheXth = new Mockingbird.HP.Control_Library.Key();
			this.keySTO = new Mockingbird.HP.Control_Library.Key();
			this.keyYToTheXth = new Mockingbird.HP.Control_Library.Key();
			this.groupBoxCard = new System.Windows.Forms.GroupBox();
			this.cardSlot = new Mockingbird.HP.Control_Library.CardSlot();
			this.toggleManNorm = new Mockingbird.HP.Control_Library.Toggle();
			this.keyE = new Mockingbird.HP.Control_Library.Key();
			this.toggleOffOn = new Mockingbird.HP.Control_Library.Toggle();
			this.togglePrgmRun = new Mockingbird.HP.Control_Library.Toggle();
			this.keyB = new Mockingbird.HP.Control_Library.Key();
			this.keyA = new Mockingbird.HP.Control_Library.Key();
			this.labelTrace = new System.Windows.Forms.Label();
			this.keyD = new Mockingbird.HP.Control_Library.Key();
			this.keyF = new Mockingbird.HP.Control_Library.Key();
			this.keyC = new Mockingbird.HP.Control_Library.Key();
			this.keyRTN = new Mockingbird.HP.Control_Library.Key();
			this.keyGTO = new Mockingbird.HP.Control_Library.Key();
			this.keySST = new Mockingbird.HP.Control_Library.Key();
			this.keyGSB = new Mockingbird.HP.Control_Library.Key();
			this.keyBST = new Mockingbird.HP.Control_Library.Key();
			this.keyLBL = new Mockingbird.HP.Control_Library.Key();
			this.panelDisplay = new System.Windows.Forms.Panel();
			this.display = new Mockingbird.HP.Control_Library.Display();
			this.panelMain.SuspendLayout();
			this.groupBoxCard.SuspendLayout();
			this.panelDisplay.SuspendLayout();
			this.SuspendLayout();
			// 
			// printer
			// 
			this.printer.Location = new System.Drawing.Point(560, 0);
			this.printer.Name = "printer";
			this.printer.Size = new System.Drawing.Size(288, 256);
			this.printer.TabIndex = 1;
			// 
			// panelMain
			// 
			this.panelMain.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelMain.Controls.Add(this.labelPrint);
			this.panelMain.Controls.Add(this.pictureBoxLineRight);
			this.panelMain.Controls.Add(this.pictureBoxLineCenter);
			this.panelMain.Controls.Add(this.pictureBoxLineLeft);
			this.panelMain.Controls.Add(this.keyPRINTx);
			this.panelMain.Controls.Add(this.keyENG);
			this.panelMain.Controls.Add(this.keySCI);
			this.panelMain.Controls.Add(this.keyCHS);
			this.panelMain.Controls.Add(this.keyFIX);
			this.panelMain.Controls.Add(this.keyENTER);
			this.panelMain.Controls.Add(this.keyEEX);
			this.panelMain.Controls.Add(this.keyPlus);
			this.panelMain.Controls.Add(this.keyDSP);
			this.panelMain.Controls.Add(this.keyPeriod);
			this.panelMain.Controls.Add(this.keyMult);
			this.panelMain.Controls.Add(this.keySub);
			this.panelMain.Controls.Add(this.keyDiv);
			this.panelMain.Controls.Add(this.key6);
			this.panelMain.Controls.Add(this.key3);
			this.panelMain.Controls.Add(this.key9);
			this.panelMain.Controls.Add(this.key5);
			this.panelMain.Controls.Add(this.key2);
			this.panelMain.Controls.Add(this.key8);
			this.panelMain.Controls.Add(this.key4);
			this.panelMain.Controls.Add(this.key1);
			this.panelMain.Controls.Add(this.key7);
			this.panelMain.Controls.Add(this.keyXExchangeY);
			this.panelMain.Controls.Add(this.keyCLx);
			this.panelMain.Controls.Add(this.keyRDown);
			this.panelMain.Controls.Add(this.key0);
			this.panelMain.Controls.Add(this.keySqrt);
			this.panelMain.Controls.Add(this.keyReciprocal);
			this.panelMain.Controls.Add(this.keyΣ);
			this.panelMain.Controls.Add(this.keySquare);
			this.panelMain.Controls.Add(this.keyPercent);
			this.panelMain.Controls.Add(this.keyRS);
			this.panelMain.Controls.Add(this.keyToRectangular);
			this.panelMain.Controls.Add(this.keyCOS);
			this.panelMain.Controls.Add(this.keyI);
			this.panelMain.Controls.Add(this.keyTAN);
			this.panelMain.Controls.Add(this.keySubI);
			this.panelMain.Controls.Add(this.keySIN);
			this.panelMain.Controls.Add(this.keyToPolar);
			this.panelMain.Controls.Add(this.keyLN);
			this.panelMain.Controls.Add(this.keyRCL);
			this.panelMain.Controls.Add(this.keyEToTheXth);
			this.panelMain.Controls.Add(this.keySTO);
			this.panelMain.Controls.Add(this.keyYToTheXth);
			this.panelMain.Controls.Add(this.groupBoxCard);
			this.panelMain.Controls.Add(this.keyRTN);
			this.panelMain.Controls.Add(this.keyGTO);
			this.panelMain.Controls.Add(this.keySST);
			this.panelMain.Controls.Add(this.keyGSB);
			this.panelMain.Controls.Add(this.keyBST);
			this.panelMain.Controls.Add(this.keyLBL);
			this.panelMain.Location = new System.Drawing.Point(8, 280);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(888, 440);
			this.panelMain.TabIndex = 2;
			// 
			// labelPrint
			// 
			this.labelPrint.AutoSize = true;
			this.labelPrint.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelPrint.ForeColor = System.Drawing.Color.Gold;
			this.labelPrint.Location = new System.Drawing.Point(392, 66);
			this.labelPrint.Name = "labelPrint";
			this.labelPrint.Size = new System.Drawing.Size(43, 18);
			this.labelPrint.TabIndex = 66;
			this.labelPrint.Text = "PRINT:";
			// 
			// pictureBoxLineRight
			// 
			this.pictureBoxLineRight.BackColor = System.Drawing.Color.Gold;
			this.pictureBoxLineRight.Location = new System.Drawing.Point(662, 74);
			this.pictureBoxLineRight.Name = "pictureBoxLineRight";
			this.pictureBoxLineRight.Size = new System.Drawing.Size(90, 2);
			this.pictureBoxLineRight.TabIndex = 65;
			this.pictureBoxLineRight.TabStop = false;
			// 
			// pictureBoxLineCenter
			// 
			this.pictureBoxLineCenter.BackColor = System.Drawing.Color.Gold;
			this.pictureBoxLineCenter.Location = new System.Drawing.Point(580, 74);
			this.pictureBoxLineCenter.Name = "pictureBoxLineCenter";
			this.pictureBoxLineCenter.Size = new System.Drawing.Size(47, 2);
			this.pictureBoxLineCenter.TabIndex = 64;
			this.pictureBoxLineCenter.TabStop = false;
			// 
			// pictureBoxLineLeft
			// 
			this.pictureBoxLineLeft.BackColor = System.Drawing.Color.Gold;
			this.pictureBoxLineLeft.Location = new System.Drawing.Point(493, 74);
			this.pictureBoxLineLeft.Name = "pictureBoxLineLeft";
			this.pictureBoxLineLeft.Size = new System.Drawing.Size(41, 2);
			this.pictureBoxLineLeft.TabIndex = 63;
			this.pictureBoxLineLeft.TabStop = false;
			// 
			// keyPRINTx
			// 
			this.keyPRINTx.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyPRINTx.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPRINTx.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyPRINTx.FGWidth = 160;
			this.keyPRINTx.FText = "STACK";
			this.keyPRINTx.GText = "";
			this.keyPRINTx.HText = "";
			this.keyPRINTx.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyPRINTx.Location = new System.Drawing.Point(696, 18);
			this.keyPRINTx.MainBackColor = System.Drawing.Color.Olive;
			this.keyPRINTx.MainForeColor = System.Drawing.Color.White;
			this.keyPRINTx.MainHeight = 36;
			this.keyPRINTx.MainText = "PRINT x";
			this.keyPRINTx.MainWidth = 160;
			this.keyPRINTx.Name = "keyPRINTx";
			this.keyPRINTx.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyPRINTx.Size = new System.Drawing.Size(160, 63);
			this.keyPRINTx.TabIndex = 62;
			this.keyPRINTx.Tag = "97-14";
			// 
			// keyENG
			// 
			this.keyENG.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyENG.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyENG.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyENG.FGWidth = 72;
			this.keyENG.FText = "REG";
			this.keyENG.GText = "";
			this.keyENG.HText = "";
			this.keyENG.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyENG.Location = new System.Drawing.Point(608, 18);
			this.keyENG.MainBackColor = System.Drawing.Color.Olive;
			this.keyENG.MainForeColor = System.Drawing.Color.White;
			this.keyENG.MainHeight = 36;
			this.keyENG.MainText = "ENG";
			this.keyENG.MainWidth = 72;
			this.keyENG.Name = "keyENG";
			this.keyENG.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyENG.Size = new System.Drawing.Size(72, 63);
			this.keyENG.TabIndex = 61;
			this.keyENG.Tag = "97-13";
			// 
			// keySCI
			// 
			this.keySCI.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keySCI.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySCI.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keySCI.FGWidth = 72;
			this.keySCI.FText = "PRGM";
			this.keySCI.GText = "";
			this.keySCI.HText = "";
			this.keySCI.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySCI.Location = new System.Drawing.Point(520, 18);
			this.keySCI.MainBackColor = System.Drawing.Color.Olive;
			this.keySCI.MainForeColor = System.Drawing.Color.White;
			this.keySCI.MainHeight = 36;
			this.keySCI.MainText = "SCI";
			this.keySCI.MainWidth = 72;
			this.keySCI.Name = "keySCI";
			this.keySCI.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySCI.Size = new System.Drawing.Size(72, 63);
			this.keySCI.TabIndex = 60;
			this.keySCI.Tag = "97-12";
			// 
			// keyCHS
			// 
			this.keyCHS.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyCHS.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyCHS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyCHS.FGWidth = 72;
			this.keyCHS.FText = "RAD";
			this.keyCHS.GText = "";
			this.keyCHS.HText = "";
			this.keyCHS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyCHS.Location = new System.Drawing.Point(608, 89);
			this.keyCHS.MainBackColor = System.Drawing.Color.Olive;
			this.keyCHS.MainForeColor = System.Drawing.Color.White;
			this.keyCHS.MainHeight = 36;
			this.keyCHS.MainText = "CHS";
			this.keyCHS.MainWidth = 72;
			this.keyCHS.Name = "keyCHS";
			this.keyCHS.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyCHS.Size = new System.Drawing.Size(72, 63);
			this.keyCHS.TabIndex = 59;
			this.keyCHS.Tag = "97-22";
			// 
			// keyFIX
			// 
			this.keyFIX.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyFIX.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyFIX.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyFIX.FGWidth = 72;
			this.keyFIX.FText = "SPACE";
			this.keyFIX.GText = "";
			this.keyFIX.HText = "";
			this.keyFIX.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyFIX.Location = new System.Drawing.Point(432, 18);
			this.keyFIX.MainBackColor = System.Drawing.Color.Olive;
			this.keyFIX.MainForeColor = System.Drawing.Color.White;
			this.keyFIX.MainHeight = 36;
			this.keyFIX.MainText = "FIX";
			this.keyFIX.MainWidth = 72;
			this.keyFIX.Name = "keyFIX";
			this.keyFIX.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyFIX.Size = new System.Drawing.Size(72, 63);
			this.keyFIX.TabIndex = 58;
			this.keyFIX.Tag = "97-11";
			// 
			// keyENTER
			// 
			this.keyENTER.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyENTER.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyENTER.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyENTER.FGWidth = 160;
			this.keyENTER.FText = "DEG";
			this.keyENTER.GText = "";
			this.keyENTER.HText = "";
			this.keyENTER.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyENTER.Location = new System.Drawing.Point(432, 89);
			this.keyENTER.MainBackColor = System.Drawing.Color.Olive;
			this.keyENTER.MainForeColor = System.Drawing.Color.White;
			this.keyENTER.MainHeight = 36;
			this.keyENTER.MainText = "ENTER ↑";
			this.keyENTER.MainWidth = 160;
			this.keyENTER.Name = "keyENTER";
			this.keyENTER.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyENTER.Size = new System.Drawing.Size(160, 63);
			this.keyENTER.TabIndex = 57;
			this.keyENTER.Tag = "97-21";
			// 
			// keyEEX
			// 
			this.keyEEX.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyEEX.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyEEX.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyEEX.FGWidth = 72;
			this.keyEEX.FText = "GRD";
			this.keyEEX.GText = "";
			this.keyEEX.HText = "";
			this.keyEEX.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyEEX.Location = new System.Drawing.Point(696, 89);
			this.keyEEX.MainBackColor = System.Drawing.Color.Olive;
			this.keyEEX.MainForeColor = System.Drawing.Color.White;
			this.keyEEX.MainHeight = 36;
			this.keyEEX.MainText = "EEX";
			this.keyEEX.MainWidth = 72;
			this.keyEEX.Name = "keyEEX";
			this.keyEEX.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyEEX.Size = new System.Drawing.Size(72, 63);
			this.keyEEX.TabIndex = 56;
			this.keyEEX.Tag = "97-23";
			// 
			// keyPlus
			// 
			this.keyPlus.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyPlus.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPlus.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyPlus.FGWidth = 72;
			this.keyPlus.FText = "H.MS+";
			this.keyPlus.GText = "";
			this.keyPlus.HText = "";
			this.keyPlus.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyPlus.Location = new System.Drawing.Point(784, 302);
			this.keyPlus.MainBackColor = System.Drawing.Color.Olive;
			this.keyPlus.MainForeColor = System.Drawing.Color.White;
			this.keyPlus.MainHeight = 106;
			this.keyPlus.MainText = "+";
			this.keyPlus.MainWidth = 72;
			this.keyPlus.Name = "keyPlus";
			this.keyPlus.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyPlus.Size = new System.Drawing.Size(72, 133);
			this.keyPlus.TabIndex = 55;
			this.keyPlus.Tag = "97-55";
			// 
			// keyDSP
			// 
			this.keyDSP.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyDSP.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyDSP.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyDSP.FGWidth = 72;
			this.keyDSP.FText = "LAST x";
			this.keyDSP.GText = "";
			this.keyDSP.HText = "";
			this.keyDSP.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyDSP.Location = new System.Drawing.Point(696, 372);
			this.keyDSP.MainBackColor = System.Drawing.Color.LightYellow;
			this.keyDSP.MainForeColor = System.Drawing.Color.Black;
			this.keyDSP.MainHeight = 36;
			this.keyDSP.MainText = "DSP";
			this.keyDSP.MainWidth = 72;
			this.keyDSP.Name = "keyDSP";
			this.keyDSP.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyDSP.Size = new System.Drawing.Size(72, 63);
			this.keyDSP.TabIndex = 54;
			this.keyDSP.Tag = "97-63";
			// 
			// keyPeriod
			// 
			this.keyPeriod.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyPeriod.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPeriod.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyPeriod.FGWidth = 72;
			this.keyPeriod.FText = "MERGE";
			this.keyPeriod.GText = "";
			this.keyPeriod.HText = "";
			this.keyPeriod.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyPeriod.Location = new System.Drawing.Point(608, 372);
			this.keyPeriod.MainBackColor = System.Drawing.Color.LightYellow;
			this.keyPeriod.MainForeColor = System.Drawing.Color.Black;
			this.keyPeriod.MainHeight = 36;
			this.keyPeriod.MainText = " ・";
			this.keyPeriod.MainWidth = 72;
			this.keyPeriod.Name = "keyPeriod";
			this.keyPeriod.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyPeriod.Size = new System.Drawing.Size(72, 63);
			this.keyPeriod.TabIndex = 53;
			this.keyPeriod.Tag = "97-62";
			// 
			// keyMult
			// 
			this.keyMult.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyMult.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyMult.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyMult.FGWidth = 72;
			this.keyMult.FText = "x≤y?";
			this.keyMult.GText = "";
			this.keyMult.HText = "";
			this.keyMult.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyMult.Location = new System.Drawing.Point(784, 160);
			this.keyMult.MainBackColor = System.Drawing.Color.Olive;
			this.keyMult.MainForeColor = System.Drawing.Color.White;
			this.keyMult.MainHeight = 36;
			this.keyMult.MainText = "×";
			this.keyMult.MainWidth = 72;
			this.keyMult.Name = "keyMult";
			this.keyMult.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyMult.Size = new System.Drawing.Size(72, 63);
			this.keyMult.TabIndex = 52;
			this.keyMult.Tag = "97-35";
			// 
			// keySub
			// 
			this.keySub.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keySub.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySub.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keySub.FGWidth = 72;
			this.keySub.FText = "x<0?";
			this.keySub.GText = "";
			this.keySub.HText = "";
			this.keySub.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySub.Location = new System.Drawing.Point(784, 231);
			this.keySub.MainBackColor = System.Drawing.Color.Olive;
			this.keySub.MainForeColor = System.Drawing.Color.White;
			this.keySub.MainHeight = 36;
			this.keySub.MainText = "-";
			this.keySub.MainWidth = 72;
			this.keySub.Name = "keySub";
			this.keySub.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySub.Size = new System.Drawing.Size(72, 63);
			this.keySub.TabIndex = 51;
			this.keySub.Tag = "97-45";
			// 
			// keyDiv
			// 
			this.keyDiv.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyDiv.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyDiv.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyDiv.FGWidth = 72;
			this.keyDiv.FText = "π";
			this.keyDiv.GText = "";
			this.keyDiv.HText = "";
			this.keyDiv.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyDiv.Location = new System.Drawing.Point(784, 89);
			this.keyDiv.MainBackColor = System.Drawing.Color.Olive;
			this.keyDiv.MainForeColor = System.Drawing.Color.White;
			this.keyDiv.MainHeight = 36;
			this.keyDiv.MainText = "÷";
			this.keyDiv.MainWidth = 72;
			this.keyDiv.Name = "keyDiv";
			this.keyDiv.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyDiv.Size = new System.Drawing.Size(72, 63);
			this.keyDiv.TabIndex = 50;
			this.keyDiv.Tag = "97-24";
			// 
			// key6
			// 
			this.key6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key6.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key6.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key6.FGWidth = 72;
			this.key6.FText = "x>0?";
			this.key6.GText = "";
			this.key6.HText = "";
			this.key6.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key6.Location = new System.Drawing.Point(696, 231);
			this.key6.MainBackColor = System.Drawing.Color.LightYellow;
			this.key6.MainForeColor = System.Drawing.Color.Black;
			this.key6.MainHeight = 36;
			this.key6.MainText = "6";
			this.key6.MainWidth = 72;
			this.key6.Name = "key6";
			this.key6.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key6.Size = new System.Drawing.Size(72, 63);
			this.key6.TabIndex = 49;
			this.key6.Tag = "97-44";
			// 
			// key3
			// 
			this.key3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key3.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key3.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key3.FGWidth = 72;
			this.key3.FText = "CL PGRM";
			this.key3.GText = "";
			this.key3.HText = "";
			this.key3.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key3.Location = new System.Drawing.Point(696, 302);
			this.key3.MainBackColor = System.Drawing.Color.LightYellow;
			this.key3.MainForeColor = System.Drawing.Color.Black;
			this.key3.MainHeight = 36;
			this.key3.MainText = "3";
			this.key3.MainWidth = 72;
			this.key3.Name = "key3";
			this.key3.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key3.Size = new System.Drawing.Size(72, 63);
			this.key3.TabIndex = 48;
			this.key3.Tag = "97-54";
			// 
			// key9
			// 
			this.key9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key9.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key9.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key9.FGWidth = 72;
			this.key9.FText = "x>y?";
			this.key9.GText = "";
			this.key9.HText = "";
			this.key9.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key9.Location = new System.Drawing.Point(696, 160);
			this.key9.MainBackColor = System.Drawing.Color.LightYellow;
			this.key9.MainForeColor = System.Drawing.Color.Black;
			this.key9.MainHeight = 36;
			this.key9.MainText = "9";
			this.key9.MainWidth = 72;
			this.key9.Name = "key9";
			this.key9.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key9.Size = new System.Drawing.Size(72, 63);
			this.key9.TabIndex = 47;
			this.key9.Tag = "97-34";
			// 
			// key5
			// 
			this.key5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key5.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key5.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key5.FGWidth = 72;
			this.key5.FText = "x=0?";
			this.key5.GText = "";
			this.key5.HText = "";
			this.key5.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key5.Location = new System.Drawing.Point(608, 231);
			this.key5.MainBackColor = System.Drawing.Color.LightYellow;
			this.key5.MainForeColor = System.Drawing.Color.Black;
			this.key5.MainHeight = 36;
			this.key5.MainText = "5";
			this.key5.MainWidth = 72;
			this.key5.Name = "key5";
			this.key5.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key5.Size = new System.Drawing.Size(72, 63);
			this.key5.TabIndex = 46;
			this.key5.Tag = "97-43";
			// 
			// key2
			// 
			this.key2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key2.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key2.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key2.FGWidth = 72;
			this.key2.FText = "CL REG";
			this.key2.GText = "";
			this.key2.HText = "";
			this.key2.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key2.Location = new System.Drawing.Point(608, 302);
			this.key2.MainBackColor = System.Drawing.Color.LightYellow;
			this.key2.MainForeColor = System.Drawing.Color.Black;
			this.key2.MainHeight = 36;
			this.key2.MainText = "2";
			this.key2.MainWidth = 72;
			this.key2.Name = "key2";
			this.key2.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key2.Size = new System.Drawing.Size(72, 63);
			this.key2.TabIndex = 45;
			this.key2.Tag = "97-53";
			// 
			// key8
			// 
			this.key8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key8.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key8.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key8.FGWidth = 72;
			this.key8.FText = "x=y?";
			this.key8.GText = "";
			this.key8.HText = "";
			this.key8.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key8.Location = new System.Drawing.Point(608, 160);
			this.key8.MainBackColor = System.Drawing.Color.LightYellow;
			this.key8.MainForeColor = System.Drawing.Color.Black;
			this.key8.MainHeight = 36;
			this.key8.MainText = "8";
			this.key8.MainWidth = 72;
			this.key8.Name = "key8";
			this.key8.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key8.Size = new System.Drawing.Size(72, 63);
			this.key8.TabIndex = 44;
			this.key8.Tag = "97-33";
			// 
			// key4
			// 
			this.key4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key4.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key4.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key4.FGWidth = 72;
			this.key4.FText = "x≠0?";
			this.key4.GText = "";
			this.key4.HText = "";
			this.key4.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key4.Location = new System.Drawing.Point(520, 231);
			this.key4.MainBackColor = System.Drawing.Color.LightYellow;
			this.key4.MainForeColor = System.Drawing.Color.Black;
			this.key4.MainHeight = 36;
			this.key4.MainText = "4";
			this.key4.MainWidth = 72;
			this.key4.Name = "key4";
			this.key4.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key4.Size = new System.Drawing.Size(72, 63);
			this.key4.TabIndex = 43;
			this.key4.Tag = "97-42";
			// 
			// key1
			// 
			this.key1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key1.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key1.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key1.FGWidth = 72;
			this.key1.FText = "DEL";
			this.key1.GText = "";
			this.key1.HText = "";
			this.key1.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key1.Location = new System.Drawing.Point(520, 302);
			this.key1.MainBackColor = System.Drawing.Color.LightYellow;
			this.key1.MainForeColor = System.Drawing.Color.Black;
			this.key1.MainHeight = 36;
			this.key1.MainText = "1";
			this.key1.MainWidth = 72;
			this.key1.Name = "key1";
			this.key1.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key1.Size = new System.Drawing.Size(72, 63);
			this.key1.TabIndex = 42;
			this.key1.Tag = "97-52";
			// 
			// key7
			// 
			this.key7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key7.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key7.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key7.FGWidth = 72;
			this.key7.FText = "x≠y?";
			this.key7.GText = "";
			this.key7.HText = "";
			this.key7.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key7.Location = new System.Drawing.Point(520, 160);
			this.key7.MainBackColor = System.Drawing.Color.LightYellow;
			this.key7.MainForeColor = System.Drawing.Color.Black;
			this.key7.MainHeight = 36;
			this.key7.MainText = "7";
			this.key7.MainWidth = 72;
			this.key7.Name = "key7";
			this.key7.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key7.Size = new System.Drawing.Size(72, 63);
			this.key7.TabIndex = 41;
			this.key7.Tag = "97-32";
			// 
			// keyXExchangeY
			// 
			this.keyXExchangeY.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyXExchangeY.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyXExchangeY.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyXExchangeY.FGWidth = 72;
			this.keyXExchangeY.FText = "x⇄I";
			this.keyXExchangeY.GText = "";
			this.keyXExchangeY.HText = "";
			this.keyXExchangeY.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyXExchangeY.Location = new System.Drawing.Point(432, 231);
			this.keyXExchangeY.MainBackColor = System.Drawing.Color.Olive;
			this.keyXExchangeY.MainForeColor = System.Drawing.Color.White;
			this.keyXExchangeY.MainHeight = 36;
			this.keyXExchangeY.MainText = "x⇄y";
			this.keyXExchangeY.MainWidth = 72;
			this.keyXExchangeY.Name = "keyXExchangeY";
			this.keyXExchangeY.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyXExchangeY.Size = new System.Drawing.Size(72, 63);
			this.keyXExchangeY.TabIndex = 40;
			this.keyXExchangeY.Tag = "97-41";
			// 
			// keyCLx
			// 
			this.keyCLx.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyCLx.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyCLx.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyCLx.FGWidth = 72;
			this.keyCLx.FText = "P⇄S";
			this.keyCLx.GText = "";
			this.keyCLx.HText = "";
			this.keyCLx.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyCLx.Location = new System.Drawing.Point(432, 302);
			this.keyCLx.MainBackColor = System.Drawing.Color.Olive;
			this.keyCLx.MainForeColor = System.Drawing.Color.White;
			this.keyCLx.MainHeight = 36;
			this.keyCLx.MainText = "CL x";
			this.keyCLx.MainWidth = 72;
			this.keyCLx.Name = "keyCLx";
			this.keyCLx.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyCLx.Size = new System.Drawing.Size(72, 63);
			this.keyCLx.TabIndex = 39;
			this.keyCLx.Tag = "97-51";
			// 
			// keyRDown
			// 
			this.keyRDown.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.keyRDown.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRDown.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyRDown.FGWidth = 72;
			this.keyRDown.FText = "R↑";
			this.keyRDown.GText = "";
			this.keyRDown.HText = "";
			this.keyRDown.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyRDown.Location = new System.Drawing.Point(432, 160);
			this.keyRDown.MainBackColor = System.Drawing.Color.Olive;
			this.keyRDown.MainForeColor = System.Drawing.Color.White;
			this.keyRDown.MainHeight = 36;
			this.keyRDown.MainText = "R↓";
			this.keyRDown.MainWidth = 72;
			this.keyRDown.Name = "keyRDown";
			this.keyRDown.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyRDown.Size = new System.Drawing.Size(72, 63);
			this.keyRDown.TabIndex = 38;
			this.keyRDown.Tag = "97-31";
			// 
			// key0
			// 
			this.key0.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key0.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key0.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key0.FGWidth = 160;
			this.key0.FText = "WRITE DATA";
			this.key0.GText = "";
			this.key0.HText = "";
			this.key0.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key0.Location = new System.Drawing.Point(432, 372);
			this.key0.MainBackColor = System.Drawing.Color.LightYellow;
			this.key0.MainForeColor = System.Drawing.Color.Black;
			this.key0.MainHeight = 36;
			this.key0.MainText = "0";
			this.key0.MainWidth = 160;
			this.key0.Name = "key0";
			this.key0.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key0.Size = new System.Drawing.Size(160, 63);
			this.key0.TabIndex = 37;
			this.key0.Tag = "97-61";
			// 
			// keySqrt
			// 
			this.keySqrt.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySqrt.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keySqrt.FGWidth = 48;
			this.keySqrt.FText = "S";
			this.keySqrt.GText = "";
			this.keySqrt.HText = "";
			this.keySqrt.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySqrt.Location = new System.Drawing.Point(200, 384);
			this.keySqrt.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySqrt.MainForeColor = System.Drawing.Color.White;
			this.keySqrt.MainHeight = 24;
			this.keySqrt.MainText = "√x̅";
			this.keySqrt.MainWidth = 48;
			this.keySqrt.Name = "keySqrt";
			this.keySqrt.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySqrt.Size = new System.Drawing.Size(48, 51);
			this.keySqrt.TabIndex = 34;
			this.keySqrt.Tag = "9754";
			// 
			// keyReciprocal
			// 
			this.keyReciprocal.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyReciprocal.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyReciprocal.FGWidth = 48;
			this.keyReciprocal.FText = "N!";
			this.keyReciprocal.GText = "";
			this.keyReciprocal.HText = "";
			this.keyReciprocal.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyReciprocal.Location = new System.Drawing.Point(88, 384);
			this.keyReciprocal.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyReciprocal.MainForeColor = System.Drawing.Color.White;
			this.keyReciprocal.MainHeight = 24;
			this.keyReciprocal.MainText = "1/x";
			this.keyReciprocal.MainWidth = 48;
			this.keyReciprocal.Name = "keyReciprocal";
			this.keyReciprocal.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyReciprocal.Size = new System.Drawing.Size(48, 51);
			this.keyReciprocal.TabIndex = 32;
			this.keyReciprocal.Tag = "9752";
			// 
			// keyΣ
			// 
			this.keyΣ.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyΣ.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyΣ.FGWidth = 48;
			this.keyΣ.FText = "Σ-";
			this.keyΣ.GText = "";
			this.keyΣ.HText = "";
			this.keyΣ.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyΣ.Location = new System.Drawing.Point(312, 384);
			this.keyΣ.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyΣ.MainForeColor = System.Drawing.Color.White;
			this.keyΣ.MainHeight = 24;
			this.keyΣ.MainText = "Σ+";
			this.keyΣ.MainWidth = 48;
			this.keyΣ.Name = "keyΣ";
			this.keyΣ.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.keyΣ.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyΣ.Size = new System.Drawing.Size(48, 51);
			this.keyΣ.TabIndex = 35;
			this.keyΣ.Tag = "9756";
			// 
			// keySquare
			// 
			this.keySquare.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySquare.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keySquare.FGWidth = 48;
			this.keySquare.FText = "x̅";
			this.keySquare.GText = "";
			this.keySquare.HText = "";
			this.keySquare.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySquare.Location = new System.Drawing.Point(144, 384);
			this.keySquare.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySquare.MainForeColor = System.Drawing.Color.White;
			this.keySquare.MainHeight = 24;
			this.keySquare.MainText = "x²";
			this.keySquare.MainWidth = 48;
			this.keySquare.Name = "keySquare";
			this.keySquare.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySquare.Size = new System.Drawing.Size(48, 51);
			this.keySquare.TabIndex = 33;
			this.keySquare.Tag = "9753";
			// 
			// keyPercent
			// 
			this.keyPercent.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPercent.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyPercent.FGWidth = 48;
			this.keyPercent.FText = "%CH";
			this.keyPercent.GText = "";
			this.keyPercent.HText = "";
			this.keyPercent.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyPercent.Location = new System.Drawing.Point(256, 384);
			this.keyPercent.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPercent.MainForeColor = System.Drawing.Color.White;
			this.keyPercent.MainHeight = 24;
			this.keyPercent.MainText = "%";
			this.keyPercent.MainWidth = 48;
			this.keyPercent.Name = "keyPercent";
			this.keyPercent.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyPercent.Size = new System.Drawing.Size(48, 51);
			this.keyPercent.TabIndex = 36;
			this.keyPercent.Tag = "9755";
			// 
			// keyRS
			// 
			this.keyRS.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyRS.FGWidth = 48;
			this.keyRS.FText = "PAUSE";
			this.keyRS.GText = "";
			this.keyRS.HText = "";
			this.keyRS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyRS.Location = new System.Drawing.Point(32, 384);
			this.keyRS.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRS.MainForeColor = System.Drawing.Color.White;
			this.keyRS.MainHeight = 24;
			this.keyRS.MainText = "R/S";
			this.keyRS.MainWidth = 48;
			this.keyRS.Name = "keyRS";
			this.keyRS.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyRS.Size = new System.Drawing.Size(48, 51);
			this.keyRS.TabIndex = 31;
			this.keyRS.Tag = "9751";
			// 
			// keyToRectangular
			// 
			this.keyToRectangular.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyToRectangular.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyToRectangular.FGWidth = 48;
			this.keyToRectangular.FText = "FRAC";
			this.keyToRectangular.GText = "";
			this.keyToRectangular.HText = "";
			this.keyToRectangular.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyToRectangular.Location = new System.Drawing.Point(200, 328);
			this.keyToRectangular.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyToRectangular.MainForeColor = System.Drawing.Color.White;
			this.keyToRectangular.MainHeight = 24;
			this.keyToRectangular.MainText = "→R";
			this.keyToRectangular.MainWidth = 48;
			this.keyToRectangular.Name = "keyToRectangular";
			this.keyToRectangular.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyToRectangular.Size = new System.Drawing.Size(48, 51);
			this.keyToRectangular.TabIndex = 28;
			this.keyToRectangular.Tag = "9744";
			// 
			// keyCOS
			// 
			this.keyCOS.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyCOS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyCOS.FGWidth = 48;
			this.keyCOS.FText = "COS⁻¹";
			this.keyCOS.GText = "";
			this.keyCOS.HText = "";
			this.keyCOS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyCOS.Location = new System.Drawing.Point(88, 328);
			this.keyCOS.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyCOS.MainForeColor = System.Drawing.Color.White;
			this.keyCOS.MainHeight = 24;
			this.keyCOS.MainText = "COS";
			this.keyCOS.MainWidth = 48;
			this.keyCOS.Name = "keyCOS";
			this.keyCOS.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyCOS.Size = new System.Drawing.Size(48, 51);
			this.keyCOS.TabIndex = 26;
			this.keyCOS.Tag = "9742";
			// 
			// keyI
			// 
			this.keyI.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyI.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyI.FGWidth = 48;
			this.keyI.FText = "R→D";
			this.keyI.GText = "";
			this.keyI.HText = "";
			this.keyI.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyI.Location = new System.Drawing.Point(312, 328);
			this.keyI.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyI.MainForeColor = System.Drawing.Color.White;
			this.keyI.MainHeight = 24;
			this.keyI.MainText = "I";
			this.keyI.MainWidth = 48;
			this.keyI.Name = "keyI";
			this.keyI.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyI.Size = new System.Drawing.Size(48, 51);
			this.keyI.TabIndex = 29;
			this.keyI.Tag = "9746";
			// 
			// keyTAN
			// 
			this.keyTAN.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyTAN.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyTAN.FGWidth = 48;
			this.keyTAN.FText = "TAN⁻¹";
			this.keyTAN.GText = "";
			this.keyTAN.HText = "";
			this.keyTAN.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyTAN.Location = new System.Drawing.Point(144, 328);
			this.keyTAN.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyTAN.MainForeColor = System.Drawing.Color.White;
			this.keyTAN.MainHeight = 24;
			this.keyTAN.MainText = "TAN";
			this.keyTAN.MainWidth = 48;
			this.keyTAN.Name = "keyTAN";
			this.keyTAN.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyTAN.Size = new System.Drawing.Size(48, 51);
			this.keyTAN.TabIndex = 27;
			this.keyTAN.Tag = "9743";
			// 
			// keySubI
			// 
			this.keySubI.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySubI.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keySubI.FGWidth = 48;
			this.keySubI.FText = "D→R";
			this.keySubI.GText = "";
			this.keySubI.HText = "";
			this.keySubI.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySubI.Location = new System.Drawing.Point(256, 328);
			this.keySubI.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySubI.MainForeColor = System.Drawing.Color.White;
			this.keySubI.MainHeight = 24;
			this.keySubI.MainText = "(i)";
			this.keySubI.MainWidth = 48;
			this.keySubI.Name = "keySubI";
			this.keySubI.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySubI.Size = new System.Drawing.Size(48, 51);
			this.keySubI.TabIndex = 30;
			this.keySubI.Tag = "9745";
			// 
			// keySIN
			// 
			this.keySIN.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySIN.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keySIN.FGWidth = 48;
			this.keySIN.FText = "SIN⁻¹";
			this.keySIN.GText = "";
			this.keySIN.HText = "";
			this.keySIN.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySIN.Location = new System.Drawing.Point(32, 328);
			this.keySIN.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySIN.MainForeColor = System.Drawing.Color.White;
			this.keySIN.MainHeight = 24;
			this.keySIN.MainText = "SIN";
			this.keySIN.MainWidth = 48;
			this.keySIN.Name = "keySIN";
			this.keySIN.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySIN.Size = new System.Drawing.Size(48, 51);
			this.keySIN.TabIndex = 25;
			this.keySIN.Tag = "9741";
			// 
			// keyToPolar
			// 
			this.keyToPolar.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyToPolar.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyToPolar.FGWidth = 48;
			this.keyToPolar.FText = "INT";
			this.keyToPolar.GText = "";
			this.keyToPolar.HText = "";
			this.keyToPolar.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyToPolar.Location = new System.Drawing.Point(200, 272);
			this.keyToPolar.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyToPolar.MainForeColor = System.Drawing.Color.White;
			this.keyToPolar.MainHeight = 24;
			this.keyToPolar.MainText = "→P";
			this.keyToPolar.MainWidth = 48;
			this.keyToPolar.Name = "keyToPolar";
			this.keyToPolar.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyToPolar.Size = new System.Drawing.Size(48, 51);
			this.keyToPolar.TabIndex = 22;
			this.keyToPolar.Tag = "9734";
			// 
			// keyLN
			// 
			this.keyLN.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyLN.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyLN.FGWidth = 48;
			this.keyLN.FText = "LOG";
			this.keyLN.GText = "";
			this.keyLN.HText = "";
			this.keyLN.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyLN.Location = new System.Drawing.Point(88, 272);
			this.keyLN.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyLN.MainForeColor = System.Drawing.Color.White;
			this.keyLN.MainHeight = 24;
			this.keyLN.MainText = "LN";
			this.keyLN.MainWidth = 48;
			this.keyLN.Name = "keyLN";
			this.keyLN.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyLN.Size = new System.Drawing.Size(48, 51);
			this.keyLN.TabIndex = 20;
			this.keyLN.Tag = "9732";
			// 
			// keyRCL
			// 
			this.keyRCL.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRCL.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyRCL.FGWidth = 48;
			this.keyRCL.FText = "H.MS→";
			this.keyRCL.GText = "";
			this.keyRCL.HText = "";
			this.keyRCL.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyRCL.Location = new System.Drawing.Point(312, 272);
			this.keyRCL.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRCL.MainForeColor = System.Drawing.Color.White;
			this.keyRCL.MainHeight = 24;
			this.keyRCL.MainText = "RCL";
			this.keyRCL.MainWidth = 48;
			this.keyRCL.Name = "keyRCL";
			this.keyRCL.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyRCL.Size = new System.Drawing.Size(48, 51);
			this.keyRCL.TabIndex = 23;
			this.keyRCL.Tag = "9736";
			// 
			// keyEToTheXth
			// 
			this.keyEToTheXth.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyEToTheXth.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyEToTheXth.FGWidth = 48;
			this.keyEToTheXth.FText = "10 ̽";
			this.keyEToTheXth.GText = "";
			this.keyEToTheXth.HText = "";
			this.keyEToTheXth.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyEToTheXth.Location = new System.Drawing.Point(144, 272);
			this.keyEToTheXth.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyEToTheXth.MainForeColor = System.Drawing.Color.White;
			this.keyEToTheXth.MainHeight = 24;
			this.keyEToTheXth.MainText = "e ̽";
			this.keyEToTheXth.MainWidth = 48;
			this.keyEToTheXth.Name = "keyEToTheXth";
			this.keyEToTheXth.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyEToTheXth.Size = new System.Drawing.Size(48, 51);
			this.keyEToTheXth.TabIndex = 21;
			this.keyEToTheXth.Tag = "9733";
			// 
			// keySTO
			// 
			this.keySTO.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySTO.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keySTO.FGWidth = 48;
			this.keySTO.FText = "→H.MS";
			this.keySTO.GText = "";
			this.keySTO.HText = "";
			this.keySTO.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySTO.Location = new System.Drawing.Point(256, 272);
			this.keySTO.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySTO.MainForeColor = System.Drawing.Color.White;
			this.keySTO.MainHeight = 24;
			this.keySTO.MainText = "STO";
			this.keySTO.MainWidth = 48;
			this.keySTO.Name = "keySTO";
			this.keySTO.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySTO.Size = new System.Drawing.Size(48, 51);
			this.keySTO.TabIndex = 24;
			this.keySTO.Tag = "9735";
			// 
			// keyYToTheXth
			// 
			this.keyYToTheXth.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyYToTheXth.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyYToTheXth.FGWidth = 48;
			this.keyYToTheXth.FText = "ABS";
			this.keyYToTheXth.GText = "";
			this.keyYToTheXth.HText = "";
			this.keyYToTheXth.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyYToTheXth.Location = new System.Drawing.Point(32, 272);
			this.keyYToTheXth.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyYToTheXth.MainForeColor = System.Drawing.Color.White;
			this.keyYToTheXth.MainHeight = 24;
			this.keyYToTheXth.MainText = "y ̽";
			this.keyYToTheXth.MainWidth = 48;
			this.keyYToTheXth.Name = "keyYToTheXth";
			this.keyYToTheXth.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyYToTheXth.Size = new System.Drawing.Size(48, 51);
			this.keyYToTheXth.TabIndex = 19;
			this.keyYToTheXth.Tag = "9731";
			// 
			// groupBoxCard
			// 
			this.groupBoxCard.Controls.Add(this.cardSlot);
			this.groupBoxCard.Controls.Add(this.toggleManNorm);
			this.groupBoxCard.Controls.Add(this.keyE);
			this.groupBoxCard.Controls.Add(this.toggleOffOn);
			this.groupBoxCard.Controls.Add(this.togglePrgmRun);
			this.groupBoxCard.Controls.Add(this.keyB);
			this.groupBoxCard.Controls.Add(this.keyA);
			this.groupBoxCard.Controls.Add(this.labelTrace);
			this.groupBoxCard.Controls.Add(this.keyD);
			this.groupBoxCard.Controls.Add(this.keyF);
			this.groupBoxCard.Controls.Add(this.keyC);
			this.groupBoxCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBoxCard.Location = new System.Drawing.Point(16, 18);
			this.groupBoxCard.Name = "groupBoxCard";
			this.groupBoxCard.Size = new System.Drawing.Size(352, 194);
			this.groupBoxCard.TabIndex = 12;
			this.groupBoxCard.TabStop = false;
			// 
			// cardSlot
			// 
			this.cardSlot.Location = new System.Drawing.Point(8, 80);
			this.cardSlot.Margin = 16;
			this.cardSlot.Name = "cardSlot";
			this.cardSlot.RichText = false;
			this.cardSlot.Size = new System.Drawing.Size(288, 50);
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
			this.toggleManNorm.Location = new System.Drawing.Point(184, 24);
			this.toggleManNorm.MainWidth = 60;
			this.toggleManNorm.Name = "toggleManNorm";
			this.toggleManNorm.Position = Mockingbird.HP.Control_Library.TogglePosition.Left;
			this.toggleManNorm.RightText = "NORM";
			this.toggleManNorm.RightWidth = 60;
			this.toggleManNorm.Size = new System.Drawing.Size(160, 16);
			this.toggleManNorm.TabIndex = 1;
			this.toggleManNorm.Load += new System.EventHandler(this.toggle1_Load);
			// 
			// keyE
			// 
			this.keyE.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyE.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyE.FGWidth = 48;
			this.keyE.FText = "e";
			this.keyE.GText = "";
			this.keyE.HText = "";
			this.keyE.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyE.Location = new System.Drawing.Point(240, 142);
			this.keyE.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyE.MainForeColor = System.Drawing.Color.White;
			this.keyE.MainHeight = 24;
			this.keyE.MainText = "E";
			this.keyE.MainWidth = 48;
			this.keyE.Name = "keyE";
			this.keyE.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyE.Size = new System.Drawing.Size(48, 51);
			this.keyE.TabIndex = 11;
			this.keyE.Tag = "9715";
			// 
			// toggleOffOn
			// 
			this.toggleOffOn.LeftText = "OFF";
			this.toggleOffOn.LeftWidth = 60;
			this.toggleOffOn.Location = new System.Drawing.Point(8, 24);
			this.toggleOffOn.MainWidth = 60;
			this.toggleOffOn.Name = "toggleOffOn";
			this.toggleOffOn.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
			this.toggleOffOn.RightText = "ON";
			this.toggleOffOn.RightWidth = 60;
			this.toggleOffOn.Size = new System.Drawing.Size(144, 16);
			this.toggleOffOn.TabIndex = 2;
			// 
			// togglePrgmRun
			// 
			this.togglePrgmRun.LeftText = "PRGM";
			this.togglePrgmRun.LeftWidth = 60;
			this.togglePrgmRun.Location = new System.Drawing.Point(184, 48);
			this.togglePrgmRun.MainWidth = 60;
			this.togglePrgmRun.Name = "togglePrgmRun";
			this.togglePrgmRun.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
			this.togglePrgmRun.RightText = "RUN";
			this.togglePrgmRun.RightWidth = 60;
			this.togglePrgmRun.Size = new System.Drawing.Size(152, 16);
			this.togglePrgmRun.TabIndex = 3;
			// 
			// keyB
			// 
			this.keyB.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyB.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyB.FGWidth = 48;
			this.keyB.FText = "b";
			this.keyB.GText = "";
			this.keyB.HText = "";
			this.keyB.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyB.Location = new System.Drawing.Point(72, 142);
			this.keyB.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyB.MainForeColor = System.Drawing.Color.White;
			this.keyB.MainHeight = 24;
			this.keyB.MainText = "B";
			this.keyB.MainWidth = 48;
			this.keyB.Name = "keyB";
			this.keyB.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyB.Size = new System.Drawing.Size(48, 51);
			this.keyB.TabIndex = 6;
			this.keyB.Tag = "9712";
			// 
			// keyA
			// 
			this.keyA.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyA.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyA.FGWidth = 48;
			this.keyA.FText = "a";
			this.keyA.GText = "";
			this.keyA.HText = "";
			this.keyA.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyA.Location = new System.Drawing.Point(16, 142);
			this.keyA.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyA.MainForeColor = System.Drawing.Color.White;
			this.keyA.MainHeight = 24;
			this.keyA.MainText = "A";
			this.keyA.MainWidth = 48;
			this.keyA.Name = "keyA";
			this.keyA.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyA.Size = new System.Drawing.Size(48, 51);
			this.keyA.TabIndex = 5;
			this.keyA.Tag = "9711";
			// 
			// labelTrace
			// 
			this.labelTrace.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.labelTrace.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelTrace.ForeColor = System.Drawing.Color.White;
			this.labelTrace.Location = new System.Drawing.Point(248, 8);
			this.labelTrace.Name = "labelTrace";
			this.labelTrace.Size = new System.Drawing.Size(56, 16);
			this.labelTrace.TabIndex = 4;
			this.labelTrace.Text = "TRACE";
			this.labelTrace.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// keyD
			// 
			this.keyD.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyD.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyD.FGWidth = 48;
			this.keyD.FText = "d";
			this.keyD.GText = "";
			this.keyD.HText = "";
			this.keyD.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyD.Location = new System.Drawing.Point(184, 142);
			this.keyD.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyD.MainForeColor = System.Drawing.Color.White;
			this.keyD.MainHeight = 24;
			this.keyD.MainText = "D";
			this.keyD.MainWidth = 48;
			this.keyD.Name = "keyD";
			this.keyD.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyD.Size = new System.Drawing.Size(48, 51);
			this.keyD.TabIndex = 8;
			this.keyD.Tag = "9714";
			// 
			// keyF
			// 
			this.keyF.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyF.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyF.FGWidth = 48;
			this.keyF.FText = "";
			this.keyF.GText = "";
			this.keyF.HText = "";
			this.keyF.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyF.Location = new System.Drawing.Point(296, 142);
			this.keyF.MainBackColor = System.Drawing.Color.Gold;
			this.keyF.MainForeColor = System.Drawing.Color.Black;
			this.keyF.MainHeight = 24;
			this.keyF.MainText = "f";
			this.keyF.MainWidth = 48;
			this.keyF.Name = "keyF";
			this.keyF.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyF.Size = new System.Drawing.Size(48, 51);
			this.keyF.TabIndex = 9;
			this.keyF.Tag = "9716";
			// 
			// keyC
			// 
			this.keyC.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyC.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyC.FGWidth = 48;
			this.keyC.FText = "c";
			this.keyC.GText = "";
			this.keyC.HText = "";
			this.keyC.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyC.Location = new System.Drawing.Point(128, 142);
			this.keyC.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyC.MainForeColor = System.Drawing.Color.White;
			this.keyC.MainHeight = 24;
			this.keyC.MainText = "C";
			this.keyC.MainWidth = 48;
			this.keyC.Name = "keyC";
			this.keyC.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyC.Size = new System.Drawing.Size(48, 51);
			this.keyC.TabIndex = 7;
			this.keyC.Tag = "9713";
			// 
			// keyRTN
			// 
			this.keyRTN.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRTN.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyRTN.FGWidth = 48;
			this.keyRTN.FText = "RND";
			this.keyRTN.GText = "";
			this.keyRTN.HText = "";
			this.keyRTN.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyRTN.Location = new System.Drawing.Point(200, 216);
			this.keyRTN.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRTN.MainForeColor = System.Drawing.Color.White;
			this.keyRTN.MainHeight = 24;
			this.keyRTN.MainText = "RTN";
			this.keyRTN.MainWidth = 48;
			this.keyRTN.Name = "keyRTN";
			this.keyRTN.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyRTN.Size = new System.Drawing.Size(48, 51);
			this.keyRTN.TabIndex = 16;
			this.keyRTN.Tag = "9724";
			// 
			// keyGTO
			// 
			this.keyGTO.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyGTO.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyGTO.FGWidth = 48;
			this.keyGTO.FText = "CLF";
			this.keyGTO.GText = "";
			this.keyGTO.HText = "";
			this.keyGTO.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyGTO.Location = new System.Drawing.Point(88, 216);
			this.keyGTO.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyGTO.MainForeColor = System.Drawing.Color.White;
			this.keyGTO.MainHeight = 24;
			this.keyGTO.MainText = "GTO";
			this.keyGTO.MainWidth = 48;
			this.keyGTO.Name = "keyGTO";
			this.keyGTO.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyGTO.Size = new System.Drawing.Size(48, 51);
			this.keyGTO.TabIndex = 14;
			this.keyGTO.Tag = "9722";
			// 
			// keySST
			// 
			this.keySST.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySST.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keySST.FGWidth = 48;
			this.keySST.FText = "ISZ";
			this.keySST.GText = "";
			this.keySST.HText = "";
			this.keySST.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keySST.Location = new System.Drawing.Point(312, 216);
			this.keySST.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySST.MainForeColor = System.Drawing.Color.White;
			this.keySST.MainHeight = 24;
			this.keySST.MainText = "SST";
			this.keySST.MainWidth = 48;
			this.keySST.Name = "keySST";
			this.keySST.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keySST.Size = new System.Drawing.Size(48, 51);
			this.keySST.TabIndex = 17;
			this.keySST.Tag = "9726";
			// 
			// keyGSB
			// 
			this.keyGSB.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyGSB.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyGSB.FGWidth = 48;
			this.keyGSB.FText = "F?";
			this.keyGSB.GText = "";
			this.keyGSB.HText = "";
			this.keyGSB.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyGSB.Location = new System.Drawing.Point(144, 216);
			this.keyGSB.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyGSB.MainForeColor = System.Drawing.Color.White;
			this.keyGSB.MainHeight = 24;
			this.keyGSB.MainText = "GSB";
			this.keyGSB.MainWidth = 48;
			this.keyGSB.Name = "keyGSB";
			this.keyGSB.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyGSB.Size = new System.Drawing.Size(48, 51);
			this.keyGSB.TabIndex = 15;
			this.keyGSB.Tag = "9723";
			// 
			// keyBST
			// 
			this.keyBST.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyBST.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyBST.FGWidth = 48;
			this.keyBST.FText = "DSZ";
			this.keyBST.GText = "";
			this.keyBST.HText = "";
			this.keyBST.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyBST.Location = new System.Drawing.Point(256, 216);
			this.keyBST.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyBST.MainForeColor = System.Drawing.Color.White;
			this.keyBST.MainHeight = 24;
			this.keyBST.MainText = "BST";
			this.keyBST.MainWidth = 48;
			this.keyBST.Name = "keyBST";
			this.keyBST.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyBST.Size = new System.Drawing.Size(48, 51);
			this.keyBST.TabIndex = 18;
			this.keyBST.Tag = "9725";
			// 
			// keyLBL
			// 
			this.keyLBL.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyLBL.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.keyLBL.FGWidth = 48;
			this.keyLBL.FText = "STF";
			this.keyLBL.GText = "";
			this.keyLBL.HText = "";
			this.keyLBL.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyLBL.Location = new System.Drawing.Point(32, 216);
			this.keyLBL.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyLBL.MainForeColor = System.Drawing.Color.White;
			this.keyLBL.MainHeight = 24;
			this.keyLBL.MainText = "LBL";
			this.keyLBL.MainWidth = 48;
			this.keyLBL.Name = "keyLBL";
			this.keyLBL.Shortcuts = new System.Windows.Forms.Keys[0];
			this.keyLBL.Size = new System.Drawing.Size(48, 51);
			this.keyLBL.TabIndex = 13;
			this.keyLBL.Tag = "9721";
			// 
			// panelDisplay
			// 
			this.panelDisplay.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(32)), ((System.Byte)(32)), ((System.Byte)(32)));
			this.panelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelDisplay.Controls.Add(this.display);
			this.panelDisplay.Location = new System.Drawing.Point(8, 216);
			this.panelDisplay.Name = "panelDisplay";
			this.panelDisplay.Size = new System.Drawing.Size(536, 64);
			this.panelDisplay.TabIndex = 4;
			// 
			// display
			// 
			this.display.ForeColor = System.Drawing.Color.Red;
			this.display.Location = new System.Drawing.Point(120, 8);
			this.display.Name = "display";
			this.display.Size = new System.Drawing.Size(408, 40);
			this.display.TabIndex = 4;
			this.display.Value = 0;
			// 
			// HP97
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.DarkKhaki;
			this.ClientSize = new System.Drawing.Size(904, 726);
			this.Controls.Add(this.panelDisplay);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.printer);
			this.MaximizeBox = false;
			this.Name = "HP97";
			this.Text = "HP97";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panelMain.ResumeLayout(false);
			this.groupBoxCard.ResumeLayout(false);
			this.panelDisplay.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new HP97 ());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void toggle1_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
