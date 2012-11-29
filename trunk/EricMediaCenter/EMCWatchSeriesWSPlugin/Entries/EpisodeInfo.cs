using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace EMCWatchSeriesWSPlugin.Entries
{
    public class EpisodeInfo : EpisodeSummaryInfo
    {
        private string m_Description;
        private Dictionary<string, LinkInfo> m_Links;

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        public Dictionary<string, LinkInfo> Links
        {
            get { return m_Links; }
            set { m_Links = value; }
        }

        public EpisodeInfo(EpisodeSummaryInfo i, string description, Dictionary<string, LinkInfo> links)
            : this(i.Season, i.No, i.Id, i.Name, i.Title, i.ReleaseDate, description, links)
        {
        }
        public EpisodeInfo(SeasonInfo season, int no, int id, string name, string title, DateTime releaseDate, string description, Dictionary<string, LinkInfo> links)
            : base(season, no, id, name, title, releaseDate)
        {
            m_Description = description;
            m_Links = links;
        }
        public EpisodeInfo(SeasonInfo season, JObject r)
            : base(season, r)
        {
            //{
            //"SeasonNo":1,
            //"Description":"After 15 years of darkness, an unlikely trio sets out on a journey to save the world. Source: NBCDirector: Jon FavreauWriter: Eric Kripke",
            //"ShowTitle":"Revolution (2012)",
            //"Links": [...]
            //"EpisodeNo":1,
            //"EpisodeId":194518,
            //"EpisodeName":"revolution_(2012)_s1_e1-194518",
            //"EpisodeTitle":"Pilot",
            //"ReleaseDate":"\/Date(1347865200000-0700)\/"
            //}  
            m_Description = (string)r["Description"];
            m_Links = LinkInfo.DeserializeLinks(this, (JArray)r["Links"]);
        }
        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}
