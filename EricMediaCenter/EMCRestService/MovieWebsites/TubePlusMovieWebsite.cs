using EMCRestService.Entries;
using EMCRestService.Services;
using EMCRestService.MovieWebsites.Entities;
using EMCRestService.VideoParser;
using EricUtility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCRestService.MovieWebsites
{
    public class TubePlusWebsite : IMovieWebsite
    {
        private async Task<IEnumerable<ListedMovie>> AvailableMoviesAsync(string baseurl)
        {
            List<ListedMovie> availables = new List<ListedMovie>();
            string src = await new HttpClient().GetStringAsync(baseurl);
            string allShows = StringUtility.Extract(src, "<div id=\"list_body\">", "<div id=\"list_footer\">");
            string itemp = "<div class=\"list_item";
            int start = allShows.IndexOf(itemp) + itemp.Length;
            while (start >= itemp.Length)
            {
                int end = allShows.IndexOf("</div><div class=\"list_item", start);
                end = end == -1 ? allShows.Length - 1 : end;
                string item = allShows.Substring(start, end - start);

                ListedMovie entry = new ListedMovie();
                entry.Name = StringUtility.Extract(item, "/player/", "/");
                entry.Title = StringUtility.Extract(item, "<b>", "</b>");
                availables.Add(entry);
                start = allShows.IndexOf(itemp, end) + itemp.Length;
            }
            ListedMovie[] items = availables.ToArray();
            Array.Sort(items);
            return items;
        }

        public async Task<IEnumerable<ListedMovie>> SearchAsync(string keywords)
        {
           try
            {
                 return await AvailableMoviesAsync("http://www.tubeplus.me/search/movies/" + keywords.Replace(" ", "_") + "/");
            }
            catch { return null; }
        }

        public async Task<IEnumerable<ListedMovie>> StartsWithAsync(string letter)
        {
            try
            {
                return await AvailableMoviesAsync("http://www.tubeplus.me/browse/movies/All_Genres/" + letter + "/");
            }
            catch { return null; }
        }

        public async Task<Movie> MovieAsync(string movieId)
        {
            Movie mov = new Movie();
            mov.Name = movieId;
            string baseurl = "http://www.tubeplus.me/player/" + movieId + "/";
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Movie have been removed"))
                return null;

            string nfos = StringUtility.RemoveBBCodeTags(StringUtility.Extract(src, "<a class=\"none\" href=\"#\">", "</a>"));
            mov.Title = StringUtility.Extract(nfos, " ", " - ");

            string all = StringUtility.Extract(src, "<ul id=\"links_list\" class=\"wonline\">", "</ul>");

            string linkDeb = "<li ";
            int startP = all.IndexOf(linkDeb) + linkDeb.Length;
            while (startP >= linkDeb.Length)
            {
                int endP = all.IndexOf("</li>", startP);
                string itemP = all.Substring(startP, endP - startP).Trim();
                startP = all.IndexOf(linkDeb, endP) + linkDeb.Length;

                string website = StringUtility.Extract(itemP, "<span>Host: </span>", "</div>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
                string url = StringUtility.Extract(itemP, "onclick=\"visited('", "');");

                if (!mov.Links.ContainsKey(website))
                    mov.Links.Add(website, new List<string>());
                mov.Links[website].Add(url);
            }
            return mov;
        }

        public StreamingInfo StreamAsync(string website, string args)
        {
            string url = TubePlusHelper.ObtainURL(website, args);
            string durl = null;

            //if (VideoParsingService.Parsers.ContainsKey(website))
            //{
            //    IVideoParser p = VideoParsingService.Parsers[website];
            //    durl = p.GetDownloadURL(url, new CookieContainer());
            //}

            return url == null ? null : new StreamingInfo() { StreamingURL = url, Arguments = args, Website = website, DownloadURL = durl };
        }

        public string MovieURL(string movieId)
        {
            return "http://www.tubeplus.me/player/" + movieId + "/";
        }
    }
}