using EMCTv.Windows.Forms;
using System;
using System.Windows.Forms;

namespace EMCTv
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm fLogin = new LoginForm();
            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(fLogin.Session));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}