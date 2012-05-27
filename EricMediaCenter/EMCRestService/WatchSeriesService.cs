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

namespace EMCRestService
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WatchSeriesService
    {
        [WebGet(UriTemplate = "AvailableLetters")]
        public string AvailableLetters()
        {
            return getAvailableItems("http://watchseries.eu/letters/");
        }
        
        [WebGet(UriTemplate = "AvailableGenres")]
        public string AvailableGenres()
        {
            return getAvailableItems("http://watchseries.eu/genres/");
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
        [WebGet(UriTemplate = "GetLetter/{id}")]
        public string GetLetter(string id)
        {
            return getAvailableShows("http://watchseries.eu/letters/" + id);
        }
        [WebGet(UriTemplate = "GetGenre/{id}")]
        public string GetGenre(string id)
        {
            return getAvailableShows("http://watchseries.eu/genres/" + id);
        }

        private string getAvailableShows(string baseurl)
        {
            List<TvShowEntry> availables = new List<TvShowEntry>();
            string src = GatheringUtility.GetPageSource(baseurl);
            string allShows = StringUtility.Extract(src, "<div id=\"left\" >", "</ul>") + StringUtility.Extract(src, "<div id=\"right\" >", "</ul>");
            string showurl = "http://watchseries.eu/serie/";
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
        [WebGet(UriTemplate = "Search/{id}")]
        public string Search(string id)
        {
            List<TvShowEntry> availables = new List<TvShowEntry>();
            string src = GatheringUtility.GetPageSource("http://watchseries.eu/search/" + id);
            string allShows = StringUtility.Extract(src, "<div class=\"episode-summary\">", "</div>");
            string td = "<td valign=\"top\">";
            string showurl = "http://watchseries.eu/serie/";
            int start = allShows.IndexOf(td) + td.Length;
            while (start >= td.Length)
            {
                int end = allShows.IndexOf("</td></tr>", start);
                string item = allShows.Substring(start, end - start).Trim();

                TvShowEntry entry = new TvShowEntry();
                entry.ShowName = StringUtility.Extract(item, showurl, "\"");
                entry.ShowTitle = StringUtility.Extract(item, "><b>", "</b>");
                entry.ReleaseYear = int.Parse(item.Substring(item.LastIndexOf(" ") + 1));
                availables.Add(entry);
                start = allShows.IndexOf(td, end) + td.Length;
            }
            TvShowEntry[] items = new TvShowEntry[availables.Count];
            availables.CopyTo(items, 0);
            Array.Sort(items);
            return JsonConvert.SerializeObject(items);
        }
        [WebGet(UriTemplate = "GetShow/{id}")]
        public string GetShow(string id)
        {
            TvShowDetailedEntry entry = new TvShowDetailedEntry();
            entry.ShowName = id;

            string baseurl = "http://watchseries.eu/serie/" + id;
            string src = GatheringUtility.GetPageSource(baseurl);

            entry.RssFeed = StringUtility.Extract(src," <a class=\"rss-title\" href=\"../rss/",".xml");

            string summary = StringUtility.Extract(src,"<div class=\"show-summary\">","</div>");

            string imageAndTitle = StringUtility.Extract(summary, "<img src=\"", "</a>");
            entry.Logo = imageAndTitle.Remove(imageAndTitle.IndexOf("\""));
            entry.ShowTitle = StringUtility.Extract(imageAndTitle, "Watch Series - ", "\"");

            string rDate = StringUtility.Extract(summary, "<b>Release Date :</b> ", "<br />");
            entry.ReleaseDate = DateTime.ParseExact(rDate, "dd , MMMM yyyy", CultureInfo.InvariantCulture);
            entry.ReleaseYear = entry.ReleaseDate.Year;

            entry.Genre = StringUtility.Extract(summary, "http://watchseries.eu/genres/", "\"");

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


                season.NbEpisodes = int.Parse(StringUtility.Extract(itemS, "  (", " episodes)"));
                season.SeasonName = null;
                season.SeasonNo = int.Parse(StringUtility.Extract(itemS, "watchseries.eu/season-", "/"));

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
                    episode.ReleaseDate = DateTime.ParseExact(eRDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    season.Episodes.Add(episode);
                    startE = itemS.IndexOf(epDeb,endE) + epDeb.Length;
                }
                entry.Seasons.Add(season);
                startS = allSeasons.IndexOf(seasDeb,endS) + seasDeb.Length;
            }


            return JsonConvert.SerializeObject(entry);
        }
        [WebGet(UriTemplate = "GetLinks/{id}")]
        public string GetLinks(string id)
        {
            Dictionary<string, List<int>> all = new Dictionary<string, List<int>>();
            string baseurl = "http://watchseries.eu/getlinks.php?q=" + id + "&domain=all";
            string src = GatheringUtility.GetPageSource(baseurl);
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
            return JsonConvert.SerializeObject(all);
        }
        [WebGet(UriTemplate = "GetUrl/{id}")]
        public string GetUrl(string id)
        {
            CookieContainer cookies = new CookieContainer();
            
            // Build cookies
            GatheringUtility.GetPageSource("http://watchseries.eu",cookies);

            //Get link
            string gateway = "http://watchseries.eu/gateway.php?link=";
            string cale = GatheringUtility.GetPageSource("http://watchseries.eu/open/cale/"+id+"/idepisod/42.html", cookies);
            string token = StringUtility.Extract(cale, gateway, "\"");

            //Get RealURL
            string rurl = GatheringUtility.GetPageUrl(gateway + token,cookies,"","application/x-www-form-urlencoded");
            
            return JsonConvert.SerializeObject(new { url = rurl });
        }
    }
}