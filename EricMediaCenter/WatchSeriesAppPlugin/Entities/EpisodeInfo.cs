using System;
using System.Collections.Generic;

namespace WatchSeriesAppPlugin.Entities
{
    public class EpisodeInfo : EpisodeSummaryInfo
    {
        private string m_Description;
        private Dictionary<string, LinkWebsiteInfo> m_Links;

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        public Dictionary<string, LinkWebsiteInfo> Links
        {
            get { return m_Links; }
            set { m_Links = value; }
        }

        public EpisodeInfo(EpisodeSummaryInfo i, string description)
            : this(i.Season, i.No, i.Id, i.Name, i.Title, i.ReleaseDate, description)
        {
        }

        public EpisodeInfo(SeasonInfo season, int no, int id, string name, string title, DateTime releaseDate, string description)
            : base(season, no, id, name, title, releaseDate)
        {
            m_Description = description;
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}