using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Execution;
using Mockingbird.HP.Parser;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mockingbird.HP.HP67
{
    /// <summary>
    /// The user interface for the HP-67 calculator.
    /// </summary>
    public class HP67 :
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
		protected System.Windows.Forms.OpenFileDialog openFileDialog;
		protected System.Windows.Forms.SaveFileDialog saveFileDialog;
		protected System.Drawing.Printing.PrintDocument printDocument;
        protected MenuStrip menuStrip;
        protected ToolStripMenuItem fileToolStripMenuItem;
        protected ToolStripMenuItem openToolStripMenuItem;
        protected ToolStripMenuItem saveToolStripMenuItem;
        protected ToolStripMenuItem saveAsToolStripMenuItem;
        protected ToolStripMenuItem printToolStripMenuItem;
        protected ToolStripMenuItem exitToolStripMenuItem;

		// CardCalculator.
		protected Mockingbird.HP.Control_Library.CardSlot cardSlot;
        protected ToolStripMenuItem editToolStripMenuItem;
        protected ToolStripMenuItem editLabelsToolStripMenuItem;
        protected ToolStripMenuItem rtfToolStripMenuItem;

		// The designer wants the following event handlers to exist otherwise it loses the
		// associations with the controls.
		private void editLabelsToolStripMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

        private void exitToolStripMenuItem_Click (object sender, System.EventArgs e)
        {
        }

        private void openToolStripMenuItem_Click (object sender, System.EventArgs e) 
		{
		}

		private void printToolStripMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void saveToolStripMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void saveAsToolStripMenuItem_Click(object sender, System.EventArgs e) 
		{
		}

		private void rtfToolStripMenuItem_Click(object sender, System.EventArgs e) 
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

		private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void Calculator_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}

		private void Calculator_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}
