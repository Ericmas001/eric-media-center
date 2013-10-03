using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using EricUtility;
using System.Web;
using System.Diagnostics;
using EMCMovie.Entities;
using EMCCommon.WebService;
using EMCCommon.VideoParser;
using EMCCommon.Entities;
using EMCCommon.Windows.Forms;
using VIBlend.Utilities;

namespace EMCMovie.Windows.Forms
{
    public partial class MainForm : Form
    {
        string m_Website;
        Movie m_Movie;
        public MainForm()
        {
            InitializeComponent();
        }
        private void Enable(bool enable)
        {
            txtSearch.Enabled = enable;
            btnSearch.Enabled = enable;
            tvSearch.Enabled = enable;
            tvLink.Enabled = enable;
            pictureBox1.Visible = !enable;
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                Enable(false);
                ClearSearch();
                var all = await WSUtility.CallWS<Dictionary<string, List<ListedMovie>>>("movie", "search", "all", txtSearch.Text);
                if (all == null)
                    MessageBox.Show("An error occured !");
                else
                {
                    string[] keys = all.Keys.ToArray();
                    Array.Sort(keys);
                    foreach (string w in keys)
                    {
                        TreeNode tn = new TreeNode(w);
                        tvSearch.Nodes.Add(tn);
                        if (all[w] != null)
                            foreach (ListedMovie lm in all[w])
                                tn.Nodes.Add(new EMCTreeNode<ListedMovie>(lm));
                        else
                            tn.Nodes.Add(new TreeNode("An error occured ...") {ForeColor = Color.Gray });
                    }
                }
                Enable(true);
            }
        }

        private void tvSearch_DoubleClick(object sender, EventArgs e)
        {
            EMCTreeNode<ListedMovie> etn = tvSearch.SelectedNode as EMCTreeNode<ListedMovie>;
            if (etn != null)
            {
                ClearMovie();
                m_Website = etn.Parent.Text;
                LoadMovie(etn.Info);
            }
        }

        private async void LoadMovie(ListedMovie ls)
        {
            Enable(false);
            m_Movie = await WSUtility.CallWS<Movie>("movie", "movie", m_Website, ls.Name);
            if (m_Movie == null)
                MessageBox.Show("An error occured !");
            else
            {
                lblMovie.Text = m_Movie.Title;
                AddLinks(m_Movie.Links.Keys.Where(w => VideoParsingFactory.Parsers.ContainsKey(w)), Color.Blue);
                AddLinks(m_Movie.Links.Keys.Where(w => !VideoParsingFactory.Parsers.ContainsKey(w)), Color.Black);
            }
            Enable(true);
        }

        private void AddLinks(IEnumerable<string> websites, Color color)
        {
            foreach (string w in websites)
            {
                TreeNode tn = new TreeNode(w);
                tn.ForeColor = color;
                tvLink.Nodes.Add(tn);
                int i = 1;
                foreach (string l in m_Movie.Links[w])
                {
                    EMCTreeNode<ListedLink> tn2 = new EMCTreeNode<ListedLink>(new ListedLink() { Name = l, Title = "Link #" + i, Website = w });
                    tn.Nodes.Add(tn2);
                    ++i;
                }
            }
        }
        private async void tvLink_DoubleClick(object sender, EventArgs e)
        {
            EMCTreeNode<ListedLink> etn = tvLink.SelectedNode as EMCTreeNode<ListedLink>;
            if (etn != null)
            {
                Enable(false);
                var si = await WSUtility.CallWS<StreamingInfo>("movie", "stream", m_Website, etn.Info.Website, etn.Info.Name);
                if (si == null)
                    MessageBox.Show("An error occured !");
                else
                {
                    try
                    {
                        if (await VideoParsingFactory.GetDownloadURLAsync(si))
                        {
                            if (!String.IsNullOrWhiteSpace(si.DownloadURL))
                            {
                                new OpenURLForm(si, m_Movie.Title).ShowDialog();
                                etn.ForeColor = Color.DarkGray;
                            }
                            else
                                etn.ForeColor = Color.Red;
                        }
                        else if (!String.IsNullOrWhiteSpace(si.StreamingURL))
                        {
                            Process.Start(si.StreamingURL);
                            etn.ForeColor = Color.DarkGray;
                        }
                        else
                            etn.ForeColor = Color.Red;
                    }
                    catch { etn.ForeColor = Color.Red; }
                    tvLink.SelectedNode = null;
                    Enable(true);
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private void ClearMovie()
        {
            tvLink.Nodes.Clear();
            m_Movie = null;
            lblMovie.Text = "";
        }
        private void ClearSearch()
        {
            tvSearch.Nodes.Clear();
            ClearMovie();
        }

        private async void openInBrowserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMCTreeNode<ListedMovie> etn = tvSearch.SelectedNode as EMCTreeNode<ListedMovie>;
            if (etn != null)
            {
                Enable(false);
                var si = await WSUtility.CallWS<string>("movie", "MovieURL", etn.Parent.Text, etn.Info.Name);
                if (si == null)
                    MessageBox.Show("An error occured !");
                else
                {
                    if (!String.IsNullOrWhiteSpace(si))
                        Process.Start(si);
                }
                Enable(true);
            }
        }


        private void ctxtSearch_Opening(object sender, CancelEventArgs e)
        {
            EMCTreeNode<ListedMovie> etn = tvSearch.SelectedNode as EMCTreeNode<ListedMovie>;
            if (etn == null)
                e.Cancel = true;
        }

        private void tvSearch_MouseDown(object sender, MouseEventArgs e)
        {
            tvSearch.SelectedNode = tvSearch.GetNodeAt(e.X, e.Y);
        }

        private void tvLink_MouseDown(object sender, MouseEventArgs e)
        {
            tvLink.SelectedNode = tvLink.GetNodeAt(e.X, e.Y);
        }

        private void ctxtLinks_Opening(object sender, CancelEventArgs e)
        {
            EMCTreeNode<ListedLink> etn = tvLink.SelectedNode as EMCTreeNode<ListedLink>;
            if (etn == null)
                e.Cancel = true;
        }

        private async void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMCTreeNode<ListedLink> etn = tvLink.SelectedNode as EMCTreeNode<ListedLink>;
            if (etn != null)
            {
                Enable(false);
                var si = await WSUtility.CallWS<StreamingInfo>("movie", "stream", m_Website, etn.Info.Website, etn.Info.Name);
                if (si == null)
                    MessageBox.Show("An error occured !");
                else
                    Process.Start(si.StreamingURL);
                Enable(true);
            }
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            WSUtility.DebugMode = !WSUtility.DebugMode;
            if (WSUtility.DebugMode)
            {
                this.BackColor = Color.Yellow;
                this.Text = "EMC Movie ~~ D E B U G ~~";
                btnDebug.VIBlendTheme = VIBLEND_THEME.METROGREEN;
            }
            else
            {
                this.BackColor = Color.White;
                this.Text = "EMC Movie";
                btnDebug.VIBlendTheme = VIBLEND_THEME.METROORANGE;
            }
        }
    }
}
