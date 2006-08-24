using Mockingbird.HP.Class_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mockingbird.HP.HP35
{
    public partial class HP35 : Form
    {
        public HP35 (string [] arguments)
        {
            InitializeComponent ();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main (string [] arguments)
        {
            try
            {
                //Application.EnableVisualStyles ();
                //Application.SetCompatibleTextRenderingDefault (false);
                Application.Run (new HP35 (arguments));
            }
            catch (Shutdown)
            {
            }
        }
    }
}