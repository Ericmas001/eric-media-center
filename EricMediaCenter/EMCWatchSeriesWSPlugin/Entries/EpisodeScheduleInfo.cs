using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace EMCWatchSeriesWSPlugin.Entries
{
    public class EpisodeScheduleInfo
    {
        private int m_NoSeason;
        private int m_NoEpisode;
        private string m_EpisodeTitle;
        private string m_ShowTitle;
        private string m_ShowUrl;

        public int NoSeason
        {
            get { return m_NoSeason; }
            set { m_NoSeason = value; }
        }

        public int NoEpisode
        {
            get { return m_NoEpisode; }
            set { m_NoEpisode = value; }
        }

        public string EpisodeTitle
        {
            get { return m_EpisodeTitle; }
            set { m_EpisodeTitle = value; }
        }

        public string ShowTitle
        {
            get { return m_ShowTitle; }
            set { m_ShowTitle = value; }
        }

        public string ShowUrl
        {
            get { return m_ShowUrl; }
            set { m_ShowUrl = value; }
        }

        public EpisodeScheduleInfo(int noSeason, int noEpisode, string episodeTitle, string showTitle, string showUrl)
        {
            m_NoSeason = noSeason;
            m_NoEpisode = noEpisode;
            m_EpisodeTitle = episodeTitle;
            m_ShowTitle = showTitle;
            m_ShowUrl = showUrl;
        }

        public static List<EpisodeScheduleInfo> DeserializeEpisodes(JArray results)
        {
            List<EpisodeScheduleInfo> all = new List<EpisodeScheduleInfo>();
            foreach (JObject r in results)
                all.Add(new EpisodeScheduleInfo(r));
            return all;
        }

        public EpisodeScheduleInfo(JObject r)
        {
            //{
            //"Url":"http://watchseries.li/serie/48_hours_mystery",
            //"ShowName":"48 Hours Mystery",
            //"ShowTitle":"The Preacher's Passion",
            //"Season":26,
            //"Episode":4}
            m_NoSeason = (int)r["Season"];
            m_NoEpisode = (int)r["Episode"];
            m_EpisodeTitle = (string)r["ShowTitle"];
            m_ShowTitle = (string)r["ShowName"];
            m_ShowUrl = (string)r["Url"];
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}