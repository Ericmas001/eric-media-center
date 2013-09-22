using EMCMovie.Entities;
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

namespace EMCMovie.Windows.Forms
{
    public partial class OpenURLForm : Form
    {
        private StreamingInfo m_StreamingInfo = null;
        private Movie m_Movie = null;
        public OpenURLForm(StreamingInfo si, Movie mov)
        {
            m_StreamingInfo = si;
            m_Movie = mov;
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

        private void btnDwldEMCD_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.emcd_path) && !String.IsNullOrWhiteSpace(Properties.Settings.Default.emcd_output))
            {
                string src = m_StreamingInfo.DownloadURL;
                string dest = String.Format("{0}\\{1}.flv", Properties.Settings.Default.emcd_output, m_Movie.Title);
                // TODO: chg name if already exist (1) (2) ...
                // TODO: exstension !!
                string args = String.Format("\"{0}\" \"{1}\" {2}", src, dest, m_StreamingInfo.MaxSegments);
                Process.Start(Properties.Settings.Default.emcd_path, args);
                Close();
            }
        }
    }
}
