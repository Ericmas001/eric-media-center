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
        private TvShow m_Show = null;
        private Episode m_Episode = null;
        public OpenURLForm(StreamingInfo si, TvShow show, Episode ep)
        {
            m_StreamingInfo = si;
            m_Show = show;
            m_Episode = ep;
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
                string dest = String.Format("{0}\\{1} S{2:00}E{3:00}.flv", Properties.Settings.Default.emcd_output, m_Show.Title, m_Episode.NoSeason, m_Episode.NoEpisode);
                // TODO: chg name if already exist (1) (2) ...
                // TODO: exstension !!
                string args = "\"" + src + "\" \"" + dest + "\"";
                Process.Start(Properties.Settings.Default.emcd_path, args);
                Close();
            }
        }
    }
}
