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

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public partial class TVShowNavPanel : NavPanel
    {
        private enum FavoriteState
        {
            NoUser,
            NoFav,
            Fav
        }
        private ShowSummaryInfo m_Show;
        public override string NavName
        {
            get { return m_Show != null ? m_Show.Title : ""; }
        }
        private FavoriteState State
        {
            get
            {
                if (User == null)
                    return FavoriteState.NoUser;
                else if (User.Favorites.ContainsKey(m_Show.Name))
                    return FavoriteState.Fav;
                else
                    return FavoriteState.NoFav;
            }
        }
        public TVShowNavPanel()
        {
            InitializeComponent();
        }
        public void SetShow(ShowSummaryInfo show)
        {
            m_Show = show;
            lblShowTitle.Text = show.Title;
            ShowInfo full = show.LoadShow();
            lstSeasons.Items.Clear();
            lstEpisodes.Items.Clear();
            lstSeasons.Items.AddRange(full.Seasons.Values.ToArray());
        }
        protected override void UserSetted(UserInfo u, UserInfo old)
        {
            base.UserSetted(u, old);
            switch (State)
            {
                case FavoriteState.NoUser: btnFav.BackgroundImage = Properties.Resources.favorite_add_disab; break;
                case FavoriteState.NoFav: btnFav.BackgroundImage = Properties.Resources.favorite_add; break;
                case FavoriteState.Fav: btnFav.BackgroundImage = Properties.Resources.favorite_remove; break;
            }
        }
        private void btnFav_Click(object sender, EventArgs e)
        {
            UserInfo old = User;
            switch (State)
            {
                case FavoriteState.NoUser: 
                    {
                        if (MessageBox.Show("This feature is only available to registered users. Do you want to register ?", "Not Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //Open a RegisterNavPanel
                        };
                        break;
                    }
                case FavoriteState.NoFav: User.AddFav(m_Show.Name); break;
                case FavoriteState.Fav: User.DelFav(m_Show.Name); break;
            }
            UserSetted(User,old);
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
    }
}
