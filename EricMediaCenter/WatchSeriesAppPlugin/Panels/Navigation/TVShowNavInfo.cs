using WatchSeriesAppPlugin.Entities;
using WatchSeriesAppPlugin.Panels.Navigation.Core;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public enum TvShowFavBtnState
    {
        NoUser,
        NoFav,
        Fav
    }

    public class TvShowNavInfo : NavInfo
    {
        private ShowSummaryInfo m_ShowSummary;
        private ShowInfo m_ShowFull;

        public UserFavoriteInfo Favorite
        {
            get
            {
                if (User != null && User.Favorites.ContainsKey(m_ShowSummary.Name))
                    return User.Favorites[m_ShowSummary.Name];
                return null;
            }
        }

        public ShowSummaryInfo ShowSummary
        {
            get { return m_ShowSummary; }
            set { m_ShowSummary = value; }
        }

        public ShowInfo ShowFull
        {
            get { return m_ShowFull; }
            set { m_ShowFull = value; }
        }

        public TvShowFavBtnState State
        {
            get
            {
                if (User == null)
                    return TvShowFavBtnState.NoUser;
                else if (User.Favorites.ContainsKey(m_ShowSummary.Name))
                    return TvShowFavBtnState.Fav;
                else
                    return TvShowFavBtnState.NoFav;
            }
        }

        public TvShowNavInfo(ShowSummaryInfo nfo, NavInfo[] parents, UserInfo user)
            : base(nfo.Title, NavType.TVShow, parents, user)
        {
            m_ShowSummary = nfo;
            m_ShowFull = m_ShowSummary.LoadShow();
        }
    }
}