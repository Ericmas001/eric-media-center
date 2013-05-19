using EMCRestService.TvWebsites;
using EMCRestService.TvWebsites.Entities;
using EricUtility2011.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace EMCRestService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TvService
    {
        private SqlServerConnector Connector = new SqlServerConnector("TURNSOL.arvixe.com", "emc2", "emc.webservice", "Emc42FTW");
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

        [WebGet(UriTemplate = "Favs/{user}/{token}")]
        public string Favs(string user, string token)
        {
            try
            {
                SPResult rAll = Connector.SelectRowsSP("ericmas001.SPUserAllFavs", new List<SPParam>
                {
                        new SPParam(new SqlParameter("@username", SqlDbType.VarChar, 50),user),
                        new SPParam(new SqlParameter("@session", SqlDbType.VarChar, 32),token),
                        new SPParam(new SqlParameter("@ok", SqlDbType.Bit),ParamDir.Output),
                        new SPParam(new SqlParameter("@info", SqlDbType.VarChar, 100),ParamDir.Output),
                        new SPParam(new SqlParameter("@validUntil", SqlDbType.DateTimeOffset),ParamDir.Output),
                });

                Dictionary<string, object> p = rAll.Parameters;

                if ((bool)p["@ok"])
                    return JsonConvert.SerializeObject(new { success = true, username = user, shows = rAll.QueryResults, token = (String)p["@info"], until = (DateTimeOffset)p["@validUntil"] }, new IsoDateTimeConverter());
                else
                    return JsonConvert.SerializeObject(new { success = false, problem = (String)p["@info"] });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { success = false, problem = e.ToString() });
            }
        }

        [WebGet(UriTemplate = "AddFav/{user}/{token}/{website}/{showname}/{showtitle}/{lastseason}/{lastepisode}")]
        public string AddFav(string user, string token, string website, string showname, string showtitle, string lastseason, string lastepisode)
        {
            try
            {
                Dictionary<string, object> p = Connector.ExecuteSP("ericmas001.SPFavAddShow", new List<SPParam>
                {
                        new SPParam(new SqlParameter("@username", SqlDbType.VarChar, 50),user),
                        new SPParam(new SqlParameter("@session", SqlDbType.VarChar, 32),token),
                        new SPParam(new SqlParameter("@website", SqlDbType.VarChar, 50),website),
                        new SPParam(new SqlParameter("@name", SqlDbType.VarChar, 50),showname),
                        new SPParam(new SqlParameter("@title", SqlDbType.VarChar, 100),showtitle),
                        new SPParam(new SqlParameter("@lastSeason", SqlDbType.Int),int.Parse(lastseason)),
                        new SPParam(new SqlParameter("@lastEpisode", SqlDbType.Int),int.Parse(lastepisode)),
                        new SPParam(new SqlParameter("@ok", SqlDbType.Bit),ParamDir.Output),
                        new SPParam(new SqlParameter("@info", SqlDbType.VarChar, 100),ParamDir.Output),
                        new SPParam(new SqlParameter("@validUntil", SqlDbType.DateTimeOffset),ParamDir.Output),
                }).Parameters;

                if ((bool)p["@ok"])
                    return JsonConvert.SerializeObject(new { success = true });
                else
                    return JsonConvert.SerializeObject(new { success = false, problem = (String)p["@info"] });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { success = false, problem = e.ToString() });
            }
        }

        [WebGet(UriTemplate = "DelFav/{user}/{token}/{website}/{showname}")]
        public string DelFav(string user, string token, string website, string showname)
        {
            try
            {
                Dictionary<string, object> p = Connector.ExecuteSP("ericmas001.SPFavDelShow", new List<SPParam>
                {
                        new SPParam(new SqlParameter("@username", SqlDbType.VarChar, 50),user),
                        new SPParam(new SqlParameter("@session", SqlDbType.VarChar, 32),token),
                        new SPParam(new SqlParameter("@website", SqlDbType.VarChar, 50),website),
                        new SPParam(new SqlParameter("@name", SqlDbType.VarChar, 50),showname),
                        new SPParam(new SqlParameter("@ok", SqlDbType.Bit),ParamDir.Output),
                        new SPParam(new SqlParameter("@info", SqlDbType.VarChar, 100),ParamDir.Output),
                        new SPParam(new SqlParameter("@validUntil", SqlDbType.DateTimeOffset),ParamDir.Output),
                }).Parameters;

                if ((bool)p["@ok"])
                    return JsonConvert.SerializeObject(new { success = true });
                else
                    return JsonConvert.SerializeObject(new { success = false, problem = (String)p["@info"] });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { success = false, problem = e.ToString() });
            }
        }
    }
}