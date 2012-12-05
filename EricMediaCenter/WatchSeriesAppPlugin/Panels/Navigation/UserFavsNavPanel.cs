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
    public partial class UserFavsNavPanel : NavPanel
    {
        public UserFavsNavInfo UserFavsInfo { get { return Info as UserFavsNavInfo; } }
        public UserFavsNavPanel()
        {
            InitializeComponent();
        }
        protected override void InfoSetted(NavInfo oldI, NavInfo newI)
        {
            base.InfoSetted(oldI, newI);
            UserFavsNavInfo nfo = newI as UserFavsNavInfo;
            RefreshList(nfo.User);
        }
        protected override void info_UserSetted(object sender, UserEventArgs args)
        {
            base.info_UserSetted(sender, args);
        }

        public void RefreshList(UserInfo u)
        {
            if (u == null)
            {
                lstNewEpShows.Items.Clear();
                lstOtherShows.Items.Clear();
            }
            else
            {
                lstNewEpShows.Items.Clear();
                lstOtherShows.Items.Clear();
                if (u.GetFavs())
                {
                    foreach (UserFavoriteInfo ufi in u.Favorites.Values)
                    {
                        if (ufi.LastSeason == ufi.LastViewedSeason && ufi.LastEpisode == ufi.LastViewedEpisode)
                            lstOtherShows.Items.Add(ufi);
                        else
                            lstNewEpShows.Items.Add(ufi);
                    }
                }
                else
                    MessageBox.Show(u.LastMessage);
            }
        }

        private void lstShows_DoubleClick(object sender, EventArgs e)
        {
            ListBox listBox1 = sender as ListBox;
            if (listBox1.SelectedIndex >= 0)
            {
                UserFavoriteInfo fav = (UserFavoriteInfo)listBox1.SelectedItem;
                ShowSummaryInfo ssi = new ShowSummaryInfo(fav.ShowName, fav.ShowTitle, -1);
                TvShowNavInfo nfo = new TvShowNavInfo(ssi, Info.FutureParents, Info.User);
                Navigate(nfo);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Navigate(new SearchNavInfo(Info.FutureParents, Info.User));
        }
    }
}
