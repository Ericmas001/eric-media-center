using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace EMCWatchSeriesWSPlugin.Entries
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
        public static Dictionary<int, EpisodeSummaryInfo> DeserializeEpisodes(SeasonInfo season, JArray results)
        {
            Dictionary<int, EpisodeSummaryInfo> all = new Dictionary<int, EpisodeSummaryInfo>();
            foreach (JObject r in results)
            {
                EpisodeSummaryInfo info = new EpisodeSummaryInfo(season, r);
                all.Add(info.No, info);
            }
            return all;
        }
        public EpisodeSummaryInfo(SeasonInfo season, JObject r)
        {
            //          {
            //          "EpisodeNo":1,
            //          "EpisodeId":194518,
            //          "EpisodeName":"revolution_(2012)_s1_e1-194518",
            //          "EpisodeTitle":"Pilot",
            //          "ReleaseDate":"\/Date(1347865200000-0700)\/"
            //          }
            m_No = (int)r["EpisodeNo"];
            m_Id = (int)r["EpisodeId"];
            m_Name = (string)r["EpisodeName"];
            m_Title = (string)r["EpisodeTitle"];
            m_ReleaseDate = (DateTime)r["ReleaseDate"];
            m_Season = season;
        }
        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}
