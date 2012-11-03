using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.WebService;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using EMCUserWSPlugin.Entries;
using Newtonsoft.Json.Converters;

namespace EMCUserWSPlugin
{
    public class UserWebService : IWebService
    {
        #region IWebService Members

        public string Title
        {
            get { return "User"; }
        }

        public string ShortDescription
        {
            get { return "UserService for EricMediaCenter"; }
        }
        #endregion

        #region IWebService Members


        public string BaseUrl
        {
            get { return "http://emc.ericmas001.com/User/"; }
        }

        public Dictionary<string, string> Commands
        {
            get
            {
                return new Dictionary<string, string>{
                    {"Connect","{user}/{pass}"},
                    {"Register","{user}/{pass}"},
                    {"GetFavs","{token}"},
                    {"AddFav","{token}/{showname}"},
                    {"DelFav","{token}/{showname}"},
                    {"SetLastViewed","{token}/{showname}/{lastViewedSeason}/{lastViewedEpisode}"}};
            }
        }

        public object GetResult(string listChoice, string result)
        {
            object newRes = result;
            switch (listChoice)
            {
                case "Connect": newRes = UserConnect(result); break;
                case "Register": newRes = UserRegister(result); break;
                case "GetFavs": newRes = UserGetFavs(result); break;
                case "AddFav": newRes = UserAddFav(result); break;
                case "DelFav": newRes = UserDelFav(result); break;
                case "SetLastViewed": newRes = UserSetLastViewed(result); break;
            }
            return newRes;
        }

        private UserDetailedResponse UserConnect(string result)
        {
            //testing/testingFullGood
            //{"success":true,"token":"8199876377c54ab4a64f10d47ca0bb90","until":"2012-10-17T13:59:38"}
            //testing/testingFullBad
            //{"success":false,"problem":"User or Password is incorrect"}
            //testingBad/testingFullGood
            //{"success":false,"problem":"User or Password is incorrect"}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return new UserDetailedResponse(r);
        }

        private UserResponse UserRegister(string result)
        {
            //testing/testingFullGood
            //{"success":true}
            //testing/testingFullGood
            //{"success":false,"problem":"User already exist"}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return new UserResponse(r);
        }

        private UserFavoritesResponse UserGetFavs(string result)
        {
            //c6c91b11cdfed4b4b264b1e8e23f05b3
            //{"success":true,"favorites":[{"username":"zeus","showname":"chuck","lastViewedSeason":3,"lastViewedEpisode":3,"showtitle":"Chuck","lastSeason":5,"lastEpisode":13},{"username":"zeus","showname":"dexter","lastViewedSeason":null,"lastViewedEpisode":null,"showtitle":"Dexter","lastSeason":7,"lastEpisode":3},{"username":"zeus","showname":"fringe","lastViewedSeason":4,"lastViewedEpisode":13,"showtitle":"Fringe","lastSeason":5,"lastEpisode":3},{"username":"zeus","showname":"homeland","lastViewedSeason":1,"lastViewedEpisode":12,"showtitle":"Homeland","lastSeason":2,"lastEpisode":3},{"username":"zeus","showname":"shameless","lastViewedSeason":null,"lastViewedEpisode":null,"showtitle":"Shameless","lastSeason":10,"lastEpisode":7}],"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:00:49"}
            //oops
            //{"success":false,"problem":"Invalid Token"}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return new UserFavoritesResponse(r);
        }

        private UserDetailedResponse UserAddFav(string result)
        {
            //c6c91b11cdfed4b4b264b1e8e23f05b3/shameless_(us)
            //{"success":true,"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:02:24"}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return new UserDetailedResponse(r);
        }

        private UserDetailedResponse UserDelFav(string result)
        {
            //c6c91b11cdfed4b4b264b1e8e23f05b3/shameless_(us)
            //{"success":true,"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:06:49"}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return new UserDetailedResponse(r);
        }


        private UserDetailedResponse UserSetLastViewed(string result)
        {
            //c6c91b11cdfed4b4b264b1e8e23f05b3/dexter/7/3
            //{"success":true,"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:03:30"}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return new UserDetailedResponse(r);
        }

        #endregion
    }
}
