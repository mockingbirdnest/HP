using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HP35
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new HP35 ());
        }
    }
}