#endif

        private Mockingbird.HP.Control_Library.Key keyA;
        private Mockingbird.HP.Control_Library.Key keyB;
        private Mockingbird.HP.Control_Library.Key keyC;
        private Mockingbird.HP.Control_Library.Key keyD;
        private Mockingbird.HP.Control_Library.Key keyE;
        private Mockingbird.HP.Control_Library.Key keyΣ;
        private Mockingbird.HP.Control_Library.Key keyGTO;
        private Mockingbird.HP.Control_Library.Key keyDSP;
        private Mockingbird.HP.Control_Library.Key keyi;
        private Mockingbird.HP.Control_Library.Key keySST;
        private Mockingbird.HP.Control_Library.Key keyf;
        private Mockingbird.HP.Control_Library.Key keyg;
        private Mockingbird.HP.Control_Library.Key keySTO;
        private Mockingbird.HP.Control_Library.Key keyRCL;
        private Mockingbird.HP.Control_Library.Key keyh;
        private Mockingbird.HP.Control_Library.Key keyENTER;
        private Mockingbird.HP.Control_Library.Key keyCHS;
        private Mockingbird.HP.Control_Library.Key keyEEX;
        private Mockingbird.HP.Control_Library.Key keyCLx;
        private Mockingbird.HP.Control_Library.Key keyMinus;
        private Mockingbird.HP.Control_Library.Key key7;
        private Mockingbird.HP.Control_Library.Key key8;
        private Mockingbird.HP.Control_Library.Key key9;
        private Mockingbird.HP.Control_Library.Key key4;
        private Mockingbird.HP.Control_Library.Key keyPlus;
        private Mockingbird.HP.Control_Library.Key key5;
        private Mockingbird.HP.Control_Library.Key key6;
        private Mockingbird.HP.Control_Library.Key keyMult;
        private Mockingbird.HP.Control_Library.Key key2;
        private Mockingbird.HP.Control_Library.Key key1;
        private Mockingbird.HP.Control_Library.Key key3;
        private Mockingbird.HP.Control_Library.Key keyDiv;
        private Mockingbird.HP.Control_Library.Key keyRS;
        private Mockingbird.HP.Control_Library.Key key0;
        private Mockingbird.HP.Control_Library.Key keyPeriod;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region Constructors & Destructors

        public HP67 (string [] arguments)
            : base (arguments, CalculatorModel.HP67)
        {
        }

        protected override void Dispose (bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose ();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (HP67));
            this.cardSlot = new Mockingbird.HP.Control_Library.CardSlot ();
            this.display = new Mockingbird.HP.Control_Library.Display ();
            this.toggleOffOn = new Mockingbird.HP.Control_Library.Toggle ();
            this.toggleWprgmRun = new Mockingbird.HP.Control_Library.Toggle ();
            this.keyA = new Mockingbird.HP.Control_Library.Key ();
            this.keyf = new Mockingbird.HP.Control_Library.Key ();
            this.keySST = new Mockingbird.HP.Control_Library.Key ();
            this.keyi = new Mockingbird.HP.Control_Library.Key ();
            this.keyDSP = new Mockingbird.HP.Control_Library.Key ();
            this.keyGTO = new Mockingbird.HP.Control_Library.Key ();
            this.keyΣ = new Mockingbird.HP.Control_Library.Key ();
            this.keyE = new Mockingbird.HP.Control_Library.Key ();
            this.keyD = new Mockingbird.HP.Control_Library.Key ();
            this.keyC = new Mockingbird.HP.Control_Library.Key ();
            this.keyB = new Mockingbird.HP.Control_Library.Key ();
            this.keyENTER = new Mockingbird.HP.Control_Library.Key ();
            this.keyEEX = new Mockingbird.HP.Control_Library.Key ();
            this.keyCLx = new Mockingbird.HP.Control_Library.Key ();
            this.keyCHS = new Mockingbird.HP.Control_Library.Key ();
            this.keyh = new Mockingbird.HP.Control_Library.Key ();
            this.keyRCL = new Mockingbird.HP.Control_Library.Key ();
            this.keySTO = new Mockingbird.HP.Control_Library.Key ();
            this.keyg = new Mockingbird.HP.Control_Library.Key ();
            this.key8 = new Mockingbird.HP.Control_Library.Key ();
            this.keyRS = new Mockingbird.HP.Control_Library.Key ();
            this.keyPeriod = new Mockingbird.HP.Control_Library.Key ();
            this.key0 = new Mockingbird.HP.Control_Library.Key ();
            this.key9 = new Mockingbird.HP.Control_Library.Key ();
            this.key3 = new Mockingbird.HP.Control_Library.Key ();
            this.key2 = new Mockingbird.HP.Control_Library.Key ();
            this.key1 = new Mockingbird.HP.Control_Library.Key ();
            this.key6 = new Mockingbird.HP.Control_Library.Key ();
            this.key5 = new Mockingbird.HP.Control_Library.Key ();
            this.key4 = new Mockingbird.HP.Control_Library.Key ();
            this.key7 = new Mockingbird.HP.Control_Library.Key ();
            this.keyMinus = new Mockingbird.HP.Control_Library.Key ();
            this.keyDiv = new Mockingbird.HP.Control_Library.Key ();
            this.keyMult = new Mockingbird.HP.Control_Library.Key ();
            this.keyPlus = new Mockingbird.HP.Control_Library.Key ();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog ();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog ();
            this.printDocument = new System.Drawing.Printing.PrintDocument ();
            this.menuStrip = new System.Windows.Forms.MenuStrip ();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.editLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.rtfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.menuStrip.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // cardSlot
            // 
            this.cardSlot.AccessibleDescription = null;
            this.cardSlot.AccessibleName = null;
            resources.ApplyResources (this.cardSlot, "cardSlot");
            this.cardSlot.BackgroundImage = null;
            this.cardSlot.Name = "cardSlot";
            this.cardSlot.RichText = false;
            this.cardSlot.State = Mockingbird.HP.Control_Library.CardSlotState.Unloaded;
            this.cardSlot.TextBoxWidth = 48;
            this.cardSlot.Title = "<TITLE>";
            this.cardSlot.UnloadedTextA = "1/x";
            this.cardSlot.UnloadedTextB = "√x̅";
            this.cardSlot.UnloadedTextC = "yˣ";
            this.cardSlot.UnloadedTextD = "R↓";
            this.cardSlot.UnloadedTextE = "x⇄y";
            // 
            // display
            // 
            this.display.AccessibleDescription = null;
            this.display.AccessibleName = null;
            resources.ApplyResources (this.display, "display");
            this.display.BackgroundImage = null;
            this.display.ForeColor = System.Drawing.Color.Red;
            this.display.Name = "display";
            this.display.Value = 0;
            // 
            // toggleOffOn
            // 
            this.toggleOffOn.AccessibleDescription = null;
            this.toggleOffOn.AccessibleName = null;
            resources.ApplyResources (this.toggleOffOn, "toggleOffOn");
            this.toggleOffOn.BackgroundImage = null;
            this.toggleOffOn.ForeColor = System.Drawing.Color.White;
            this.toggleOffOn.LeftText = "OFF";
            this.toggleOffOn.LeftWidth = 30;
            this.toggleOffOn.MainWidth = 50;
            this.toggleOffOn.Name = "toggleOffOn";
            this.toggleOffOn.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
            this.toggleOffOn.RightText = "ON";
            this.toggleOffOn.RightWidth = 30;
            this.toggleOffOn.ToggleClick += new Mockingbird.HP.Control_Library.Toggle.ToggleClickEvent (this.toggleOffOn_ToggleClick);
            // 
            // toggleWprgmRun
            // 
            this.toggleWprgmRun.AccessibleDescription = null;
            this.toggleWprgmRun.AccessibleName = null;
            resources.ApplyResources (this.toggleWprgmRun, "toggleWprgmRun");
            this.toggleWprgmRun.BackgroundImage = null;
            this.toggleWprgmRun.ForeColor = System.Drawing.Color.White;
            this.toggleWprgmRun.LeftText = "W/PRGM";
            this.toggleWprgmRun.LeftWidth = 60;
            this.toggleWprgmRun.MainWidth = 50;
            this.toggleWprgmRun.Name = "toggleWprgmRun";
            this.toggleWprgmRun.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
            this.toggleWprgmRun.RightText = "RUN";
            this.toggleWprgmRun.RightWidth = 30;
            this.toggleWprgmRun.ToggleClick += new Mockingbird.HP.Control_Library.Toggle.ToggleClickEvent (this.toggleWprgmRun_ToggleClick);
            // 
            // keyA
            // 
            this.keyA.AccessibleDescription = null;
            this.keyA.AccessibleName = null;
            resources.ApplyResources (this.keyA, "keyA");
            this.keyA.BackgroundImage = null;
            this.keyA.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyA.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyA.FGWidth = 48;
            this.keyA.FText = "a";
            this.keyA.GText = "";
            this.keyA.HText = "";
            this.keyA.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyA.MainBackColor = System.Drawing.Color.Olive;
            this.keyA.MainForeColor = System.Drawing.Color.White;
            this.keyA.MainHeight = 24;
            this.keyA.MainText = "A";
            this.keyA.MainWidth = 48;
            this.keyA.Name = "keyA";
            this.keyA.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.A};
            this.keyA.Tag = "6711";
            this.keyA.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyA.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyf
            // 
            this.keyf.AccessibleDescription = null;
            this.keyf.AccessibleName = null;
            resources.ApplyResources (this.keyf, "keyf");
            this.keyf.BackgroundImage = null;
            this.keyf.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyf.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyf.FGWidth = 48;
            this.keyf.FText = "";
            this.keyf.GText = "";
            this.keyf.HText = "";
            this.keyf.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyf.MainBackColor = System.Drawing.Color.Gold;
            this.keyf.MainForeColor = System.Drawing.Color.Black;
            this.keyf.MainHeight = 24;
            this.keyf.MainText = "f";
            this.keyf.MainWidth = 48;
            this.keyf.Name = "keyf";
            this.keyf.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.F};
            this.keyf.Tag = "6731";
            this.keyf.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyf.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySST
            // 
            this.keySST.AccessibleDescription = null;
            this.keySST.AccessibleName = null;
            resources.ApplyResources (this.keySST, "keySST");
            this.keySST.BackgroundImage = null;
            this.keySST.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySST.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySST.FGWidth = 48;
            this.keySST.FText = "LBL";
            this.keySST.GText = "f";
            this.keySST.HText = "BST";
            this.keySST.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySST.MainBackColor = System.Drawing.Color.Olive;
            this.keySST.MainForeColor = System.Drawing.Color.White;
            this.keySST.MainHeight = 24;
            this.keySST.MainText = "SST";
            this.keySST.MainWidth = 48;
            this.keySST.Name = "keySST";
            this.keySST.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySST.Tag = "6725";
            this.keySST.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySST.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyi
            // 
            this.keyi.AccessibleDescription = null;
            this.keyi.AccessibleName = null;
            resources.ApplyResources (this.keyi, "keyi");
            this.keyi.BackgroundImage = null;
            this.keyi.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyi.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyi.FGWidth = 48;
            this.keyi.FText = "RND";
            this.keyi.GText = "";
            this.keyi.HText = "x⇆I";
            this.keyi.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyi.MainBackColor = System.Drawing.Color.Olive;
            this.keyi.MainForeColor = System.Drawing.Color.White;
            this.keyi.MainHeight = 24;
            this.keyi.MainText = "(i)";
            this.keyi.MainWidth = 48;
            this.keyi.Name = "keyi";
            this.keyi.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyi.Tag = "6724";
            this.keyi.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyi.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyDSP
            // 
            this.keyDSP.AccessibleDescription = null;
            this.keyDSP.AccessibleName = null;
            resources.ApplyResources (this.keyDSP, "keyDSP");
            this.keyDSP.BackgroundImage = null;
            this.keyDSP.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyDSP.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyDSP.FGWidth = 48;
            this.keyDSP.FText = "FIX";
            this.keyDSP.GText = "SCI";
            this.keyDSP.HText = "ENG";
            this.keyDSP.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyDSP.MainBackColor = System.Drawing.Color.Olive;
            this.keyDSP.MainForeColor = System.Drawing.Color.White;
            this.keyDSP.MainHeight = 24;
            this.keyDSP.MainText = "DSP";
            this.keyDSP.MainWidth = 48;
            this.keyDSP.Name = "keyDSP";
            this.keyDSP.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyDSP.Tag = "6723";
            this.keyDSP.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyDSP.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyGTO
            // 
            this.keyGTO.AccessibleDescription = null;
            this.keyGTO.AccessibleName = null;
            resources.ApplyResources (this.keyGTO, "keyGTO");
            this.keyGTO.BackgroundImage = null;
            this.keyGTO.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyGTO.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyGTO.FGWidth = 48;
            this.keyGTO.FText = "GSB";
            this.keyGTO.GText = "f";
            this.keyGTO.HText = "RTN";
            this.keyGTO.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyGTO.MainBackColor = System.Drawing.Color.Olive;
            this.keyGTO.MainForeColor = System.Drawing.Color.White;
            this.keyGTO.MainHeight = 24;
            this.keyGTO.MainText = "GTO";
            this.keyGTO.MainWidth = 48;
            this.keyGTO.Name = "keyGTO";
            this.keyGTO.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyGTO.Tag = "6722";
            this.keyGTO.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyGTO.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyΣ
            // 
            this.keyΣ.AccessibleDescription = null;
            this.keyΣ.AccessibleName = null;
            resources.ApplyResources (this.keyΣ, "keyΣ");
            this.keyΣ.BackgroundImage = null;
            this.keyΣ.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyΣ.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyΣ.FGWidth = 48;
            this.keyΣ.FText = "x̄";
            this.keyΣ.GText = "s";
            this.keyΣ.HText = "Σ-";
            this.keyΣ.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyΣ.MainBackColor = System.Drawing.Color.Olive;
            this.keyΣ.MainForeColor = System.Drawing.Color.White;
            this.keyΣ.MainHeight = 24;
            this.keyΣ.MainText = "Σ+";
            this.keyΣ.MainWidth = 48;
            this.keyΣ.Name = "keyΣ";
            this.keyΣ.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyΣ.Tag = "6721";
            this.keyΣ.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyΣ.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyE
            // 
            this.keyE.AccessibleDescription = null;
            this.keyE.AccessibleName = null;
            resources.ApplyResources (this.keyE, "keyE");
            this.keyE.BackgroundImage = null;
            this.keyE.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyE.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyE.FGWidth = 48;
            this.keyE.FText = "e";
            this.keyE.GText = "";
            this.keyE.HText = "";
            this.keyE.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyE.MainBackColor = System.Drawing.Color.Olive;
            this.keyE.MainForeColor = System.Drawing.Color.White;
            this.keyE.MainHeight = 24;
            this.keyE.MainText = "E";
            this.keyE.MainWidth = 48;
            this.keyE.Name = "keyE";
            this.keyE.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.E};
            this.keyE.Tag = "6715";
            this.keyE.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyE.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyD
            // 
            this.keyD.AccessibleDescription = null;
            this.keyD.AccessibleName = null;
            resources.ApplyResources (this.keyD, "keyD");
            this.keyD.BackgroundImage = null;
            this.keyD.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyD.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyD.FGWidth = 48;
            this.keyD.FText = "d";
            this.keyD.GText = "";
            this.keyD.HText = "";
            this.keyD.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyD.MainBackColor = System.Drawing.Color.Olive;
            this.keyD.MainForeColor = System.Drawing.Color.White;
            this.keyD.MainHeight = 24;
            this.keyD.MainText = "D";
            this.keyD.MainWidth = 48;
            this.keyD.Name = "keyD";
            this.keyD.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D};
            this.keyD.Tag = "6714";
            this.keyD.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyD.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyC
            // 
            this.keyC.AccessibleDescription = null;
            this.keyC.AccessibleName = null;
            resources.ApplyResources (this.keyC, "keyC");
            this.keyC.BackgroundImage = null;
            this.keyC.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyC.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyC.FGWidth = 48;
            this.keyC.FText = "c";
            this.keyC.GText = "";
            this.keyC.HText = "";
            this.keyC.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyC.MainBackColor = System.Drawing.Color.Olive;
            this.keyC.MainForeColor = System.Drawing.Color.White;
            this.keyC.MainHeight = 24;
            this.keyC.MainText = "C";
            this.keyC.MainWidth = 48;
            this.keyC.Name = "keyC";
            this.keyC.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.C};
            this.keyC.Tag = "6713";
            this.keyC.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyC.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyB
            // 
            this.keyB.AccessibleDescription = null;
            this.keyB.AccessibleName = null;
            resources.ApplyResources (this.keyB, "keyB");
            this.keyB.BackgroundImage = null;
            this.keyB.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyB.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyB.FGWidth = 48;
            this.keyB.FText = "b";
            this.keyB.GText = "";
            this.keyB.HText = "";
            this.keyB.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyB.MainBackColor = System.Drawing.Color.Olive;
            this.keyB.MainForeColor = System.Drawing.Color.White;
            this.keyB.MainHeight = 24;
            this.keyB.MainText = "B";
            this.keyB.MainWidth = 48;
            this.keyB.Name = "keyB";
            this.keyB.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.B};
            this.keyB.Tag = "6712";
            this.keyB.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyB.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyENTER
            // 
            this.keyENTER.AccessibleDescription = null;
            this.keyENTER.AccessibleName = null;
            resources.ApplyResources (this.keyENTER, "keyENTER");
            this.keyENTER.BackgroundImage = null;
            this.keyENTER.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyENTER.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.keyENTER.FGWidth = 120;
            this.keyENTER.FText = "W/DATA";
            this.keyENTER.GText = "MERGE";
            this.keyENTER.HText = "DEG";
            this.keyENTER.HTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.keyENTER.MainBackColor = System.Drawing.Color.Olive;
            this.keyENTER.MainForeColor = System.Drawing.Color.White;
            this.keyENTER.MainHeight = 24;
            this.keyENTER.MainText = "ENTER ↑";
            this.keyENTER.MainWidth = 104;
            this.keyENTER.Name = "keyENTER";
            this.keyENTER.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Return};
            this.keyENTER.Tag = "6741";
            this.keyENTER.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyENTER.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyEEX
            // 
            this.keyEEX.AccessibleDescription = null;
            this.keyEEX.AccessibleName = null;
            resources.ApplyResources (this.keyEEX, "keyEEX");
            this.keyEEX.BackgroundImage = null;
            this.keyEEX.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyEEX.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyEEX.FGWidth = 48;
            this.keyEEX.FText = "CL REG";
            this.keyEEX.GText = "";
            this.keyEEX.HText = "GRD";
            this.keyEEX.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyEEX.MainBackColor = System.Drawing.Color.Olive;
            this.keyEEX.MainForeColor = System.Drawing.Color.White;
            this.keyEEX.MainHeight = 24;
            this.keyEEX.MainText = "EEX";
            this.keyEEX.MainWidth = 48;
            this.keyEEX.Name = "keyEEX";
            this.keyEEX.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyEEX.Tag = "6743";
            this.keyEEX.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyEEX.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyCLx
            // 
            this.keyCLx.AccessibleDescription = null;
            this.keyCLx.AccessibleName = null;
            resources.ApplyResources (this.keyCLx, "keyCLx");
            this.keyCLx.BackgroundImage = null;
            this.keyCLx.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyCLx.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyCLx.FGWidth = 64;
            this.keyCLx.FText = "CL PRGM";
            this.keyCLx.GText = "";
            this.keyCLx.HText = "DEL";
            this.keyCLx.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyCLx.MainBackColor = System.Drawing.Color.Olive;
            this.keyCLx.MainForeColor = System.Drawing.Color.White;
            this.keyCLx.MainHeight = 24;
            this.keyCLx.MainText = "CLx";
            this.keyCLx.MainWidth = 48;
            this.keyCLx.Name = "keyCLx";
            this.keyCLx.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyCLx.Tag = "6744";
            this.keyCLx.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyCLx.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyCHS
            // 
            this.keyCHS.AccessibleDescription = null;
            this.keyCHS.AccessibleName = null;
            resources.ApplyResources (this.keyCHS, "keyCHS");
            this.keyCHS.BackgroundImage = null;
            this.keyCHS.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyCHS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyCHS.FGWidth = 48;
            this.keyCHS.FText = "P⇆S";
            this.keyCHS.GText = "";
            this.keyCHS.HText = "RAD";
            this.keyCHS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyCHS.MainBackColor = System.Drawing.Color.Olive;
            this.keyCHS.MainForeColor = System.Drawing.Color.White;
            this.keyCHS.MainHeight = 24;
            this.keyCHS.MainText = "CHS";
            this.keyCHS.MainWidth = 48;
            this.keyCHS.Name = "keyCHS";
            this.keyCHS.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyCHS.Tag = "6742";
            this.keyCHS.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyCHS.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyh
            // 
            this.keyh.AccessibleDescription = null;
            this.keyh.AccessibleName = null;
            resources.ApplyResources (this.keyh, "keyh");
            this.keyh.BackgroundImage = null;
            this.keyh.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyh.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyh.FGWidth = 48;
            this.keyh.FText = "";
            this.keyh.GText = "";
            this.keyh.HText = "";
            this.keyh.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyh.MainBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (32)))), ((int) (((byte) (32)))), ((int) (((byte) (32)))));
            this.keyh.MainForeColor = System.Drawing.Color.White;
            this.keyh.MainHeight = 24;
            this.keyh.MainText = "h";
            this.keyh.MainWidth = 48;
            this.keyh.Name = "keyh";
            this.keyh.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.H};
            this.keyh.Tag = "6735";
            this.keyh.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyh.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyRCL
            // 
            this.keyRCL.AccessibleDescription = null;
            this.keyRCL.AccessibleName = null;
            resources.ApplyResources (this.keyRCL, "keyRCL");
            this.keyRCL.BackgroundImage = null;
            this.keyRCL.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRCL.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyRCL.FGWidth = 48;
            this.keyRCL.FText = "ISZ";
            this.keyRCL.GText = "(i)";
            this.keyRCL.HText = "RC I";
            this.keyRCL.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyRCL.MainBackColor = System.Drawing.Color.Olive;
            this.keyRCL.MainForeColor = System.Drawing.Color.White;
            this.keyRCL.MainHeight = 24;
            this.keyRCL.MainText = "RCL";
            this.keyRCL.MainWidth = 48;
            this.keyRCL.Name = "keyRCL";
            this.keyRCL.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyRCL.Tag = "6734";
            this.keyRCL.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyRCL.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keySTO
            // 
            this.keySTO.AccessibleDescription = null;
            this.keySTO.AccessibleName = null;
            resources.ApplyResources (this.keySTO, "keySTO");
            this.keySTO.BackgroundImage = null;
            this.keySTO.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keySTO.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keySTO.FGWidth = 48;
            this.keySTO.FText = "DSZ";
            this.keySTO.GText = "(i)";
            this.keySTO.HText = "ST I";
            this.keySTO.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keySTO.MainBackColor = System.Drawing.Color.Olive;
            this.keySTO.MainForeColor = System.Drawing.Color.White;
            this.keySTO.MainHeight = 24;
            this.keySTO.MainText = "STO";
            this.keySTO.MainWidth = 48;
            this.keySTO.Name = "keySTO";
            this.keySTO.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keySTO.Tag = "6733";
            this.keySTO.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keySTO.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyg
            // 
            this.keyg.AccessibleDescription = null;
            this.keyg.AccessibleName = null;
            resources.ApplyResources (this.keyg, "keyg");
            this.keyg.BackgroundImage = null;
            this.keyg.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyg.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.keyg.FGWidth = 48;
            this.keyg.FText = "";
            this.keyg.GText = "";
            this.keyg.HText = "";
            this.keyg.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyg.MainBackColor = System.Drawing.Color.SkyBlue;
            this.keyg.MainForeColor = System.Drawing.Color.Black;
            this.keyg.MainHeight = 24;
            this.keyg.MainText = "g";
            this.keyg.MainWidth = 48;
            this.keyg.Name = "keyg";
            this.keyg.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.G};
            this.keyg.Tag = "6732";
            this.keyg.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyg.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key8
            // 
            this.key8.AccessibleDescription = null;
            this.key8.AccessibleName = null;
            resources.ApplyResources (this.key8, "key8");
            this.key8.BackgroundImage = null;
            this.key8.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key8.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.key8.FGWidth = 56;
            this.key8.FText = "LOG";
            this.key8.GText = "10 ̽";
            this.key8.HText = "R↓";
            this.key8.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key8.MainBackColor = System.Drawing.Color.LightYellow;
            this.key8.MainForeColor = System.Drawing.Color.Black;
            this.key8.MainHeight = 24;
            this.key8.MainText = "8";
            this.key8.MainWidth = 56;
            this.key8.Name = "key8";
            this.key8.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D8,
        System.Windows.Forms.Keys.NumPad8};
            this.key8.Tag = "6753";
            this.key8.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key8.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyRS
            // 
            this.keyRS.AccessibleDescription = null;
            this.keyRS.AccessibleName = null;
            resources.ApplyResources (this.keyRS, "keyRS");
            this.keyRS.BackgroundImage = null;
            this.keyRS.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyRS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.keyRS.FGWidth = 56;
            this.keyRS.FText = "–x–";
            this.keyRS.GText = "STK";
            this.keyRS.HText = "SPACE";
            this.keyRS.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyRS.MainBackColor = System.Drawing.Color.LightYellow;
            this.keyRS.MainForeColor = System.Drawing.Color.Black;
            this.keyRS.MainHeight = 24;
            this.keyRS.MainText = "R/S";
            this.keyRS.MainWidth = 56;
            this.keyRS.Name = "keyRS";
            this.keyRS.Shortcuts = new System.Windows.Forms.Keys [0];
            this.keyRS.Tag = "6784";
            this.keyRS.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyRS.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyPeriod
            // 
            this.keyPeriod.AccessibleDescription = null;
            this.keyPeriod.AccessibleName = null;
            resources.ApplyResources (this.keyPeriod, "keyPeriod");
            this.keyPeriod.BackgroundImage = null;
            this.keyPeriod.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPeriod.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.keyPeriod.FGWidth = 72;
            this.keyPeriod.FText = "INT";
            this.keyPeriod.GText = "FRAC";
            this.keyPeriod.HText = "H.MS+";
            this.keyPeriod.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyPeriod.MainBackColor = System.Drawing.Color.LightYellow;
            this.keyPeriod.MainForeColor = System.Drawing.Color.Black;
            this.keyPeriod.MainHeight = 24;
            this.keyPeriod.MainText = " ・";
            this.keyPeriod.MainWidth = 56;
            this.keyPeriod.Name = "keyPeriod";
            this.keyPeriod.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Decimal};
            this.keyPeriod.Tag = "6783";
            this.keyPeriod.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyPeriod.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key0
            // 
            this.key0.AccessibleDescription = null;
            this.key0.AccessibleName = null;
            resources.ApplyResources (this.key0, "key0");
            this.key0.BackgroundImage = null;
            this.key0.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key0.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.key0.FGWidth = 56;
            this.key0.FText = "%";
            this.key0.GText = "%CH";
            this.key0.HText = "LST x";
            this.key0.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key0.MainBackColor = System.Drawing.Color.LightYellow;
            this.key0.MainForeColor = System.Drawing.Color.Black;
            this.key0.MainHeight = 24;
            this.key0.MainText = "0";
            this.key0.MainWidth = 56;
            this.key0.Name = "key0";
            this.key0.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D0,
        System.Windows.Forms.Keys.NumPad0};
            this.key0.Tag = "6782";
            this.key0.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key0.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key9
            // 
            this.key9.AccessibleDescription = null;
            this.key9.AccessibleName = null;
            resources.ApplyResources (this.key9, "key9");
            this.key9.BackgroundImage = null;
            this.key9.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key9.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.key9.FGWidth = 56;
            this.key9.FText = "√x̅";
            this.key9.GText = "x²";
            this.key9.HText = "R↑";
            this.key9.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key9.MainBackColor = System.Drawing.Color.LightYellow;
            this.key9.MainForeColor = System.Drawing.Color.Black;
            this.key9.MainHeight = 24;
            this.key9.MainText = "9";
            this.key9.MainWidth = 56;
            this.key9.Name = "key9";
            this.key9.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D9,
        System.Windows.Forms.Keys.NumPad9};
            this.key9.Tag = "6754";
            this.key9.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key9.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key3
            // 
            this.key3.AccessibleDescription = null;
            this.key3.AccessibleName = null;
            resources.ApplyResources (this.key3, "key3");
            this.key3.BackgroundImage = null;
            this.key3.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key3.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key3.FGWidth = 56;
            this.key3.FText = "H⇄";
            this.key3.GText = "H.MS";
            this.key3.HText = "REG";
            this.key3.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key3.MainBackColor = System.Drawing.Color.LightYellow;
            this.key3.MainForeColor = System.Drawing.Color.Black;
            this.key3.MainHeight = 24;
            this.key3.MainText = "3";
            this.key3.MainWidth = 56;
            this.key3.Name = "key3";
            this.key3.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D3,
        System.Windows.Forms.Keys.NumPad3};
            this.key3.Tag = "6774";
            this.key3.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key3.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key2
            // 
            this.key2.AccessibleDescription = null;
            this.key2.AccessibleName = null;
            resources.ApplyResources (this.key2, "key2");
            this.key2.BackgroundImage = null;
            this.key2.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key2.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key2.FGWidth = 56;
            this.key2.FText = "D⇄";
            this.key2.GText = "R";
            this.key2.HText = "π";
            this.key2.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key2.MainBackColor = System.Drawing.Color.LightYellow;
            this.key2.MainForeColor = System.Drawing.Color.Black;
            this.key2.MainHeight = 24;
            this.key2.MainText = "2";
            this.key2.MainWidth = 56;
            this.key2.Name = "key2";
            this.key2.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D2,
        System.Windows.Forms.Keys.NumPad2};
            this.key2.Tag = "6773";
            this.key2.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key2.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key1
            // 
            this.key1.AccessibleDescription = null;
            this.key1.AccessibleName = null;
            resources.ApplyResources (this.key1, "key1");
            this.key1.BackgroundImage = null;
            this.key1.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key1.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key1.FGWidth = 56;
            this.key1.FText = "R⇄";
            this.key1.GText = "P";
            this.key1.HText = "PAUSE";
            this.key1.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key1.MainBackColor = System.Drawing.Color.LightYellow;
            this.key1.MainForeColor = System.Drawing.Color.Black;
            this.key1.MainHeight = 24;
            this.key1.MainText = "1";
            this.key1.MainWidth = 56;
            this.key1.Name = "key1";
            this.key1.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D1,
        System.Windows.Forms.Keys.NumPad1};
            this.key1.Tag = "6772";
            this.key1.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key1.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key6
            // 
            this.key6.AccessibleDescription = null;
            this.key6.AccessibleName = null;
            resources.ApplyResources (this.key6, "key6");
            this.key6.BackgroundImage = null;
            this.key6.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key6.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key6.FGWidth = 56;
            this.key6.FText = "TAN";
            this.key6.GText = "⁻¹";
            this.key6.HText = "ABS";
            this.key6.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key6.MainBackColor = System.Drawing.Color.LightYellow;
            this.key6.MainForeColor = System.Drawing.Color.Black;
            this.key6.MainHeight = 24;
            this.key6.MainText = "6";
            this.key6.MainWidth = 56;
            this.key6.Name = "key6";
            this.key6.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D6,
        System.Windows.Forms.Keys.NumPad6};
            this.key6.Tag = "6764";
            this.key6.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key6.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key5
            // 
            this.key5.AccessibleDescription = null;
            this.key5.AccessibleName = null;
            resources.ApplyResources (this.key5, "key5");
            this.key5.BackgroundImage = null;
            this.key5.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key5.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key5.FGWidth = 56;
            this.key5.FText = "COS";
            this.key5.GText = "⁻¹";
            this.key5.HText = "y ̽";
            this.key5.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key5.MainBackColor = System.Drawing.Color.LightYellow;
            this.key5.MainForeColor = System.Drawing.Color.Black;
            this.key5.MainHeight = 24;
            this.key5.MainText = "5";
            this.key5.MainWidth = 56;
            this.key5.Name = "key5";
            this.key5.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D5,
        System.Windows.Forms.Keys.NumPad5};
            this.key5.Tag = "6763";
            this.key5.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key5.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key4
            // 
            this.key4.AccessibleDescription = null;
            this.key4.AccessibleName = null;
            resources.ApplyResources (this.key4, "key4");
            this.key4.BackgroundImage = null;
            this.key4.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key4.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
            this.key4.FGWidth = 56;
            this.key4.FText = "SIN";
            this.key4.GText = "⁻¹";
            this.key4.HText = "1/x";
            this.key4.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key4.MainBackColor = System.Drawing.Color.LightYellow;
            this.key4.MainForeColor = System.Drawing.Color.Black;
            this.key4.MainHeight = 24;
            this.key4.MainText = "4";
            this.key4.MainWidth = 56;
            this.key4.Name = "key4";
            this.key4.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D4,
        System.Windows.Forms.Keys.NumPad4};
            this.key4.Tag = "6762";
            this.key4.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key4.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // key7
            // 
            this.key7.AccessibleDescription = null;
            this.key7.AccessibleName = null;
            resources.ApplyResources (this.key7, "key7");
            this.key7.BackgroundImage = null;
            this.key7.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.key7.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.key7.FGWidth = 56;
            this.key7.FText = "LN";
            this.key7.GText = "e ̽";
            this.key7.HText = "x⇆y";
            this.key7.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.key7.MainBackColor = System.Drawing.Color.LightYellow;
            this.key7.MainForeColor = System.Drawing.Color.Black;
            this.key7.MainHeight = 24;
            this.key7.MainText = "7";
            this.key7.MainWidth = 56;
            this.key7.Name = "key7";
            this.key7.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.D7,
        System.Windows.Forms.Keys.NumPad7};
            this.key7.Tag = "6752";
            this.key7.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.key7.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyMinus
            // 
            this.keyMinus.AccessibleDescription = null;
            this.keyMinus.AccessibleName = null;
            resources.ApplyResources (this.keyMinus, "keyMinus");
            this.keyMinus.BackgroundImage = null;
            this.keyMinus.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyMinus.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.keyMinus.FGWidth = 48;
            this.keyMinus.FText = "x=0";
            this.keyMinus.GText = "x=y";
            this.keyMinus.HText = "SF";
            this.keyMinus.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyMinus.MainBackColor = System.Drawing.Color.Olive;
            this.keyMinus.MainForeColor = System.Drawing.Color.White;
            this.keyMinus.MainHeight = 24;
            this.keyMinus.MainText = "–";
            this.keyMinus.MainWidth = 32;
            this.keyMinus.Name = "keyMinus";
            this.keyMinus.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Subtract};
            this.keyMinus.Tag = "6751";
            this.keyMinus.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyMinus.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyDiv
            // 
            this.keyDiv.AccessibleDescription = null;
            this.keyDiv.AccessibleName = null;
            resources.ApplyResources (this.keyDiv, "keyDiv");
            this.keyDiv.BackgroundImage = null;
            this.keyDiv.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyDiv.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.keyDiv.FGWidth = 48;
            this.keyDiv.FText = "x>0";
            this.keyDiv.GText = "x>y";
            this.keyDiv.HText = "N!";
            this.keyDiv.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyDiv.MainBackColor = System.Drawing.Color.Olive;
            this.keyDiv.MainForeColor = System.Drawing.Color.White;
            this.keyDiv.MainHeight = 24;
            this.keyDiv.MainText = "÷";
            this.keyDiv.MainWidth = 32;
            this.keyDiv.Name = "keyDiv";
            this.keyDiv.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Divide};
            this.keyDiv.Tag = "6781";
            this.keyDiv.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyDiv.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyMult
            // 
            this.keyMult.AccessibleDescription = null;
            this.keyMult.AccessibleName = null;
            resources.ApplyResources (this.keyMult, "keyMult");
            this.keyMult.BackgroundImage = null;
            this.keyMult.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyMult.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.keyMult.FGWidth = 48;
            this.keyMult.FText = "x<0";
            this.keyMult.GText = "x≤y";
            this.keyMult.HText = "F?";
            this.keyMult.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyMult.MainBackColor = System.Drawing.Color.Olive;
            this.keyMult.MainForeColor = System.Drawing.Color.White;
            this.keyMult.MainHeight = 24;
            this.keyMult.MainText = "×";
            this.keyMult.MainWidth = 32;
            this.keyMult.Name = "keyMult";
            this.keyMult.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Multiply};
            this.keyMult.Tag = "6771";
            this.keyMult.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyMult.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // keyPlus
            // 
            this.keyPlus.AccessibleDescription = null;
            this.keyPlus.AccessibleName = null;
            resources.ApplyResources (this.keyPlus, "keyPlus");
            this.keyPlus.BackgroundImage = null;
            this.keyPlus.FGBackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.keyPlus.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
            this.keyPlus.FGWidth = 48;
            this.keyPlus.FText = "x≠0";
            this.keyPlus.GText = "x≠y";
            this.keyPlus.HText = "CF";
            this.keyPlus.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyPlus.MainBackColor = System.Drawing.Color.Olive;
            this.keyPlus.MainForeColor = System.Drawing.Color.White;
            this.keyPlus.MainHeight = 24;
            this.keyPlus.MainText = "+";
            this.keyPlus.MainWidth = 32;
            this.keyPlus.Name = "keyPlus";
            this.keyPlus.Shortcuts = new System.Windows.Forms.Keys [] {
        System.Windows.Forms.Keys.Add};
            this.keyPlus.Tag = "6761";
            this.keyPlus.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseDown);
            this.keyPlus.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent (this.Key_LeftMouseUp);
            // 
            // openFileDialog
            // 
            resources.ApplyResources (this.openFileDialog, "openFileDialog");
            // 
            // saveFileDialog
            // 
            resources.ApplyResources (this.saveFileDialog, "saveFileDialog");
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler (this.printDocument_PrintPage);
            // 
            // menuStrip
            // 
            this.menuStrip.AccessibleDescription = null;
            this.menuStrip.AccessibleName = null;
            resources.ApplyResources (this.menuStrip, "menuStrip");
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.BackgroundImage = null;
            this.menuStrip.Font = null;
            this.menuStrip.Items.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AccessibleDescription = null;
            this.fileToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.BackgroundImage = null;
            this.fileToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.AccessibleDescription = null;
            this.openToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.BackgroundImage = null;
            this.openToolStripMenuItem.Image = global::Mockingbird.HP.HP67.Properties.Resources.openHS;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.openToolStripMenuItem.Click += new System.EventHandler (this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.AccessibleDescription = null;
            this.saveToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.BackgroundImage = null;
            this.saveToolStripMenuItem.Image = global::Mockingbird.HP.HP67.Properties.Resources.saveHS;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.saveToolStripMenuItem.Click += new System.EventHandler (this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.AccessibleDescription = null;
            this.saveAsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.BackgroundImage = null;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.saveAsToolStripMenuItem.Click += new System.EventHandler (this.saveAsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.AccessibleDescription = null;
            this.printToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.BackgroundImage = null;
            this.printToolStripMenuItem.Image = global::Mockingbird.HP.HP67.Properties.Resources.PrintHS;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.printToolStripMenuItem.Click += new System.EventHandler (this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AccessibleDescription = null;
            this.exitToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.BackgroundImage = null;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.exitToolStripMenuItem.Click += new System.EventHandler (this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.AccessibleDescription = null;
            this.editToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.BackgroundImage = null;
            this.editToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem [] {
            this.editLabelsToolStripMenuItem,
            this.rtfToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // editLabelsToolStripMenuItem
            // 
            this.editLabelsToolStripMenuItem.AccessibleDescription = null;
            this.editLabelsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.editLabelsToolStripMenuItem, "editLabelsToolStripMenuItem");
            this.editLabelsToolStripMenuItem.BackgroundImage = null;
            this.editLabelsToolStripMenuItem.Name = "editLabelsToolStripMenuItem";
            this.editLabelsToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.editLabelsToolStripMenuItem.Click += new System.EventHandler (this.editLabelsToolStripMenuItem_Click);
            // 
            // rtfToolStripMenuItem
            // 
            this.rtfToolStripMenuItem.AccessibleDescription = null;
            this.rtfToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources (this.rtfToolStripMenuItem, "rtfToolStripMenuItem");
            this.rtfToolStripMenuItem.BackgroundImage = null;
            this.rtfToolStripMenuItem.Name = "rtfToolStripMenuItem";
            this.rtfToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.rtfToolStripMenuItem.Click += new System.EventHandler (this.rtfToolStripMenuItem_Click);
            // 
            // HP67
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources (this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.BackgroundImage = null;
            this.Controls.Add (this.keyPlus);
            this.Controls.Add (this.keyMult);
            this.Controls.Add (this.keyDiv);
            this.Controls.Add (this.keyMinus);
            this.Controls.Add (this.key7);
            this.Controls.Add (this.key4);
            this.Controls.Add (this.key5);
            this.Controls.Add (this.key6);
            this.Controls.Add (this.key1);
            this.Controls.Add (this.key2);
            this.Controls.Add (this.key3);
            this.Controls.Add (this.key9);
            this.Controls.Add (this.key0);
            this.Controls.Add (this.keyPeriod);
            this.Controls.Add (this.keyRS);
            this.Controls.Add (this.key8);
            this.Controls.Add (this.keyg);
            this.Controls.Add (this.keySTO);
            this.Controls.Add (this.keyRCL);
            this.Controls.Add (this.keyh);
            this.Controls.Add (this.keyCHS);
            this.Controls.Add (this.keyCLx);
            this.Controls.Add (this.keyEEX);
            this.Controls.Add (this.keyENTER);
            this.Controls.Add (this.keyB);
            this.Controls.Add (this.keyC);
            this.Controls.Add (this.keyD);
            this.Controls.Add (this.keyE);
            this.Controls.Add (this.keyΣ);
            this.Controls.Add (this.keyGTO);
            this.Controls.Add (this.keyDSP);
            this.Controls.Add (this.keyi);
            this.Controls.Add (this.keySST);
            this.Controls.Add (this.keyf);
            this.Controls.Add (this.keyA);
            this.Controls.Add (this.toggleWprgmRun);
            this.Controls.Add (this.toggleOffOn);
            this.Controls.Add (this.display);
            this.Controls.Add (this.cardSlot);
            this.Controls.Add (this.menuStrip);
            this.Font = null;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "HP67";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler (this.Calculator_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler (this.Calculator_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler (this.Calculator_KeyDown);
            this.menuStrip.ResumeLayout (false);
            this.menuStrip.PerformLayout ();
            this.ResumeLayout (false);
            this.PerformLayout ();

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
                Application.Run (new HP67 (arguments));
            }
            catch (Shutdown)
            {
            }
        }

    }
}