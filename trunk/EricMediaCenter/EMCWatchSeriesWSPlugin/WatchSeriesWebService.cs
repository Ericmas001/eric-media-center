 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.WebService;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using EMCWatchSeriesWSPlugin.Entries;

namespace EMCWatchSeriesWSPlugin
{
    public class WatchSeriesWebService : IWebService
    {
        #region IWebService Members

        public string Title
        {
            get { return "WatchSeries"; }
        }

        public string ShortDescription
        {
            get { return "Series from WatchSeries.li"; }
        }
        #endregion

        #region IWebService Members


        public string BaseUrl
        {
            get { return "http://emc.ericmas001.com/WatchSeries/"; }
        }

        public Dictionary<string,string> Commands
        {
            get
            {
                return new Dictionary<string, string>{
                    {"GetPopulars",""},
                    {"AvailableLetters",""},
                    {"AvailableGenres",""},
                    {"GetLetter","{letter}"},
                    {"GetGenre","{genre}"},
                    {"Search","{keywords}"},
                    {"GetShow","{showname}"},
                    {"GetLinks","{epid}"},
                    {"GetEpisode","{epname}"},
                    {"GetUrl","{linkid}"}
                };
            }
        }

        public object GetResult(string listChoice, string result)
        {
            object newRes = result;
            switch (listChoice)
            {
                case "GetPopulars": newRes = WatchSeriesGetPopulars(result); break;
                case "AvailableLetters": newRes = WatchSeriesAvailableLetters(result); break;
                case "AvailableGenres": newRes = WatchSeriesAvailableGenres(result); break;
                case "GetLetter": newRes = WatchSeriesGetLetter(result); break;
                case "GetGenre": newRes = WatchSeriesGetGenre(result); break;
                case "Search": newRes = WatchSeriesSearch(result); break;
                case "GetShow": newRes = WatchSeriesGetShow(result); break;
                case "GetLinks": newRes = WatchSeriesGetLinks(result); break;
                case "GetEpisode": newRes = WatchSeriesGetEpisode(result); break;
                case "GetUrl": newRes = WatchSeriesGetUrl(result); break;
            }
            return newRes;
        }
        private List<ShowSummaryInfo> WatchSeriesGetPopulars(string result)
        {
            //
            //[{"ShowName":"how_i_met_your_mother","ShowTitle":"How I Met Your Mother","ReleaseYear":0},{"ShowName":"new_girl","ShowTitle":"New Girl","ReleaseYear":0},{"ShowName":"big_bang_theory","ShowTitle":"Big Bang Theory","ReleaseYear":0},{"ShowName":"gossip_girl","ShowTitle":"Gossip Girl","ReleaseYear":0},{"ShowName":"modern_family","ShowTitle":"Modern Family","ReleaseYear":0},{"ShowName":"family_guy","ShowTitle":"Family Guy","ReleaseYear":0},{"ShowName":"friends","ShowTitle":"Friends","ReleaseYear":0},{"ShowName":"the_walking_dead","ShowTitle":"The Walking Dead","ReleaseYear":0},{"ShowName":"sons_of_anarchy","ShowTitle":"Sons Of Anarchy","ReleaseYear":0},{"ShowName":"hart_of_dixie","ShowTitle":"Hart Of Dixie","ReleaseYear":0},{"ShowName":"the_vampire_diaries","ShowTitle":"The Vampire Diaries","ReleaseYear":0},{"ShowName":"dexter","ShowTitle":"Dexter","ReleaseYear":0}]
            List<ShowSummaryInfo> list = new List<ShowSummaryInfo>();
            foreach (JObject r in JsonConvert.DeserializeObject<dynamic>(result))
                list.Add(new ShowSummaryInfo(r));
            return list;
        }

        private List<string> WatchSeriesAvailableLetters(string result)
        {
            //
            //["09","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"]
            List<string> list = new List<string>();
            foreach (string s in JsonConvert.DeserializeObject<dynamic>(result))
                list.Add(s);
            return list;
        }

        private List<string> WatchSeriesAvailableGenres(string result)
        {
            //
            //["action","adventure","animation","cartoons","celebrities","children","comedy","cooking","crime","documentary","drama","family","fantasy","fashion","history","horror","lifestyle","medical","music","mystery","reality","sci fi","science","sports","talent","talk show","tech","teens","thriller","travel","war"]
            List<string> list = new List<string>();
            foreach (string s in JsonConvert.DeserializeObject<dynamic>(result))
                list.Add(s);
            return list;
        }

