using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.WebService;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EMCTestWSPlugin
{
    public class MyPlainWebService : IWebService
    {
        #region IWebService Members

        public string Title
        {
            get { return "PLAIN"; }
        }

        public string ShortDescription
        {
            get { return "My Plain WebService"; }
        }
        #endregion

        #region IWebService Members


        public string BaseUrl
        {
            get { return "http://emc.ericmas001.com/"; }
        }

        public Dictionary<string,string> Commands
        {
            get
            {
                return new Dictionary<string, string>{
                    {"TimeService|CurrentTime","" },
                    {"TvSchedule|AvailableSchedule",""},
                    {"TvSchedule|GetSchedule","{id}"},
                    {"VideoParsing|AvailableWebsites",""},
                    {"VideoParsing|Parse","{website}/{args}"},
                    {"User|Connect","{user}/{pass}"},
                    {"User|Register","{user}/{pass}"},
                    {"User|GetFavs","{token}}"},
                    {"User|AddFav","{token}/{showname}"},
                    {"User|DelFav","{token}/{showname}"},
                    {"User|SetLastViewed","{token}/{showname}/{lastViewedSeason}/{lastViewedEpisode}"},
                    {"WatchSeries|GetPopulars",""},
                    {"WatchSeries|AvailableLetters",""},
                    {"WatchSeries|AvailableGenres",""},
                    {"WatchSeries|GetLetter","{letter}"},
                    {"WatchSeries|GetGenre","{genre}"},
                    {"WatchSeries|Search","{keywords}"},
                    {"WatchSeries|GetShow","{showname}"},
                    {"WatchSeries|GetLinks","{epid}"},
                    {"WatchSeries|GetEpisode","{epname}"},
                    {"WatchSeries|GetUrl","{linkid}"},
                    {"Automated|UpdateLastEpisodes",""},
                    {"EpGuide|Search","{id}"},
                    {"EpGuide|GetShow","{id}"},
                    {"TvRage|Search","{id}"},
                    {"TvRage|GetShow","{id}"}
                };
            }
        }

        public object GetResult(string listChoice, string result)
        {
            return result;
        }

        #endregion
    }
}
