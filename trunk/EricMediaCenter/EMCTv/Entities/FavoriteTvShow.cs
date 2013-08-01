using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCTv.Entities
{
    public class FavoriteTvShow : ListedShow
    {
        int m_IdShow;

        public int IdShow
        {
            get { return m_IdShow; }
            set { m_IdShow = value; }
        }

        public string ShowName
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        private string m_Website;

        public string Website
        {
            get { return m_Website; }
            set { m_Website = value; }
        }

        public string ShowTitle
        {
            get { return base.Title; }
            set { base.Title = value; }
        }
        int m_LastSeason;

        public int LastSeason
        {
            get { return m_LastSeason; }
            set { m_LastSeason = value; }
        }
        int m_LastEpisode;

        public int LastEpisode
        {
            get { return m_LastEpisode; }
            set { m_LastEpisode = value; }
        }
        int m_LastViewedSeason;

        public int LastViewedSeason
        {
            get { return m_LastViewedSeason; }
            set { m_LastViewedSeason = value; }
        }
        int m_LastViewedEpisode;

        public int LastViewedEpisode
        {
            get { return m_LastViewedEpisode; }
            set { m_LastViewedEpisode = value; }
        }
        int m_AllViewed;

        public int AllViewed
        {
            get { return m_AllViewed; }
            set { m_AllViewed = value; }
        }
        public bool IsAllViewed
        {
            get { return m_AllViewed==1; }
        }
        public override string ToString()
        {
            return base.Title + (String.IsNullOrWhiteSpace(m_Website) ? "" : " (" + m_Website + ")");
        }
    }
}
