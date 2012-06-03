using System;
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

namespace EMCRestService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EpGuideService
    {
        public static string EPGUIDE_USELESS { get { return "(a Titles & Air Dates Guide)"; } }
        public static List<SearchResultEntry> GoogleSearch(string searchString, int maxresults)
        {
            string pattern = "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&rsz=large&safe=active&q={0}&start={1}";
            List<SearchResultEntry> resultsList = new List<SearchResultEntry>();
            if ((maxresults % 8) > 0)
                maxresults += (8 - (maxresults % 8));
            for (int p = 0; p < maxresults; p += 8)
            {
                string res = GatheringUtility.GetPageSource(string.Format(pattern, searchString, p));
                int i = -1;
                while ((i = res.IndexOf("GsearchResultClass", i + 1)) >= 0)
                {
                    string url = StringUtility.Extract(res, "\"url\":\"", "\"", i);
                    string title = WebUtility.HtmlDecode(StringUtility.Extract(res, "\"titleNoFormatting\":\"", "\"", i).Replace("\\u0026", "&"));
                    //string title = Uri.UnescapeDataString(StringUtility.Extract(res, "\"titleNoFormatting\":\"", "\"", i).Replace("\\u0026", "&"));
                    //string title = WebStringUtility.DecodeString(StringUtility.Extract(res, "\"titleNoFormatting\":\"", "\"", i).Replace("\\u0026", "&"));
                    string content = StringUtility.Extract(res, "\"content\":\"", "\"", i);
                    resultsList.Add(new SearchResultEntry(url, title, content, SearchEngineType.Google));
                }
            }
            return resultsList;
        }
        public static List<SearchResultEntry> GoogleSearch(string searchString)
        {
            return GoogleSearch(searchString, 8);
        }
        [WebGet(UriTemplate = "Search/{id}")]
        public string Search(string id)
        {
            List<SearchResultEntry> entries = GoogleSearch(System.Uri.EscapeDataString("allintitle: site:epguides.com \"" + EPGUIDE_USELESS + "\" " + id));
            Dictionary<string, string> results = new Dictionary<string, string>();

            foreach (SearchResultEntry e in entries)
            {
                string title = e.Title.Replace(EPGUIDE_USELESS, "").Trim();
                string name = e.Url.Replace("http://epguides.com/", "").Replace("/", "");
                if( !name.Contains(".shtml") )
                    results.Add(name, title);
            }
            
            return JsonConvert.SerializeObject(results);
        }
        [WebGet(UriTemplate = "GetShow/{id}")]
        public string GetShow(string id)
        {
            string baseurl = "http://epguides.com/" + id + "/";

            CookieContainer cookies = new CookieContainer();
            string srcTvRage = GatheringUtility.GetPageSource(baseurl, cookies);
            string srcTv = GatheringUtility.GetPageSource(baseurl + "./", cookies, "list=tv.com");

            EpGuideEntry entry = new EpGuideEntry();

            entry.TvRageId = StringUtility.Extract(srcTvRage, "http://www.tvrage.com/shows/", "/");
            entry.TvId = StringUtility.Extract(srcTv, "http://www.tv.com/show/", "/");
            entry.FutonCriticId = StringUtility.Extract(srcTv, "http://thefutoncritic.com/showatch.aspx?id=", "&#38");
            entry.ImdbId = StringUtility.Extract(srcTv, "http://us.imdb.com/title/", "\"");
            entry.ShareTvId = StringUtility.Extract(srcTv, "http://sharetv.org/shows/", "\"");
            entry.TvClubId = StringUtility.Extract(srcTv, "http://www.avclub.com/tvclub/tvshow/", "\"");
            entry.TvGuideId = StringUtility.Extract(srcTv, "http://www.tvguide.com/detail/tv-show.aspx?tvobjectid=", "\"");
            entry.WikiId = StringUtility.Extract(srcTv, "http://en.wikipedia.org/wiki/", "\"");
            entry.ClickerId = StringUtility.Extract(srcTv, "http://www.clicker.com/tv/", "\"");

            return JsonConvert.SerializeObject(entry);
        }
    }
}