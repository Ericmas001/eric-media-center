using EMCRestService.Entries;
using EMCRestService.StreamingWebsites.Entities;
using EricUtility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCRestService.StreamingWebsites
{
    public class TubePlusMovieWebsite : IMovieWebsite
    {
        private async Task<IEnumerable<ListedMovie>> AvailableMoviesAsync(string baseurl)
        {
            List<ListedMovie> availables = new List<ListedMovie>();
            string src = await new HttpClient().GetStringAsync(baseurl);
            string allShows = src.Extract("<div id=\"list_body\">", "<div id=\"list_footer\">");
            string itemp = "<div class=\"list_item";
            int start = allShows.IndexOf(itemp) + itemp.Length;
            while (start >= itemp.Length)
            {
                int end = allShows.IndexOf("</div><div class=\"list_item", start);
                end = end == -1 ? allShows.Length - 1 : end;
                string item = allShows.Substring(start, end - start);

                ListedMovie entry = new ListedMovie();
                entry.Name = item.Extract( "/player/", "/");
                entry.Title = item.Extract( "<b>", "</b>");
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

            string nfos = StringUtility.RemoveBBCodeTags(src.Extract("<a class=\"none\" href=\"#\">", "</a>"));
            mov.Title = nfos.Extract( " ", " - ");

            string all = src.Extract("<ul id=\"links_list\" class=\"wonline\">", "</ul>");

            string linkDeb = "<li ";
            int startP = all.IndexOf(linkDeb) + linkDeb.Length;
            while (startP >= linkDeb.Length)
            {
                int endP = all.IndexOf("</li>", startP);
                string itemP = all.Substring(startP, endP - startP).Trim();
                startP = all.IndexOf(linkDeb, endP) + linkDeb.Length;

                string website = itemP.Extract( "<span>Host: </span>", "</div>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
                string url = itemP.Extract( "onclick=\"visited('", "');");

                if (!mov.Links.ContainsKey(website))
                    mov.Links.Add(website, new List<string>());
                mov.Links[website].Add(url);
            }
            return mov;
        }

        public Task<StreamingInfo> StreamAsync(string website, string args)
        {
            string url = TubePlusHelper.ObtainURL(website, args);
            return new Task<StreamingInfo>(delegate() { return url == null ? null : new StreamingInfo() { StreamingURL = url, Arguments = args, Website = website, DownloadURL = null }; });
        }

        public string MovieURL(string movieId)
        {
            return "http://www.tubeplus.me/player/" + movieId + "/";
        }
    }
}