﻿using EMCRestService.Entries;
using EMCRestService.StreamingWebsites.Entities;
using EricUtility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCRestService.StreamingWebsites
{
    public class TubePlusTvWebsite : ITvWebsite
    {
        private async Task<IEnumerable<ListedTvShow>> AvailableShowsAsync(string baseurl)
        {
            List<ListedTvShow> availables = new List<ListedTvShow>();
            string src = await new HttpClient().GetStringAsync(baseurl);
            string allShows = src.Extract("<div id=\"list_body\">", "<div id=\"list_footer\">");
            string itemp = "<div class=\"list_item";
            int start = allShows.IndexOf(itemp) + itemp.Length;
            while (start >= itemp.Length)
            {
                int end = allShows.IndexOf("</div><div class=\"list_item", start);
                end = end == -1 ? allShows.Length - 1 : end;
                string item = allShows.Substring(start, end - start);

                ListedTvShow entry = new ListedTvShow();
                entry.Name = item.Extract( "/player/", "/");
                entry.Title = item.Extract( "<b>", "</b>");
                availables.Add(entry);
                start = allShows.IndexOf(itemp, end) + itemp.Length;
            }
            ListedTvShow[] items = availables.ToArray();
            Array.Sort(items);
            return items;
        }

        public async Task<IEnumerable<ListedTvShow>> SearchAsync(string keywords)
        {
            try
            {
                return await AvailableShowsAsync("http://www.tubeplus.me/search/tv-shows/" + keywords.Replace(" ", "_") + "/");
            }
            catch { return null; }
        }

        public async Task<IEnumerable<ListedTvShow>> StartsWithAsync(string letter)
        {
            try
            {
                return await AvailableShowsAsync("http://www.tubeplus.me/browse/tv-shows/All_Genres/" + letter + "/");
            }
            catch { return null; }
        }

        public async Task<TvShow> ShowAsync(string name, bool full)
        {
            int bidon = 0;
            if (!int.TryParse(name, out bidon))
                return null;
            TvShow show = new TvShow();
            show.Name = name;
            show.IsComplete = true;
            string baseurl = "http://www.tubeplus.me/info/" + name + "/";
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Movie have been removed"))
                return null;
            show.Title = src.Extract("<title>TUBE+ - \"", "\"");
            if (show.Title == null)
                return null;
            string allSeasons = src.Extract("<div id=\"seasons\">", "</div>");
            string seasDeb = "<a id=";
            int startS = allSeasons.IndexOf(seasDeb) + seasDeb.Length;
            while (startS >= seasDeb.Length)
            {
                int endS = allSeasons.IndexOf("</span>", startS);
                string itemS = allSeasons.Substring(startS, endS - startS).Trim();
                String sInfo = itemS.Extract( "javascript:show_season(", "\")'>");
                string[] eps = sInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<int, DateTime> infos = new Dictionary<int, DateTime>();
                foreach (string ep in eps)
                {
                    string[] parts = ep.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 2)
                    {
                        int id = int.Parse(parts[2]);
                        try
                        {
                            DateTime date = DateTime.ParseExact(parts.Last(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                            infos.Add(id, date);
                        }
                        catch { }
                    }
                }

                startS = allSeasons.IndexOf(seasDeb, endS) + seasDeb.Length;
                int no = 0;
                if (!int.TryParse(itemS.Extract( "lseason_", "\""), out no))
                    continue;
                if (!show.Episodes.ContainsKey(no))
                    show.Episodes.Add(no, new List<ListedEpisode>());
                List<ListedEpisode> episodes = (List<ListedEpisode>)show.Episodes[no];

                string epDeb = "<a name=";
                int startE = itemS.IndexOf(epDeb) + epDeb.Length;
                while (startE >= epDeb.Length)
                {
                    ListedEpisode episode = new ListedEpisode();
                    int endE = itemS.IndexOf("</a>", startE);
                    string itemE = itemS.Substring(startE, endE - startE).Trim();

                    episode.Name = itemE.Extract( "/player/", "/");
                    int id = int.Parse(episode.Name);
                    episode.NoEpisode = int.Parse(itemE.Extract( ">Episode ", " -"));
                    episode.NoSeason = no;
                    episode.Title = itemE.Substring(itemE.LastIndexOf(" - ") + 3);

                    episode.ReleaseDate = DateTime.MinValue;
                    if (infos.ContainsKey(id))
                    {
                        episode.ReleaseDate = infos[id];
                        if (episode.ReleaseDate <= DateTime.Now)
                        {
                            episodes.Insert(0, episode);
                            if (show.NoLastSeason == 0)
                            {
                                show.NoLastSeason = episode.NoSeason;
                                show.NoLastEpisode = episode.NoEpisode;
                            }
                        }
                    }
                    startE = itemS.IndexOf(epDeb, endE) + epDeb.Length;
                }
            }
            return show;
        }

        public async Task<Episode> EpisodeAsync(string epId)
        {
            Episode ep = new Episode();
            ep.Name = epId;
            string baseurl = "http://www.tubeplus.me/player/" + epId + "/";
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Movie have been removed"))
                return null;

            string nfos = src.Extract("<a class=\"none\" href=\"#\">", "</a>");
            string sep = " - ";
            ep.Title = nfos.Extract( sep, sep);
            string nfoNos = nfos.Extract( "  ", sep);
            ep.NoSeason = int.Parse(nfoNos.Extract( "S", "E"));
            ep.NoEpisode = int.Parse(nfoNos.Substring(nfoNos.IndexOf("E") + 1));
            ep.ReleaseDate = DateTime.MinValue;

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

                if (!ep.Links.ContainsKey(website))
                    ep.Links.Add(website, new List<string>());
                ep.Links[website].Add(url);
            }
            return ep;
        }

        public Task<StreamingInfo> StreamAsync(string website, string args)
        {
            string url = TubePlusHelper.ObtainURL(website, args);
            return new Task<StreamingInfo>(delegate() { return url == null ? null : new StreamingInfo() { StreamingURL = url, Arguments = args, Website = website, DownloadURL = null }; });
        }

        public string ShowURL(string name)
        {
            return "http://www.tubeplus.me/info/" + name + "/";
        }

        public string EpisodeURL(string epId)
        {
            return "http://www.tubeplus.me/player/" + epId + "/";
        }
    }
}