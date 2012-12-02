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
using System.Diagnostics;

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
                lstLinks.Items.AddRange(l.LinkIds.ToArray());
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
                LinkSummaryInfo lsi = (LinkSummaryInfo)lstLinks.SelectedItem;
                LinkInfo li = lsi.LoadLink();
                Process.Start(li.FullUrl);
                //li.
                //TVEpisodeNavInfo epNfo = new TVEpisodeNavInfo(esi, esi.GetPreviousEpisode(), esi.GetNextEpisode(), Info.FutureParents, Info.User);
                //Navigate(epNfo);
            }
        }
    }
}
