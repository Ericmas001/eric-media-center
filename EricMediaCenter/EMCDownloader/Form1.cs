using System;
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
            if (this.Args != null)
            {
                ProcessParameters(null, this.Args);
                this.Args = null;
            }
        }

        public delegate void ProcessParametersDelegate(object sender, string[] args);

        public void ProcessParameters(object sender, string[] args)
        {
            if (args != null && args.Length != 0)
            {
                //listBox1.Items.Add(String.Format("{0} {1}", DateTime.Now.ToString("HH:mm:ss.ff"), String.Join(" ", args)));
                //downloadList1.AddDownloadURLs(new ResourceLocation[] { new ResourceLocation() { URL = args[0] } }, 1, args[1], 0);
                int segments = args.Length >= 2 ? int.Parse(args[2]) : 10;
                downloadList1.AddDownload(args[0], args[1], segments);
            }
        }
    }
}