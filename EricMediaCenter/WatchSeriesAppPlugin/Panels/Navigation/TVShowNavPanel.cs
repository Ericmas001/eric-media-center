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
            RefreshFavs();
            base.InfoSetted(oldI, newI);
        }
        private void RefreshFavs()
        {
            if (TVShowInfo.Favorite != null && TVShowInfo.Favorite.LastViewedSeason > 0)
                lblLastViewed.Text = String.Format("Last Viewed: S{0:00}E{1:00}", TVShowInfo.Favorite.LastViewedSeason, TVShowInfo.Favorite.LastViewedEpisode);
            else
                lblLastViewed.Text = "";
            lstSeasons.Refresh();
            lstEpisodes.Refresh();
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
            RefreshFavs();
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
                case TvShowFavBtnState.NoFav:
                    {
                        Info.User.AddFav(TVShowInfo.ShowSummary.Name);
                        break;
                    }
                case TvShowFavBtnState.Fav:
                    {
                        Info.User.DelFav(TVShowInfo.ShowSummary.Name);
                        break;
                    }
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

        private void setAsViewedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstEpisodes.SelectedIndex >= 0)
            {
                EpisodeSummaryInfo esi = (EpisodeSummaryInfo)lstEpisodes.SelectedItem;
                Info.User.SetLastViewed(esi.Season.Show.Name, esi.Season.No, esi.No);
                RefreshFavs();
            }
        }

        private void setAsNotViewedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstEpisodes.SelectedIndex >= 0)
            {
                EpisodeSummaryInfo esi = (EpisodeSummaryInfo)lstEpisodes.SelectedItem;
                EpisodeSummaryInfo pesi = esi.GetPreviousEpisode();
                Info.User.SetLastViewed(esi.Season.Show.Name, pesi == null ? -1 : pesi.Season.No, pesi == null ? -1 : pesi.No);
                RefreshFavs();
            }
        }

        private void cmsEpisodes_Opening(object sender, CancelEventArgs e)
        {
            if (lstEpisodes.SelectedIndex < 0 || TVShowInfo.Favorite == null)
            {
                e.Cancel = true;
                return;
            }
            EpisodeSummaryInfo esi = (EpisodeSummaryInfo)lstEpisodes.SelectedItem;
            UserFavoriteInfo ufi = TVShowInfo.Favorite;
            bool viewed = esi.Season.No < ufi.LastViewedSeason || (esi.Season.No == ufi.LastViewedSeason && esi.No <= ufi.LastViewedEpisode);
            setAsNotViewedToolStripMenuItem.Visible = viewed;
            setAsViewedToolStripMenuItem.Visible = !viewed;
        }

        private void lstEpisodes_MouseDown(object sender, MouseEventArgs e)
        {
            int indexover = lstEpisodes.IndexFromPoint(e.X, e.Y);
            if (indexover >= 0 && indexover < lstEpisodes.Items.Count)
                lstEpisodes.SelectedIndex = indexover;
            else
                lstEpisodes.SelectedIndex = -1;
        }

        private void lstEpisodes_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0 && lstEpisodes.Items.Count > e.Index)
            {
                EpisodeSummaryInfo ei = (EpisodeSummaryInfo)lstEpisodes.Items[e.Index];
                UserFavoriteInfo ufi = TVShowInfo.Favorite;
                bool isNew = true;
                if (ufi == null)
                    isNew = false;
                else if (ufi.LastViewedSeason == -1 || ufi.LastViewedEpisode == -1)
                    isNew = true;
                else if (ei.Season.No < ufi.LastViewedSeason)
                    isNew = false;
                else if (ufi.LastViewedSeason == ei.Season.No && ei.No <= ufi.LastViewedEpisode)
                    isNew = false;
                e.Graphics.DrawString(ei.ToString(), new Font(lstEpisodes.Font.FontFamily, lstEpisodes.Font.Size, isNew ? FontStyle.Bold : FontStyle.Regular), Brushes.Black, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void lstSeasons_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0 && lstSeasons.Items.Count > e.Index)
            {
                SeasonInfo si = (SeasonInfo)lstSeasons.Items[e.Index];
                UserFavoriteInfo ufi = TVShowInfo.Favorite;
                bool isNew = true;
                if (ufi == null)
                    isNew = false;
                else if (ufi.LastViewedSeason == -1)
                    isNew = true;
                else if (si.No < ufi.LastViewedSeason)
                    isNew = false;
                else if (ufi.LastViewedSeason ==si.No && si.Episodes.Last().Key <= ufi.LastViewedEpisode)
                    isNew = false;
                e.Graphics.DrawString(si.ToString(), new Font(lstEpisodes.Font.FontFamily, lstEpisodes.Font.Size, isNew ? FontStyle.Bold : FontStyle.Regular), Brushes.Black, e.Bounds);
            }
            e.DrawFocusRectangle();
        }
    }
}
