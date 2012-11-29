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
                LinkInfo l = (LinkInfo)lstWebsites.SelectedItem;
                for (int i = l.Ids.Count - 1; i >= 0; --i)
                    lstLinks.Items.Add("Link #" + (l.Ids.Count - i));
            }
        }
    }
}
