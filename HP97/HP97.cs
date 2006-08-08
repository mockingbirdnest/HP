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
		private Mockingbird.HP.Control_Library.Printer printer1;
		private System.Windows.Forms.Panel panel1;
		private Mockingbird.HP.Control_Library.Toggle toggle1;
		private Mockingbird.HP.Control_Library.Toggle toggle2;
		private Mockingbird.HP.Control_Library.Toggle toggle3;
		private System.Windows.Forms.Label label1;
		private Mockingbird.HP.Control_Library.Key key1;
		private Mockingbird.HP.Control_Library.Key key2;
		private Mockingbird.HP.Control_Library.Key key3;
		private Mockingbird.HP.Control_Library.Key key4;
		private Mockingbird.HP.Control_Library.Key key5;
		private Mockingbird.HP.Control_Library.Key key7;
		private System.Windows.Forms.GroupBox groupBox1;
		private Mockingbird.HP.Control_Library.CardSlot cardSlot1;
		private Mockingbird.HP.Control_Library.Key key6;
		private Mockingbird.HP.Control_Library.Key key8;
		private Mockingbird.HP.Control_Library.Key key9;
		private Mockingbird.HP.Control_Library.Key key10;
		private Mockingbird.HP.Control_Library.Key key11;
		private Mockingbird.HP.Control_Library.Key key12;
		private Mockingbird.HP.Control_Library.Key key13;
		private Mockingbird.HP.Control_Library.Key key14;
		private Mockingbird.HP.Control_Library.Key key15;
		private Mockingbird.HP.Control_Library.Key key16;
		private Mockingbird.HP.Control_Library.Key key17;
		private Mockingbird.HP.Control_Library.Key key18;
		private Mockingbird.HP.Control_Library.Key key19;
		private Mockingbird.HP.Control_Library.Key key20;
		private Mockingbird.HP.Control_Library.Key key21;
		private Mockingbird.HP.Control_Library.Key key22;
		private Mockingbird.HP.Control_Library.Key key23;
		private Mockingbird.HP.Control_Library.Key key24;
		private Mockingbird.HP.Control_Library.Key key25;
		private Mockingbird.HP.Control_Library.Key key26;
		private Mockingbird.HP.Control_Library.Key key27;
		private Mockingbird.HP.Control_Library.Key key28;
		private Mockingbird.HP.Control_Library.Key key29;
		private Mockingbird.HP.Control_Library.Key key30;
		private Mockingbird.HP.Control_Library.Key key31;
		private Mockingbird.HP.Control_Library.Key key32;
		private Mockingbird.HP.Control_Library.Key key33;
		private Mockingbird.HP.Control_Library.Key key34;
		private Mockingbird.HP.Control_Library.Key key35;
		private Mockingbird.HP.Control_Library.Key key36;
		private Mockingbird.HP.Control_Library.Key key37;
		private Mockingbird.HP.Control_Library.Key key38;
		private Mockingbird.HP.Control_Library.Key key39;
		private Mockingbird.HP.Control_Library.Key key40;
		private Mockingbird.HP.Control_Library.Key key41;
		private Mockingbird.HP.Control_Library.Key key42;
		private Mockingbird.HP.Control_Library.Key key43;
		private Mockingbird.HP.Control_Library.Key key44;
		private Mockingbird.HP.Control_Library.Key key45;
		private Mockingbird.HP.Control_Library.Key key46;
		private Mockingbird.HP.Control_Library.Key key47;
		private Mockingbird.HP.Control_Library.Key key48;
		private Mockingbird.HP.Control_Library.Key key49;
		private Mockingbird.HP.Control_Library.Key key50;
		private Mockingbird.HP.Control_Library.Key key51;
		private Mockingbird.HP.Control_Library.Key key52;
		private Mockingbird.HP.Control_Library.Key key53;
		private Mockingbird.HP.Control_Library.Key key54;
		private Mockingbird.HP.Control_Library.Key key55;
		private Mockingbird.HP.Control_Library.Key key56;
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
			this.printer1 = new Mockingbird.HP.Control_Library.Printer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.key25 = new Mockingbird.HP.Control_Library.Key();
			this.key26 = new Mockingbird.HP.Control_Library.Key();
			this.key27 = new Mockingbird.HP.Control_Library.Key();
			this.key28 = new Mockingbird.HP.Control_Library.Key();
			this.key29 = new Mockingbird.HP.Control_Library.Key();
			this.key30 = new Mockingbird.HP.Control_Library.Key();
			this.key19 = new Mockingbird.HP.Control_Library.Key();
			this.key20 = new Mockingbird.HP.Control_Library.Key();
			this.key21 = new Mockingbird.HP.Control_Library.Key();
			this.key22 = new Mockingbird.HP.Control_Library.Key();
			this.key23 = new Mockingbird.HP.Control_Library.Key();
			this.key24 = new Mockingbird.HP.Control_Library.Key();
			this.key13 = new Mockingbird.HP.Control_Library.Key();
			this.key14 = new Mockingbird.HP.Control_Library.Key();
			this.key15 = new Mockingbird.HP.Control_Library.Key();
			this.key16 = new Mockingbird.HP.Control_Library.Key();
			this.key17 = new Mockingbird.HP.Control_Library.Key();
			this.key18 = new Mockingbird.HP.Control_Library.Key();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cardSlot1 = new Mockingbird.HP.Control_Library.CardSlot();
			this.toggle1 = new Mockingbird.HP.Control_Library.Toggle();
			this.key7 = new Mockingbird.HP.Control_Library.Key();
			this.toggle2 = new Mockingbird.HP.Control_Library.Toggle();
			this.toggle3 = new Mockingbird.HP.Control_Library.Toggle();
			this.key2 = new Mockingbird.HP.Control_Library.Key();
			this.key1 = new Mockingbird.HP.Control_Library.Key();
			this.label1 = new System.Windows.Forms.Label();
			this.key4 = new Mockingbird.HP.Control_Library.Key();
			this.key5 = new Mockingbird.HP.Control_Library.Key();
			this.key3 = new Mockingbird.HP.Control_Library.Key();
			this.key10 = new Mockingbird.HP.Control_Library.Key();
			this.key8 = new Mockingbird.HP.Control_Library.Key();
			this.key11 = new Mockingbird.HP.Control_Library.Key();
			this.key12 = new Mockingbird.HP.Control_Library.Key();
			this.key6 = new Mockingbird.HP.Control_Library.Key();
			this.key9 = new Mockingbird.HP.Control_Library.Key();
			this.key31 = new Mockingbird.HP.Control_Library.Key();
			this.key32 = new Mockingbird.HP.Control_Library.Key();
			this.key33 = new Mockingbird.HP.Control_Library.Key();
			this.key34 = new Mockingbird.HP.Control_Library.Key();
			this.key35 = new Mockingbird.HP.Control_Library.Key();
			this.key36 = new Mockingbird.HP.Control_Library.Key();
			this.key37 = new Mockingbird.HP.Control_Library.Key();
			this.key38 = new Mockingbird.HP.Control_Library.Key();
			this.key39 = new Mockingbird.HP.Control_Library.Key();
			this.key40 = new Mockingbird.HP.Control_Library.Key();
			this.key41 = new Mockingbird.HP.Control_Library.Key();
			this.key42 = new Mockingbird.HP.Control_Library.Key();
			this.key43 = new Mockingbird.HP.Control_Library.Key();
			this.key44 = new Mockingbird.HP.Control_Library.Key();
			this.key45 = new Mockingbird.HP.Control_Library.Key();
			this.key46 = new Mockingbird.HP.Control_Library.Key();
			this.key47 = new Mockingbird.HP.Control_Library.Key();
			this.key48 = new Mockingbird.HP.Control_Library.Key();
			this.key49 = new Mockingbird.HP.Control_Library.Key();
			this.key50 = new Mockingbird.HP.Control_Library.Key();
			this.key51 = new Mockingbird.HP.Control_Library.Key();
			this.key52 = new Mockingbird.HP.Control_Library.Key();
			this.key53 = new Mockingbird.HP.Control_Library.Key();
			this.key54 = new Mockingbird.HP.Control_Library.Key();
			this.key55 = new Mockingbird.HP.Control_Library.Key();
			this.key56 = new Mockingbird.HP.Control_Library.Key();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// printer1
			// 
			this.printer1.Location = new System.Drawing.Point(464, -8);
			this.printer1.Name = "printer1";
			this.printer1.Size = new System.Drawing.Size(304, 288);
			this.printer1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.key56);
			this.panel1.Controls.Add(this.key55);
			this.panel1.Controls.Add(this.key54);
			this.panel1.Controls.Add(this.key51);
			this.panel1.Controls.Add(this.key52);
			this.panel1.Controls.Add(this.key53);
			this.panel1.Controls.Add(this.key50);
			this.panel1.Controls.Add(this.key49);
			this.panel1.Controls.Add(this.key48);
			this.panel1.Controls.Add(this.key47);
			this.panel1.Controls.Add(this.key44);
			this.panel1.Controls.Add(this.key45);
			this.panel1.Controls.Add(this.key46);
			this.panel1.Controls.Add(this.key41);
			this.panel1.Controls.Add(this.key42);
			this.panel1.Controls.Add(this.key43);
			this.panel1.Controls.Add(this.key38);
			this.panel1.Controls.Add(this.key39);
			this.panel1.Controls.Add(this.key40);
			this.panel1.Controls.Add(this.key35);
			this.panel1.Controls.Add(this.key36);
			this.panel1.Controls.Add(this.key37);
			this.panel1.Controls.Add(this.key34);
			this.panel1.Controls.Add(this.key33);
			this.panel1.Controls.Add(this.key32);
			this.panel1.Controls.Add(this.key31);
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
			this.panel1.Location = new System.Drawing.Point(8, 280);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1096, 440);
			this.panel1.TabIndex = 2;
			// 
			// key25
			// 
			this.key25.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key25.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key25.FGWidth = 48;
			this.key25.FText = "S";
			this.key25.GText = "";
			this.key25.HText = "";
			this.key25.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key25.Location = new System.Drawing.Point(200, 384);
			this.key25.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key25.MainForeColor = System.Drawing.Color.White;
			this.key25.MainHeight = 24;
			this.key25.MainText = "√x̅";
			this.key25.MainWidth = 48;
			this.key25.Name = "key25";
			this.key25.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key25.Size = new System.Drawing.Size(48, 51);
			this.key25.TabIndex = 34;
			// 
			// key26
			// 
			this.key26.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key26.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key26.FGWidth = 48;
			this.key26.FText = "N!";
			this.key26.GText = "";
			this.key26.HText = "";
			this.key26.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key26.Location = new System.Drawing.Point(88, 384);
			this.key26.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key26.MainForeColor = System.Drawing.Color.White;
			this.key26.MainHeight = 24;
			this.key26.MainText = "1/x";
			this.key26.MainWidth = 48;
			this.key26.Name = "key26";
			this.key26.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key26.Size = new System.Drawing.Size(48, 51);
			this.key26.TabIndex = 32;
			// 
			// key27
			// 
			this.key27.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key27.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key27.FGWidth = 48;
			this.key27.FText = "Σ-";
			this.key27.GText = "";
			this.key27.HText = "";
			this.key27.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key27.Location = new System.Drawing.Point(312, 384);
			this.key27.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key27.MainForeColor = System.Drawing.Color.White;
			this.key27.MainHeight = 24;
			this.key27.MainText = "Σ+";
			this.key27.MainWidth = 48;
			this.key27.Name = "key27";
			this.key27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.key27.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key27.Size = new System.Drawing.Size(48, 51);
			this.key27.TabIndex = 35;
			// 
			// key28
			// 
			this.key28.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key28.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key28.FGWidth = 48;
			this.key28.FText = "x̅";
			this.key28.GText = "";
			this.key28.HText = "";
			this.key28.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key28.Location = new System.Drawing.Point(144, 384);
			this.key28.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key28.MainForeColor = System.Drawing.Color.White;
			this.key28.MainHeight = 24;
			this.key28.MainText = "x²";
			this.key28.MainWidth = 48;
			this.key28.Name = "key28";
			this.key28.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key28.Size = new System.Drawing.Size(48, 51);
			this.key28.TabIndex = 33;
			// 
			// key29
			// 
			this.key29.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key29.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key29.FGWidth = 48;
			this.key29.FText = "%CH";
			this.key29.GText = "";
			this.key29.HText = "";
			this.key29.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key29.Location = new System.Drawing.Point(256, 384);
			this.key29.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key29.MainForeColor = System.Drawing.Color.White;
			this.key29.MainHeight = 24;
			this.key29.MainText = "%";
			this.key29.MainWidth = 48;
			this.key29.Name = "key29";
			this.key29.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key29.Size = new System.Drawing.Size(48, 51);
			this.key29.TabIndex = 36;
			// 
			// key30
			// 
			this.key30.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key30.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key30.FGWidth = 48;
			this.key30.FText = "PAUSE";
			this.key30.GText = "";
			this.key30.HText = "";
			this.key30.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key30.Location = new System.Drawing.Point(32, 384);
			this.key30.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key30.MainForeColor = System.Drawing.Color.White;
			this.key30.MainHeight = 24;
			this.key30.MainText = "R/S";
			this.key30.MainWidth = 48;
			this.key30.Name = "key30";
			this.key30.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key30.Size = new System.Drawing.Size(48, 51);
			this.key30.TabIndex = 31;
			// 
			// key19
			// 
			this.key19.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key19.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key19.FGWidth = 48;
			this.key19.FText = "FRAC";
			this.key19.GText = "";
			this.key19.HText = "";
			this.key19.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key19.Location = new System.Drawing.Point(200, 328);
			this.key19.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key19.MainForeColor = System.Drawing.Color.White;
			this.key19.MainHeight = 24;
			this.key19.MainText = "→R";
			this.key19.MainWidth = 48;
			this.key19.Name = "key19";
			this.key19.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key19.Size = new System.Drawing.Size(48, 51);
			this.key19.TabIndex = 28;
			// 
			// key20
			// 
			this.key20.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key20.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key20.FGWidth = 48;
			this.key20.FText = "COS⁻¹";
			this.key20.GText = "";
			this.key20.HText = "";
			this.key20.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key20.Location = new System.Drawing.Point(88, 328);
			this.key20.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key20.MainForeColor = System.Drawing.Color.White;
			this.key20.MainHeight = 24;
			this.key20.MainText = "COS";
			this.key20.MainWidth = 48;
			this.key20.Name = "key20";
			this.key20.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key20.Size = new System.Drawing.Size(48, 51);
			this.key20.TabIndex = 26;
			// 
			// key21
			// 
			this.key21.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key21.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key21.FGWidth = 48;
			this.key21.FText = "R→D";
			this.key21.GText = "";
			this.key21.HText = "";
			this.key21.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key21.Location = new System.Drawing.Point(312, 328);
			this.key21.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key21.MainForeColor = System.Drawing.Color.White;
			this.key21.MainHeight = 24;
			this.key21.MainText = "I";
			this.key21.MainWidth = 48;
			this.key21.Name = "key21";
			this.key21.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key21.Size = new System.Drawing.Size(48, 51);
			this.key21.TabIndex = 29;
			// 
			// key22
			// 
			this.key22.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key22.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key22.FGWidth = 48;
			this.key22.FText = "TAN⁻¹";
			this.key22.GText = "";
			this.key22.HText = "";
			this.key22.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key22.Location = new System.Drawing.Point(144, 328);
			this.key22.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key22.MainForeColor = System.Drawing.Color.White;
			this.key22.MainHeight = 24;
			this.key22.MainText = "TAN";
			this.key22.MainWidth = 48;
			this.key22.Name = "key22";
			this.key22.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key22.Size = new System.Drawing.Size(48, 51);
			this.key22.TabIndex = 27;
			// 
			// key23
			// 
			this.key23.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key23.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key23.FGWidth = 48;
			this.key23.FText = "D→R";
			this.key23.GText = "";
			this.key23.HText = "";
			this.key23.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key23.Location = new System.Drawing.Point(256, 328);
			this.key23.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key23.MainForeColor = System.Drawing.Color.White;
			this.key23.MainHeight = 24;
			this.key23.MainText = "(i)";
			this.key23.MainWidth = 48;
			this.key23.Name = "key23";
			this.key23.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key23.Size = new System.Drawing.Size(48, 51);
			this.key23.TabIndex = 30;
			// 
			// key24
			// 
			this.key24.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key24.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key24.FGWidth = 48;
			this.key24.FText = "SIN⁻¹";
			this.key24.GText = "";
			this.key24.HText = "";
			this.key24.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key24.Location = new System.Drawing.Point(32, 328);
			this.key24.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key24.MainForeColor = System.Drawing.Color.White;
			this.key24.MainHeight = 24;
			this.key24.MainText = "SIN";
			this.key24.MainWidth = 48;
			this.key24.Name = "key24";
			this.key24.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key24.Size = new System.Drawing.Size(48, 51);
			this.key24.TabIndex = 25;
			// 
			// key13
			// 
			this.key13.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key13.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key13.FGWidth = 48;
			this.key13.FText = "INT";
			this.key13.GText = "";
			this.key13.HText = "";
			this.key13.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key13.Location = new System.Drawing.Point(200, 272);
			this.key13.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key13.MainForeColor = System.Drawing.Color.White;
			this.key13.MainHeight = 24;
			this.key13.MainText = "→P";
			this.key13.MainWidth = 48;
			this.key13.Name = "key13";
			this.key13.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key13.Size = new System.Drawing.Size(48, 51);
			this.key13.TabIndex = 22;
			// 
			// key14
			// 
			this.key14.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key14.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key14.FGWidth = 48;
			this.key14.FText = "LOG";
			this.key14.GText = "";
			this.key14.HText = "";
			this.key14.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key14.Location = new System.Drawing.Point(88, 272);
			this.key14.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key14.MainForeColor = System.Drawing.Color.White;
			this.key14.MainHeight = 24;
			this.key14.MainText = "LN";
			this.key14.MainWidth = 48;
			this.key14.Name = "key14";
			this.key14.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key14.Size = new System.Drawing.Size(48, 51);
			this.key14.TabIndex = 20;
			// 
			// key15
			// 
			this.key15.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key15.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key15.FGWidth = 48;
			this.key15.FText = "H.MS→";
			this.key15.GText = "";
			this.key15.HText = "";
			this.key15.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key15.Location = new System.Drawing.Point(312, 272);
			this.key15.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key15.MainForeColor = System.Drawing.Color.White;
			this.key15.MainHeight = 24;
			this.key15.MainText = "RCL";
			this.key15.MainWidth = 48;
			this.key15.Name = "key15";
			this.key15.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key15.Size = new System.Drawing.Size(48, 51);
			this.key15.TabIndex = 23;
			// 
			// key16
			// 
			this.key16.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key16.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key16.FGWidth = 48;
			this.key16.FText = "10 ̽";
			this.key16.GText = "";
			this.key16.HText = "";
			this.key16.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key16.Location = new System.Drawing.Point(144, 272);
			this.key16.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key16.MainForeColor = System.Drawing.Color.White;
			this.key16.MainHeight = 24;
			this.key16.MainText = "e ̽";
			this.key16.MainWidth = 48;
			this.key16.Name = "key16";
			this.key16.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key16.Size = new System.Drawing.Size(48, 51);
			this.key16.TabIndex = 21;
			// 
			// key17
			// 
			this.key17.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key17.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key17.FGWidth = 48;
			this.key17.FText = "→H.MS";
			this.key17.GText = "";
			this.key17.HText = "";
			this.key17.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key17.Location = new System.Drawing.Point(256, 272);
			this.key17.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key17.MainForeColor = System.Drawing.Color.White;
			this.key17.MainHeight = 24;
			this.key17.MainText = "STO";
			this.key17.MainWidth = 48;
			this.key17.Name = "key17";
			this.key17.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key17.Size = new System.Drawing.Size(48, 51);
			this.key17.TabIndex = 24;
			// 
			// key18
			// 
			this.key18.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key18.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key18.FGWidth = 48;
			this.key18.FText = "ABS";
			this.key18.GText = "";
			this.key18.HText = "";
			this.key18.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key18.Location = new System.Drawing.Point(32, 272);
			this.key18.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key18.MainForeColor = System.Drawing.Color.White;
			this.key18.MainHeight = 24;
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
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(16, 18);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 194);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// cardSlot1
			// 
			this.cardSlot1.Location = new System.Drawing.Point(8, 80);
			this.cardSlot1.Margin = 16;
			this.cardSlot1.Name = "cardSlot1";
			this.cardSlot1.RichText = false;
			this.cardSlot1.Size = new System.Drawing.Size(288, 50);
			this.cardSlot1.State = Mockingbird.HP.Control_Library.CardSlotState.Unloaded;
			this.cardSlot1.TabIndex = 12;
			this.cardSlot1.TextBoxWidth = 48;
			this.cardSlot1.Title = "<TITLE>";
			this.cardSlot1.UnloadedTextA = "1/x";
			this.cardSlot1.UnloadedTextB = "√x̅";
			this.cardSlot1.UnloadedTextC = "yˣ";
			this.cardSlot1.UnloadedTextD = "R↓";
			this.cardSlot1.UnloadedTextE = "x⇄y";
			// 
			// toggle1
			// 
			this.toggle1.LeftText = "MAN";
			this.toggle1.LeftWidth = 60;
			this.toggle1.Location = new System.Drawing.Point(184, 24);
			this.toggle1.MainWidth = 60;
			this.toggle1.Name = "toggle1";
			this.toggle1.Position = Mockingbird.HP.Control_Library.TogglePosition.Left;
			this.toggle1.RightText = "NORM";
			this.toggle1.RightWidth = 60;
			this.toggle1.Size = new System.Drawing.Size(160, 16);
			this.toggle1.TabIndex = 1;
			this.toggle1.Load += new System.EventHandler(this.toggle1_Load);
			// 
			// key7
			// 
			this.key7.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key7.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key7.FGWidth = 48;
			this.key7.FText = "e";
			this.key7.GText = "";
			this.key7.HText = "";
			this.key7.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key7.Location = new System.Drawing.Point(240, 142);
			this.key7.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key7.MainForeColor = System.Drawing.Color.White;
			this.key7.MainHeight = 24;
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
			this.toggle2.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
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
			this.toggle3.Position = Mockingbird.HP.Control_Library.TogglePosition.Right;
			this.toggle3.RightText = "RUN";
			this.toggle3.RightWidth = 60;
			this.toggle3.Size = new System.Drawing.Size(152, 16);
			this.toggle3.TabIndex = 3;
			// 
			// key2
			// 
			this.key2.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key2.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key2.FGWidth = 48;
			this.key2.FText = "b";
			this.key2.GText = "";
			this.key2.HText = "";
			this.key2.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key2.Location = new System.Drawing.Point(72, 142);
			this.key2.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key2.MainForeColor = System.Drawing.Color.White;
			this.key2.MainHeight = 24;
			this.key2.MainText = "B";
			this.key2.MainWidth = 48;
			this.key2.Name = "key2";
			this.key2.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key2.Size = new System.Drawing.Size(48, 51);
			this.key2.TabIndex = 6;
			// 
			// key1
			// 
			this.key1.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key1.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key1.FGWidth = 48;
			this.key1.FText = "a";
			this.key1.GText = "";
			this.key1.HText = "";
			this.key1.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key1.Location = new System.Drawing.Point(16, 142);
			this.key1.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key1.MainForeColor = System.Drawing.Color.White;
			this.key1.MainHeight = 24;
			this.key1.MainText = "A";
			this.key1.MainWidth = 48;
			this.key1.Name = "key1";
			this.key1.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key1.Size = new System.Drawing.Size(48, 51);
			this.key1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(248, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "TRACE";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// key4
			// 
			this.key4.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key4.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key4.FGWidth = 48;
			this.key4.FText = "d";
			this.key4.GText = "";
			this.key4.HText = "";
			this.key4.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key4.Location = new System.Drawing.Point(184, 142);
			this.key4.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key4.MainForeColor = System.Drawing.Color.White;
			this.key4.MainHeight = 24;
			this.key4.MainText = "D";
			this.key4.MainWidth = 48;
			this.key4.Name = "key4";
			this.key4.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key4.Size = new System.Drawing.Size(48, 51);
			this.key4.TabIndex = 8;
			// 
			// key5
			// 
			this.key5.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key5.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key5.FGWidth = 48;
			this.key5.FText = "";
			this.key5.GText = "";
			this.key5.HText = "";
			this.key5.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key5.Location = new System.Drawing.Point(296, 142);
			this.key5.MainBackColor = System.Drawing.Color.Gold;
			this.key5.MainForeColor = System.Drawing.Color.Black;
			this.key5.MainHeight = 24;
			this.key5.MainText = "f";
			this.key5.MainWidth = 48;
			this.key5.Name = "key5";
			this.key5.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key5.Size = new System.Drawing.Size(48, 51);
			this.key5.TabIndex = 9;
			// 
			// key3
			// 
			this.key3.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key3.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key3.FGWidth = 48;
			this.key3.FText = "c";
			this.key3.GText = "";
			this.key3.HText = "";
			this.key3.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key3.Location = new System.Drawing.Point(128, 142);
			this.key3.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key3.MainForeColor = System.Drawing.Color.White;
			this.key3.MainHeight = 24;
			this.key3.MainText = "C";
			this.key3.MainWidth = 48;
			this.key3.Name = "key3";
			this.key3.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key3.Size = new System.Drawing.Size(48, 51);
			this.key3.TabIndex = 7;
			// 
			// key10
			// 
			this.key10.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key10.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key10.FGWidth = 48;
			this.key10.FText = "RND";
			this.key10.GText = "";
			this.key10.HText = "";
			this.key10.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key10.Location = new System.Drawing.Point(200, 216);
			this.key10.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key10.MainForeColor = System.Drawing.Color.White;
			this.key10.MainHeight = 24;
			this.key10.MainText = "RTN";
			this.key10.MainWidth = 48;
			this.key10.Name = "key10";
			this.key10.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key10.Size = new System.Drawing.Size(48, 51);
			this.key10.TabIndex = 16;
			// 
			// key8
			// 
			this.key8.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key8.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key8.FGWidth = 48;
			this.key8.FText = "CLF";
			this.key8.GText = "";
			this.key8.HText = "";
			this.key8.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key8.Location = new System.Drawing.Point(88, 216);
			this.key8.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key8.MainForeColor = System.Drawing.Color.White;
			this.key8.MainHeight = 24;
			this.key8.MainText = "GTO";
			this.key8.MainWidth = 48;
			this.key8.Name = "key8";
			this.key8.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key8.Size = new System.Drawing.Size(48, 51);
			this.key8.TabIndex = 14;
			// 
			// key11
			// 
			this.key11.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key11.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key11.FGWidth = 48;
			this.key11.FText = "ISZ";
			this.key11.GText = "";
			this.key11.HText = "";
			this.key11.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key11.Location = new System.Drawing.Point(312, 216);
			this.key11.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key11.MainForeColor = System.Drawing.Color.White;
			this.key11.MainHeight = 24;
			this.key11.MainText = "SST";
			this.key11.MainWidth = 48;
			this.key11.Name = "key11";
			this.key11.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key11.Size = new System.Drawing.Size(48, 51);
			this.key11.TabIndex = 17;
			// 
			// key12
			// 
			this.key12.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key12.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key12.FGWidth = 48;
			this.key12.FText = "F?";
			this.key12.GText = "";
			this.key12.HText = "";
			this.key12.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key12.Location = new System.Drawing.Point(144, 216);
			this.key12.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key12.MainForeColor = System.Drawing.Color.White;
			this.key12.MainHeight = 24;
			this.key12.MainText = "GSB";
			this.key12.MainWidth = 48;
			this.key12.Name = "key12";
			this.key12.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key12.Size = new System.Drawing.Size(48, 51);
			this.key12.TabIndex = 15;
			// 
			// key6
			// 
			this.key6.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key6.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key6.FGWidth = 48;
			this.key6.FText = "DSZ";
			this.key6.GText = "";
			this.key6.HText = "";
			this.key6.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key6.Location = new System.Drawing.Point(256, 216);
			this.key6.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key6.MainForeColor = System.Drawing.Color.White;
			this.key6.MainHeight = 24;
			this.key6.MainText = "BST";
			this.key6.MainWidth = 48;
			this.key6.Name = "key6";
			this.key6.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key6.Size = new System.Drawing.Size(48, 51);
			this.key6.TabIndex = 18;
			// 
			// key9
			// 
			this.key9.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key9.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key9.FGWidth = 48;
			this.key9.FText = "STF";
			this.key9.GText = "";
			this.key9.HText = "";
			this.key9.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key9.Location = new System.Drawing.Point(32, 216);
			this.key9.MainBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key9.MainForeColor = System.Drawing.Color.White;
			this.key9.MainHeight = 24;
			this.key9.MainText = "LBL";
			this.key9.MainWidth = 48;
			this.key9.Name = "key9";
			this.key9.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key9.Size = new System.Drawing.Size(48, 51);
			this.key9.TabIndex = 13;
			// 
			// key31
			// 
			this.key31.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key31.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key31.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key31.FGWidth = 160;
			this.key31.FText = "STF";
			this.key31.GText = "";
			this.key31.HText = "";
			this.key31.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key31.Location = new System.Drawing.Point(432, 372);
			this.key31.MainBackColor = System.Drawing.Color.LightYellow;
			this.key31.MainForeColor = System.Drawing.Color.Black;
			this.key31.MainHeight = 36;
			this.key31.MainText = "0";
			this.key31.MainWidth = 160;
			this.key31.Name = "key31";
			this.key31.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key31.Size = new System.Drawing.Size(160, 63);
			this.key31.TabIndex = 37;
			// 
			// key32
			// 
			this.key32.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key32.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key32.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key32.FGWidth = 72;
			this.key32.FText = "R↑";
			this.key32.GText = "";
			this.key32.HText = "";
			this.key32.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key32.Location = new System.Drawing.Point(432, 160);
			this.key32.MainBackColor = System.Drawing.Color.Olive;
			this.key32.MainForeColor = System.Drawing.Color.White;
			this.key32.MainHeight = 36;
			this.key32.MainText = "R";
			this.key32.MainWidth = 72;
			this.key32.Name = "key32";
			this.key32.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key32.Size = new System.Drawing.Size(72, 63);
			this.key32.TabIndex = 38;
			// 
			// key33
			// 
			this.key33.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key33.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key33.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key33.FGWidth = 72;
			this.key33.FText = "STF";
			this.key33.GText = "";
			this.key33.HText = "";
			this.key33.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key33.Location = new System.Drawing.Point(432, 302);
			this.key33.MainBackColor = System.Drawing.Color.Olive;
			this.key33.MainForeColor = System.Drawing.Color.White;
			this.key33.MainHeight = 36;
			this.key33.MainText = "CL x";
			this.key33.MainWidth = 72;
			this.key33.Name = "key33";
			this.key33.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key33.Size = new System.Drawing.Size(72, 63);
			this.key33.TabIndex = 39;
			// 
			// key34
			// 
			this.key34.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key34.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key34.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key34.FGWidth = 72;
			this.key34.FText = "STF";
			this.key34.GText = "";
			this.key34.HText = "";
			this.key34.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key34.Location = new System.Drawing.Point(432, 231);
			this.key34.MainBackColor = System.Drawing.Color.Olive;
			this.key34.MainForeColor = System.Drawing.Color.White;
			this.key34.MainHeight = 36;
			this.key34.MainText = "x⇄y";
			this.key34.MainWidth = 72;
			this.key34.Name = "key34";
			this.key34.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key34.Size = new System.Drawing.Size(72, 63);
			this.key34.TabIndex = 40;
			// 
			// key35
			// 
			this.key35.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key35.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key35.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key35.FGWidth = 72;
			this.key35.FText = "STF";
			this.key35.GText = "";
			this.key35.HText = "";
			this.key35.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key35.Location = new System.Drawing.Point(520, 231);
			this.key35.MainBackColor = System.Drawing.Color.LightYellow;
			this.key35.MainForeColor = System.Drawing.Color.Black;
			this.key35.MainHeight = 36;
			this.key35.MainText = "4";
			this.key35.MainWidth = 72;
			this.key35.Name = "key35";
			this.key35.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key35.Size = new System.Drawing.Size(72, 63);
			this.key35.TabIndex = 43;
			// 
			// key36
			// 
			this.key36.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key36.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key36.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key36.FGWidth = 72;
			this.key36.FText = "STF";
			this.key36.GText = "";
			this.key36.HText = "";
			this.key36.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key36.Location = new System.Drawing.Point(520, 302);
			this.key36.MainBackColor = System.Drawing.Color.LightYellow;
			this.key36.MainForeColor = System.Drawing.Color.Black;
			this.key36.MainHeight = 36;
			this.key36.MainText = "1";
			this.key36.MainWidth = 72;
			this.key36.Name = "key36";
			this.key36.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key36.Size = new System.Drawing.Size(72, 63);
			this.key36.TabIndex = 42;
			// 
			// key37
			// 
			this.key37.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key37.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key37.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key37.FGWidth = 72;
			this.key37.FText = "STF";
			this.key37.GText = "";
			this.key37.HText = "";
			this.key37.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key37.Location = new System.Drawing.Point(520, 160);
			this.key37.MainBackColor = System.Drawing.Color.LightYellow;
			this.key37.MainForeColor = System.Drawing.Color.Black;
			this.key37.MainHeight = 36;
			this.key37.MainText = "7";
			this.key37.MainWidth = 72;
			this.key37.Name = "key37";
			this.key37.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key37.Size = new System.Drawing.Size(72, 63);
			this.key37.TabIndex = 41;
			// 
			// key38
			// 
			this.key38.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key38.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key38.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key38.FGWidth = 72;
			this.key38.FText = "STF";
			this.key38.GText = "";
			this.key38.HText = "";
			this.key38.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key38.Location = new System.Drawing.Point(608, 231);
			this.key38.MainBackColor = System.Drawing.Color.LightYellow;
			this.key38.MainForeColor = System.Drawing.Color.Black;
			this.key38.MainHeight = 36;
			this.key38.MainText = "5";
			this.key38.MainWidth = 72;
			this.key38.Name = "key38";
			this.key38.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key38.Size = new System.Drawing.Size(72, 63);
			this.key38.TabIndex = 46;
			// 
			// key39
			// 
			this.key39.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key39.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key39.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key39.FGWidth = 72;
			this.key39.FText = "STF";
			this.key39.GText = "";
			this.key39.HText = "";
			this.key39.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key39.Location = new System.Drawing.Point(608, 302);
			this.key39.MainBackColor = System.Drawing.Color.LightYellow;
			this.key39.MainForeColor = System.Drawing.Color.Black;
			this.key39.MainHeight = 36;
			this.key39.MainText = "2";
			this.key39.MainWidth = 72;
			this.key39.Name = "key39";
			this.key39.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key39.Size = new System.Drawing.Size(72, 63);
			this.key39.TabIndex = 45;
			// 
			// key40
			// 
			this.key40.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key40.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key40.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key40.FGWidth = 72;
			this.key40.FText = "STF";
			this.key40.GText = "";
			this.key40.HText = "";
			this.key40.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key40.Location = new System.Drawing.Point(608, 160);
			this.key40.MainBackColor = System.Drawing.Color.LightYellow;
			this.key40.MainForeColor = System.Drawing.Color.Black;
			this.key40.MainHeight = 36;
			this.key40.MainText = "8";
			this.key40.MainWidth = 72;
			this.key40.Name = "key40";
			this.key40.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key40.Size = new System.Drawing.Size(72, 63);
			this.key40.TabIndex = 44;
			// 
			// key41
			// 
			this.key41.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key41.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key41.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key41.FGWidth = 72;
			this.key41.FText = "STF";
			this.key41.GText = "";
			this.key41.HText = "";
			this.key41.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key41.Location = new System.Drawing.Point(696, 231);
			this.key41.MainBackColor = System.Drawing.Color.LightYellow;
			this.key41.MainForeColor = System.Drawing.Color.Black;
			this.key41.MainHeight = 36;
			this.key41.MainText = "6";
			this.key41.MainWidth = 72;
			this.key41.Name = "key41";
			this.key41.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key41.Size = new System.Drawing.Size(72, 63);
			this.key41.TabIndex = 49;
			// 
			// key42
			// 
			this.key42.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key42.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key42.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key42.FGWidth = 72;
			this.key42.FText = "STF";
			this.key42.GText = "";
			this.key42.HText = "";
			this.key42.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key42.Location = new System.Drawing.Point(696, 302);
			this.key42.MainBackColor = System.Drawing.Color.LightYellow;
			this.key42.MainForeColor = System.Drawing.Color.Black;
			this.key42.MainHeight = 36;
			this.key42.MainText = "3";
			this.key42.MainWidth = 72;
			this.key42.Name = "key42";
			this.key42.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key42.Size = new System.Drawing.Size(72, 63);
			this.key42.TabIndex = 48;
			// 
			// key43
			// 
			this.key43.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key43.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key43.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key43.FGWidth = 72;
			this.key43.FText = "STF";
			this.key43.GText = "";
			this.key43.HText = "";
			this.key43.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key43.Location = new System.Drawing.Point(696, 160);
			this.key43.MainBackColor = System.Drawing.Color.LightYellow;
			this.key43.MainForeColor = System.Drawing.Color.Black;
			this.key43.MainHeight = 36;
			this.key43.MainText = "9";
			this.key43.MainWidth = 72;
			this.key43.Name = "key43";
			this.key43.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key43.Size = new System.Drawing.Size(72, 63);
			this.key43.TabIndex = 47;
			// 
			// key44
			// 
			this.key44.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key44.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key44.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key44.FGWidth = 72;
			this.key44.FText = "STF";
			this.key44.GText = "";
			this.key44.HText = "";
			this.key44.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key44.Location = new System.Drawing.Point(784, 160);
			this.key44.MainBackColor = System.Drawing.Color.Olive;
			this.key44.MainForeColor = System.Drawing.Color.White;
			this.key44.MainHeight = 36;
			this.key44.MainText = "×";
			this.key44.MainWidth = 72;
			this.key44.Name = "key44";
			this.key44.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key44.Size = new System.Drawing.Size(72, 63);
			this.key44.TabIndex = 52;
			// 
			// key45
			// 
			this.key45.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key45.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key45.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key45.FGWidth = 72;
			this.key45.FText = "STF";
			this.key45.GText = "";
			this.key45.HText = "";
			this.key45.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key45.Location = new System.Drawing.Point(784, 231);
			this.key45.MainBackColor = System.Drawing.Color.Olive;
			this.key45.MainForeColor = System.Drawing.Color.White;
			this.key45.MainHeight = 36;
			this.key45.MainText = "-";
			this.key45.MainWidth = 72;
			this.key45.Name = "key45";
			this.key45.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key45.Size = new System.Drawing.Size(72, 63);
			this.key45.TabIndex = 51;
			// 
			// key46
			// 
			this.key46.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key46.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key46.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key46.FGWidth = 72;
			this.key46.FText = "π";
			this.key46.GText = "";
			this.key46.HText = "";
			this.key46.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key46.Location = new System.Drawing.Point(784, 89);
			this.key46.MainBackColor = System.Drawing.Color.Olive;
			this.key46.MainForeColor = System.Drawing.Color.White;
			this.key46.MainHeight = 36;
			this.key46.MainText = "÷";
			this.key46.MainWidth = 72;
			this.key46.Name = "key46";
			this.key46.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key46.Size = new System.Drawing.Size(72, 63);
			this.key46.TabIndex = 50;
			// 
			// key47
			// 
			this.key47.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key47.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key47.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key47.FGWidth = 72;
			this.key47.FText = "STF";
			this.key47.GText = "";
			this.key47.HText = "";
			this.key47.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key47.Location = new System.Drawing.Point(608, 372);
			this.key47.MainBackColor = System.Drawing.Color.LightYellow;
			this.key47.MainForeColor = System.Drawing.Color.Black;
			this.key47.MainHeight = 36;
			this.key47.MainText = " ・";
			this.key47.MainWidth = 72;
			this.key47.Name = "key47";
			this.key47.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key47.Size = new System.Drawing.Size(72, 63);
			this.key47.TabIndex = 53;
			// 
			// key48
			// 
			this.key48.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key48.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key48.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key48.FGWidth = 72;
			this.key48.FText = "STF";
			this.key48.GText = "";
			this.key48.HText = "";
			this.key48.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key48.Location = new System.Drawing.Point(696, 372);
			this.key48.MainBackColor = System.Drawing.Color.LightYellow;
			this.key48.MainForeColor = System.Drawing.Color.Black;
			this.key48.MainHeight = 36;
			this.key48.MainText = "DSP";
			this.key48.MainWidth = 72;
			this.key48.Name = "key48";
			this.key48.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key48.Size = new System.Drawing.Size(72, 63);
			this.key48.TabIndex = 54;
			// 
			// key49
			// 
			this.key49.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key49.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key49.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key49.FGWidth = 72;
			this.key49.FText = "STF";
			this.key49.GText = "";
			this.key49.HText = "";
			this.key49.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key49.Location = new System.Drawing.Point(784, 302);
			this.key49.MainBackColor = System.Drawing.Color.Olive;
			this.key49.MainForeColor = System.Drawing.Color.White;
			this.key49.MainHeight = 106;
			this.key49.MainText = "+";
			this.key49.MainWidth = 72;
			this.key49.Name = "key49";
			this.key49.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key49.Size = new System.Drawing.Size(72, 133);
			this.key49.TabIndex = 55;
			// 
			// key50
			// 
			this.key50.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key50.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key50.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key50.FGWidth = 72;
			this.key50.FText = "GRD";
			this.key50.GText = "";
			this.key50.HText = "";
			this.key50.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key50.Location = new System.Drawing.Point(696, 89);
			this.key50.MainBackColor = System.Drawing.Color.Olive;
			this.key50.MainForeColor = System.Drawing.Color.White;
			this.key50.MainHeight = 36;
			this.key50.MainText = "EEX";
			this.key50.MainWidth = 72;
			this.key50.Name = "key50";
			this.key50.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key50.Size = new System.Drawing.Size(72, 63);
			this.key50.TabIndex = 56;
			// 
			// key51
			// 
			this.key51.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key51.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key51.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key51.FGWidth = 72;
			this.key51.FText = "RAD";
			this.key51.GText = "";
			this.key51.HText = "";
			this.key51.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key51.Location = new System.Drawing.Point(608, 89);
			this.key51.MainBackColor = System.Drawing.Color.Olive;
			this.key51.MainForeColor = System.Drawing.Color.White;
			this.key51.MainHeight = 36;
			this.key51.MainText = "CHS";
			this.key51.MainWidth = 72;
			this.key51.Name = "key51";
			this.key51.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key51.Size = new System.Drawing.Size(72, 63);
			this.key51.TabIndex = 59;
			// 
			// key52
			// 
			this.key52.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key52.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key52.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key52.FGWidth = 72;
			this.key52.FText = "SPACE";
			this.key52.GText = "";
			this.key52.HText = "";
			this.key52.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key52.Location = new System.Drawing.Point(432, 18);
			this.key52.MainBackColor = System.Drawing.Color.Olive;
			this.key52.MainForeColor = System.Drawing.Color.White;
			this.key52.MainHeight = 36;
			this.key52.MainText = "FIX";
			this.key52.MainWidth = 72;
			this.key52.Name = "key52";
			this.key52.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key52.Size = new System.Drawing.Size(72, 63);
			this.key52.TabIndex = 58;
			// 
			// key53
			// 
			this.key53.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key53.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key53.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key53.FGWidth = 160;
			this.key53.FText = "DEG";
			this.key53.GText = "";
			this.key53.HText = "";
			this.key53.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key53.Location = new System.Drawing.Point(432, 89);
			this.key53.MainBackColor = System.Drawing.Color.Olive;
			this.key53.MainForeColor = System.Drawing.Color.White;
			this.key53.MainHeight = 36;
			this.key53.MainText = "ENTER ↑";
			this.key53.MainWidth = 160;
			this.key53.Name = "key53";
			this.key53.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key53.Size = new System.Drawing.Size(160, 63);
			this.key53.TabIndex = 57;
			// 
			// key54
			// 
			this.key54.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key54.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key54.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key54.FGWidth = 72;
			this.key54.FText = "PRGM";
			this.key54.GText = "";
			this.key54.HText = "";
			this.key54.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key54.Location = new System.Drawing.Point(520, 18);
			this.key54.MainBackColor = System.Drawing.Color.Olive;
			this.key54.MainForeColor = System.Drawing.Color.White;
			this.key54.MainHeight = 36;
			this.key54.MainText = "SCI";
			this.key54.MainWidth = 72;
			this.key54.Name = "key54";
			this.key54.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key54.Size = new System.Drawing.Size(72, 63);
			this.key54.TabIndex = 60;
			// 
			// key55
			// 
			this.key55.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key55.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key55.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key55.FGWidth = 72;
			this.key55.FText = "REG";
			this.key55.GText = "";
			this.key55.HText = "";
			this.key55.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key55.Location = new System.Drawing.Point(608, 18);
			this.key55.MainBackColor = System.Drawing.Color.Olive;
			this.key55.MainForeColor = System.Drawing.Color.White;
			this.key55.MainHeight = 36;
			this.key55.MainText = "ENG";
			this.key55.MainWidth = 72;
			this.key55.Name = "key55";
			this.key55.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key55.Size = new System.Drawing.Size(72, 63);
			this.key55.TabIndex = 61;
			// 
			// key56
			// 
			this.key56.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key56.FGBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(55)), ((System.Byte)(30)));
			this.key56.FGTextAlign = Mockingbird.HP.Control_Library.TextAlign.Centered;
			this.key56.FGWidth = 160;
			this.key56.FText = "STACK";
			this.key56.GText = "";
			this.key56.HText = "";
			this.key56.HTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.key56.Location = new System.Drawing.Point(696, 18);
			this.key56.MainBackColor = System.Drawing.Color.Olive;
			this.key56.MainForeColor = System.Drawing.Color.White;
			this.key56.MainHeight = 36;
			this.key56.MainText = "PRINT x";
			this.key56.MainWidth = 160;
			this.key56.Name = "key56";
			this.key56.Shortcuts = new System.Windows.Forms.Keys[0];
			this.key56.Size = new System.Drawing.Size(160, 63);
			this.key56.TabIndex = 62;
			// 
			// HP97
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(1112, 726);
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