        private List<ShowSummaryInfo> WatchSeriesGetLetter(string result)
        {
            //X
            //[{"ShowName":"x_files","ShowTitle":"X Files","ReleaseYear":1993},{"ShowName":"xavier:_renegade_angel","ShowTitle":"Xavier: Renegade Angel","ReleaseYear":2007},{"ShowName":"xena:_warrior_princess","ShowTitle":"Xena: Warrior Princess","ReleaseYear":1995},{"ShowName":"xiaolin_showdown","ShowTitle":"Xiaolin Showdown","ReleaseYear":2003},{"ShowName":"xiii_(2011)","ShowTitle":"XIII (2011)","ReleaseYear":2011},{"ShowName":"x-men","ShowTitle":"X-men","ReleaseYear":1992},{"ShowName":"x-men_2011","ShowTitle":"X-Men 2011","ReleaseYear":2011},{"ShowName":"x-men_eng_2011","ShowTitle":"X-Men eng 2011","ReleaseYear":2011},{"ShowName":"x-men:_evolution","ShowTitle":"X-Men: Evolution","ReleaseYear":2000},{"ShowName":"x-play","ShowTitle":"X-Play","ReleaseYear":1998},{"ShowName":"xtreme_waterparks","ShowTitle":"Xtreme Waterparks","ReleaseYear":0}]
            List<ShowSummaryInfo> list = new List<ShowSummaryInfo>();
            foreach (JObject r in JsonConvert.DeserializeObject<dynamic>(result))
                list.Add(new ShowSummaryInfo(r));
            return list;
        }

        private List<ShowSummaryInfo> WatchSeriesGetGenre(string result)
        {
            //celebrities
            //[{"ShowName":"austin_city_limits\n","ShowTitle":"Austin City Limits","ReleaseYear":1975},{"ShowName":"comedy_world_cup\n","ShowTitle":"Comedy World Cup","ReleaseYear":2012},{"ShowName":"life_after\n","ShowTitle":"Life After","ReleaseYear":2009}]
            List<ShowSummaryInfo> list = new List<ShowSummaryInfo>();
            foreach (JObject r in JsonConvert.DeserializeObject<dynamic>(result))
                list.Add(new ShowSummaryInfo(r));
            return list;
        }

        private List<ShowSummaryInfo> WatchSeriesSearch(string result)
        {
            //shame
            //[{"ShowName":"shameless","ShowTitle":"Shameless","ReleaseYear":2004},{"ShowName":"shameless_(us)","ShowTitle":"Shameless (US)","ReleaseYear":2011}]
            List<ShowSummaryInfo> list = new List<ShowSummaryInfo>();
            foreach (JObject r in JsonConvert.DeserializeObject<dynamic>(result))
                list.Add(new ShowSummaryInfo(r));
            return list;
        }

        private ShowInfo WatchSeriesGetShow(string result)
        {
            //revolution_(2012)
            //{"ReleaseDate":"\/Date(1347865200000-0700)\/","Genre":"mystery","Status":"New Series","Network":"NBC (US)","Imdb":"tt2070791","Description":"What would you do without it all? In this epic adventure from J.J. Abrams' Bad Robot Productions and \"Supernatural's\" Eric Kripke, a family struggles to reunite in an American landscape where every single piece of technology - computers, planes, cars,   phones, even lights - has mysteriously blacked out forever. A drama with sweeping scope and intimate focus, \"Revolution\" is also about family - both the family you're born into and the family you choose. This is a swashbuckling journey of hope and rebirth seen through the eyes of one strong-willed young woman, Charlie Matheson (Tracy Spiridakos, \"Being Human\"), and her brother Danny (Graham Rogers, \"Memphis Beat\"). When Danny is kidnapped by militia leaders for a darker purpose, Charlie must reconnect with her estranged uncle Miles (Billy Burke, \"The Twilight Saga\"), a former U.S. Marine living a reclusive life. Together, with a rogue band of survivors, they set out to rescue Danny, overthrow the militia and ultimately re-establish the United States of America. All the while, they explore the enduring mystery of why the power failed, and if - or how - it will ever return. (Source: NBC)","NbEpisodes":5,"RssFeed":"5921","Logo":"http://watchseries.li/imagini/Revolution2012.JPG","Seasons":[{"SeasonNo":1,"NbEpisodes":5,"SeasonName":null,"Episodes":[{"EpisodeNo":1,"EpisodeId":194518,"EpisodeName":"revolution_(2012)_s1_e1-194518","EpisodeTitle":"Pilot","ReleaseDate":"\/Date(1347865200000-0700)\/"},{"EpisodeNo":2,"EpisodeId":198699,"EpisodeName":"revolution_(2012)_s1_e2-198699","EpisodeTitle":"Chained Heat","ReleaseDate":"\/Date(1348470000000-0700)\/"},{"EpisodeNo":3,"EpisodeId":199579,"EpisodeName":"revolution_(2012)_s1_e3-199579","EpisodeTitle":"No Quarter","ReleaseDate":"\/Date(1349074800000-0700)\/"},{"EpisodeNo":4,"EpisodeId":200524,"EpisodeName":"revolution_(2012)_s1_e4-200524","EpisodeTitle":"The Plague Dogs","ReleaseDate":"\/Date(1349679600000-0700)\/"},{"EpisodeNo":5,"EpisodeId":201819,"EpisodeName":"revolution_(2012)_s1_e5-201819","EpisodeTitle":"Soul Train","ReleaseDate":"\/Date(1350284400000-0700)\/"}]}],"ShowName":"revolution_(2012)","ShowTitle":"Revolution (2012)","ReleaseYear":2012}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return r == null ? null : new ShowInfo(r);
        }

