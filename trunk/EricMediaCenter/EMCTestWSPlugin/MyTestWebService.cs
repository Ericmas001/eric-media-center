using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.WebService;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EMCTestWSPlugin
{
    public class MyTestWebService : IWebService
    {
        #region IWebService Members

        public string Title
        {
            get { return "TEST"; }
        }

        public string ShortDescription
        {
            get { return "My Test WebService"; }
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
            string newRes = result;
            switch (listChoice)
            {
                case "TimeService|CurrentTime": newRes = TimeServiceCurrentTime(result); break;
                case "TvSchedule|AvailableSchedule": newRes = TvScheduleAvailableSchedule(result); break;
                case "TvSchedule|GetSchedule": newRes = TvScheduleGetSchedule(result); break;
                case "VideoParsing|AvailableWebsites": newRes = VideoParsingAvailableWebsites(result); break;
                case "VideoParsing|Parse": newRes = VideoParsingParse(result); break;
                case "User|Connect": newRes = UserConnect(result); break;
                case "User|Register": newRes = UserRegister(result); break;
                case "User|GetFavs": newRes = UserGetFavs(result); break;
                case "User|AddFav": newRes = UserAddFav(result); break;
                case "User|SetLastViewed": newRes = UserSetLastViewed(result); break;
                case "WatchSeries|GetPopulars": newRes = WatchSeriesGetPopulars(result); break;
                case "WatchSeries|AvailableLetters": newRes = WatchSeriesAvailableLetters(result); break;
                case "WatchSeries|AvailableGenres": newRes = WatchSeriesAvailableGenres(result); break;
                case "WatchSeries|GetLetter": newRes = WatchSeriesGetLetter(result); break;
                case "WatchSeries|GetGenre": newRes = WatchSeriesGetGenre(result); break;
                case "WatchSeries|Search": newRes = WatchSeriesSearch(result); break;
                case "WatchSeries|GetShow": newRes = WatchSeriesGetShow(result); break;
                case "WatchSeries|GetLinks": newRes = WatchSeriesGetLinks(result); break;
                case "WatchSeries|GetEpisode": newRes = WatchSeriesGetEpisode(result); break;
                case "WatchSeries|GetUrl": newRes = WatchSeriesGetUrl(result); break;
                case "Automated|UpdateLastEpisodes": newRes = AutomatedUpdateLastEpisodes(result); break;
                case "EpGuide|Search": newRes = EpGuideSearch(result); break;
                case "EpGuide|GetShow": newRes = EpGuideGetShow(result); break;
                case "TvRage|Search": newRes = TvRageSearch(result); break;
                case "TvRage|GetShow": newRes = TvRageGetShow(result); break;
            }
            return newRes;
        }

        private string TimeServiceCurrentTime(string result)
        {
            string newRes = "";
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            if (r == null)
                newRes = "ERROR PArsing !!";
            else
                newRes = "Server Current Time: " + r["value"].ToString();
            return newRes;
        }

        private string TvScheduleAvailableSchedule(string result)
        {
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JObject r in results)
            {
                newRes += "(" + r["Key"].ToString() + ") " + r["Value"].ToString();
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string TvScheduleGetSchedule(string result)
        {
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JObject r in results)
            {
                newRes += r["ShowName"].ToString() + " " + r["Season"].ToString() + "x" + r["Episode"].ToString() + ": " + r["ShowTitle"].ToString();
                if (r["Url"].ToString() != "#")
                    newRes += " (" + r["Url"].ToString() + ")";
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string VideoParsingAvailableWebsites(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string VideoParsingParse(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserConnect(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserRegister(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserGetFavs(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserAddFav(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string UserSetLastViewed(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetPopulars(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesAvailableLetters(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesAvailableGenres(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetLetter(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetGenre(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesSearch(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetShow(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetLinks(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetEpisode(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetUrl(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string AutomatedUpdateLastEpisodes(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string EpGuideSearch(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string EpGuideGetShow(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string TvRageSearch(string result)
        {
            string newRes = result;
            return newRes;
        }

        private string TvRageGetShow(string result)
        {
            string newRes = result;
            return newRes;
        }

        #endregion
    }
}
