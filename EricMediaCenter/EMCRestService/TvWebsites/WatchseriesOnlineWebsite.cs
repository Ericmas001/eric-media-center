using EMCRestService.Services;
using EMCRestService.TvWebsites.Entities;
using EMCRestService.VideoParser;
using EricUtility;
using EricUtility.Networking.Gathering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCRestService.TvWebsites
{
    public class WatchseriesOnlineWebsite : ITvWebsite
    {
        private async Task<IEnumerable<ListedTvShow>> AvailableShowsAsync(params string[] keywords)
        {
            List<ListedTvShow> availables = new List<ListedTvShow>();
            string src = await new HttpClient().GetStringAsync("http://www.watchseries-online.eu/2005/07/index.html");
            string allShows = StringUtility.Extract(src, "<div id=\"ddmcc_container\">", "<div class=\"cleared\">");
            string itemp = "<li>";
            int start = allShows.IndexOf(itemp) + itemp.Length;
            while (start >= itemp.Length)
            {
                int end = allShows.IndexOf("</li>", start);
                end = end == -1 ? allShows.Length - 1 : end;
                string item = allShows.Substring(start, end - start);

                ListedTvShow entry = new ListedTvShow();
                entry.Name = StringUtility.Extract(item, "http://www.watchseries-online.eu/category/", "\">");
                entry.Title = StringUtility.Extract(item, entry.Name + "\">", "</a>");
                if (keywords.Count(x => entry.Title.ToLower().Contains(x.ToLower()) || entry.Name.ToLower().Contains(x.ToLower())) > 0)
                    availables.Add(entry);
                start = allShows.IndexOf(itemp, end) + itemp.Length;
            }
            ListedTvShow[] items = availables.ToArray();
            Array.Sort(items);
            return items;
        }

        public async Task<IEnumerable<ListedTvShow>> SearchAsync(string keywords)
        {
            return await AvailableShowsAsync(keywords.Split(' '));
        }

        public async Task<IEnumerable<ListedTvShow>> StartsWithAsync(string letter)
        {
            char debut = letter.ToLower()[0];
            return (await AvailableShowsAsync(debut.ToString())).Where(x => x.Title.ToLower()[0] == debut || ((debut < 'a' || debut > 'z') && (x.Title.ToLower()[0] < 'a' || x.Title.ToLower()[0] > 'z')));
        }

        public void ExtractTitleAndNos(ListedEpisode episode, string title, string showname)
        {
            string[] tparts = title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] sparts = showname.Split(' ');
            int i = 1;
            episode.NoSeason = episode.NoEpisode = -1;
            while ((i < tparts.Length) && episode.NoSeason == -1 && episode.NoEpisode == -1)
            {
                string nfo = tparts[i].Trim();
                try
                {
                    if (nfo.StartsWith("-"))
                    {
                        string mid = "&#215;";
                        if (nfo.Contains("x"))
                            mid = "x";
                        if (nfo.Contains("X"))
                            mid = "X";
                        if (nfo.Contains("×"))
                            mid = "×";
                        episode.NoSeason = int.Parse(StringUtility.Extract(nfo, "-", mid));
                        episode.NoEpisode = int.Parse(StringUtility.Extract(nfo, mid, "-"));
                    }
                    else if (nfo.StartsWith("S"))
                    {
                        episode.NoSeason = int.Parse(StringUtility.Extract(nfo, "S", "E"));
                        episode.NoEpisode = int.Parse(nfo.Substring(nfo.IndexOf('E') + 1));
                    }
                    else
                        episode.NoSeason = episode.NoEpisode = -1;
                }
                catch
                {
                    episode.NoSeason = episode.NoEpisode = -1;
                }
                ++i;
            }
            episode.Title = String.Join(" ", tparts.Skip(i));
        }

        public List<ListedEpisode> GetEpisodesOnPage(string showname, string src)
        {
            List<ListedEpisode> eps = new List<ListedEpisode>();
            string all = StringUtility.Extract(src, "<h2 class=\"pagetitle\">", "<div class=\"sidebar2\">");
            string postDeb = "<div class=\"Post-inner article\">";
            int startP = all.IndexOf(postDeb) + postDeb.Length;
            while (startP >= postDeb.Length)
            {
                int endP = all.IndexOf("<div class=\"PostContent\">", startP);
                string itemP = all.Substring(startP, endP - startP).Trim();
                startP = all.IndexOf(postDeb, endP) + postDeb.Length;

                ListedEpisode episode = new ListedEpisode();
                episode.Name = StringUtility.Extract(itemP, "<a href=\"http://www.watchseries-online.eu/", ".html").Replace("/", "_");

                string title = StringUtility.RemoveHTMLTags(StringUtility.Extract(itemP, "<span class=\"PostHeader\">", "</a>")).Replace("\n", "");
                ExtractTitleAndNos(episode, title, showname);

                string date = StringUtility.Extract(itemP, "alt=\"PostDateIcon\" />", " | ").Replace("\n", "").Replace("th,", ",").Replace("st,", ",").Replace("nd,", ",").Replace("rd,", ",");
                episode.ReleaseDate = DateTime.ParseExact(date, "MMMM d, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                eps.Add(episode);
            }
            return eps;
        }

        public async Task<TvShow> ShowAsync(string name, bool full)
        {
            TvShow show = new TvShow();
            show.Name = name;

            string baseurl = "http://www.watchseries-online.eu/category/" + name;
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Page not found"))
                return null;
            show.Title = StringUtility.Extract(src, "Episodes Available for: &#8216;", "&#8217;");
            if (show.Title == null)
                return null;
            List<ListedEpisode> eps = GetEpisodesOnPage(show.Title, src);
            show.IsComplete = true;
            if (src.Contains("<ol class=\"wp-paginate\">"))
            {
                if (full)
                {
                    string navig = StringUtility.Extract(src, "<ol class=\"wp-paginate\">", "class=\"next\">");
                    navig = navig.Substring(navig.LastIndexOf("class='page'>"));
                    int nbPages = int.Parse(StringUtility.Extract(navig, ">", "</"));
                    for (int i = 2; i <= nbPages; ++i)
                        eps.AddRange(GetEpisodesOnPage(show.Title, await new HttpClient().GetStringAsync(baseurl + "/page/" + i)));
                }
                else
                    show.IsComplete = false;
            }

            Dictionary<int, IEnumerable<ListedEpisode>> les = new Dictionary<int, IEnumerable<ListedEpisode>>();
            foreach (ListedEpisode le in eps)
            {
                if (!les.ContainsKey(le.NoSeason))
                    les.Add(le.NoSeason, new List<ListedEpisode>());
                List<ListedEpisode> episodes = (List<ListedEpisode>)les[le.NoSeason];
                episodes.Add(le);
            }
            foreach (int no in les.Keys)
            {
                ListedEpisode[] epis = les[no].ToArray();
                Array.Sort(epis);
                show.Episodes.Add(no, epis);
            }
            ListedEpisode lastEp = show.Episodes.Last().Value.Last();
            show.NoLastEpisode = lastEp.NoEpisode;
            show.NoLastSeason = lastEp.NoSeason;
            return show;
        }

        public async Task<Episode> EpisodeAsync(string epId)
        {
            Episode ep = new Episode();
            ep.Name = epId;
            string baseurl = "http://www.watchseries-online.eu/" + epId.Replace("_", "/") + ".html";
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Page not found"))
                return null;

            string showname = StringUtility.Extract(src, "rel=\"category tag\">", "</a>");
            string title = StringUtility.RemoveHTMLTags(StringUtility.Extract(src, "<span class=\"PostHeader\">", "</span>")).Replace("\n", "").Trim();
            ExtractTitleAndNos(ep, title, showname);

            string date = StringUtility.Extract(src, "alt=\"PostDateIcon\"/>", " | ").Replace("\n", "").Replace("th", "").Replace("st", "").Replace("nd", "").Replace("rd", "").Replace("Augu ", "August ");
            ep.ReleaseDate = DateTime.ParseExact(date.Trim(), "MMMM d, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

            string all = StringUtility.Extract(src, "<table class=\"postlinks\">", "</table>");

            string linkDeb = "<tr><td class=";
            int startP = all.IndexOf(linkDeb) + linkDeb.Length;
            while (startP >= linkDeb.Length)
            {
                int endP = all.IndexOf("</td></tr>", startP);
                string itemP = all.Substring(startP, endP - startP).Trim();
                startP = all.IndexOf(linkDeb, endP) + linkDeb.Length;

                string nfo = StringUtility.Extract(itemP, "<a target=\"_blank\" id=\"hovered\"", "</td>");
                string website = StringUtility.Extract(nfo, ">", "<");
                int sp = website.IndexOf(" ");
                if (sp > 1)
                    website = website.Remove(sp);
                string url = StringUtility.Extract(nfo, "href=\"http://www.watchseries-online.eu/getlink.php?l=http://", "\">").Replace("/", "_");

                if (!ep.Links.ContainsKey(website))
                    ep.Links.Add(website, new List<string>());
                ep.Links[website].Add(url);
            }
            return ep;
        }

        public async Task<StreamingInfo> StreamAsync(string website, string args)
        {
            string url = "http://www.watchseries-online.eu/getlink.php?l=http://" + args.Replace("_", "/");
            string durl = null;
            //if (VideoParsingService.Parsers.ContainsKey(website))
            //{
            //    CookieContainer cookies = new CookieContainer();
            //    url = GatheringUtility.GetPageUrl(url, cookies);
            //    IVideoParser p = VideoParsingService.Parsers[website];
            //    durl = p.GetDownloadURL(url, new CookieContainer());
            //}
            return new StreamingInfo() { StreamingURL = url, Arguments = args, Website = website, DownloadURL = durl };
        }


        public string ShowURL(string name)
        {
            return "http://www.watchseries-online.eu/category/" + name;
        }

        public string EpisodeURL(string epId)
        {
            return "http://www.watchseries-online.eu/" + epId.Replace("_", "/") + ".html";
        }
    }
}