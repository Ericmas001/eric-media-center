using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchSeriesAppPlugin.Panels;
using WatchSeriesAppPlugin.Panels.Navigation;
using WatchSeriesAppPlugin.Panels.Navigation.Core;
using System.Windows.Forms;
using WatchSeriesAppPlugin.Entities;
using EMCMasterPluginLib;

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
        private static TestNavPanel m_PanelTest = new TestNavPanel();
        private static SearchNavPanel m_PanelSearch = new SearchNavPanel();
        private static TVShowNavPanel m_PanelTVShow = new TVShowNavPanel();
        private static LoginPanel m_LoginPanel = new LoginPanel();

        public static LoginPanel LoginPanel
        {
            get { return WSGlobal.m_LoginPanel; }
        }
        private static RegisterPanel m_RegisterPanel = new RegisterPanel();

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

        public static TestNavPanel PanelTest
        {
            get { return WSGlobal.m_PanelTest; }
        }
        public static SearchNavPanel PanelSearch
        {
            get { return WSGlobal.m_PanelSearch; }
        }
        public static TVShowNavPanel PanelTVShow
        {
            get { return WSGlobal.m_PanelTVShow; }
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
                case NavType.Test:
                    {
                        nav = PanelTest;
                        break;
                    }
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
