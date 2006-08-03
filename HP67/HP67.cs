using Mockingbird.HP.Calculator_Library;
using Mockingbird.HP.Class_Library;
using Mockingbird.HP.Control_Library;
using Mockingbird.HP.Parser;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mockingbird.HP.HP67
{
	/// <summary>
	/// The user interface for the HP-67 calculator.
	/// </summary>
	public class HP67 : CardCalculator
	{

		#region Private Data

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
		
		public HP67 (string [] arguments) : base (arguments, CalculatorModel.HP67)
		{
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HP67));
			this.keyA = new Mockingbird.HP.Control_Library.Key();
			this.keyf = new Mockingbird.HP.Control_Library.Key();
			this.keySST = new Mockingbird.HP.Control_Library.Key();
			this.keyi = new Mockingbird.HP.Control_Library.Key();
			this.keyDSP = new Mockingbird.HP.Control_Library.Key();
			this.keyGTO = new Mockingbird.HP.Control_Library.Key();
			this.keyΣ = new Mockingbird.HP.Control_Library.Key();
			this.keyE = new Mockingbird.HP.Control_Library.Key();
			this.keyD = new Mockingbird.HP.Control_Library.Key();
			this.keyC = new Mockingbird.HP.Control_Library.Key();
			this.keyB = new Mockingbird.HP.Control_Library.Key();
			this.keyENTER = new Mockingbird.HP.Control_Library.Key();
			this.keyEEX = new Mockingbird.HP.Control_Library.Key();
			this.keyCLx = new Mockingbird.HP.Control_Library.Key();
			this.keyCHS = new Mockingbird.HP.Control_Library.Key();
			this.keyh = new Mockingbird.HP.Control_Library.Key();
			this.keyRCL = new Mockingbird.HP.Control_Library.Key();
			this.keySTO = new Mockingbird.HP.Control_Library.Key();
			this.keyg = new Mockingbird.HP.Control_Library.Key();
			this.key8 = new Mockingbird.HP.Control_Library.Key();
			this.keyRS = new Mockingbird.HP.Control_Library.Key();
			this.keyPeriod = new Mockingbird.HP.Control_Library.Key();
			this.key0 = new Mockingbird.HP.Control_Library.Key();
			this.key9 = new Mockingbird.HP.Control_Library.Key();
			this.key3 = new Mockingbird.HP.Control_Library.Key();
			this.key2 = new Mockingbird.HP.Control_Library.Key();
			this.key1 = new Mockingbird.HP.Control_Library.Key();
			this.key6 = new Mockingbird.HP.Control_Library.Key();
			this.key5 = new Mockingbird.HP.Control_Library.Key();
			this.key4 = new Mockingbird.HP.Control_Library.Key();
			this.key7 = new Mockingbird.HP.Control_Library.Key();
			this.keyMinus = new Mockingbird.HP.Control_Library.Key();
			this.keyDiv = new Mockingbird.HP.Control_Library.Key();
			this.keyMult = new Mockingbird.HP.Control_Library.Key();
			this.keyPlus = new Mockingbird.HP.Control_Library.Key();
			this.SuspendLayout();
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
			this.keyA.Tag = "6711";
			this.keyA.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyA.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyf
			// 
			this.keyf.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyf.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyf.Tag = "6731";
			this.keyf.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyf.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keySST
			// 
			this.keySST.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySST.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keySST.Tag = "6725";
			this.keySST.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keySST.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyi
			// 
			this.keyi.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyi.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyi.Tag = "6724";
			this.keyi.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyi.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyDSP
			// 
			this.keyDSP.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyDSP.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyDSP.Tag = "6723";
			this.keyDSP.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyDSP.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyGTO
			// 
			this.keyGTO.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyGTO.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyGTO.Tag = "6722";
			this.keyGTO.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyGTO.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyΣ
			// 
			this.keyΣ.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyΣ.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyΣ.Tag = "6721";
			this.keyΣ.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyΣ.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
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
			this.keyE.Tag = "6715";
			this.keyE.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyE.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
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
			this.keyD.Tag = "6714";
			this.keyD.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyD.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
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
			this.keyC.Tag = "6713";
			this.keyC.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyC.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
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
			this.keyB.Tag = "6712";
			this.keyB.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyB.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyENTER
			// 
			this.keyENTER.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyENTER.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.keyENTER.Tag = "6741";
			this.keyENTER.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyENTER.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyEEX
			// 
			this.keyEEX.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyEEX.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyEEX.Tag = "6743";
			this.keyEEX.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyEEX.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyCLx
			// 
			this.keyCLx.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyCLx.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyCLx.Tag = "6744";
			this.keyCLx.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyCLx.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyCHS
			// 
			this.keyCHS.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyCHS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyCHS.Tag = "6742";
			this.keyCHS.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyCHS.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyh
			// 
			this.keyh.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyh.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyh.Tag = "6735";
			this.keyh.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyh.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyRCL
			// 
			this.keyRCL.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRCL.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyRCL.Tag = "6734";
			this.keyRCL.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyRCL.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keySTO
			// 
			this.keySTO.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keySTO.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keySTO.Tag = "6733";
			this.keySTO.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keySTO.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyg
			// 
			this.keyg.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyg.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.keyg.Tag = "6732";
			this.keyg.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyg.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key8
			// 
			this.key8.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key8.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.key8.Tag = "6753";
			this.key8.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key8.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyRS
			// 
			this.keyRS.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyRS.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.keyRS.Tag = "6784";
			this.keyRS.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyRS.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyPeriod
			// 
			this.keyPeriod.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPeriod.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.keyPeriod.Tag = "6783";
			this.keyPeriod.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyPeriod.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key0
			// 
			this.key0.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key0.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.key0.Tag = "6782";
			this.key0.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key0.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key9
			// 
			this.key9.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key9.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.key9.Tag = "6754";
			this.key9.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key9.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key3
			// 
			this.key3.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key3.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.key3.Tag = "6774";
			this.key3.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key3.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key2
			// 
			this.key2.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key2.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.key2.Tag = "6773";
			this.key2.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key2.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key1
			// 
			this.key1.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key1.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.key1.Tag = "6772";
			this.key1.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key1.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key6
			// 
			this.key6.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key6.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.key6.Tag = "6764";
			this.key6.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key6.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key5
			// 
			this.key5.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key5.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.key5.Tag = "6763";
			this.key5.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key5.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key4
			// 
			this.key4.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key4.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
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
			this.key4.Tag = "6762";
			this.key4.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key4.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// key7
			// 
			this.key7.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.key7.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.key7.Tag = "6752";
			this.key7.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.key7.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyMinus
			// 
			this.keyMinus.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyMinus.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.keyMinus.Tag = "6751";
			this.keyMinus.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyMinus.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyDiv
			// 
			this.keyDiv.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyDiv.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.keyDiv.Tag = "6781";
			this.keyDiv.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyDiv.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyMult
			// 
			this.keyMult.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyMult.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.keyMult.Tag = "6771";
			this.keyMult.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyMult.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// keyPlus
			// 
			this.keyPlus.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyPlus.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Justified;
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
			this.keyPlus.Tag = "6761";
			this.keyPlus.LeftMouseUp += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseUp);
			this.keyPlus.LeftMouseDown += new Mockingbird.HP.Control_Library.Key.KeystrokeEvent(this.Key_LeftMouseDown);
			// 
			// HP67
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.ClientSize = new System.Drawing.Size(304, 590);
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
			this.MaximumSize = new System.Drawing.Size(312, 624);
			this.MinimumSize = new System.Drawing.Size(312, 624);
			this.Name = "HP67";
			this.Text = "HP67";
			this.ResumeLayout(false);
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