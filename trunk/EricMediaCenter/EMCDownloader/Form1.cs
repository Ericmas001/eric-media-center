using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMCDownloader
{
    public partial class Form1 : Form
    {
        public string[] Args;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // The single-instance code is going to save the command line 
            // arguments in this member variable before opening the first instance
            // of the app.
            if (this.Args != null)
            {
                ProcessParameters(null, this.Args);
                this.Args = null;
            }
        }

        public delegate void ProcessParametersDelegate(object sender, string[] args);
        public void ProcessParameters(object sender, string[] args)
        {
            // The form has loaded, and initialization will have been be done.

            // Add the command-line arguments to our textbox, just to confirm that
            // it reached here.
            if (args != null && args.Length != 0)
                listBox1.Items.Add(String.Format("{0} {1}", DateTime.Now.ToString("mm:ss.ff"), String.Join(" ", args)));
        }
    }
}
