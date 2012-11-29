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
    public partial class TVShowNavPanel : NavPanel
    {
        public TvShowNavInfo TVShowInfo { get { return Info as TvShowNavInfo; } }
        public TVShowNavPanel()
        {
            InitializeComponent();
        }
        protected override void InfoSetted(NavInfo oldI, NavInfo newI)
        {
            lblShowTitle.Text = Info.Name;
            lstSeasons.Items.Clear();
            lstEpisodes.Items.Clear();
            if (TVShowInfo.ShowFull != null)
                lstSeasons.Items.AddRange(TVShowInfo.ShowFull.Seasons.Values.ToArray());
            switch (TVShowInfo.State)
            {
                case TvShowFavBtnState.NoUser: btnFav.BackgroundImage = Properties.Resources.favorite_add_disab; break;
                case TvShowFavBtnState.NoFav: btnFav.BackgroundImage = Properties.Resources.favorite_add; break;
                case TvShowFavBtnState.Fav: btnFav.BackgroundImage = Properties.Resources.favorite_remove; break;
            }
            base.InfoSetted(oldI, newI);
        }
        protected override void info_UserSetted(object sender, UserEventArgs args)
        {
            base.info_UserSetted(sender, args);
            switch (TVShowInfo.State)
            {
                case TvShowFavBtnState.NoUser: btnFav.BackgroundImage = Properties.Resources.favorite_add_disab; break;
                case TvShowFavBtnState.NoFav: btnFav.BackgroundImage = Properties.Resources.favorite_add; break;
                case TvShowFavBtnState.Fav: btnFav.BackgroundImage = Properties.Resources.favorite_remove; break;
            }
        }
        private void btnFav_Click(object sender, EventArgs e)
        {
            UserInfo old = Info.User;
            switch (TVShowInfo.State)
            {
                case TvShowFavBtnState.NoUser: 
                    {
                        if (MessageBox.Show("This feature is only available to registered users. Do you want to register ?", "Not Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //Open a RegisterNavPanel
                        };
                        break;
                    }
                case TvShowFavBtnState.NoFav: Info.User.AddFav(TVShowInfo.ShowSummary.Name); break;
                case TvShowFavBtnState.Fav: Info.User.DelFav(TVShowInfo.ShowSummary.Name); break;
            }
            Info.FireUserSetted(old,Info.User);
        }

        private void lstSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( lstSeasons.SelectedIndex >= 0 )
            {
                lstEpisodes.Items.Clear();
                SeasonInfo s = (SeasonInfo)lstSeasons.SelectedItem;
                lstEpisodes.Items.AddRange(s.Episodes.Values.ToArray());
            }
        }

        private void lstEpisodes_DoubleClick(object sender, EventArgs e)
        {
            if (lstEpisodes.SelectedIndex >= 0)
            {
                EpisodeSummaryInfo esi = (EpisodeSummaryInfo)lstEpisodes.SelectedItem;
                TVEpisodeNavInfo epNfo = new TVEpisodeNavInfo(esi, esi.GetPreviousEpisode(), esi.GetNextEpisode(), Info.FutureParents, Info.User);
                Navigate(epNfo);
            }
        }
    }
}
