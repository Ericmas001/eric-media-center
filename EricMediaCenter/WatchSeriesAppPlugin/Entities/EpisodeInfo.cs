﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WatchSeriesAppPlugin.Entities
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