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
    public class WatchSeriesService
    {
        private const string RANDOM_EPISODE_URL = "http://watchseries.li/episode/big_bang_theory_s1_e9-8171.html";
        [WebGet(UriTemplate = "GetPopulars")]
        public string GetPopulars()
        {
            List<TvShowEntry> availables = new List<TvShowEntry>();
            string src = GatheringUtility.GetPageSource("http://watchseries.li/");
            string allShows = StringUtility.Extract(src, "<div class=\"div-home-inside-left\">", "</div>");
            string showurl = "http://watchseries.li/serie/";
            int start = allShows.IndexOf(showurl) + showurl.Length;
            while (start >= showurl.Length)
            {
                int end = allShows.IndexOf("<br/>", start);
                string item = allShows.Substring(start, end - start);

                TvShowEntry entry = new TvShowEntry();
                entry.ShowName = item.Remove(item.IndexOf("\""));
                //entry.ShowTitle = StringUtility.Extract(item, "\">", "<");
                entry.ShowTitle = new CultureInfo("en-US",false).TextInfo.ToTitleCase(entry.ShowName.Replace("_"," "));
                entry.ReleaseYear = 0;
                availables.Add(entry);
                start = allShows.IndexOf(showurl, end) + showurl.Length;
            }
            TvShowEntry[] items = new TvShowEntry[availables.Count];
            availables.CopyTo(items, 0);
            //Array.Sort(items);
            return JsonConvert.SerializeObject(items);
        }
        [WebGet(UriTemplate = "AvailableLetters")]
        public string AvailableLetters()
        {
            return getAvailableItems("http://watchseries.li/letters/");
        }
        
        [WebGet(UriTemplate = "AvailableGenres")]
        public string AvailableGenres()
        {
            return getAvailableItems("http://watchseries.li/genres/");
        }

        private string getAvailableItems( string baseurl )
        {
            List<string> availables = new List<string>();
            string src = GatheringUtility.GetPageSource(baseurl);
            string choices = StringUtility.Extract(src, "<ul class=\"pagination\">", "</ul>");
            int start = choices.IndexOf(baseurl) + baseurl.Length;
            while (start >= baseurl.Length)
            {
                int end = choices.IndexOf("\"", start);
                string letter = choices.Substring(start, end - start);
                availables.Add(letter);
                start = choices.IndexOf(baseurl,end) + baseurl.Length;
            }
            string[] items = new string[availables.Count];
            availables.CopyTo(items, 0);
            Array.Sort(items);
            return JsonConvert.SerializeObject(items);
        }
        [WebGet(UriTemplate = "GetLetter/{letter}")]
        public string GetLetter(string letter)
        {
            return getAvailableShows("http://watchseries.li/letters/" + letter);
        }
        [WebGet(UriTemplate = "GetGenre/{genre}")]
        public string GetGenre(string genre)
        {
            return getAvailableShows("http://watchseries.li/genres/" + genre);
        }

        private string getAvailableShows(string baseurl)
        {
            List<TvShowEntry> availables = new List<TvShowEntry>();
            string src = GatheringUtility.GetPageSource(baseurl);
            string allShows = StringUtility.Extract(src, "<div id=\"left\" >", "</ul>") + StringUtility.Extract(src, "<div id=\"right\">", "</ul>");
            string showurl = "http://watchseries.li/serie/";
            int start = allShows.IndexOf(showurl) + showurl.Length;
            while (start >= showurl.Length)
            {
                int end = allShows.IndexOf("</li>", start);
                string item = allShows.Substring(start, end - start);

                TvShowEntry entry = new TvShowEntry();
                entry.ShowName = item.Remove(item.IndexOf("\""));
                entry.ShowTitle = StringUtility.Extract(item, "\">", "<");
                entry.ReleaseYear = int.Parse(StringUtility.Extract(item, "<span class=\"epnum\">", "</span>"));
                availables.Add(entry);
                start = allShows.IndexOf(showurl, end) + showurl.Length;
            }
            TvShowEntry[] items = new TvShowEntry[availables.Count];
            availables.CopyTo(items, 0);
            Array.Sort(items);
            return JsonConvert.SerializeObject(items);
        }
        [WebGet(UriTemplate = "Search/{keywords}")]
        public string Search(string keywords)
        {
            List<TvShowEntry> availables = new List<TvShowEntry>();
            string src = GatheringUtility.GetPageSource("http://watchseries.li/search/" + keywords);
            string allShows = StringUtility.Extract(src, "<div class=\"episode-summary\">", "</div>");
            if (allShows == null)
                return null;
            string td = "<td valign=\"top\">";
            string showurl = "http://watchseries.li/serie/";
            int start = allShows.IndexOf(td) + td.Length;
            while (start >= td.Length)
            {
                int end = allShows.IndexOf("</td></tr>", start);
                string item = allShows.Substring(start, end - start).Trim();

                TvShowEntry entry = new TvShowEntry();
                entry.ShowName = StringUtility.Extract(item, showurl, "\"");
                entry.ShowTitle = StringUtility.Extract(item, "><b>", "</b>");
                string year = entry.ShowTitle.Substring(entry.ShowTitle.LastIndexOf("("));
                entry.ReleaseYear = int.Parse(StringUtility.Extract(year, "(", ")"));
                entry.ShowTitle = entry.ShowTitle.Remove(entry.ShowTitle.LastIndexOf("(")-1);
                availables.Add(entry);
                start = allShows.IndexOf(td, end) + td.Length;
            }
            TvShowEntry[] items = new TvShowEntry[availables.Count];
            availables.CopyTo(items, 0);
            Array.Sort(items);
            return JsonConvert.SerializeObject(items);
        }
        [WebGet(UriTemplate = "GetShow/{showname}")]
        public string GetShow(string showname)
        {
            showname = showname.Replace(';', ':');
            TvShowDetailedEntry entry = new TvShowDetailedEntry();
            entry.ShowName = showname;

            string baseurl = "http://watchseries.li/serie/" + showname;
            string src = GatheringUtility.GetPageSource(baseurl);

            if (src.Contains("Um, Where did the page go?"))
                return null;

            entry.RssFeed = StringUtility.Extract(src," <a class=\"rss-title\" href=\"../rss/",".xml");

            string summary = StringUtility.Extract(src,"<div class=\"show-summary\">","</div>");

            string imageAndTitle = StringUtility.Extract(summary, "<img src=\"", "</a>");
            entry.Logo = imageAndTitle.Remove(imageAndTitle.IndexOf("\""));
            entry.ShowTitle = StringUtility.Extract(imageAndTitle, "Watch Series - ", "\"");

            string rDate = StringUtility.Extract(summary, "<b>Release Date :</b> ", "<br />");
            entry.ReleaseDate = DateTime.ParseExact(rDate, "dd , MMMM yyyy", CultureInfo.InvariantCulture);
            entry.ReleaseYear = entry.ReleaseDate.Year;

            entry.Genre = StringUtility.Extract(summary, "http://watchseries.li/genres/", "\"");

            entry.Status = StringUtility.Extract(summary, "<b>Status : </b>", "<");
            if (entry.Status != null) entry.Status = entry.Status.Trim();

            entry.Network = StringUtility.Extract(summary, "<b>Network : </b>", "<");
            if (entry.Network != null) entry.Network = entry.Network.Trim();

            entry.Imdb = StringUtility.Extract(summary, "http://www.imdb.com/title/", "/");

            entry.Description = StringUtility.Extract(summary, "<b>Description :</b> ", "<br />");
            if (entry.Description != null) entry.Description = StringUtility.RemoveHTMLTags(entry.Description).Replace("[+]more", "").Trim();

            entry.NbEpisodes = int.Parse(StringUtility.Extract(summary, "<b>No. of episodes :</b> ", " episode"));

            string allSeasons = StringUtility.Extract(src, "<div id=\"left\">", "<!-- end of left -->") + StringUtility.Extract(src, "<div id=\"right\">", "<!-- end right -->");
            string seasDeb = "<h2 class=\"lists\">";
            int startS = allSeasons.IndexOf(seasDeb) + seasDeb.Length;
            while (startS >= seasDeb.Length)
            {
                TvSeasonEntry season = new TvSeasonEntry();
                int endS = allSeasons.IndexOf("</ul>", startS);
                string itemS = allSeasons.Substring(startS, endS - startS).Trim();
                startS = allSeasons.IndexOf(seasDeb, endS) + seasDeb.Length;


                season.NbEpisodes = int.Parse(StringUtility.Extract(itemS, "  (", " episodes)"));
                season.SeasonName = null;
                int no = 0;
                if (!int.TryParse(StringUtility.Extract(itemS, "watchseries.li/season-", "/"), out no))
                    continue;
                season.SeasonNo = no;

                string epDeb = "<li>";
                int startE = itemS.IndexOf(epDeb) + epDeb.Length;
                while (startE >= epDeb.Length)
                {
                    TvEpisodeEntry episode = new TvEpisodeEntry();
                    int endE = itemS.IndexOf("</li>", startE);
                    string itemE = itemS.Substring(startE, endE - startE).Trim();

                    episode.EpisodeName = StringUtility.Extract(itemE, "href=\"../episode/", ".html");
                    episode.EpisodeId = int.Parse(episode.EpisodeName.Substring(episode.EpisodeName.LastIndexOf("-")+1));
                    episode.EpisodeNo = int.Parse(StringUtility.Extract(itemE, ">Episode ", "&nbsp;"));
                    episode.EpisodeTitle = StringUtility.Extract(itemE, "&nbsp;&nbsp;&nbsp;", "</span>");

                    string eRDate = StringUtility.Extract(itemE, "<span class=\"epnum\">", "</span>");
                    DateTime d = DateTime.MinValue;
                    DateTime.TryParseExact(eRDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out d);
                    episode.ReleaseDate = d;

                    season.Episodes.Add(episode);
                    startE = itemS.IndexOf(epDeb,endE) + epDeb.Length;
                }
                entry.Seasons.Add(season);
            }


            return JsonConvert.SerializeObject(entry);
        }
        public List<TvWebsiteEntry> Links(int id)
        {
            CookieContainer cookies = new CookieContainer();
            // Build cookies
            GatheringUtility.GetPageSource(RANDOM_EPISODE_URL, cookies);
            Dictionary<string, List<int>> all = new Dictionary<string, List<int>>();
            string baseurl = "http://watchseries.li/getlinks.php?q=" + id + "&domain=all";
            string src = GatheringUtility.GetPageSource(baseurl, cookies);
            string deb = "<div class=\"linewrap\" >";
            int start = src.IndexOf(deb) + deb.Length;
            while (start >= deb.Length)
            {
                int end = src.IndexOf("<br class=\"clear\">", start);
                string item = src.Substring(start, end - start).Trim();

                string site = StringUtility.Extract(item, "<div class=\"site\">", "</div>").Trim();
                if (site.Contains(" "))
                    site = site.Remove(site.IndexOf(" "));
                int wid = int.Parse(StringUtility.Extract(item, "../open/cale/", "/idepisod/").Trim());

                if (!all.ContainsKey(site))
                    all.Add(site, new List<int>());
                all[site].Add(wid);

                start = src.IndexOf(deb, end) + deb.Length;
            }
            string[] items = new string[all.Count];
            all.Keys.CopyTo(items, 0);
            Array.Sort(items);
            List<TvWebsiteEntry> websites = new List<TvWebsiteEntry>();
            foreach (string s in items)
                websites.Add(new TvWebsiteEntry(){ Name = s, LinkIDs = all[s]});
            return websites;
        }
        [WebGet(UriTemplate = "GetLinks/{epid}")]
        public string GetLinks(string epid)
        {
            return JsonConvert.SerializeObject(Links(int.Parse(epid)));
        }
        [WebGet(UriTemplate = "GetEpisode/{epname}")]
        public string GetEpisode(string epname)
        {
            epname = epname.Replace(';', ':');
            TvEpisodeDetailedEntry entry = new TvEpisodeDetailedEntry();
            entry.EpisodeName = epname;
            entry.EpisodeId = int.Parse(epname.Substring(epname.LastIndexOf('-') + 1));
            entry.EpisodeNo = int.Parse(StringUtility.Extract(epname.Substring(epname.LastIndexOf('_')), "_e", "-"));
            string season = epname.Remove(epname.LastIndexOf('_'));
            entry.SeasonNo = int.Parse(season.Substring(season.LastIndexOf('_') + 2));
            entry.Links = Links(entry.EpisodeId);

            string baseurl = "http://watchseries.li/episode/" + epname + ".html";
            string src = StringUtility.Extract(GatheringUtility.GetPageSource(baseurl),"<div class=\"fullwrap\">","</div>");

            string showtitle = StringUtility.Extract(src, "<a href=\"http://watchseries.li/serie/", "</a>");
            entry.ShowTitle = showtitle.Substring(showtitle.LastIndexOf('>') + 1);

            entry.EpisodeTitle = StringUtility.Extract(src, "  - ", "</span>").Trim();

            string airdate = StringUtility.Extract(src, "<b>Air Date:</b> ", "<br />");
            DateTime d = DateTime.MinValue;
            DateTime.TryParseExact(airdate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
            entry.ReleaseDate = d;

            string desc = StringUtility.Extract(src, "<p><b>Summary:</b>", "<br /><br />");
            entry.Description = StringUtility.RemoveHTMLTags(desc.Replace("[+]more", "")).Trim();

            return JsonConvert.SerializeObject(entry);
        }
        [WebGet(UriTemplate = "GetUrl/{linkid}")]
        public string GetUrl(string linkid)
        {
            CookieContainer cookies = new CookieContainer();
            // Build cookies
            GatheringUtility.GetPageSource(RANDOM_EPISODE_URL, cookies);

            //Get link
            string gateway = "http://watchseries.li/gateway.php?link=";
            string cale = GatheringUtility.GetPageSource("http://watchseries.li/open/cale/" + linkid + "/idepisod/42.html", cookies);
            string token = StringUtility.Extract(cale, gateway, "\"");

            //Get RealURL
            string rurl = GatheringUtility.GetPageUrl(gateway + token,cookies,"","application/x-www-form-urlencoded");

            string trimmed = rurl.Replace("http://", "").Replace("https://", "").Replace("www.", "");
            string websiteName = trimmed.Remove(trimmed.IndexOf('/'));
            bool isSupported = VideoParsingService.Parsers.ContainsKey(websiteName);
            string websiteArgs = null;
            if (isSupported)
                websiteArgs = VideoParsingService.Parsers[websiteName].ParseArgs(trimmed);
            return JsonConvert.SerializeObject(new { url = rurl, supported = isSupported, website = websiteName, args = websiteArgs });
        }
    }
}