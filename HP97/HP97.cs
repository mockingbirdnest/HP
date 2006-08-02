using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HP97
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class HP97 : System.Windows.Forms.Form
	{
		private HP67_Control_Library.Printer printer1;
		private System.Windows.Forms.Panel panel1;
		private HP67_Control_Library.Toggle toggle1;
		private HP67_Control_Library.Toggle toggle2;
		private HP67_Control_Library.Toggle toggle3;
		private System.Windows.Forms.Label label1;
		private HP67_Control_Library.Key key1;
		private HP67_Control_Library.Key key2;
		private HP67_Control_Library.Key key3;
		private HP67_Control_Library.Key key4;
		private HP67_Control_Library.Key key5;
		private HP67_Control_Library.Key key7;
		private System.Windows.Forms.GroupBox groupBox1;
		private HP67_Control_Library.CardSlot cardSlot1;
		private HP67_Control_Library.Key key6;
		private HP67_Control_Library.Key key8;
		private HP67_Control_Library.Key key9;
		private HP67_Control_Library.Key key10;
		private HP67_Control_Library.Key key11;
		private HP67_Control_Library.Key key12;
		private HP67_Control_Library.Key key13;
		private HP67_Control_Library.Key key14;
		private HP67_Control_Library.Key key15;
		private HP67_Control_Library.Key key16;
		private HP67_Control_Library.Key key17;
		private HP67_Control_Library.Key key18;
		private HP67_Control_Library.Key key19;
		private HP67_Control_Library.Key key20;
		private HP67_Control_Library.Key key21;
		private HP67_Control_Library.Key key22;
		private HP67_Control_Library.Key key23;
		private HP67_Control_Library.Key key24;
		private HP67_Control_Library.Key key25;
		private HP67_Control_Library.Key key26;
		private HP67_Control_Library.Key key27;
		private HP67_Control_Library.Key key28;
		private HP67_Control_Library.Key key29;
		private HP67_Control_Library.Key key30;
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
			this.printer1 = new HP67_Control_Library.Printer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.key25 = new HP67_Control_Library.Key();
			this.key26 = new HP67_Control_Library.Key();
			this.key27 = new HP67_Control_Library.Key();
			this.key28 = new HP67_Control_Library.Key();
			this.key29 = new HP67_Control_Library.Key();
			this.key30 = new HP67_Control_Library.Key();
			this.key19 = new HP67_Control_Library.Key();
			this.key20 = new HP67_Control_Library.Key();
			this.key21 = new HP67_Control_Library.Key();
			this.key22 = new HP67_Control_Library.Key();
			this.key23 = new HP67_Control_Library.Key();
			this.key24 = new HP67_Control_Library.Key();
			this.key13 = new HP67_Control_Library.Key();
			this.key14 = new HP67_Control_Library.Key();
			this.key15 = new HP67_Control_Library.Key();
			this.key16 = new HP67_Control_Library.Key();
			this.key17 = new HP67_Control_Library.Key();
			this.key18 = new HP67_Control_Library.Key();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cardSlot1 = new HP67_Control_Library.CardSlot();
			this.toggle1 = new HP67_Control_Library.Toggle();
			this.key7 = new HP67_Control_Library.Key();
			this.toggle2 = new HP67_Control_Library.Toggle();
			this.toggle3 = new HP67_Control_Library.Toggle();
			this.key2 = new HP67_Control_Library.Key();
			this.key1 = new HP67_Control_Library.Key();
			this.label1 = new System.Windows.Forms.Label();
			this.key4 = new HP67_Control_Library.Key();
			this.key5 = new HP67_Control_Library.Key();
			this.key3 = new HP67_Control_Library.Key();
			this.key10 = new HP67_Control_Library.Key();
			this.key8 = new HP67_Control_Library.Key();
			this.key11 = new HP67_Control_Library.Key();
			this.key12 = new HP67_Control_Library.Key();
			this.key6 = new HP67_Control_Library.Key();
			this.key9 = new HP67_Control_Library.Key();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// printer1
			// 
			this.printer1.Location = new System.Drawing.Point(464, 0);
			this.printer1.Name = "printer1";
			this.printer1.Size = new System.Drawing.Size(304, 288);
			this.printer1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.panel1.Controls.Add(this.key25);
			this.panel1.Controls.Add(this.key26);
			this.panel1.Controls.Add(this.key27);
			this.panel1.Controls.Add(this.key28);
			this.panel1.Controls.Add(this.key29);
			this.panel1.Controls.Add(this.key30);
			this.panel1.Controls.Add(this.key19);
			this.panel1.Controls.Add(this.key20);
			this.panel1.Controls.Add(this.key21);
			this.panel1.Controls.Add(this.key22);
			this.panel1.Controls.Add(this.key23);
			this.panel1.Controls.Add(this.key24);
			this.panel1.Controls.Add(this.key13);
			this.panel1.Controls.Add(this.key14);
			this.panel1.Controls.Add(this.key15);
			this.panel1.Controls.Add(this.key16);
			this.panel1.Controls.Add(this.key17);
			this.panel1.Controls.Add(this.key18);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.key10);
			this.panel1.Controls.Add(this.key8);
			this.panel1.Controls.Add(this.key11);
			this.panel1.Controls.Add(this.key12);
			this.panel1.Controls.Add(this.key6);
			this.panel1.Controls.Add(this.key9);
			this.panel1.Location = new System.Drawing.Point(8, 288);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1096, 424);
			this.panel1.TabIndex = 2;
			// 
			// key25
			// 
			this.key25.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key25.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key25.FGWidth = 48;
			this.key25.FText = "d";
			this.key25.GText = "";
			this.key25.HText = "";
			this.key25.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key25.Location = new System.Drawing.Point(200, 368);
			this.key25.MainBackColor = System.Drawing.Color.Olive;
			this.key25.MainForeColor = System.Drawing.Color.White;
			this.key25.MainText = "√x̅";
			this.key25.MainWidth = 48;
			this.key25.Name = "key25";
			this.key25.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key25.Size = new System.Drawing.Size(48, 51);
			this.key25.TabIndex = 34;
			// 
			// key26
			// 
			this.key26.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key26.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key26.FGWidth = 48;
			this.key26.FText = "b";
			this.key26.GText = "";
			this.key26.HText = "";
			this.key26.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key26.Location = new System.Drawing.Point(88, 368);
			this.key26.MainBackColor = System.Drawing.Color.Olive;
			this.key26.MainForeColor = System.Drawing.Color.White;
			this.key26.MainText = "1/x";
			this.key26.MainWidth = 48;
			this.key26.Name = "key26";
			this.key26.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key26.Size = new System.Drawing.Size(48, 51);
			this.key26.TabIndex = 32;
			// 
			// key27
			// 
			this.key27.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key27.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key27.FGWidth = 48;
			this.key27.FText = "";
			this.key27.GText = "";
			this.key27.HText = "";
			this.key27.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key27.Location = new System.Drawing.Point(312, 368);
			this.key27.MainBackColor = System.Drawing.Color.Olive;
			this.key27.MainForeColor = System.Drawing.Color.White;
			this.key27.MainText = "f";
			this.key27.MainWidth = 48;
			this.key27.Name = "key27";
			this.key27.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key27.Size = new System.Drawing.Size(48, 51);
			this.key27.TabIndex = 35;
			// 
			// key28
			// 
			this.key28.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key28.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key28.FGWidth = 48;
			this.key28.FText = "c";
			this.key28.GText = "";
			this.key28.HText = "";
			this.key28.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key28.Location = new System.Drawing.Point(144, 368);
			this.key28.MainBackColor = System.Drawing.Color.Olive;
			this.key28.MainForeColor = System.Drawing.Color.White;
			this.key28.MainText = "x²";
			this.key28.MainWidth = 48;
			this.key28.Name = "key28";
			this.key28.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key28.Size = new System.Drawing.Size(48, 51);
			this.key28.TabIndex = 33;
			// 
			// key29
			// 
			this.key29.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key29.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key29.FGWidth = 48;
			this.key29.FText = "e";
			this.key29.GText = "";
			this.key29.HText = "";
			this.key29.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key29.Location = new System.Drawing.Point(256, 368);
			this.key29.MainBackColor = System.Drawing.Color.Olive;
			this.key29.MainForeColor = System.Drawing.Color.White;
			this.key29.MainText = "%";
			this.key29.MainWidth = 48;
			this.key29.Name = "key29";
			this.key29.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key29.Size = new System.Drawing.Size(48, 51);
			this.key29.TabIndex = 36;
			// 
			// key30
			// 
			this.key30.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key30.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key30.FGWidth = 48;
			this.key30.FText = "a";
			this.key30.GText = "";
			this.key30.HText = "";
			this.key30.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key30.Location = new System.Drawing.Point(32, 368);
			this.key30.MainBackColor = System.Drawing.Color.Olive;
			this.key30.MainForeColor = System.Drawing.Color.White;
			this.key30.MainText = "R/S";
			this.key30.MainWidth = 48;
			this.key30.Name = "key30";
			this.key30.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key30.Size = new System.Drawing.Size(48, 51);
			this.key30.TabIndex = 31;
			// 
			// key19
			// 
			this.key19.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key19.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key19.FGWidth = 48;
			this.key19.FText = "d";
			this.key19.GText = "";
			this.key19.HText = "";
			this.key19.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key19.Location = new System.Drawing.Point(200, 312);
			this.key19.MainBackColor = System.Drawing.Color.Olive;
			this.key19.MainForeColor = System.Drawing.Color.White;
			this.key19.MainText = "→R";
			this.key19.MainWidth = 48;
			this.key19.Name = "key19";
			this.key19.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key19.Size = new System.Drawing.Size(48, 51);
			this.key19.TabIndex = 28;
			// 
			// key20
			// 
			this.key20.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key20.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key20.FGWidth = 48;
			this.key20.FText = "b";
			this.key20.GText = "";
			this.key20.HText = "";
			this.key20.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key20.Location = new System.Drawing.Point(88, 312);
			this.key20.MainBackColor = System.Drawing.Color.Olive;
			this.key20.MainForeColor = System.Drawing.Color.White;
			this.key20.MainText = "COS";
			this.key20.MainWidth = 48;
			this.key20.Name = "key20";
			this.key20.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key20.Size = new System.Drawing.Size(48, 51);
			this.key20.TabIndex = 26;
			// 
			// key21
			// 
			this.key21.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key21.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key21.FGWidth = 48;
			this.key21.FText = "";
			this.key21.GText = "";
			this.key21.HText = "";
			this.key21.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key21.Location = new System.Drawing.Point(312, 312);
			this.key21.MainBackColor = System.Drawing.Color.Olive;
			this.key21.MainForeColor = System.Drawing.Color.White;
			this.key21.MainText = "I";
			this.key21.MainWidth = 48;
			this.key21.Name = "key21";
			this.key21.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key21.Size = new System.Drawing.Size(48, 51);
			this.key21.TabIndex = 29;
			// 
			// key22
			// 
			this.key22.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key22.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key22.FGWidth = 48;
			this.key22.FText = "c";
			this.key22.GText = "";
			this.key22.HText = "";
			this.key22.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key22.Location = new System.Drawing.Point(144, 312);
			this.key22.MainBackColor = System.Drawing.Color.Olive;
			this.key22.MainForeColor = System.Drawing.Color.White;
			this.key22.MainText = "TAN";
			this.key22.MainWidth = 48;
			this.key22.Name = "key22";
			this.key22.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key22.Size = new System.Drawing.Size(48, 51);
			this.key22.TabIndex = 27;
			// 
			// key23
			// 
			this.key23.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key23.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key23.FGWidth = 48;
			this.key23.FText = "e";
			this.key23.GText = "";
			this.key23.HText = "";
			this.key23.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key23.Location = new System.Drawing.Point(256, 312);
			this.key23.MainBackColor = System.Drawing.Color.Olive;
			this.key23.MainForeColor = System.Drawing.Color.White;
			this.key23.MainText = "(i)";
			this.key23.MainWidth = 48;
			this.key23.Name = "key23";
			this.key23.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key23.Size = new System.Drawing.Size(48, 51);
			this.key23.TabIndex = 30;
			// 
			// key24
			// 
			this.key24.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key24.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key24.FGWidth = 48;
			this.key24.FText = "a";
			this.key24.GText = "";
			this.key24.HText = "";
			this.key24.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key24.Location = new System.Drawing.Point(32, 312);
			this.key24.MainBackColor = System.Drawing.Color.Olive;
			this.key24.MainForeColor = System.Drawing.Color.White;
			this.key24.MainText = "SIN";
			this.key24.MainWidth = 48;
			this.key24.Name = "key24";
			this.key24.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key24.Size = new System.Drawing.Size(48, 51);
			this.key24.TabIndex = 25;
			// 
			// key13
			// 
			this.key13.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key13.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key13.FGWidth = 48;
			this.key13.FText = "d";
			this.key13.GText = "";
			this.key13.HText = "";
			this.key13.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key13.Location = new System.Drawing.Point(200, 256);
			this.key13.MainBackColor = System.Drawing.Color.Olive;
			this.key13.MainForeColor = System.Drawing.Color.White;
			this.key13.MainText = "→P";
			this.key13.MainWidth = 48;
			this.key13.Name = "key13";
			this.key13.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key13.Size = new System.Drawing.Size(48, 51);
			this.key13.TabIndex = 22;
			// 
			// key14
			// 
			this.key14.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key14.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key14.FGWidth = 48;
			this.key14.FText = "b";
			this.key14.GText = "";
			this.key14.HText = "";
			this.key14.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key14.Location = new System.Drawing.Point(88, 256);
			this.key14.MainBackColor = System.Drawing.Color.Olive;
			this.key14.MainForeColor = System.Drawing.Color.White;
			this.key14.MainText = "LN";
			this.key14.MainWidth = 48;
			this.key14.Name = "key14";
			this.key14.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key14.Size = new System.Drawing.Size(48, 51);
			this.key14.TabIndex = 20;
			// 
			// key15
			// 
			this.key15.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key15.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key15.FGWidth = 48;
			this.key15.FText = "";
			this.key15.GText = "";
			this.key15.HText = "";
			this.key15.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key15.Location = new System.Drawing.Point(312, 256);
			this.key15.MainBackColor = System.Drawing.Color.Olive;
			this.key15.MainForeColor = System.Drawing.Color.White;
			this.key15.MainText = "RCL";
			this.key15.MainWidth = 48;
			this.key15.Name = "key15";
			this.key15.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key15.Size = new System.Drawing.Size(48, 51);
			this.key15.TabIndex = 23;
			// 
			// key16
			// 
			this.key16.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key16.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key16.FGWidth = 48;
			this.key16.FText = "c";
			this.key16.GText = "";
			this.key16.HText = "";
			this.key16.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key16.Location = new System.Drawing.Point(144, 256);
			this.key16.MainBackColor = System.Drawing.Color.Olive;
			this.key16.MainForeColor = System.Drawing.Color.White;
			this.key16.MainText = "e ̽";
			this.key16.MainWidth = 48;
			this.key16.Name = "key16";
			this.key16.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key16.Size = new System.Drawing.Size(48, 51);
			this.key16.TabIndex = 21;
			// 
			// key17
			// 
			this.key17.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key17.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key17.FGWidth = 48;
			this.key17.FText = "e";
			this.key17.GText = "";
			this.key17.HText = "";
			this.key17.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key17.Location = new System.Drawing.Point(256, 256);
			this.key17.MainBackColor = System.Drawing.Color.Olive;
			this.key17.MainForeColor = System.Drawing.Color.White;
			this.key17.MainText = "STO";
			this.key17.MainWidth = 48;
			this.key17.Name = "key17";
			this.key17.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key17.Size = new System.Drawing.Size(48, 51);
			this.key17.TabIndex = 24;
			// 
			// key18
			// 
			this.key18.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key18.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key18.FGWidth = 48;
			this.key18.FText = "a";
			this.key18.GText = "";
			this.key18.HText = "";
			this.key18.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key18.Location = new System.Drawing.Point(32, 256);
			this.key18.MainBackColor = System.Drawing.Color.Olive;
			this.key18.MainForeColor = System.Drawing.Color.White;
			this.key18.MainText = "y ̽";
			this.key18.MainWidth = 48;
			this.key18.Name = "key18";
			this.key18.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key18.Size = new System.Drawing.Size(48, 51);
			this.key18.TabIndex = 19;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cardSlot1);
			this.groupBox1.Controls.Add(this.toggle1);
			this.groupBox1.Controls.Add(this.key7);
			this.groupBox1.Controls.Add(this.toggle2);
			this.groupBox1.Controls.Add(this.toggle3);
			this.groupBox1.Controls.Add(this.key2);
			this.groupBox1.Controls.Add(this.key1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.key4);
			this.groupBox1.Controls.Add(this.key5);
			this.groupBox1.Controls.Add(this.key3);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 184);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// cardSlot1
			// 
			this.cardSlot1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.cardSlot1.Location = new System.Drawing.Point(8, 72);
			this.cardSlot1.Margin = 16;
			this.cardSlot1.Name = "cardSlot1";
			this.cardSlot1.RichText = false;
			this.cardSlot1.Size = new System.Drawing.Size(288, 50);
			this.cardSlot1.State = HP67_Control_Library.CardSlotState.Unloaded;
			this.cardSlot1.TabIndex = 12;
			this.cardSlot1.TextBoxWidth = 48;
			this.cardSlot1.Title = "<TITLE>";
			// 
			// toggle1
			// 
			this.toggle1.LeftText = "MAN";
			this.toggle1.LeftWidth = 60;
			this.toggle1.Location = new System.Drawing.Point(184, 24);
			this.toggle1.MainWidth = 60;
			this.toggle1.Name = "toggle1";
			this.toggle1.Position = HP67_Control_Library.TogglePosition.Left;
			this.toggle1.RightText = "NORM";
			this.toggle1.RightWidth = 60;
			this.toggle1.Size = new System.Drawing.Size(160, 16);
			this.toggle1.TabIndex = 1;
			this.toggle1.Load += new System.EventHandler(this.toggle1_Load);
			// 
			// key7
			// 
			this.key7.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key7.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key7.FGWidth = 48;
			this.key7.FText = "e";
			this.key7.GText = "";
			this.key7.HText = "";
			this.key7.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key7.Location = new System.Drawing.Point(240, 128);
			this.key7.MainBackColor = System.Drawing.Color.Olive;
			this.key7.MainForeColor = System.Drawing.Color.White;
			this.key7.MainText = "E";
			this.key7.MainWidth = 48;
			this.key7.Name = "key7";
			this.key7.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key7.Size = new System.Drawing.Size(48, 51);
			this.key7.TabIndex = 11;
			// 
			// toggle2
			// 
			this.toggle2.LeftText = "OFF";
			this.toggle2.LeftWidth = 60;
			this.toggle2.Location = new System.Drawing.Point(8, 24);
			this.toggle2.MainWidth = 60;
			this.toggle2.Name = "toggle2";
			this.toggle2.Position = HP67_Control_Library.TogglePosition.Right;
			this.toggle2.RightText = "ON";
			this.toggle2.RightWidth = 60;
			this.toggle2.Size = new System.Drawing.Size(144, 16);
			this.toggle2.TabIndex = 2;
			// 
			// toggle3
			// 
			this.toggle3.LeftText = "PRGM";
			this.toggle3.LeftWidth = 60;
			this.toggle3.Location = new System.Drawing.Point(184, 48);
			this.toggle3.MainWidth = 60;
			this.toggle3.Name = "toggle3";
			this.toggle3.Position = HP67_Control_Library.TogglePosition.Right;
			this.toggle3.RightText = "RUN";
			this.toggle3.RightWidth = 60;
			this.toggle3.Size = new System.Drawing.Size(152, 16);
			this.toggle3.TabIndex = 3;
			// 
			// key2
			// 
			this.key2.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key2.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key2.FGWidth = 48;
			this.key2.FText = "b";
			this.key2.GText = "";
			this.key2.HText = "";
			this.key2.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key2.Location = new System.Drawing.Point(72, 128);
			this.key2.MainBackColor = System.Drawing.Color.Olive;
			this.key2.MainForeColor = System.Drawing.Color.White;
			this.key2.MainText = "B";
			this.key2.MainWidth = 48;
			this.key2.Name = "key2";
			this.key2.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key2.Size = new System.Drawing.Size(48, 51);
			this.key2.TabIndex = 6;
			// 
			// key1
			// 
			this.key1.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key1.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key1.FGWidth = 48;
			this.key1.FText = "a";
			this.key1.GText = "";
			this.key1.HText = "";
			this.key1.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key1.Location = new System.Drawing.Point(16, 128);
			this.key1.MainBackColor = System.Drawing.Color.Olive;
			this.key1.MainForeColor = System.Drawing.Color.White;
			this.key1.MainText = "A";
			this.key1.MainWidth = 48;
			this.key1.Name = "key1";
			this.key1.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key1.Size = new System.Drawing.Size(48, 51);
			this.key1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(184, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "TRACE";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// key4
			// 
			this.key4.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key4.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key4.FGWidth = 48;
			this.key4.FText = "d";
			this.key4.GText = "";
			this.key4.HText = "";
			this.key4.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key4.Location = new System.Drawing.Point(184, 128);
			this.key4.MainBackColor = System.Drawing.Color.Olive;
			this.key4.MainForeColor = System.Drawing.Color.White;
			this.key4.MainText = "D";
			this.key4.MainWidth = 48;
			this.key4.Name = "key4";
			this.key4.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key4.Size = new System.Drawing.Size(48, 51);
			this.key4.TabIndex = 8;
			// 
			// key5
			// 
			this.key5.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key5.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key5.FGWidth = 48;
			this.key5.FText = "";
			this.key5.GText = "";
			this.key5.HText = "";
			this.key5.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key5.Location = new System.Drawing.Point(296, 128);
			this.key5.MainBackColor = System.Drawing.Color.Gold;
			this.key5.MainForeColor = System.Drawing.Color.Black;
			this.key5.MainText = "f";
			this.key5.MainWidth = 48;
			this.key5.Name = "key5";
			this.key5.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key5.Size = new System.Drawing.Size(48, 51);
			this.key5.TabIndex = 9;
			// 
			// key3
			// 
			this.key3.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key3.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key3.FGWidth = 48;
			this.key3.FText = "c";
			this.key3.GText = "";
			this.key3.HText = "";
			this.key3.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key3.Location = new System.Drawing.Point(128, 128);
			this.key3.MainBackColor = System.Drawing.Color.Olive;
			this.key3.MainForeColor = System.Drawing.Color.White;
			this.key3.MainText = "C";
			this.key3.MainWidth = 48;
			this.key3.Name = "key3";
			this.key3.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key3.Size = new System.Drawing.Size(48, 51);
			this.key3.TabIndex = 7;
			// 
			// key10
			// 
			this.key10.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key10.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key10.FGWidth = 48;
			this.key10.FText = "d";
			this.key10.GText = "";
			this.key10.HText = "";
			this.key10.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key10.Location = new System.Drawing.Point(200, 200);
			this.key10.MainBackColor = System.Drawing.Color.Olive;
			this.key10.MainForeColor = System.Drawing.Color.White;
			this.key10.MainText = "RTN";
			this.key10.MainWidth = 48;
			this.key10.Name = "key10";
			this.key10.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key10.Size = new System.Drawing.Size(48, 51);
			this.key10.TabIndex = 16;
			// 
			// key8
			// 
			this.key8.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key8.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key8.FGWidth = 48;
			this.key8.FText = "b";
			this.key8.GText = "";
			this.key8.HText = "";
			this.key8.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key8.Location = new System.Drawing.Point(88, 200);
			this.key8.MainBackColor = System.Drawing.Color.Olive;
			this.key8.MainForeColor = System.Drawing.Color.White;
			this.key8.MainText = "GTO";
			this.key8.MainWidth = 48;
			this.key8.Name = "key8";
			this.key8.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key8.Size = new System.Drawing.Size(48, 51);
			this.key8.TabIndex = 14;
			// 
			// key11
			// 
			this.key11.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key11.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key11.FGWidth = 48;
			this.key11.FText = "";
			this.key11.GText = "";
			this.key11.HText = "";
			this.key11.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key11.Location = new System.Drawing.Point(312, 200);
			this.key11.MainBackColor = System.Drawing.Color.Olive;
			this.key11.MainForeColor = System.Drawing.Color.White;
			this.key11.MainText = "SST";
			this.key11.MainWidth = 48;
			this.key11.Name = "key11";
			this.key11.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key11.Size = new System.Drawing.Size(48, 51);
			this.key11.TabIndex = 17;
			// 
			// key12
			// 
			this.key12.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key12.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key12.FGWidth = 48;
			this.key12.FText = "c";
			this.key12.GText = "";
			this.key12.HText = "";
			this.key12.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key12.Location = new System.Drawing.Point(144, 200);
			this.key12.MainBackColor = System.Drawing.Color.Olive;
			this.key12.MainForeColor = System.Drawing.Color.White;
			this.key12.MainText = "GSB";
			this.key12.MainWidth = 48;
			this.key12.Name = "key12";
			this.key12.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key12.Size = new System.Drawing.Size(48, 51);
			this.key12.TabIndex = 15;
			// 
			// key6
			// 
			this.key6.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key6.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key6.FGWidth = 48;
			this.key6.FText = "e";
			this.key6.GText = "";
			this.key6.HText = "";
			this.key6.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key6.Location = new System.Drawing.Point(256, 200);
			this.key6.MainBackColor = System.Drawing.Color.Olive;
			this.key6.MainForeColor = System.Drawing.Color.White;
			this.key6.MainText = "BST";
			this.key6.MainWidth = 48;
			this.key6.Name = "key6";
			this.key6.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key6.Size = new System.Drawing.Size(48, 51);
			this.key6.TabIndex = 18;
			// 
			// key9
			// 
			this.key9.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(85)), ((System.Byte)(56)), ((System.Byte)(26)));
			this.key9.FGTextAlign = HP67_Control_Library.TextAlign.Centered;
			this.key9.FGWidth = 48;
			this.key9.FText = "a";
			this.key9.GText = "";
			this.key9.HText = "";
			this.key9.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key9.Location = new System.Drawing.Point(32, 200);
			this.key9.MainBackColor = System.Drawing.Color.Olive;
			this.key9.MainForeColor = System.Drawing.Color.White;
			this.key9.MainText = "LBL";
			this.key9.MainWidth = 48;
			this.key9.Name = "key9";
			this.key9.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key9.Size = new System.Drawing.Size(48, 51);
			this.key9.TabIndex = 13;
			// 
			// HP97
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(1112, 710);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.printer1);
			this.MaximizeBox = false;
			this.Name = "HP97";
			this.Text = "HP97";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void toggle1_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
