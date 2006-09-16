using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mockingbird.HP.Testing
{
    public partial class PrinterTest : Form
    {
        public PrinterTest ()
        {
            InitializeComponent ();
        }

        [STAThread]
        static void Main ()
        {
            Application.Run (new PrinterTest ());
        }

        private void buttonAppend_Click (object sender, EventArgs e)
        {
            PrinterUnderTest.PrintNumeric (textBox.Text, ""); // TODO: Improve testability.
            //if (radioButtonCenter.Checked)
            //{
            //    PrinterUnderTest.Append (textBox.Text, HorizontalAlignment.Center);
            //}
            //else if (radioButtonLeft.Checked)
            //{
            //    PrinterUnderTest.Append (textBox.Text, HorizontalAlignment.Left);
            //}
            //else if (radioButtonRight.Checked)
            //{
            //    PrinterUnderTest.Append (textBox.Text, HorizontalAlignment.Right);
            //}
        }
    }
}