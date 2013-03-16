using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace EMCWatchSeriesWSPlugin.Entries
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

        public SeasonInfo(ShowInfo show, int no, int nbEpisodes, string name, Dictionary<int, EpisodeSummaryInfo> episodes)
        {
            m_No = no;
            m_NbEpisodes = nbEpisodes;
            m_Name = name;
            m_Episodes = episodes;
            m_Show = show;
        }

        public static Dictionary<int, SeasonInfo> DeserializeSeasons(ShowInfo show, JArray results)
        {
            Dictionary<int, SeasonInfo> all = new Dictionary<int, SeasonInfo>();
            foreach (JObject r in results)
            {
                SeasonInfo info = new SeasonInfo(show, r);
                all.Add(info.No, info);
            }
            return all;
        }

        public SeasonInfo(ShowInfo show, JObject r)
        {
            //      {
            //      "SeasonNo":1,
            //      "NbEpisodes":5,
            //      "SeasonName":null,
            //      "Episodes":[...]
            //       }
            m_No = (int)r["SeasonNo"];
            m_NbEpisodes = (int)r["NbEpisodes"];
            m_Name = (string)r["SeasonName"];
            m_Episodes = EpisodeSummaryInfo.DeserializeEpisodes(this, (JArray)r["Episodes"]);
            m_Show = show;
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}