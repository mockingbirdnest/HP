namespace Mockingbird.HP.Testing
{
    partial class PrinterTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.PrinterUnderTest = new Mockingbird.HP.Control_Library.Printer ();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid ();
            this.textBox = new System.Windows.Forms.TextBox ();
            this.buttonAppend = new System.Windows.Forms.Button ();
            this.radioButtonLeft = new System.Windows.Forms.RadioButton ();
            this.radioButtonCenter = new System.Windows.Forms.RadioButton ();
            this.radioButtonRight = new System.Windows.Forms.RadioButton ();
            this.groupBox1 = new System.Windows.Forms.GroupBox ();
            this.groupBox1.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // PrinterUnderTest
            // 
            this.PrinterUnderTest.Location = new System.Drawing.Point (355, 12);
            this.PrinterUnderTest.Name = "PrinterUnderTest";
            this.PrinterUnderTest.Size = new System.Drawing.Size (240, 216);
            this.PrinterUnderTest.TabIndex = 0;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point (8, 8);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.SelectedObject = this.PrinterUnderTest;
            this.propertyGrid.Size = new System.Drawing.Size (320, 448);
            this.propertyGrid.TabIndex = 1;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point (355, 278);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size (240, 20);
            this.textBox.TabIndex = 2;
            // 
            // buttonAppend
            // 
            this.buttonAppend.Location = new System.Drawing.Point (520, 327);
            this.buttonAppend.Name = "buttonAppend";
            this.buttonAppend.Size = new System.Drawing.Size (75, 23);
            this.buttonAppend.TabIndex = 3;
            this.buttonAppend.Text = "Append";
            this.buttonAppend.UseVisualStyleBackColor = true;
            this.buttonAppend.Click += new System.EventHandler (this.buttonAppend_Click);
            // 
            // radioButtonLeft
            // 
            this.radioButtonLeft.AutoSize = true;
            this.radioButtonLeft.Checked = true;
            this.radioButtonLeft.Location = new System.Drawing.Point (6, 19);
            this.radioButtonLeft.Name = "radioButtonLeft";
            this.radioButtonLeft.Size = new System.Drawing.Size (43, 17);
            this.radioButtonLeft.TabIndex = 4;
            this.radioButtonLeft.TabStop = true;
            this.radioButtonLeft.Text = "Left";
            this.radioButtonLeft.UseVisualStyleBackColor = true;
            // 
            // radioButtonCenter
            // 
            this.radioButtonCenter.AutoSize = true;
            this.radioButtonCenter.Location = new System.Drawing.Point (6, 42);
            this.radioButtonCenter.Name = "radioButtonCenter";
            this.radioButtonCenter.Size = new System.Drawing.Size (56, 17);
            this.radioButtonCenter.TabIndex = 5;
            this.radioButtonCenter.Text = "Center";
            this.radioButtonCenter.UseVisualStyleBackColor = true;
            // 
            // radioButtonRight
            // 
            this.radioButtonRight.AutoSize = true;
            this.radioButtonRight.Location = new System.Drawing.Point (6, 65);
            this.radioButtonRight.Name = "radioButtonRight";
            this.radioButtonRight.Size = new System.Drawing.Size (50, 17);
            this.radioButtonRight.TabIndex = 6;
            this.radioButtonRight.Text = "Right";
            this.radioButtonRight.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add (this.radioButtonRight);
            this.groupBox1.Controls.Add (this.radioButtonLeft);
            this.groupBox1.Controls.Add (this.radioButtonCenter);
            this.groupBox1.Location = new System.Drawing.Point (355, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size (118, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alignment";
            // 
            // PrinterTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (607, 485);
            this.Controls.Add (this.groupBox1);
            this.Controls.Add (this.buttonAppend);
            this.Controls.Add (this.textBox);
            this.Controls.Add (this.propertyGrid);
            this.Controls.Add (this.PrinterUnderTest);
            this.Name = "PrinterTest";
            this.Text = "PrinterTest";
            this.groupBox1.ResumeLayout (false);
            this.groupBox1.PerformLayout ();
            this.ResumeLayout (false);
            this.PerformLayout ();

        }

        #endregion

        private Mockingbird.HP.Control_Library.Printer PrinterUnderTest;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonAppend;
        private System.Windows.Forms.RadioButton radioButtonLeft;
        private System.Windows.Forms.RadioButton radioButtonCenter;
        private System.Windows.Forms.RadioButton radioButtonRight;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}