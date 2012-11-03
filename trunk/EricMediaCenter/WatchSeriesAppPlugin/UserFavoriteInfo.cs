using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WatchSeriesAppPlugin
{
    public class UserFavoriteInfo
    {
        private string m_ShowName;
        private string m_ShowTitle;
        private int m_LastSeason;
        private int m_LastEpisode;
        private int m_LastViewedSeason;
        private int m_LastViewedEpisode;

        public string ShowName
        {
            get { return m_ShowName; }
            set { m_ShowName = value; }
        }

        public string ShowTitle
        {
            get { return m_ShowTitle; }
            set { m_ShowTitle = value; }
        }
        public int LastSeason
        {
            get { return m_LastSeason; }
            set { m_LastSeason = value; }
        }

        public int LastEpisode
        {
            get { return m_LastEpisode; }
            set { m_LastEpisode = value; }
        }

        public int LastViewedSeason
        {
            get { return m_LastViewedSeason; }
            set { m_LastViewedSeason = value; }
        }

        public int LastViewedEpisode
        {
            get { return m_LastViewedEpisode; }
            set { m_LastViewedEpisode = value; }
        }
        public UserFavoriteInfo(string showName, string showTitle, int lastSeason, int lastEpisode, int lastViewedSeason, int lastViewedEpisode)
        {
            m_ShowName = showName;
            m_ShowTitle = showTitle;
            m_LastSeason = lastSeason;
            m_LastEpisode = lastEpisode;
            m_LastViewedSeason = lastViewedSeason;
            m_LastViewedEpisode = lastViewedEpisode;
        }
        public override string ToString()
        {
            return m_ShowTitle + " (" + m_ShowName + "): LastEpisode: " + m_LastSeason + "x" + m_LastEpisode + ", Watched: " + m_LastViewedSeason + "x" + m_LastViewedEpisode;
        }
    }
}
