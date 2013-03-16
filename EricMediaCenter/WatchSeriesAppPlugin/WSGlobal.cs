using System.Collections.Generic;
using WatchSeriesAppPlugin.Entities;
using WatchSeriesAppPlugin.Panels;
using WatchSeriesAppPlugin.Panels.Navigation;
using WatchSeriesAppPlugin.Panels.Navigation.Core;

namespace WatchSeriesAppPlugin
{
    public static class WSGlobal
    {
        private static UserInfo m_User;

        public static UserInfo User
        {
            get { return WSGlobal.m_User; }
            set { WSGlobal.m_User = value; }
        }

        private static List<string> m_Genres;
        private static List<string> m_Letters;
        private static MainPanel m_PanelMain;
        private static SearchNavPanel m_PanelSearch = new SearchNavPanel();
        private static TVShowNavPanel m_PanelTVShow = new TVShowNavPanel();
        private static TVEpisodeNavPanel m_PanelTVEpisode = new TVEpisodeNavPanel();
        private static UserFavsNavPanel m_PanelUserFavs = new UserFavsNavPanel();

        private static LoginPanel m_LoginPanel = new LoginPanel();
        private static RegisterPanel m_RegisterPanel = new RegisterPanel();

        public static LoginPanel LoginPanel
        {
            get { return WSGlobal.m_LoginPanel; }
        }

        public static RegisterPanel RegisterPanel
        {
            get { return WSGlobal.m_RegisterPanel; }
        }

        public static List<string> Letters
        {
            get { return m_Letters; }
            set { m_Letters = value; }
        }

        public static List<string> Genres
        {
            get { return m_Genres; }
            set { m_Genres = value; }
        }

        public static SearchNavPanel PanelSearch
        {
            get { return WSGlobal.m_PanelSearch; }
        }

        public static TVShowNavPanel PanelTVShow
        {
            get { return WSGlobal.m_PanelTVShow; }
        }

        public static TVEpisodeNavPanel PanelTVEpisode
        {
            get { return WSGlobal.m_PanelTVEpisode; }
        }

        public static UserFavsNavPanel PanelUserFavs
        {
            get { return WSGlobal.m_PanelUserFavs; }
        }

        public static MainPanel PanelMain
        {
            get { return WSGlobal.m_PanelMain; }
            set { WSGlobal.m_PanelMain = value; }
        }

        public static NavPanel Navigate(NavInfo nfo)
        {
            NavPanel nav;

            switch (nfo.TypeNav)
            {
                case NavType.Search:
                    {
                        nav = PanelSearch;
                        break;
                    }
                case NavType.TVShow:
                    {
                        nav = PanelTVShow;
                        break;
                    }
                case NavType.TVEpisode:
                    {
                        nav = PanelTVEpisode;
                        break;
                    }
                case NavType.UserFavs:
                    {
                        nav = PanelUserFavs;
                        break;
                    }
                default:
                    {
                        nav = null;
                        break;
                    }
            }
            nav.Info = nfo;
            return nav;
        }
    }
}