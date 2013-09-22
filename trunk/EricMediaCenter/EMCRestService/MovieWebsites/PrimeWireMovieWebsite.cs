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
using EricUtility.Networking.Gathering;
using System.Web;

namespace EMCRestService.MovieWebsites
{
    public class PrimeWireMovieWebsite : IMovieWebsite
    {
        private async Task<IEnumerable<ListedMovie>> AvailableMoviesAsync(CookieContainer cookies, string baseurl)
        {
            List<ListedMovie> availables = new List<ListedMovie>();
            string src = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(baseurl);
            string allShows = "<div class=\"index_item index_item_ie\">" + StringUtility.Extract(src, "<div class=\"index_item index_item_ie\">", "<div class=\"col2\">");
            string itemp = "<div class=\"index_item index_item_ie\">";
            int start = allShows.IndexOf(itemp) + itemp.Length;
            while (start >= itemp.Length)
            {
                int end = allShows.IndexOf("</div></div>", start);
                end = end == -1 ? allShows.Length - 1 : end;
                string item = allShows.Substring(start, end - start);

                ListedMovie entry = new ListedMovie();
                entry.Name = StringUtility.Extract(item, "<a href=\"/", "\"");
                entry.Title = StringUtility.Extract(item, " title=\"Watch ", "\"").Trim();
                availables.Add(entry);
                start = allShows.IndexOf(itemp, end) + itemp.Length;
            }
            ListedMovie[] items = availables.ToArray();
            Array.Sort(items);
            return items;
        }

        public async Task<IEnumerable<ListedMovie>> SearchAsync(string keywords)
        {
            CookieContainer cookies = new CookieContainer();

            string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync("http://www.primewire.ag/");
            string key = StringUtility.Extract(res, "<input type=\"hidden\" name=\"key\" value=\"", "\"");
            return await AvailableMoviesAsync(cookies,"http://www.primewire.ag/index.php?search_keywords=" + keywords.Replace(" ", "+") + "&key=" + key);
        }

        public async Task<IEnumerable<ListedMovie>> StartsWithAsync(string letter)
        {
            return null;
            //return await AvailableMoviesAsync("http://www.tubeplus.me/browse/movies/All_Genres/" + letter + "/");
        }

        public async Task<Movie> MovieAsync(string movieId)
        {
            CookieContainer cookies = new CookieContainer();
            Movie mov = new Movie();
            mov.Name = movieId;
            string baseurl = "http://www.primewire.ag/" + movieId + "/";
            string src = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(baseurl);

            if (src.Contains("Doesn't look like there are any links"))
                return null;

            mov.Title = StringUtility.Extract(src, "<a href=\"/"+movieId+"\">", "</a>");

            string all = StringUtility.Extract(src, mov.Title + " Links", "<div class=\"download_link\">");

            string linkDeb = "<span class=quality_dvd>";
            int startP = all.IndexOf(linkDeb) + linkDeb.Length;
            while (startP >= linkDeb.Length)
            {
                int endP = all.IndexOf("</table>", startP);
                string itemP = all.Substring(startP, endP - startP).Trim();
                startP = all.IndexOf(linkDeb, endP) + linkDeb.Length;

                string website = StringUtility.Extract(itemP, "<script type=\"text/javascript\">document.writeln('", "');</script>");
                string url = StringUtility.Extract(itemP, "<a href=\"/external.php?", "\"");

                //string srcUrl = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(url);
                //if (srcUrl.Contains("frame_header.php?hello=&title="))
                //    url = StringUtility.Extract(srcUrl, "</frameset><noframes>", "</noframes>");

                if (!mov.Links.ContainsKey(website))
                    mov.Links.Add(website, new List<string>());
                mov.Links[website].Add(HttpUtility.UrlEncode(url).Replace("%","."));
            }
            return mov;
        }

        public StreamingInfo StreamAsync(string website, string args)
        {
            string url = "http://www.primewire.ag/external.php?" + HttpUtility.UrlDecode(args.Replace(".", "%"));
            string srcUrl = GatheringUtility.GetPageSource(url);
            if (srcUrl.Contains("frame_header.php?hello=&title="))
                url = StringUtility.Extract(srcUrl, "</frameset><noframes>", "</noframes>");
            else
                url = GatheringUtility.GetPageUrl(url, new CookieContainer());
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
            return "http://www.primewire.ag/" + movieId + "/";
        }
    }
}