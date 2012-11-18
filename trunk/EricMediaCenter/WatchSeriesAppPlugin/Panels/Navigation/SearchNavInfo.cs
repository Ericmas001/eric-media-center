using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchSeriesAppPlugin.Panels.Navigation.Core;
using WatchSeriesAppPlugin.Entities;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public class SearchNavInfo : NavInfo
    {
        private string m_Keywords;
        private List<string> m_Choices = new List<string>();
        private List<ShowSummaryInfo> m_Results = new List<ShowSummaryInfo>();
        private bool m_IsLetter = false;

        public string Keywords
        {
            get { return m_Keywords; }
            set { m_Keywords = value; }
        }

        public List<string> Choices
        {
            get { return m_Choices; }
            set { m_Choices = value; }
        }

        public List<ShowSummaryInfo> Results
        {
            get { return m_Results; }
            set { m_Results = value; }
        }

        public bool IsLetter
        {
            get { return m_IsLetter; }
            set { m_IsLetter = value; }
        }
        public SearchNavInfo(NavInfo[] parents, UserInfo user)
            : base("Search", NavType.Search, parents, user)
        {
        }
    }
}
