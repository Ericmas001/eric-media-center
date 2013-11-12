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
using EMCTv.Entities;
using EMCTv.WebService;
using EMCCommon.VideoParser;
using EMCCommon.Entities;
using EMCCommon.WebService;
using EMCCommon.Windows.Forms;
using VIBlend.Utilities;

namespace EMCTv.Windows.Forms
{
    public partial class MainForm : Form
    {
        private SessionInfo m_Session;
        private FavoriteTvShow m_Fav;
        string m_Website;
        TvShow m_Show;
        Episode m_Episode;
        private IEnumerable<string> m_Websites = new string[0];
        string m_SearchLang = "en";
        string m_ShowLang;
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
            btnSupported.Enabled = enable;
            btnRefresh.Enabled = enable;
            btnRefreshHard.Enabled = enable;
            btnSettings.Enabled = enable;
            btnAddFavorites.Enabled = enable && m_Show != null && m_Fav == null;
            btnDelFavorites.Enabled = enable && m_Show != null && m_Fav != null;
            btnLastViewed.Enabled = enable && m_Episode != null && m_Fav != null;
            btnLoadAll.Enabled = enable && m_Show != null && !m_Show.IsComplete;
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                Enable(false);
                ClearSearch();
                m_Fav = null;
                var all = await WSUtility.CallWS<Dictionary<string, List<ListedShow>>>("tv", "search", m_SearchLang, m_Websites.Count() == 0 ? "all" : "some_" + String.Join("_", m_Websites), txtSearch.Text);
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
                            foreach (ListedShow ls in all[w])
                                tn.Nodes.Add(new EMCTreeNode<ListedShow>(ls));
                        else
                            tn.Nodes.Add(new TreeNode("An error occured ...") {ForeColor = Color.Gray });
                    }
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
                m_Fav = null;
                m_Website = etn.Parent.Text;
                m_ShowLang = m_SearchLang;
                LoadShow(etn.Info, false);
            }
        }

        private async void LoadShow(ListedShow ls, bool full)
        {
            Enable(false);
            string command = full ? "showFull" : "show";
            m_Show = await WSUtility.CallWS<TvShow>("tv", command, m_ShowLang, m_Website, ls.Name);
            EMCTreeNode<ListedEpisode> nextEpisode = null;
            if (m_Show == null)
                MessageBox.Show("An error occured !");
            else
            {
                lblShow.Text = m_Show.Title;
                nextEpisode = PeupleShow();
            }
            Enable(true);
            if (nextEpisode != null)
            {
                tvEpisode.SelectedNode = nextEpisode;
                nextEpisode.EnsureVisible();
                tvEpisode_DoubleClick(tvEpisode, new EventArgs());
            }
        }

        private EMCTreeNode<ListedEpisode> PeupleShow()
        {
            EMCTreeNode<ListedEpisode> nextEpisode = null;
            if (m_Show != null)
            {
                foreach (int s in m_Show.Episodes.Keys)
                {
                    TreeNode tn = new TreeNode("Season " + s);

                    tvEpisode.Nodes.Add(tn);
                    bool allviewed = true;
                    foreach (ListedEpisode le in m_Show.Episodes[s])
                    {
                        EMCTreeNode<ListedEpisode> tn2 = new EMCTreeNode<ListedEpisode>(le);
                        if (m_Fav != null && (tn2.Info.NoSeason < m_Fav.LastViewedSeason || (tn2.Info.NoSeason == m_Fav.LastViewedSeason && tn2.Info.NoEpisode <= m_Fav.LastViewedEpisode)))
                            tn2.ForeColor = Color.DarkGray;
                        else
                        {
                            if (nextEpisode == null)
                                nextEpisode = tn2;
                            tn2.ForeColor = Color.Black;
                            allviewed = false;
                        }
                        tn.Nodes.Add(tn2);
                    }
                    if (allviewed)
                        tn.ForeColor = Color.DarkGray;
                    else
                        tn.ForeColor = Color.Black;
                }
            }
            return nextEpisode;
        }

        private async void tvEpisode_DoubleClick(object sender, EventArgs e)
        {
            EMCTreeNode<ListedEpisode> etn = tvEpisode.SelectedNode as EMCTreeNode<ListedEpisode>;
            if (etn != null)
            {
                Enable(false);
                ClearEpisode();
                m_Episode = await WSUtility.CallWS<Episode>("tv", "episode", m_ShowLang, m_Website, etn.Info.Name);

                if (m_Episode == null)
                    MessageBox.Show("An error occured !");
                else
                {
                    lblEpisode.Text = String.Format("S{0:00}E{1:00}", m_Episode.NoSeason, m_Episode.NoEpisode);
                    AddLinks(m_Episode.Links.Keys.Where(w => VideoParsingFactory.Parsers.ContainsKey(w)), Color.Blue);
                    AddLinks(m_Episode.Links.Keys.Where(w => !VideoParsingFactory.Parsers.ContainsKey(w)), Color.Black);
                }
                Enable(true);
            }
        }
        private void AddLinks(IEnumerable<string> websites, Color color)
        {
            foreach (string w in websites)
            {
                TreeNode tn = new TreeNode(w);
                tn.ForeColor = color;
                tvLink.Nodes.Add(tn);
                int i = 1;
                foreach (string l in m_Episode.Links[w])
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
                var si = await WSUtility.CallWS<StreamingInfo>("tv", "stream", m_ShowLang, m_Website, etn.Info.Website, etn.Info.Name);
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
                                new OpenURLForm(si, String.Format("{0} S{1:00}E{2:00}.flv", m_Show.Title, m_Episode.NoSeason, m_Episode.NoEpisode)).ShowDialog();
                                if( m_Fav != null )
                                    await SetLastViewed(m_Episode.NoSeason, m_Episode.NoEpisode);
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
                }
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
                m_Fav = fts;
                m_Website = fts.Website;
                m_ShowLang = fts.Lang;
                LoadShow(fts, false);
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
            if (!(await m_Session.AddFav(m_ShowLang, m_Website, m_Show.Name, m_Show.Title, m_Show.NoLastSeason, m_Show.NoLastEpisode)))
                MessageBox.Show("Une erreur est survenue :(");
            ClearFavs();
            lstFavs.Items.AddRange((await m_Session.Favorites()).ToArray());
            lstFavs.SelectedItem = lstFavs.Items.OfType<FavoriteTvShow>().First(x => x.ShowName == m_Show.Name && x.Website == m_Website && x.Lang == m_ShowLang);
            lstFavs_DoubleClick(sender, e);
        }

        private async void btnDelFavorites_Click(object sender, EventArgs e)
        {
            Enable(false);
            if (!(await m_Session.DelFav(m_ShowLang, m_Website, m_Show.Name)))
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
            m_ShowLang = null;
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
            await SetLastViewed(m_Episode.NoSeason, m_Episode.NoEpisode);
        }


        private async void setAsLastViewedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMCTreeNode<ListedEpisode> etn = tvEpisode.SelectedNode as EMCTreeNode<ListedEpisode>;
            await SetLastViewed(etn.Info.NoSeason, etn.Info.NoEpisode);
        }
        private async Task<bool> SetLastViewed(int sId, int eId)
        {
            Enable(false);
            if (!(await m_Session.SetLastViewed(m_ShowLang, m_Website, m_Show.Name, sId, eId)))
            {
                MessageBox.Show("Une erreur est survenue :(");
                return false;
            }
            else
            {
                m_Fav.LastViewedSeason = sId;
                m_Fav.LastViewedEpisode = eId;
                tvEpisode.Nodes.Clear();
                PeupleShow();
                foreach (TreeNode tn in tvEpisode.Nodes)
                    foreach (EMCTreeNode<ListedEpisode> et in tn.Nodes)
                        if (et.Info.NoSeason == sId && et.Info.NoEpisode == eId)
                            et.EnsureVisible();
            }
            btnRefresh_Click(null, new EventArgs());
            return true;
        }

        private void lstFavs_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            FavoriteTvShow fts = lstFavs.Items[e.Index] as FavoriteTvShow;
            Font font = fts.IsAllViewed ? lstFavs.Font : new Font(lstFavs.Font, FontStyle.Bold);
            Color c = lstFavs.ForeColor;
            if (!lstFavs.Enabled)
                c = ControlPaint.Light(c, 42);
            e.Graphics.DrawString(lstFavs.Items[e.Index].ToString(), font, new SolidBrush(c), e.Bounds);
            e.DrawFocusRectangle();
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            ListedShow ls = m_Show;
            string website = m_Website;
            string lang = m_ShowLang;
            ClearShow();
            m_Website = website;
            m_ShowLang = lang;
            LoadShow(ls, true);
        }

        private void lstFavs_MouseDown(object sender, MouseEventArgs e)
        {
            lstFavs.SelectedIndex = lstFavs.IndexFromPoint(e.Location);
        }

        private async void removeFromFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FavoriteTvShow fts = lstFavs.SelectedItem as FavoriteTvShow;
            if (fts != null)
            {
                Enable(false);
                if (!(await m_Session.DelFav(fts.Lang, fts.Website, fts.ShowName)))
                    MessageBox.Show("Une erreur est survenue :(");
                btnRefresh_Click(sender, e);
            }
        }

        private async void openInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FavoriteTvShow fts = lstFavs.SelectedItem as FavoriteTvShow;
            if (fts != null)
            {
                Enable(false);
                var si = await WSUtility.CallWS<string>("tv", "ShowURL", fts.Lang, fts.Website, fts.ShowName);
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

        private async void openInBrowserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EMCTreeNode<ListedShow> etn = tvSearch.SelectedNode as EMCTreeNode<ListedShow>;
            if (etn != null)
            {
                Enable(false);
                var si = await WSUtility.CallWS<string>("tv", "ShowURL", m_SearchLang, etn.Parent.Text, etn.Info.Name);
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

        private async void addToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMCTreeNode<ListedShow> etn = tvSearch.SelectedNode as EMCTreeNode<ListedShow>;
            if (etn != null)
            {
                Enable(false);
                if (!(await m_Session.AddFav(m_SearchLang, etn.Parent.Text, etn.Info.Name, etn.Info.Title, 0, 0)))
                    MessageBox.Show("Une erreur est survenue :(");
                if (m_SearchLang == m_ShowLang && etn.Parent.Text == m_Website && m_Show != null && etn.Info.Name == m_Show.Name)
                {
                    ClearFavs();
                    lstFavs.Items.AddRange((await m_Session.Favorites()).ToArray());
                    lstFavs.SelectedItem = lstFavs.Items.OfType<FavoriteTvShow>().First(x => x.ShowName == m_Show.Name && x.Website == m_Website && x.Lang == m_ShowLang);
                    lstFavs_DoubleClick(sender, e);
                }
                else
                    btnRefresh_Click(sender, e);
            }
        }

        private void ctxtFavs_Opening(object sender, CancelEventArgs e)
        {
            FavoriteTvShow fts = lstFavs.SelectedItem as FavoriteTvShow;
            if (fts == null)
                e.Cancel = true;
        }

        private void ctxtSearch_Opening(object sender, CancelEventArgs e)
        {
            EMCTreeNode<ListedShow> etn = tvSearch.SelectedNode as EMCTreeNode<ListedShow>;
            if (etn == null)
                e.Cancel = true;
        }

        private void tvSearch_MouseDown(object sender, MouseEventArgs e)
        {
            tvSearch.SelectedNode = tvSearch.GetNodeAt(e.X, e.Y);
        }

        private void tvEpisode_MouseDown(object sender, MouseEventArgs e)
        {
            tvEpisode.SelectedNode = tvEpisode.GetNodeAt(e.X, e.Y);
        }

        private void tvLink_MouseDown(object sender, MouseEventArgs e)
        {
            tvLink.SelectedNode = tvLink.GetNodeAt(e.X, e.Y);
        }

        private void ctxtEpisode_Opening(object sender, CancelEventArgs e)
        {
            EMCTreeNode<ListedEpisode> etn = tvEpisode.SelectedNode as EMCTreeNode<ListedEpisode>;
            if (etn == null)
                e.Cancel = true;
            setAsLastViewedToolStripMenuItem.Visible = m_Fav != null;
        }

        private void ctxtLinks_Opening(object sender, CancelEventArgs e)
        {
            EMCTreeNode<ListedLink> etn = tvLink.SelectedNode as EMCTreeNode<ListedLink>;
            if (etn == null)
                e.Cancel = true;
        }

        private async void openInBrowserToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EMCTreeNode<ListedLink> etn = tvLink.SelectedNode as EMCTreeNode<ListedLink>;
            if (etn != null)
            {
                Enable(false);
                var si = await WSUtility.CallWS<StreamingInfo>("tv", "stream", m_ShowLang, m_Website, etn.Info.Website, etn.Info.Name);
                if (si == null)
                    MessageBox.Show("An error occured !");
                else
                    Process.Start(si.StreamingURL);
                Enable(true);
            }
        }

        private async void openInBrowserToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            EMCTreeNode<ListedEpisode> etn = tvEpisode.SelectedNode as EMCTreeNode<ListedEpisode>;
            if (etn != null)
            {
                Enable(false);
                var si = await WSUtility.CallWS<string>("tv", "EpisodeURL", m_ShowLang, m_Website, etn.Info.Name);
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

        private async void btnSupported_Click(object sender, EventArgs e)
        {
            Enable(false);
            Dictionary<string, IEnumerable<string>> all = await WSUtility.CallWS<Dictionary<string, IEnumerable<string>>>("tv", "supported");
            SelectSupportedForm ssf = new SelectSupportedForm(all, m_Websites, m_SearchLang);
            ssf.ShowDialog();
            m_Websites = ssf.Choosen;
            m_SearchLang = ssf.Lang;
            Enable(true);
        }

        private void findOnOtherWebsitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FavoriteTvShow fts = lstFavs.SelectedItem as FavoriteTvShow;
            tabControl1.SelectedTab = tabPage2;
            txtSearch.Text = fts.Title;
            btnSearch_Click(sender, e);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new GlobalSettingsForm().ShowDialog();
        }
    }
}
