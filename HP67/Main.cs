using Mockingbird.HP.Class_Library;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mockingbird.HP.HP67
{
    static class Program
    {
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
                Application.Run (new HP67 (arguments));
            }
            catch (Shutdown)
            {
            }
        }
    }
}