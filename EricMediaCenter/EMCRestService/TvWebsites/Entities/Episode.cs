﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMCRestService.TvWebsites.Entities
{
    public class Episode : ListedEpisode
    {
        private SortedDictionary<string, List<string>> m_Links = new SortedDictionary<string, List<string>>();

        public SortedDictionary<string, List<string>> Links
        {
            get { return m_Links; }
            set { m_Links = value; }
        }
    }
}