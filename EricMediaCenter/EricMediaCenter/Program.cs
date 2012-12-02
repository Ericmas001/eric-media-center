using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EricMediaCenter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // HTTP POST Returns The Error: 417 “Expectation Failed.” (C#)
            // http://stackoverflow.com/questions/566437/http-post-returns-the-error-417-expectation-failed-c
            System.Net.ServicePointManager.Expect100Continue = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

// TODOS
// Largeur du bouton lorsque reutilise ;) (NavBar)
// Popular
