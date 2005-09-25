using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HP67
{
	/// <summary>
	/// Summary description for HP67.
	/// </summary>
	public class HP67 : System.Windows.Forms.Form
	{
		private HP67_Control_Library.Display display1;
		private HP67_Control_Library.CardSlot cardSlot1;
		private HP67_Control_Library.Toggle toggle1;
		private HP67_Control_Library.Toggle toggle2;
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
		private HP67_Control_Library.Key keyDot;
		private HP67_Control_Library.Key key0;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HP67()
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
		private void InitializeComponent()
		{
			this.display1 = new HP67_Control_Library.Display();
			this.cardSlot1 = new HP67_Control_Library.CardSlot();
			this.toggle1 = new HP67_Control_Library.Toggle();
			this.toggle2 = new HP67_Control_Library.Toggle();
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
			this.keyDot = new HP67_Control_Library.Key();
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
			this.SuspendLayout();
			// 
			// display1
			// 
			this.display1.Font = new System.Drawing.Font("Quartz", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.display1.ForeColor = System.Drawing.Color.Red;
			this.display1.Location = new System.Drawing.Point(8, 8);
			this.display1.Name = "display1";
			this.display1.Size = new System.Drawing.Size(288, 40);
			this.display1.TabIndex = 0;
			this.display1.Value = 0;
			// 
			// cardSlot1
			// 
			this.cardSlot1.Location = new System.Drawing.Point(8, 80);
			this.cardSlot1.Margin = 8;
			this.cardSlot1.Name = "cardSlot1";
			this.cardSlot1.RichText = false;
			this.cardSlot1.Size = new System.Drawing.Size(288, 50);
			this.cardSlot1.State = HP67_Control_Library.CardSlotState.Unloaded;
			this.cardSlot1.TabIndex = 1;
			this.cardSlot1.TextBoxWidth = 48;
			this.cardSlot1.Title = "TITLE";
			// 
			// toggle1
			// 
			this.toggle1.LeftText = "OFF";
			this.toggle1.LeftWidth = 30;
			this.toggle1.Location = new System.Drawing.Point(8, 56);
			this.toggle1.MainWidth = 50;
			this.toggle1.Name = "toggle1";
			this.toggle1.RightText = "ON";
			this.toggle1.RightWidth = 30;
			this.toggle1.Size = new System.Drawing.Size(110, 16);
			this.toggle1.TabIndex = 2;
			// 
			// toggle2
			// 
			this.toggle2.LeftText = "W/PRGM";
			this.toggle2.LeftWidth = 60;
			this.toggle2.Location = new System.Drawing.Point(160, 56);
			this.toggle2.MainWidth = 50;
			this.toggle2.Name = "toggle2";
			this.toggle2.RightText = "RUN";
			this.toggle2.RightWidth = 30;
			this.toggle2.Size = new System.Drawing.Size(140, 16);
			this.toggle2.TabIndex = 3;
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
			this.keyA.Size = new System.Drawing.Size(48, 51);
			this.keyA.TabIndex = 1;
			this.keyA.Tag = "11";
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
			this.keyf.Size = new System.Drawing.Size(48, 51);
			this.keyf.TabIndex = 11;
			this.keyf.Tag = "31";
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
			this.keySST.Size = new System.Drawing.Size(48, 51);
			this.keySST.TabIndex = 10;
			this.keySST.Tag = "25";
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
			this.keyi.Size = new System.Drawing.Size(48, 51);
			this.keyi.TabIndex = 9;
			this.keyi.Tag = "24";
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
			this.keyDSP.Size = new System.Drawing.Size(48, 51);
			this.keyDSP.TabIndex = 8;
			this.keyDSP.Tag = "23";
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
			this.keyGTO.Size = new System.Drawing.Size(48, 51);
			this.keyGTO.TabIndex = 7;
			this.keyGTO.Tag = "22";
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
			this.keyΣ.Size = new System.Drawing.Size(48, 51);
			this.keyΣ.TabIndex = 6;
			this.keyΣ.Tag = "21";
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
			this.keyE.Size = new System.Drawing.Size(48, 51);
			this.keyE.TabIndex = 5;
			this.keyE.Tag = "15";
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
			this.keyD.Size = new System.Drawing.Size(48, 51);
			this.keyD.TabIndex = 4;
			this.keyD.Tag = "14";
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
			this.keyC.Size = new System.Drawing.Size(48, 51);
			this.keyC.TabIndex = 3;
			this.keyC.Tag = "13";
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
			this.keyB.Size = new System.Drawing.Size(48, 51);
			this.keyB.TabIndex = 2;
			this.keyB.Tag = "12";
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
			this.keyENTER.Size = new System.Drawing.Size(120, 51);
			this.keyENTER.TabIndex = 16;
			this.keyENTER.Tag = "41";
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
			this.keyEEX.Size = new System.Drawing.Size(48, 51);
			this.keyEEX.TabIndex = 18;
			this.keyEEX.Tag = "43";
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
			this.keyCLx.Size = new System.Drawing.Size(64, 51);
			this.keyCLx.TabIndex = 19;
			this.keyCLx.Tag = "44";
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
			this.keyCHS.Size = new System.Drawing.Size(48, 51);
			this.keyCHS.TabIndex = 17;
			this.keyCHS.Tag = "42";
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
			this.keyh.Size = new System.Drawing.Size(48, 51);
			this.keyh.TabIndex = 15;
			this.keyh.Tag = "35";
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
			this.keyRCL.Size = new System.Drawing.Size(48, 51);
			this.keyRCL.TabIndex = 14;
			this.keyRCL.Tag = "34";
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
			this.keySTO.Size = new System.Drawing.Size(48, 51);
			this.keySTO.TabIndex = 13;
			this.keySTO.Tag = "33";
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
			this.keyg.Size = new System.Drawing.Size(48, 51);
			this.keyg.TabIndex = 12;
			this.keyg.Tag = "32";
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
			this.key8.Size = new System.Drawing.Size(56, 51);
			this.key8.TabIndex = 22;
			this.key8.Tag = "53";
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
			this.keyRS.Size = new System.Drawing.Size(56, 51);
			this.keyRS.TabIndex = 35;
			this.keyRS.Tag = "84";
			// 
			// keyDot
			// 
			this.keyDot.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.keyDot.FGTextAlign = HP67_Control_Library.TextAlign.Justified;
			this.keyDot.FGWidth = 72;
			this.keyDot.FText = "INT";
			this.keyDot.GText = "FRAC";
			this.keyDot.HText = "H.MS+";
			this.keyDot.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.keyDot.Location = new System.Drawing.Point(144, 528);
			this.keyDot.MainBackColor = System.Drawing.Color.LightYellow;
			this.keyDot.MainForeColor = System.Drawing.Color.Black;
			this.keyDot.MainText = " ・";
			this.keyDot.MainWidth = 56;
			this.keyDot.Name = "keyDot";
			this.keyDot.Size = new System.Drawing.Size(72, 51);
			this.keyDot.TabIndex = 34;
			this.keyDot.Tag = "83";
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
			this.key0.Size = new System.Drawing.Size(56, 51);
			this.key0.TabIndex = 33;
			this.key0.Tag = "82";
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
			this.key9.Size = new System.Drawing.Size(56, 51);
			this.key9.TabIndex = 23;
			this.key9.Tag = "54";
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
			this.key3.Size = new System.Drawing.Size(56, 51);
			this.key3.TabIndex = 31;
			this.key3.Tag = "74";
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
			this.key2.Size = new System.Drawing.Size(56, 51);
			this.key2.TabIndex = 30;
			this.key2.Tag = "73";
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
			this.key1.Size = new System.Drawing.Size(56, 51);
			this.key1.TabIndex = 29;
			this.key1.Tag = "72";
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
			this.key6.Size = new System.Drawing.Size(56, 51);
			this.key6.TabIndex = 27;
			this.key6.Tag = "64";
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
			this.key5.Size = new System.Drawing.Size(56, 51);
			this.key5.TabIndex = 26;
			this.key5.Tag = "63";
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
			this.key4.Size = new System.Drawing.Size(56, 51);
			this.key4.TabIndex = 25;
			this.key4.Tag = "62";
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
			this.key7.Size = new System.Drawing.Size(56, 51);
			this.key7.TabIndex = 21;
			this.key7.Tag = "52";
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
			this.keyMinus.Size = new System.Drawing.Size(48, 51);
			this.keyMinus.TabIndex = 20;
			this.keyMinus.Tag = "51";
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
			this.keyDiv.Size = new System.Drawing.Size(48, 51);
			this.keyDiv.TabIndex = 32;
			this.keyDiv.Tag = "81";
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
			this.keyMult.Size = new System.Drawing.Size(48, 51);
			this.keyMult.TabIndex = 28;
			this.keyMult.Tag = "71";
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
			this.keyPlus.Size = new System.Drawing.Size(48, 51);
			this.keyPlus.TabIndex = 24;
			this.keyPlus.Tag = "61";
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
			this.Controls.Add(this.keyDot);
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
			this.Controls.Add(this.toggle2);
			this.Controls.Add(this.toggle1);
			this.Controls.Add(this.cardSlot1);
			this.Controls.Add(this.display1);
			this.Name = "HP67";
			this.Text = "HP67";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new HP67());
		}
	}
}
