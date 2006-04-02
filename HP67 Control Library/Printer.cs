using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HP67_Control_Library
{
	/// <summary>
	/// Description résumée de UserControl2.
	/// </summary>
	public class Printer : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListBox listBox1;
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Printer()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent

		}

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listBox1.Items.AddRange(new object[] {
														  "1ABCDEFGHIJKLMNOPQRSTUVWXYZ",
														  "3",
														  "4",
														  "5",
														  "6",
														  "7",
														  "8",
														  "9",
														  "0",
														  "1",
														  "2",
														  "3",
														  "4",
														  "5",
														  "6",
														  "7",
														  "8",
														  "9",
														  "0",
														  "1"});
			this.listBox1.Location = new System.Drawing.Point(16, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.listBox1.Size = new System.Drawing.Size(152, 173);
			this.listBox1.TabIndex = 0;
			// 
			// Printer
			// 
			this.Controls.Add(this.listBox1);
			this.Name = "Printer";
			this.Size = new System.Drawing.Size(192, 232);
			this.ResumeLayout(false);

		}
		#endregion


	}
}
