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
        string m_Website;
        TvShow m_Show;
        Episode m_Episode;
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
            btnAddFavorites.Enabled = enable && m_Show != null;
            btnDelFavorites.Enabled = enable && m_Show != null;
            btnLastViewed.Enabled = enable && m_Episode != null;
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                Enable(false);
                ClearSearch();

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
                ClearShow();
                m_Website = etn.Parent.Text;
                LoadShow(etn.Info);
            }
        }

        private async void LoadShow(ListedShow ls)
        {
            Enable(false);
            m_Show = await WSUtility.CallWS<TvShow>("tv", "show", m_Website, ls.Name);
            lblShow.Text = m_Show.Title;
            if (m_Show != null)
            {
                foreach (int s in m_Show.Episodes.Keys)
                {
                    TreeNode tn = new TreeNode("Season " + s);

                    tvEpisode.Nodes.Add(tn);

                    foreach (ListedEpisode le in m_Show.Episodes[s])
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
                ClearEpisode();
                m_Episode = await WSUtility.CallWS<Episode>("tv", "episode", m_Website, etn.Info.Name);
                lblEpisode.Text = String.Format("S{0:00}E{1:00}", m_Episode.NoSeason, m_Episode.NoEpisode);
                foreach (string w in m_Episode.Links.Keys)
                {
                    TreeNode tn = new TreeNode(w);

                    tvLink.Nodes.Add(tn);
                    int i = 1;
                    foreach (string l in m_Episode.Links[w])
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
                var si = await WSUtility.CallWS<StreamingInfo>("tv", "stream", m_Website, etn.Info.Website, etn.Info.Name);
                
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
            {
                ClearShow();
                m_Website = fts.Website;
                LoadShow(fts);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            Enable(false);
            ClearFavs();
            lstFavs.Items.AddRange((await m_Session.Favorites()).ToArray());
            Enable(true);
        }

        private async void btnRefreshHard_Click(object sender, EventArgs e)
        {
            Enable(false);
            await WSUtility.CallWS<StreamingInfo>("bot", "TvUpdate");
            btnRefresh_Click(sender, e);
        }

        private async void btnAddFavorites_Click(object sender, EventArgs e)
        {
            Enable(false);
            if (!(await m_Session.AddFav(m_Website, m_Show.Name, m_Show.Title, m_Show.NoLastSeason, m_Show.NoLastEpisode)))
                MessageBox.Show("Une erreur est survenue :(");
            btnRefresh_Click(sender, e);
        }

        private async void btnDelFavorites_Click(object sender, EventArgs e)
        {
            Enable(false);
            if (!(await m_Session.DelFav(m_Website, m_Show.Name)))
                MessageBox.Show("Une erreur est survenue :(");
            btnRefresh_Click(sender, e);
        }

        private void ClearEpisode()
        {
            tvLink.Nodes.Clear();
            m_Episode = null;
            lblEpisode.Text = "";
        }
        private void ClearShow()
        {
            tvEpisode.Nodes.Clear();
            m_Show = null;
            m_Website = null;
            lblShow.Text = "";
            ClearEpisode();
        }
        
        private void ClearFavs()
        {
            lstFavs.Items.Clear();
        }
        private void ClearSearch()
        {
            tvSearch.Nodes.Clear();
            ClearShow();
        }

        private async void btnLastViewed_Click(object sender, EventArgs e)
        {
            Enable(false);
            if (!(await m_Session.SetLastViewed(m_Website, m_Show.Name, m_Episode.NoSeason, m_Episode.NoEpisode)))
                MessageBox.Show("Une erreur est survenue :(");
            btnRefresh_Click(sender, e);
        }
    }
}