        private Dictionary<string, LinkInfo> WatchSeriesGetLinks(string result)
        {
            //1790
            //[{"Name":"allmyvideos.net","LinkIDs":[6234811,5778797]},{"Name":"clicktoview.org","LinkIDs":[6649217,5931034]},{"Name":"cyberlocker.ch","LinkIDs":[7102246,6701415,6652658]},{"Name":"daclips.in","LinkIDs":[3311652,3311649]},{"Name":"faststream.in","LinkIDs":[7102245]},{"Name":"filebox.com","LinkIDs":[5022918]},{"Name":"filenuke.com","LinkIDs":[7102247,6770189,6514659,6496170]},{"Name":"gorillavid.in","LinkIDs":[3311648]},{"Name":"movpod.in","LinkIDs":[3311653,3311650]},{"Name":"movreel.com","LinkIDs":[6234809]},{"Name":"movshare.net","LinkIDs":[5360200]},{"Name":"muchshare.net","LinkIDs":[6234812]},{"Name":"played.to","LinkIDs":[6681446]},{"Name":"putlocker.com","LinkIDs":[5122292,5122289,4846694,4829312,4814810,4814370,4814311,4800876,4782990,4755457,4489386,4449223,4239656,4189434,4135109,3885401,3871335,3418492,2583578,2388111,2379739,2377149,2375504]},{"Name":"sockshare.com","LinkIDs":[5122288,4755458,4511905,4509322,4189437,3923964,3896005,3885409]},{"Name":"uploadc.com","LinkIDs":[6234808,5939438,5077747]},{"Name":"vidbull.com","LinkIDs":[7047230,6714186,6711593,6709838,6401470,6374487,6291070]},{"Name":"vidbux.com","LinkIDs":[7051065,6234810]},{"Name":"vidxden.com","LinkIDs":[7051034,6555971,6234807]},{"Name":"vureel.com","LinkIDs":[6452937]}]
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            return LinkInfo.DeserializeLinks(null, results);
        }

        private EpisodeInfo WatchSeriesGetEpisode(string result)
        {
            //revolution_(2012)_s1_e1-194518
            //{"SeasonNo":1,"Description":"After 15 years of darkness, an unlikely trio sets out on a journey to save the world. Source: NBCDirector: Jon FavreauWriter: Eric Kripke","ShowTitle":"Revolution (2012)","Links":[{"Name":"180upload.com","LinkIDs":[6800989]},{"Name":"allmyvideos.net","LinkIDs":[6804502,6802462,6802391]},{"Name":"clicktoview.org","LinkIDs":[6962003,6946503,6807019,6802463,6802390,6798570]},{"Name":"cyberlocker.ch","LinkIDs":[6804687,6800378]},{"Name":"filenuke.com","LinkIDs":[6807031,6804710,6802568,6802523,6802389,6801352,6800264,6799207,6798644,6798643]},{"Name":"flashx.tv","LinkIDs":[6807023,6802467,6802395]},{"Name":"hostingbulk.com","LinkIDs":[6807035]},{"Name":"movreel.com","LinkIDs":[6802461,6802388,6801962,6799969,6799373]},{"Name":"muchshare.net","LinkIDs":[6801372]},{"Name":"nosvideo.com","LinkIDs":[6955331,6798671]},{"Name":"novamov.com","LinkIDs":[6904836]},{"Name":"nowvideo.li","LinkIDs":[6860806,6860805,6860804]},{"Name":"putlocker.com","LinkIDs":[6904835]},{"Name":"uploadc.com","LinkIDs":[6953608,6802584,6802231,6801469]},{"Name":"vidbull.com","LinkIDs":[6802465,6802393,6801639,6801638,6799970,6799294,6799264]},{"Name":"vidbux.com","LinkIDs":[6904837,6802460,6802387,6799203]},{"Name":"vidxden.com","LinkIDs":[6904834,6802459,6802386,6802232,6799202,6798652,6798651]},{"Name":"vreer.com","LinkIDs":[6802466,6802394,6801920,6801884,6801666,6801330,6801207]},{"Name":"vureel.com","LinkIDs":[7144060]}],"EpisodeNo":1,"EpisodeId":194518,"EpisodeName":"revolution_(2012)_s1_e1-194518","EpisodeTitle":"Pilot","ReleaseDate":"\/Date(1347865200000-0700)\/"}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return new EpisodeInfo(null,r);
        }

        private DownloadUrl WatchSeriesGetUrl(string result)
        {
            //6234811
            //{"url":"http://www.allmyvideos.net/ga0lxylkcuy7","supported":false,"website":"allmyvideos.net","args":null}
            //3311648
            //{"url":"http://gorillavid.in/r7k9my4xu42c","supported":true,"website":"gorillavid.in","args":"r7k9my4xu42c"}
            JObject r = JsonConvert.DeserializeObject<dynamic>(result);
            return new DownloadUrl(r);
        }

        #endregion
    }
}
