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

        public Dictionary<string, string> Commands
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
                    {"User|GetFavs","{token}"},
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
                case "User|DelFav": newRes = UserDelFav(result); break;
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
            //
            //{"value":"10/17/2012 1:53:22 PM"}
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
            //
            //[{"Key":"-1","Value":"Tuesday, October 16"},{"Key":"0","Value":"Wednesday, October 17"},{"Key":"1","Value":"Thursday, October 18"},{"Key":"2","Value":"Friday, October 19"},{"Key":"3","Value":"Saturday, October 20"},{"Key":"4","Value":"Sunday, October 21"},{"Key":"5","Value":"Monday, October 22"}]
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
            //3
            //[{"Url":"http://watchseries.eu/serie/48_hours_mystery","ShowName":"48 Hours Mystery","ShowTitle":"The Preacher's Passion","Season":26,"Episode":4},{"Url":"#","ShowName":"ABC Saturday Night College Football","ShowTitle":"Florida State at Miami (FL)","Season":7,"Episode":6},{"Url":"http://watchseries.eu/serie/billy_the_exterminator","ShowName":"Billy the Exterminator","ShowTitle":"Fight or Flight","Season":5,"Episode":16},{"Url":"http://watchseries.eu/serie/billy_the_exterminator","ShowName":"Billy the Exterminator","ShowTitle":"Wasp Warfare","Season":5,"Episode":17},{"Url":"#","ShowName":"Bleach (US)","ShowTitle":"One Hit Kill, SuÃ¬-FÄ?ng, Bankai!","Season":14,"Episode":11},{"Url":"#","ShowName":"CFB on FOX","ShowTitle":"Kansas State at West Virginia","Season":1,"Episode":8},{"Url":"#","ShowName":"Deadly Affairs","ShowTitle":"Killer Ambition","Season":1,"Episode":7},{"Url":"#","ShowName":"Doomsday Preppers Bugged Out","ShowTitle":"The End of the World as We Know It","Season":1,"Episode":2},{"Url":"http://watchseries.eu/serie/home_by_novogratz","ShowName":"Home by Novogratz","ShowTitle":"Williamsburg Couple's Modern Meets Natural Loft","Season":2,"Episode":12},{"Url":"#","ShowName":"Legends of","ShowTitle":"Alaska","Season":1,"Episode":99},{"Url":"http://watchseries.eu/serie/parking_wars","ShowName":"Parking Wars","ShowTitle":"Season 6, Episode 18","Season":6,"Episode":18},{"Url":"http://watchseries.eu/serie/parking_wars","ShowName":"Parking Wars","ShowTitle":"Season 6, Episode 19","Season":6,"Episode":19},{"Url":"http://watchseries.eu/serie/saturday_night_live","ShowName":"Saturday Night Live","ShowTitle":"Bruno Mars / Bruno Mars","Season":38,"Episode":5},{"Url":"http://watchseries.eu/serie/the_high_low_project","ShowName":"The High Low Project","ShowTitle":"Happy Medium Master Bedroom","Season":3,"Episode":3}]
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
            //
            //["gorillavid.in","putlocker.com","sockshare.com"]
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JToken r in results)
            {
                newRes += (string)r;
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string VideoParsingParse(string result)
        {
            //putlocker.com/85BDF24DE8F8D3F9
            //{"downloadURL":"http://cdn.putlocker.com/r1KH3Z%2FaMY6kLQ9Y4nVxYin3YLZ84fxf1LKRddhWfjqOHBkgmXux73NU7gxVJXeudTsIvsWsV48ALJW47kMtWVLFTrBrtjoHY8pknhjxTPrz7cSDDLIPz3ofoQNJDxBeyG3Yk1GcbQ%2Fg1pXyGYQ1COxm0Rbwr%2FwdSjprAEsSNXI9HuyUm8GLycpN1Raq1yOPRvcyfcrWAD6G4Iwa%2By6X8pXle7FlkQsjnC0IpY77GjQ%3D/fe01d1e290d8e99bc9c07dba07d6b0d8_sd.flv"}
            if (String.IsNullOrEmpty(result))
                return null;
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return (string)r["downloadURL"];
        }

        private string UserConnect(string result)
        {
            //testing/testingFullGood
            //{"success":true,"token":"8199876377c54ab4a64f10d47ca0bb90","until":"2012-10-17T13:59:38"}
            //testing/testingFullBad
            //{"success":false,"problem":"User or Password is incorrect"}
            //testingBad/testingFullGood
            //{"success":false,"problem":"User or Password is incorrect"}
            string newRes = "";
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            if (r == null)
                newRes = "ERROR PArsing !!";
            else
            {
                if ((bool)r["success"])
                {
                    newRes = "Connecté avec succes !!!" + Environment.NewLine;
                    newRes += "Token: " + r["token"] + Environment.NewLine;
                    newRes += "Valid Until: " + r["until"];
                }
                else
                    newRes = "Error Connecting: " + r["problem"].ToString();
            }
            return newRes;
        }

        private string UserRegister(string result)
        {
            //testing/testingFullGood
            //{"success":true}
            //testing/testingFullGood
            //{"success":false,"problem":"User already exist"}
            string newRes = "";
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            if (r == null)
                newRes = "ERROR PArsing !!";
            else
            {
                if ((bool)r["success"])
                {
                    newRes = "Enregistré avec succes !!!";
                }
                else
                    newRes = "Error When Register: " + r["problem"].ToString();
            }
            return newRes;
        }

        private string UserGetFavs(string result)
        {
            //c6c91b11cdfed4b4b264b1e8e23f05b3
            //{"success":true,"favorites":[{"username":"zeus","showname":"chuck","lastViewedSeason":3,"lastViewedEpisode":3,"showtitle":"Chuck","lastSeason":5,"lastEpisode":13},{"username":"zeus","showname":"dexter","lastViewedSeason":null,"lastViewedEpisode":null,"showtitle":"Dexter","lastSeason":7,"lastEpisode":3},{"username":"zeus","showname":"fringe","lastViewedSeason":4,"lastViewedEpisode":13,"showtitle":"Fringe","lastSeason":5,"lastEpisode":3},{"username":"zeus","showname":"homeland","lastViewedSeason":1,"lastViewedEpisode":12,"showtitle":"Homeland","lastSeason":2,"lastEpisode":3},{"username":"zeus","showname":"shameless","lastViewedSeason":null,"lastViewedEpisode":null,"showtitle":"Shameless","lastSeason":10,"lastEpisode":7}],"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:00:49"}
            //oops
            //{"success":false,"problem":"Invalid Token"}
            string newRes = "";
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            if (r == null)
                newRes = "ERROR PArsing !!";
            else
            {
                if ((bool)r["success"])
                {
                    newRes = "GetFavs avec succes !!!" + Environment.NewLine;
                    newRes += "Token: " + r["token"] + Environment.NewLine;
                    newRes += "Valid Until: " + r["until"] + Environment.NewLine;
                    foreach (JObject r2 in r["favorites"])
                    {
                        newRes += r2["showtitle"] + "(" + r2["showname"] + ") ";
                        newRes += "Last: " + r2["lastSeason"] + "x" + r2["lastEpisode"] + ", ";
                        newRes += "LastViewed (" + r2["user"] + "): " + r2["lastViewedSeason"] + "x" + r2["lastViewedEpisode"];
                        newRes += Environment.NewLine;
                    }
                }
                else
                    newRes = "Error When GetFavs: " + r["problem"].ToString();
            }
            return newRes;
        }

        private string UserAddFav(string result)
        {
            //c6c91b11cdfed4b4b264b1e8e23f05b3/shameless_(us)
            //{"success":true,"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:02:24"}
            string newRes = "";
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            if (r == null)
                newRes = "ERROR PArsing !!";
            else
            {
                if ((bool)r["success"])
                {
                    newRes = "Ajouté avec succes !!!" + Environment.NewLine;
                    newRes += "Token: " + r["token"] + Environment.NewLine;
                    newRes += "Valid Until: " + r["until"];
                }
                else
                    newRes = "Error Adding Fav: " + r["problem"].ToString();
            }
            return newRes;
        }

        private string UserSetLastViewed(string result)
        {
            //c6c91b11cdfed4b4b264b1e8e23f05b3/dexter/7/3
            //{"success":true,"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:03:30"}
            string newRes = "";
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            if (r == null)
                newRes = "ERROR PArsing !!";
            else
            {
                if ((bool)r["success"])
                {
                    newRes = "Episode Viewed avec succes !!!" + Environment.NewLine;
                    newRes += "Token: " + r["token"] + Environment.NewLine;
                    newRes += "Valid Until: " + r["until"];
                }
                else
                    newRes = "Error Setting Last Viewed: " + r["problem"].ToString();
            }
            return newRes;
        }

        private string UserDelFav(string result)
        {
            //c6c91b11cdfed4b4b264b1e8e23f05b3/shameless_(us)
            //{"success":true,"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:06:49"}
            string newRes = "";
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            if (r == null)
                newRes = "ERROR PArsing !!";
            else
            {
                if ((bool)r["success"])
                {
                    newRes = "Supprimé avec succes !!!" + Environment.NewLine;
                    newRes += "Token: " + r["token"] + Environment.NewLine;
                    newRes += "Valid Until: " + r["until"];
                }
                else
                    newRes = "Error Deleting Fav: " + r["problem"].ToString();
            }
            return newRes;
        }

        private string WatchSeriesGetPopulars(string result)
        {
            //
            //[{"ShowName":"how_i_met_your_mother","ShowTitle":"How I Met Your Mother","ReleaseYear":0},{"ShowName":"new_girl","ShowTitle":"New Girl","ReleaseYear":0},{"ShowName":"big_bang_theory","ShowTitle":"Big Bang Theory","ReleaseYear":0},{"ShowName":"gossip_girl","ShowTitle":"Gossip Girl","ReleaseYear":0},{"ShowName":"modern_family","ShowTitle":"Modern Family","ReleaseYear":0},{"ShowName":"family_guy","ShowTitle":"Family Guy","ReleaseYear":0},{"ShowName":"friends","ShowTitle":"Friends","ReleaseYear":0},{"ShowName":"the_walking_dead","ShowTitle":"The Walking Dead","ReleaseYear":0},{"ShowName":"sons_of_anarchy","ShowTitle":"Sons Of Anarchy","ReleaseYear":0},{"ShowName":"hart_of_dixie","ShowTitle":"Hart Of Dixie","ReleaseYear":0},{"ShowName":"the_vampire_diaries","ShowTitle":"The Vampire Diaries","ReleaseYear":0},{"ShowName":"dexter","ShowTitle":"Dexter","ReleaseYear":0}]
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JObject r in results)
            {
                newRes += r["ShowTitle"] + " (" + r["ShowName"] + ")";
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string WatchSeriesAvailableLetters(string result)
        {
            //
            //["09","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"]
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JToken r in results)
            {
                newRes += (string)r;
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string WatchSeriesAvailableGenres(string result)
        {
            //
            //["action","adventure","animation","cartoons","celebrities","children","comedy","cooking","crime","documentary","drama","family","fantasy","fashion","history","horror","lifestyle","medical","music","mystery","reality","sci fi","science","sports","talent","talk show","tech","teens","thriller","travel","war"]
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JToken r in results)
            {
                newRes += (string)r;
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string WatchSeriesGetLetter(string result)
        {
            //X
            //[{"ShowName":"x_files","ShowTitle":"X Files","ReleaseYear":1993},{"ShowName":"xavier:_renegade_angel","ShowTitle":"Xavier: Renegade Angel","ReleaseYear":2007},{"ShowName":"xena:_warrior_princess","ShowTitle":"Xena: Warrior Princess","ReleaseYear":1995},{"ShowName":"xiaolin_showdown","ShowTitle":"Xiaolin Showdown","ReleaseYear":2003},{"ShowName":"xiii_(2011)","ShowTitle":"XIII (2011)","ReleaseYear":2011},{"ShowName":"x-men","ShowTitle":"X-men","ReleaseYear":1992},{"ShowName":"x-men_2011","ShowTitle":"X-Men 2011","ReleaseYear":2011},{"ShowName":"x-men_eng_2011","ShowTitle":"X-Men eng 2011","ReleaseYear":2011},{"ShowName":"x-men:_evolution","ShowTitle":"X-Men: Evolution","ReleaseYear":2000},{"ShowName":"x-play","ShowTitle":"X-Play","ReleaseYear":1998},{"ShowName":"xtreme_waterparks","ShowTitle":"Xtreme Waterparks","ReleaseYear":0}]
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JObject r in results)
            {
                newRes += r["ShowTitle"] + " (" + r["ShowName"] + ") released in " + r["ReleaseYear"];
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string WatchSeriesGetGenre(string result)
        {
            //celebrities
            //[{"ShowName":"austin_city_limits\n","ShowTitle":"Austin City Limits","ReleaseYear":1975},{"ShowName":"comedy_world_cup\n","ShowTitle":"Comedy World Cup","ReleaseYear":2012},{"ShowName":"life_after\n","ShowTitle":"Life After","ReleaseYear":2009}]
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JObject r in results)
            {
                newRes += r["ShowTitle"] + " (" + r["ShowName"] + ") released in " + r["ReleaseYear"];
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string WatchSeriesSearch(string result)
        {
            //shame
            //[{"ShowName":"shameless","ShowTitle":"Shameless","ReleaseYear":2004},{"ShowName":"shameless_(us)","ShowTitle":"Shameless (US)","ReleaseYear":2011}]
            string newRes = "";
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            foreach (JObject r in results)
            {
                newRes += r["ShowTitle"] + " (" + r["ShowName"] + ") released in " + r["ReleaseYear"];
                newRes += Environment.NewLine;
            }
            return newRes;
        }

        private string WatchSeriesGetShow(string result)
        {
            //revolution_(2012)
            //{"ReleaseDate":"\/Date(1347865200000-0700)\/","Genre":"mystery","Status":"New Series","Network":"NBC (US)","Imdb":"tt2070791","Description":"What would you do without it all? In this epic adventure from J.J. Abrams' Bad Robot Productions and \"Supernatural's\" Eric Kripke, a family struggles to reunite in an American landscape where every single piece of technology - computers, planes, cars,   phones, even lights - has mysteriously blacked out forever. A drama with sweeping scope and intimate focus, \"Revolution\" is also about family - both the family you're born into and the family you choose. This is a swashbuckling journey of hope and rebirth seen through the eyes of one strong-willed young woman, Charlie Matheson (Tracy Spiridakos, \"Being Human\"), and her brother Danny (Graham Rogers, \"Memphis Beat\"). When Danny is kidnapped by militia leaders for a darker purpose, Charlie must reconnect with her estranged uncle Miles (Billy Burke, \"The Twilight Saga\"), a former U.S. Marine living a reclusive life. Together, with a rogue band of survivors, they set out to rescue Danny, overthrow the militia and ultimately re-establish the United States of America. All the while, they explore the enduring mystery of why the power failed, and if - or how - it will ever return. (Source: NBC)","NbEpisodes":5,"RssFeed":"5921","Logo":"http://watchseries.eu/imagini/Revolution2012.JPG","Seasons":[{"SeasonNo":1,"NbEpisodes":5,"SeasonName":null,"Episodes":[{"EpisodeNo":1,"EpisodeId":194518,"EpisodeName":"revolution_(2012)_s1_e1-194518","EpisodeTitle":"Pilot","ReleaseDate":"\/Date(1347865200000-0700)\/"},{"EpisodeNo":2,"EpisodeId":198699,"EpisodeName":"revolution_(2012)_s1_e2-198699","EpisodeTitle":"Chained Heat","ReleaseDate":"\/Date(1348470000000-0700)\/"},{"EpisodeNo":3,"EpisodeId":199579,"EpisodeName":"revolution_(2012)_s1_e3-199579","EpisodeTitle":"No Quarter","ReleaseDate":"\/Date(1349074800000-0700)\/"},{"EpisodeNo":4,"EpisodeId":200524,"EpisodeName":"revolution_(2012)_s1_e4-200524","EpisodeTitle":"The Plague Dogs","ReleaseDate":"\/Date(1349679600000-0700)\/"},{"EpisodeNo":5,"EpisodeId":201819,"EpisodeName":"revolution_(2012)_s1_e5-201819","EpisodeTitle":"Soul Train","ReleaseDate":"\/Date(1350284400000-0700)\/"}]}],"ShowName":"revolution_(2012)","ShowTitle":"Revolution (2012)","ReleaseYear":2012}
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetLinks(string result)
        {
            //1790
            //[{"Name":"allmyvideos.net","LinkIDs":[6234811,5778797]},{"Name":"clicktoview.org","LinkIDs":[6649217,5931034]},{"Name":"cyberlocker.ch","LinkIDs":[7102246,6701415,6652658]},{"Name":"daclips.in","LinkIDs":[3311652,3311649]},{"Name":"faststream.in","LinkIDs":[7102245]},{"Name":"filebox.com","LinkIDs":[5022918]},{"Name":"filenuke.com","LinkIDs":[7102247,6770189,6514659,6496170]},{"Name":"gorillavid.in","LinkIDs":[3311648]},{"Name":"movpod.in","LinkIDs":[3311653,3311650]},{"Name":"movreel.com","LinkIDs":[6234809]},{"Name":"movshare.net","LinkIDs":[5360200]},{"Name":"muchshare.net","LinkIDs":[6234812]},{"Name":"played.to","LinkIDs":[6681446]},{"Name":"putlocker.com","LinkIDs":[5122292,5122289,4846694,4829312,4814810,4814370,4814311,4800876,4782990,4755457,4489386,4449223,4239656,4189434,4135109,3885401,3871335,3418492,2583578,2388111,2379739,2377149,2375504]},{"Name":"sockshare.com","LinkIDs":[5122288,4755458,4511905,4509322,4189437,3923964,3896005,3885409]},{"Name":"uploadc.com","LinkIDs":[6234808,5939438,5077747]},{"Name":"vidbull.com","LinkIDs":[7047230,6714186,6711593,6709838,6401470,6374487,6291070]},{"Name":"vidbux.com","LinkIDs":[7051065,6234810]},{"Name":"vidxden.com","LinkIDs":[7051034,6555971,6234807]},{"Name":"vureel.com","LinkIDs":[6452937]}]
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetEpisode(string result)
        {
            //revolution_(2012)_s1_e1-194518
            //{"SeasonNo":1,"Description":"After 15 years of darkness, an unlikely trio sets out on a journey to save the world. Source: NBCDirector: Jon FavreauWriter: Eric Kripke","ShowTitle":"Revolution (2012)","Links":[{"Name":"180upload.com","LinkIDs":[6800989]},{"Name":"allmyvideos.net","LinkIDs":[6804502,6802462,6802391]},{"Name":"clicktoview.org","LinkIDs":[6962003,6946503,6807019,6802463,6802390,6798570]},{"Name":"cyberlocker.ch","LinkIDs":[6804687,6800378]},{"Name":"filenuke.com","LinkIDs":[6807031,6804710,6802568,6802523,6802389,6801352,6800264,6799207,6798644,6798643]},{"Name":"flashx.tv","LinkIDs":[6807023,6802467,6802395]},{"Name":"hostingbulk.com","LinkIDs":[6807035]},{"Name":"movreel.com","LinkIDs":[6802461,6802388,6801962,6799969,6799373]},{"Name":"muchshare.net","LinkIDs":[6801372]},{"Name":"nosvideo.com","LinkIDs":[6955331,6798671]},{"Name":"novamov.com","LinkIDs":[6904836]},{"Name":"nowvideo.eu","LinkIDs":[6860806,6860805,6860804]},{"Name":"putlocker.com","LinkIDs":[6904835]},{"Name":"uploadc.com","LinkIDs":[6953608,6802584,6802231,6801469]},{"Name":"vidbull.com","LinkIDs":[6802465,6802393,6801639,6801638,6799970,6799294,6799264]},{"Name":"vidbux.com","LinkIDs":[6904837,6802460,6802387,6799203]},{"Name":"vidxden.com","LinkIDs":[6904834,6802459,6802386,6802232,6799202,6798652,6798651]},{"Name":"vreer.com","LinkIDs":[6802466,6802394,6801920,6801884,6801666,6801330,6801207]},{"Name":"vureel.com","LinkIDs":[7144060]}],"EpisodeNo":1,"EpisodeId":194518,"EpisodeName":"revolution_(2012)_s1_e1-194518","EpisodeTitle":"Pilot","ReleaseDate":"\/Date(1347865200000-0700)\/"}
            string newRes = result;
            return newRes;
        }

        private string WatchSeriesGetUrl(string result)
        {
            //6234811
            //{"url":"http://www.allmyvideos.net/ga0lxylkcuy7","supported":false,"website":"allmyvideos.net","args":null}
            //3311648
            //{"url":"http://gorillavid.in/r7k9my4xu42c","supported":true,"website":"gorillavid.in","args":"r7k9my4xu42c"}
            string newRes = result;
            return newRes;
        }

        private string AutomatedUpdateLastEpisodes(string result)
        {
            //
            //[{"showname":"chuck","lastSeason":5,"lastEpisode":13,"changed":false},{"showname":"dexter","lastSeason":7,"lastEpisode":3,"changed":false},{"showname":"fringe","lastSeason":5,"lastEpisode":3,"changed":false},{"showname":"homeland","lastSeason":2,"lastEpisode":3,"changed":false},{"showname":"shameless","lastSeason":10,"lastEpisode":7,"changed":false},{"showname":"shameless_(us)","lastSeason":2,"lastEpisode":12,"changed":false}]
            string newRes = result;
            return newRes;
        }

        private string EpGuideSearch(string result)
        {
            //dexter
            //{"Dexter":"Dexter","DextersLaboratory":"Dexter's Laboratory"}
            string newRes = result;
            return newRes;
        }

        private string EpGuideGetShow(string result)
        {
            //dexter
            //{"TvRageId":"7926","TvId":"62683","FutonCriticId":"Dexter","ImdbId":"tt773262","ShareTvId":"dexter","TvClubId":"dexter,17","TvGuideId":"283488","WikiId":"Dexter_(TV_series)","ClickerId":"dexter"}
            string newRes = result;
            return newRes;
        }

        private string TvRageSearch(string result)
        {
            //dexter
            //{"7926":"Dexter","30970":"Dexter: Early Cuts","3298":"Dexter's Laboratory"}
            string newRes = result;
            return newRes;
        }

        private string TvRageGetShow(string result)
        {
            //7926
            //{"Title":"Dexter","NbSeasons":7,"Id":7926,"Url":"http://tvrage.com/Dexter","DateStarted":"\/Date(1159686000000-0700)\/","DateEnded":"\/Date(253402300799999-0800)\/","ImageUrl":"http://images.tvrage.com/shows/8/7926.jpg","Country":"US","Status":"http://images.tvrage.com/shows/8/7926.jpg","Classification":"Scripted","Genres":["Crime","Drama"],"Runtime":60,"Network":"Showtime","AirTime":"\/Date(1350532800000-0700)\/","AirDay":"Sunday","TimeZone":"GMT-5 +DST","LastEpisode":{"AbsoluteNo":75,"RelativeNo":3,"Season":7,"AirDate":"\/Date(-62135568000000-0800)\/","EpId":1065185345,"Title":"Buck the System"},"NextEpisode":{"AbsoluteNo":76,"RelativeNo":4,"Season":7,"AirDate":"\/Date(-62135568000000-0800)\/","EpId":1065191399,"Title":"Run"}}
            string newRes = result;
            return newRes;
        }

        #endregion
    }
}
