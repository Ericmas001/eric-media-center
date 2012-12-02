using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatchSeriesAppPlugin.Entities;
using EMCMasterPluginLib;
using System.Collections;
using WatchSeriesAppPlugin.Panels.Navigation.Core;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public partial class TVEpisodeNavPanel : NavPanel
    {
        public TVEpisodeNavInfo TVEpisodeInfo { get { return Info as TVEpisodeNavInfo; } }
        public TVEpisodeNavPanel()
        {
            InitializeComponent();
        }
        protected override void InfoSetted(NavInfo oldI, NavInfo newI)
        {
            lblEpisodeTitle.Text = Info.Name;
            lstWebsites.Items.Clear();
            lstLinks.Items.Clear();
            if (TVEpisodeInfo.EpisodeFull != null)
                lstWebsites.Items.AddRange(TVEpisodeInfo.EpisodeFull.Links.Values.ToArray());
            btnLast.Visible = TVEpisodeInfo.EpisodePrev != null;
            btnNext.Visible = TVEpisodeInfo.EpisodeNext != null;
            base.InfoSetted(oldI, newI);
        }
        protected override void info_UserSetted(object sender, UserEventArgs args)
        {
            base.info_UserSetted(sender, args);
        }

        private void lstWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( lstWebsites.SelectedIndex >= 0 )
            {
                lstLinks.Items.Clear();
                LinkWebsiteInfo l = (LinkWebsiteInfo)lstWebsites.SelectedItem;
                for (int i = l.LinkIds.Count - 1; i >= 0; --i)
                    lstLinks.Items.Add("Link #" + (l.LinkIds.Count - i));
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            TVEpisodeNavInfo epNfo = new TVEpisodeNavInfo(TVEpisodeInfo.EpisodePrev, TVEpisodeInfo.EpisodePrev.GetPreviousEpisode(), TVEpisodeInfo.EpisodePrev.GetNextEpisode(), Info.Parents, Info.User);
            Navigate(epNfo);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TVEpisodeNavInfo epNfo = new TVEpisodeNavInfo(TVEpisodeInfo.EpisodeNext, TVEpisodeInfo.EpisodeNext.GetPreviousEpisode(), TVEpisodeInfo.EpisodeNext.GetNextEpisode(), Info.Parents, Info.User);
            Navigate(epNfo);
        }

        private void lstLinks_DoubleClick(object sender, EventArgs e)
        {
            if (lstLinks.SelectedIndex >= 0)
            {
                //LinkWebsiteInfo li = (LinkWebsiteInfo)lstLinks.SelectedItem;
                //li.
                //TVEpisodeNavInfo epNfo = new TVEpisodeNavInfo(esi, esi.GetPreviousEpisode(), esi.GetNextEpisode(), Info.FutureParents, Info.User);
                //Navigate(epNfo);
            }
        }
    }
}
