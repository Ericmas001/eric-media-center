﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using EricUtility.Networking.Gathering;
using EricUtility;
using EricUtility2011;
using System.Globalization;
using System.Net;
using EMCRestService.Entries;
using EMCRestService.TvWebsites;
using EMCRestService.TvWebsites.Entities;

namespace EMCRestService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TvService
    {
        private static Dictionary<string, ITvWebsite> m_Supported = new Dictionary<string, ITvWebsite>()
        {
            {"tubeplus.me",new TubePlusWebsite()},
            {"watchseries-online.eu",new WatchseriesOnlineWebsite()},
            {"free-tv-video-online.me",new ProjectFreeTvWebsite()},
            {"tv-links.eu",new TvLinksWebsite()},
        };

        [WebGet(UriTemplate = "Supported")]
        public string Supported()
        {
            string[] items = m_Supported.Keys.ToArray();
            Array.Sort(items);
            return JsonConvert.SerializeObject(items);
        }

        [WebGet(UriTemplate = "Search/{website}/{keywords}")]
        public string Search(string website, string keywords)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].Search(keywords));
        }

        [WebGet(UriTemplate = "Letter/{website}/{letter}")]
        public string Letter(string website, string letter)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].StartsWith(letter));
        }

        [WebGet(UriTemplate = "Show/{website}/{showId}")]
        public string Show(string website, string showId)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].Show(showId) ?? new TvShow());
        }
    }
}