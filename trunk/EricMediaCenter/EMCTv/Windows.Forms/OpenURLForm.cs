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
                string dest = Properties.Settings.Default.emcd_output + "/" + m_Show.Title + " S" + m_Episode.NoSeason + "E" + m_Episode.NoEpisode + ".flv";
                // TODO: chg name if already exist (1) (2) ...
                // TODO: exstension !!
                // TODO: padding S3E5 => S03E05
                string args = "\"" + src + "\" \"" + dest + "\"";
                Process.Start(Properties.Settings.Default.emcd_path, args);
            }
        }
    }
}
