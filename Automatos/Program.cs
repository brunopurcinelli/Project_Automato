using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Automatos.FormsAutomato;
using Automatos.Forms;
using System.Threading;

namespace Automatos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
            About splash = new About();
            splash.Show();
            Application.DoEvents();
           
            Thread.Sleep(5000);
            splash.Dispose();
            */
            Application.Run(new Index());
        }
    }
}
