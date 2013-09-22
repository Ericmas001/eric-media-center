using EMCRestService.Entries;
using EMCRestService.MovieWebsites;
using EMCRestService.MovieWebsites.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace EMCRestService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MovieService
    {
        private static Dictionary<string, IMovieWebsite> m_Supported = new Dictionary<string, IMovieWebsite>()
        {
            {"tubeplus.me",new TubePlusWebsite()},
            {"primewire.ag",new PrimeWireWebsite()},
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

        [WebGet(UriTemplate = "Movie/{website}/{movieId}")]
        public string Movie(string website, string movieId)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].MovieAsync(movieId).Result ?? new Movie());
        }

        [WebGet(UriTemplate = "MovieURL/{website}/{movieId}")]
        public string MovieURL(string website, string movieId)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].MovieURL(movieId));
        }

        [WebGet(UriTemplate = "Stream/{website}/{streamWebsite}/{args}")]
        public string Stream(string website, string streamWebsite, string args)
        {
            if (!m_Supported.ContainsKey(website))
                return null;
            return JsonConvert.SerializeObject(m_Supported[website].StreamAsync(streamWebsite, args) ?? new StreamingInfo() { Website = streamWebsite, Arguments = args });
        }
    }
}