﻿using EMCRestService.Entries;
using EMCRestService.MovieWebsites.Entities;
using EricUtility;
using EricUtility.Networking.Gathering;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EMCRestService.MovieWebsites
{
    public class PrimeWireWebsite : IMovieWebsite
    {
        private async Task<IEnumerable<ListedMovie>> AvailableMoviesAsync(CookieContainer cookies, string baseurl)
        {
            List<ListedMovie> availables = new List<ListedMovie>();
            string src = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(baseurl);
            int max = 1;

            if (src.Contains("<div class=\"pagination\">"))
            {
                string pages = src.Extract("<div class=\"pagination\">", "</div>");
                pages = pages.Substring(pages.LastIndexOf("<a href="));
                max = int.Parse(src.Extract("&page=", "\""));
            }

            for (int i = 0; i < max; ++i)
            {
                if (i > 0)
                    src = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(baseurl + "&page=" + (i + 1));
                string allShows = "<div class=\"index_item index_item_ie\">" + src.Extract("<div class=\"index_item index_item_ie\">", "<div class=\"col2\">");
                string itemp = "<div class=\"index_item index_item_ie\">";
                int start = allShows.IndexOf(itemp) + itemp.Length;
                while (start >= itemp.Length)
                {
                    int end = allShows.IndexOf("</div></div>", start);
                    end = end == -1 ? allShows.Length - 1 : end;
                    string item = allShows.Substring(start, end - start);

                    ListedMovie entry = new ListedMovie();
                    entry.Name = item.Extract( "<a href=\"/", "\"");
                    entry.Title = item.Extract( " title=\"Watch ", "\"").Trim();
                    availables.Add(entry);
                    start = allShows.IndexOf(itemp, end) + itemp.Length;
                }
            }
            ListedMovie[] items = availables.ToArray();
            Array.Sort(items);
            return items;
        }

        public async Task<IEnumerable<ListedMovie>> SearchAsync(string keywords)
        {
            try
            {
                CookieContainer cookies = new CookieContainer();

                string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync("http://www.primewire.ag/");
                string key = res.Extract("<input type=\"hidden\" name=\"key\" value=\"", "\"");
                return await AvailableMoviesAsync(cookies, "http://www.primewire.ag/index.php?search_section=1&search_keywords=" + keywords.Replace(" ", "+") + "&key=" + key);
            }
            catch { return null; }
        }

        public Task<IEnumerable<ListedMovie>> StartsWithAsync(string letter)
        {
            return null;
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

            mov.Title = src.Extract("<a href=\"/" + movieId + "\">", "</a>");

            string all = src.Extract(mov.Title + " Links", "<div class=\"download_link\">");

            string linkDeb = "<span class=quality_dvd>";
            int startP = all.IndexOf(linkDeb) + linkDeb.Length;
            while (startP >= linkDeb.Length)
            {
                int endP = all.IndexOf("</table>", startP);
                string itemP = all.Substring(startP, endP - startP).Trim();
                startP = all.IndexOf(linkDeb, endP) + linkDeb.Length;

                string website = itemP.Extract( "<script type=\"text/javascript\">document.writeln('", "');</script>");
                string url = itemP.Extract( "<a href=\"/external.php?", "\"");

                //string srcUrl = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(url);
                //if (srcUrl.Contains("frame_header.php?hello=&title="))
                //    url = srcUrl.Extract( "</frameset><noframes>", "</noframes>");

                if (!mov.Links.ContainsKey(website))
                    mov.Links.Add(website, new List<string>());
                mov.Links[website].Add(HttpUtility.UrlEncode(url).Replace("%", "."));
            }
            return mov;
        }

        public StreamingInfo StreamAsync(string website, string args)
        {
            string url = "http://www.primewire.ag/external.php?" + HttpUtility.UrlDecode(args.Replace(".", "%"));
            string srcUrl = GatheringUtility.GetPageSource(url);
            if (srcUrl.Contains("frame_header.php?hello=&title="))
                url = srcUrl.Extract( "</frameset><noframes>", "</noframes>");
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