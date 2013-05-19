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

namespace EMCTv
{
    public partial class MainForm : Form
    {
        private SessionInfo m_Session;
        public MainForm(SessionInfo session)
        {
            m_Session = session;
            InitializeComponent();
        }
        private void Enable(bool enable)
        {
            txtSearch.Enabled = enable;
            btnSearch.Enabled = enable;
            tvSearch.Enabled = enable;
            tvEpisode.Enabled = enable;
            tvLink.Enabled = enable;
            pictureBox1.Visible = !enable;
            lstFavs.Enabled = enable;
            btnRefresh.Enabled = enable;
            btnRefreshHard.Enabled = enable;
        }
        private string website;
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                Enable(false);
                tvSearch.Nodes.Clear();
                tvEpisode.Nodes.Clear();
                tvLink.Nodes.Clear();

                var all = await WSUtility.CallWS<Dictionary<string, List<ListedShow>>>("tv", "search", "all", txtSearch.Text);
                foreach (string w in all.Keys)
                {
                    TreeNode tn = new TreeNode(w);
                    tvSearch.Nodes.Add(tn);

                    foreach (ListedShow ls in all[w])
                        tn.Nodes.Add(new EMCTreeNode<ListedShow>(ls));
                }
                Enable(true);
            }
        }

        private void tvSearch_DoubleClick(object sender, EventArgs e)
        {
            EMCTreeNode<ListedShow> etn = tvSearch.SelectedNode as EMCTreeNode<ListedShow>;
            if (etn != null)
            {
                website = etn.Parent.Text;
                LoadShow(website, etn.Info);
            }
        }

        private async void LoadShow(string website, ListedShow ls)
        {
            Enable(false);
            tvEpisode.Nodes.Clear();
            tvLink.Nodes.Clear();
            var show = await WSUtility.CallWS<TvShow>("tv", "show", website, ls.Name);
            if (show != null)
            {
                foreach (int s in show.Episodes.Keys)
                {
                    TreeNode tn = new TreeNode("Season " + s);

                    tvEpisode.Nodes.Add(tn);

                    foreach (ListedEpisode le in show.Episodes[s])
                    {
                        EMCTreeNode<ListedEpisode> tn2 = new EMCTreeNode<ListedEpisode>(le);
                        tn.Nodes.Add(tn2);
                    }
                }
            }
            Enable(true);
        }

        private async void tvEpisode_DoubleClick(object sender, EventArgs e)
        {
            EMCTreeNode<ListedEpisode> etn = tvEpisode.SelectedNode as EMCTreeNode<ListedEpisode>;
            if (etn != null)
            {
                Enable(false);
                tvLink.Nodes.Clear();
                var ep = await WSUtility.CallWS<Episode>("tv", "episode", website, etn.Info.Name);
                foreach (string w in ep.Links.Keys)
                {
                    TreeNode tn = new TreeNode(w);

                    tvLink.Nodes.Add(tn);
                    int i = 1;
                    foreach (string l in ep.Links[w])
                    {
                        EMCTreeNode<ListedLink> tn2 = new EMCTreeNode<ListedLink>(new ListedLink() { Name = l, Title = "Link #" + i, Website = w });
                        tn.Nodes.Add(tn2);
                        ++i;
                    }
                }
                Enable(true);
            }
        }

        private async void tvLink_DoubleClick(object sender, EventArgs e)
        {
            EMCTreeNode<ListedLink> etn = tvLink.SelectedNode as EMCTreeNode<ListedLink>;
            if (etn != null)
            {
                Enable(false);
                var si = await WSUtility.CallWS<StreamingInfo>("tv", "stream", website, etn.Info.Website, etn.Info.Name);
                
                if (!String.IsNullOrWhiteSpace(si.DownloadURL))
                    Process.Start(si.DownloadURL);
                else if (!String.IsNullOrWhiteSpace(si.StreamingURL))
                    Process.Start(si.StreamingURL);

                Enable(true);
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void lstFavs_DoubleClick(object sender, EventArgs e)
        {
            FavoriteTvShow fts = lstFavs.SelectedItem as FavoriteTvShow;
            if (fts != null)
                LoadShow(fts.Website, fts);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            Enable(false);
            tvEpisode.Nodes.Clear();
            tvLink.Nodes.Clear();
            lstFavs.Items.Clear();
            lstFavs.Items.AddRange((await m_Session.Favorites()).ToArray());
            Enable(true);
        }

        private async void btnRefreshHard_Click(object sender, EventArgs e)
        {
            Enable(false);
            await WSUtility.CallWS<StreamingInfo>("bot", "TvUpdate");
            btnRefresh_Click(sender, e);
        }
    }
}
