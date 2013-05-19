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
        public MainForm()
        {
            InitializeComponent();
        }
        private void Enable(bool enable)
        {
            txtSearch.Enabled = enable;
            btnSearch.Enabled = enable;
            tvSearch.Enabled = enable;
            tvEpisode.Enabled = enable;
            tvLink.Enabled = enable;
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

                Dictionary<string, List<ListedShow>> all = JsonConvert.DeserializeObject<Dictionary<string, List<ListedShow>>>(await WSUtility.CallWS("http://emc.ericmas001.com/tv/search/all/" + txtSearch.Text));

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

        private async void tvSearch_DoubleClick(object sender, EventArgs e)
        {
            EMCTreeNode<ListedShow> etn = tvSearch.SelectedNode as EMCTreeNode<ListedShow>;
            if (etn != null)
            {
                Enable(false);
                tvEpisode.Nodes.Clear();
                tvLink.Nodes.Clear();
                website = etn.Parent.Text;
                TvShow show = JsonConvert.DeserializeObject<TvShow>(await WSUtility.CallWS("http://emc.ericmas001.com/tv/show/" + website + "/" + etn.Info.Name));
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
                Enable(true);
            }
        }

        private async void tvEpisode_DoubleClick(object sender, EventArgs e)
        {
            EMCTreeNode<ListedEpisode> etn = tvEpisode.SelectedNode as EMCTreeNode<ListedEpisode>;
            if (etn != null)
            {
                Enable(false);
                tvLink.Nodes.Clear();
                Episode ep = JsonConvert.DeserializeObject<Episode>(await WSUtility.CallWS("http://emc.ericmas001.com/tv/episode/" + website + "/" + etn.Info.Name));
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
                string url = "http://emc.ericmas001.com/tv/stream/" + website + "/" + etn.Info.Website + "/" + etn.Info.Name;
                StreamingInfo si = JsonConvert.DeserializeObject<StreamingInfo>(await WSUtility.CallWS(url));

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
    }
}
