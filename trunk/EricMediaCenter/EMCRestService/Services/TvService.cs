using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using EricUtility;
using EricUtility2011;
using System.Globalization;
using System.Net;
using EMCRestService.Entries;
using EMCRestService.TvWebsites;
using EMCRestService.TvWebsites.Entities;
using System.Threading.Tasks;

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
            if (website == "all")
            {
                Dictionary<string, object> res = new Dictionary<string, object>();
                Parallel.ForEach(m_Supported.Keys, site => res.Add(site, m_Supported[site].SearchAsync(keywords).Result));
                return JsonConvert.SerializeObject(res);
            }
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].SearchAsync(keywords).Result);
        }

        [WebGet(UriTemplate = "Letter/{website}/{letter}")]
        public string Letter(string website, string letter)
        {
            if (website == "all")
            {
                Dictionary<string, object> res = new Dictionary<string, object>();
                Parallel.ForEach(m_Supported.Keys, site => res.Add(site, m_Supported[site].StartsWithAsync(letter).Result));
                return JsonConvert.SerializeObject(res);
            }
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].StartsWithAsync(letter).Result);
        }

        [WebGet(UriTemplate = "Show/{website}/{showId}")]
        public string Show(string website, string showId)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].ShowAsync(showId).Result ?? new TvShow());
        }

        [WebGet(UriTemplate = "Episode/{website}/{epId}")]
        public string Episode(string website, string epId)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].EpisodeAsync(epId).Result ?? new Episode());
        }

        [WebGet(UriTemplate = "Stream/{website}/{streamWebsite}/{args}")]
        public string Stream(string website, string streamWebsite, string args)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].StreamAsync(streamWebsite, args).Result ?? new StreamingInfo() { Website = streamWebsite, Arguments = args });
        }
    }
}