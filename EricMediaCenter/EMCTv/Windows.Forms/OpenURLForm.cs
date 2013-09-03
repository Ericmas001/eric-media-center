using EMCTv.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMCTv.Windows.Forms
{
    public partial class OpenURLForm : Form
    {
        private StreamingInfo m_StreamingInfo = null;
        public OpenURLForm(StreamingInfo si)
        {
            m_StreamingInfo = si;
            InitializeComponent();
        }

        private void btnDwldBrowser_Click(object sender, EventArgs e)
        {
            Process.Start(m_StreamingInfo.DownloadURL);
            Close();
        }

        private void btnDwldClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(m_StreamingInfo.DownloadURL);
            Close();
        }

        private void btnStreamBrowser_Click(object sender, EventArgs e)
        {
            Process.Start(m_StreamingInfo.StreamingURL);
            Close();
        }
    }
}
