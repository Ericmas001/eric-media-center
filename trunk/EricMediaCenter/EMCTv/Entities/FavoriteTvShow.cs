using System;

namespace EMCTv.Entities
{
    public class FavoriteTvShow : ListedShow
    {
        private int m_IdShow;

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

        private string m_Lang;

        public string Lang
        {
            get { return m_Lang; }
            set { m_Lang = value; }
        }

        public string ShowTitle
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

        private int m_LastSeason;

        public int LastSeason
        {
            get { return m_LastSeason; }
            set { m_LastSeason = value; }
        }

        private int m_LastEpisode;

        public int LastEpisode
        {
            get { return m_LastEpisode; }
            set { m_LastEpisode = value; }
        }

        private int m_LastViewedSeason;

        public int LastViewedSeason
        {
            get { return m_LastViewedSeason; }
            set { m_LastViewedSeason = value; }
        }

        private int m_LastViewedEpisode;

        public int LastViewedEpisode
        {
            get { return m_LastViewedEpisode; }
            set { m_LastViewedEpisode = value; }
        }

        private int m_AllViewed;

        public int AllViewed
        {
            get { return m_AllViewed; }
            set { m_AllViewed = value; }
        }

        public bool IsAllViewed
        {
            get { return m_AllViewed == 1; }
        }

        public override string ToString()
        {
            return base.Title + (String.IsNullOrWhiteSpace(m_Website) ? "" : " (" + m_Website + ")");
        }
    }
}