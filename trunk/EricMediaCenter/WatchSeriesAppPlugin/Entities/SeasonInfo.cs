using System;
using System.Collections.Generic;
using System.Linq;

namespace WatchSeriesAppPlugin.Entities
{
    public class SeasonInfo
    {
        private int m_No;
        private int m_NbEpisodes;
        private string m_Name;
        private Dictionary<int, EpisodeSummaryInfo> m_Episodes;
        private ShowInfo m_Show;

        public int No
        {
            get { return m_No; }
            set { m_No = value; }
        }

        public int NbEpisodes
        {
            get { return m_NbEpisodes; }
            set { m_NbEpisodes = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public Dictionary<int, EpisodeSummaryInfo> Episodes
        {
            get { return m_Episodes; }
            set { m_Episodes = value; }
        }

        public ShowInfo Show
        {
            get { return m_Show; }
            set { m_Show = value; }
        }

        public SeasonInfo(ShowInfo show, int no, int nbEpisodes, string name)
        {
            m_No = no;
            m_NbEpisodes = nbEpisodes;
            m_Name = name;
            m_Show = show;
        }

        public override string ToString()
        {
            return String.Format("Season {0:00}", m_No);
        }

        public static Dictionary<int, SeasonInfo> GetSeasons(ShowInfo show, dynamic lstSeasons)
        {
            Dictionary<int, SeasonInfo> seasons = new Dictionary<int, SeasonInfo>();
            foreach (int i in lstSeasons.Keys)
            {
                SeasonInfo s = new SeasonInfo(show, lstSeasons[i].No, lstSeasons[i].NbEpisodes, lstSeasons[i].Name);
                s.Episodes = EpisodeSummaryInfo.GetEpisodes(s, lstSeasons[i].Episodes);
                seasons.Add(i, s);
            }
            return seasons;
        }

        public SeasonInfo GetPreviousSeason()
        {
            SeasonInfo s = null;
            int[] sInShow = Show.Seasons.Keys.ToArray();
            int si = 0;
            for (; si < sInShow.Length && sInShow[si] != No; ++si) ;
            if (si == sInShow.Length)
                return null;
            if (si > 0)
                s = Show.Seasons[sInShow[si - 1]];
            return s;
        }

        public SeasonInfo GetNextSeason()
        {
            SeasonInfo s = null;
            int[] sInShow = Show.Seasons.Keys.ToArray();
            int si = 0;
            for (; si < sInShow.Length && sInShow[si] != No; ++si) ;
            if (si == sInShow.Length)
                return null;
            if (si < sInShow.Length - 1)
                s = Show.Seasons[sInShow[si + 1]];
            return s;
        }
    }
}