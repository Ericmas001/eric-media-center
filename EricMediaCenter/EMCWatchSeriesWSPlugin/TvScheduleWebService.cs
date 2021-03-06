﻿using EMCMasterPluginLib.WebService;
using EMCWatchSeriesWSPlugin.Entries;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace EMCWatchSeriesWSPlugin
{
    public class TvScheduleWebService : IWebService
    {
        #region IWebService Members

        public string Title
        {
            get { return "TvSchedule"; }
        }

        public string ShortDescription
        {
            get { return "TvSchedule from WatchSeries.li"; }
        }

        #endregion IWebService Members

        #region IWebService Members

        public string BaseUrl
        {
            get { return "http://emc.ericmas001.com/TvSchedule/"; }
        }

        public Dictionary<string, string> Commands
        {
            get
            {
                return new Dictionary<string, string>{
                    {"AvailableSchedule",""},
                    {"GetSchedule","{id}"}
                };
            }
        }

        public object GetResult(string listChoice, string result)
        {
            object newRes = result;
            switch (listChoice)
            {
                case "AvailableSchedule": newRes = TvScheduleAvailableSchedule(result); break;
                case "GetSchedule": newRes = TvScheduleGetSchedule(result); break;
            }
            return newRes;
        }

        private Dictionary<int, string> TvScheduleAvailableSchedule(string result)
        {
            //
            //[{"Key":"-1","Value":"Tuesday, October 16"},{"Key":"0","Value":"Wednesday, October 17"},{"Key":"1","Value":"Thursday, October 18"},{"Key":"2","Value":"Friday, October 19"},{"Key":"3","Value":"Saturday, October 20"},{"Key":"4","Value":"Sunday, October 21"},{"Key":"5","Value":"Monday, October 22"}]
            Dictionary<int, string> days = new Dictionary<int, string>();
            foreach (JObject r in JsonConvert.DeserializeObject<dynamic>(result))
                days.Add((int)r["Key"], (string)r["Value"]);
            return days;
        }

        private List<EpisodeScheduleInfo> TvScheduleGetSchedule(string result)
        {
            //3
            //[{"Url":"http://watchseries.li/serie/48_hours_mystery","ShowName":"48 Hours Mystery","ShowTitle":"The Preacher's Passion","Season":26,"Episode":4},{"Url":"#","ShowName":"ABC Saturday Night College Football","ShowTitle":"Florida State at Miami (FL)","Season":7,"Episode":6},{"Url":"http://watchseries.li/serie/billy_the_exterminator","ShowName":"Billy the Exterminator","ShowTitle":"Fight or Flight","Season":5,"Episode":16},{"Url":"http://watchseries.li/serie/billy_the_exterminator","ShowName":"Billy the Exterminator","ShowTitle":"Wasp Warfare","Season":5,"Episode":17},{"Url":"#","ShowName":"Bleach (US)","ShowTitle":"One Hit Kill, SuÃ¬-FÄng, Bankai!","Season":14,"Episode":11},{"Url":"#","ShowName":"CFB on FOX","ShowTitle":"Kansas State at West Virginia","Season":1,"Episode":8},{"Url":"#","ShowName":"Deadly Affairs","ShowTitle":"Killer Ambition","Season":1,"Episode":7},{"Url":"#","ShowName":"Doomsday Preppers Bugged Out","ShowTitle":"The End of the World as We Know It","Season":1,"Episode":2},{"Url":"http://watchseries.li/serie/home_by_novogratz","ShowName":"Home by Novogratz","ShowTitle":"Williamsburg Couple's Modern Meets Natural Loft","Season":2,"Episode":12},{"Url":"#","ShowName":"Legends of","ShowTitle":"Alaska","Season":1,"Episode":99},{"Url":"http://watchseries.li/serie/parking_wars","ShowName":"Parking Wars","ShowTitle":"Season 6, Episode 18","Season":6,"Episode":18},{"Url":"http://watchseries.li/serie/parking_wars","ShowName":"Parking Wars","ShowTitle":"Season 6, Episode 19","Season":6,"Episode":19},{"Url":"http://watchseries.li/serie/saturday_night_live","ShowName":"Saturday Night Live","ShowTitle":"Bruno Mars / Bruno Mars","Season":38,"Episode":5},{"Url":"http://watchseries.li/serie/the_high_low_project","ShowName":"The High Low Project","ShowTitle":"Happy Medium Master Bedroom","Season":3,"Episode":3}]
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            return EpisodeScheduleInfo.DeserializeEpisodes(results);
        }

        #endregion IWebService Members
    }
}