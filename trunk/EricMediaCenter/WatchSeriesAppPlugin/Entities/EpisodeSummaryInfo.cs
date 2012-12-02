using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using EMCMasterPluginLib;

namespace WatchSeriesAppPlugin.Entities
{
    public class EpisodeSummaryInfo
    {
        private int m_No;
        private int m_Id;
        private string m_Name;
        private string m_Title;
        private DateTime m_ReleaseDate;
        private SeasonInfo m_Season;

        public int No
        {
            get { return m_No; }
            set { m_No = value; }
        }
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
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
        public DateTime ReleaseDate
        {
            get { return m_ReleaseDate; }
            set { m_ReleaseDate = value; }
        }
        public SeasonInfo Season
        {
            get { return m_Season; }
            set { m_Season = value; }
        }

        public EpisodeSummaryInfo(SeasonInfo season, int no, int id, string name, string title, DateTime releaseDate)
        {
            m_No = no;
            m_Id = id;
            m_Name = name;
            m_Title = title;
            m_ReleaseDate = releaseDate;
            m_Season = season;
        }
        public override string ToString()
        {

            return String.Format("#{0:00}: {1} ({2:yyyy-MM-dd})", m_No, m_Title, m_ReleaseDate);
        }
        public static Dictionary<int, EpisodeSummaryInfo> GetEpisodes(SeasonInfo season, dynamic lstEpisodes)
        {
            Dictionary<int, EpisodeSummaryInfo> episodes = new Dictionary<int, EpisodeSummaryInfo>();
            foreach (int i in lstEpisodes.Keys)
            {
                EpisodeSummaryInfo esi = new EpisodeSummaryInfo(season, lstEpisodes[i].No, lstEpisodes[i].Id, lstEpisodes[i].Name, lstEpisodes[i].Title, lstEpisodes[i].ReleaseDate);
                episodes.Add(i, esi);
            }
            return episodes;
        }
        public EpisodeInfo LoadEpisode()
        {
            dynamic e = EMCGlobal.GetWebServiceResult("WatchSeries|GetEpisode", m_Name);
            if (e == null)
                return null;
            EpisodeInfo ep = new EpisodeInfo(this,e.Description);
            ep.Links = LinkWebsiteInfo.GetLinks(ep, e.Links);
            return ep;
        }

        public EpisodeSummaryInfo GetPreviousEpisode()
        {
            EpisodeSummaryInfo ep = null;
            int[] epInSeasons = Season.Episodes.Keys.ToArray();
            int ei = 0;
            for (; ei < epInSeasons.Length && epInSeasons[ei] != No; ++ei) ;
            if (ei == epInSeasons.Length)
                return null;
            if (ei > 0)
                ep = Season.Episodes[epInSeasons[ei - 1]];
            else
            {
                SeasonInfo lastS = Season.GetPreviousSeason();
                if (lastS != null)
                    ep = lastS.Episodes.Last().Value;
            }
            return ep;
        }

        public EpisodeSummaryInfo GetNextEpisode()
        {
            EpisodeSummaryInfo ep = null;
            int[] epInSeasons = Season.Episodes.Keys.ToArray();
            int ei = 0;
            for (; ei < epInSeasons.Length && epInSeasons[ei] != No; ++ei) ;
            if (ei == epInSeasons.Length)
                return null;
            if (ei < epInSeasons.Length-1)
                ep = Season.Episodes[epInSeasons[ei + 1]];
            else
            {
                SeasonInfo nextS = Season.GetNextSeason();
                if (nextS != null)
                    ep = nextS.Episodes.First().Value;
            }
            return ep;
        }
    }
}
