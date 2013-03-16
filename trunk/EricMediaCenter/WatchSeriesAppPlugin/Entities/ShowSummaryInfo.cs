using EMCMasterPluginLib;
using System;

namespace WatchSeriesAppPlugin.Entities
{
    public class ShowSummaryInfo
    {
        private string m_Name;
        private string m_Title;
        private int m_ReleaseYear;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public int ReleaseYear
        {
            get { return m_ReleaseYear; }
            set { m_ReleaseYear = value; }
        }

        public ShowSummaryInfo(string name, string title, int releaseYear)
        {
            m_Name = name;
            m_Title = title;
            m_ReleaseYear = releaseYear;
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", m_Title, m_ReleaseYear > 0 ? String.Format(" ({0})", m_ReleaseYear) : "", m_Name);
        }

        public ShowInfo LoadShow()
        {
            dynamic s = EMCGlobal.GetWebServiceResult("WatchSeries|GetShow", m_Name);
            if (s == null)
                return null;
            ShowInfo show = new ShowInfo(this, s.ReleaseDate, s.Genre, s.Status, s.Network, s.Imdb, s.Description, s.NbEpisodes, s.RssFeed, s.LogoURL);
            show.Seasons = SeasonInfo.GetSeasons(show, s.Seasons);
            return show;
        }
    }
}