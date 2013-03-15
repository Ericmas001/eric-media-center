using EMCRestService.TvWebsites.Entities;
using EricUtility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EMCRestService.TvWebsites
{
    public class ProjectFreeTvWebsite : ITvWebsite
    {
        private async Task<IEnumerable<ListedTvShow>> AvailableShowsAsync(params string[] keywords)
        {
            List<ListedTvShow> availables = new List<ListedTvShow>();
            string src = await new HttpClient().GetStringAsync("http://www.free-tv-video-online.me/internet/");
            string allShows = StringUtility.Extract(src, "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\" align=\"center\" bgcolor=\"#FFFFFF\">", "<!-- Start of the latest link tables -->");
            string itemp = "class=\"mnlcategorylist\"";
            int start = allShows.IndexOf(itemp) + itemp.Length;
            while (start >= itemp.Length)
            {
                int end = allShows.IndexOf("</tr>", start);
                end = end == -1 ? allShows.Length - 1 : end;
                string item = allShows.Substring(start, end - start);

                ListedTvShow entry = new ListedTvShow();
                entry.Name = StringUtility.Extract(item, "><a href=\"", "/\">");
                entry.Title = StringUtility.Extract(item, "<b>", "</b>");
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
        public async Task<TvShow> ShowAsync(string name)
        {
            TvShow show = new TvShow();
            show.Name = name;

            string baseurl = "http://www.free-tv-video-online.me/internet/" + name;
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Project Free TV Disclaimer"))
                return null;
            show.Title = StringUtility.Extract(src, "<h1 style=\"margin:0; font-size: 20px;\">", "</h1>");
            if (show.Title == null)
                return null;
            Dictionary<int,string> seasons = new Dictionary<int,string>();
            string allSeasons = StringUtility.Extract(src, " Categories</td>", "<!-- Start of the latest link tables -->");
            string seasDeb = "mnlcategorylist\">";
            int startS = allSeasons.IndexOf(seasDeb) + seasDeb.Length;
            while (startS >= seasDeb.Length)
            {
                int endS = allSeasons.IndexOf("</td>", startS);
                string itemS = allSeasons.Substring(startS, endS - startS).Trim();
                int no = int.Parse(StringUtility.Extract(itemS, "<b>Season ", "</b>")??"-1");
                if (no != -1)
                {
                    seasons.Add(no, StringUtility.Extract(itemS, "<a href=\"", ".html\">"));
                    show.Episodes.Add(no, new List<ListedEpisode>());
                }
                startS = allSeasons.IndexOf(seasDeb, endS) + seasDeb.Length;
            }

            foreach(int no in seasons.Keys)
            //Parallel.ForEach(seasons.Keys, async no =>
            {
                List<ListedEpisode> episodes = (List<ListedEpisode>)show.Episodes[no];
                string srcS = await new HttpClient().GetStringAsync(baseurl + "/" + seasons[no]+".html");
                string allEps = StringUtility.Extract(srcS, "<!-- Start of middle column -->", "<!-- End of the middle_column -->");
                string epDeb = "<td class=\"episode\">";
                int startE = allEps.IndexOf(epDeb) + epDeb.Length;
                while (startE >= epDeb.Length)
                {
                    ListedEpisode ep = new ListedEpisode();
                    int endE = allEps.IndexOf("<a class=\"info\"", startE);
                    if (endE == -1)
                        break;
                    string itemS = allEps.Substring(startE, endE - startE).Trim();
                    ep.Name = show.Name + "-" + seasons[no] + "-" + StringUtility.Extract(itemS, "<a name=\"", "\"></a>");
                    ep.Title = StringUtility.Extract(itemS, "</a><b>", "</b></td>");
                    string nfo = StringUtility.Extract(itemS, "<td class=\"mnllinklist\" align=\"right\">", "/div>");
                    ep.NoSeason = int.Parse(StringUtility.Extract(nfo, ">S", "E"));
                    ep.NoEpisode = int.Parse(StringUtility.Extract(nfo, ep.NoSeason + "E", "&nbsp;"));
                    string dt = StringUtility.Extract(nfo, "Air Date: ", "<");
                    ep.ReleaseDate = DateTime.ParseExact(dt, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    episodes.Add(ep);
                    startE = allEps.IndexOf(epDeb, endE) + epDeb.Length;
                }
            }//);

            ListedEpisode lastEp = show.Episodes.Last().Value.Last();
            show.NoLastEpisode = lastEp.NoEpisode;
            show.NoLastSeason = lastEp.NoSeason;
            return show;
        }


        public async Task<Episode> EpisodeAsync(string epId)
        {
            Episode ep = new Episode();
            ep.Name = epId;
            string[] info = epId.Split('-');
            string baseurl = "http://www.free-tv-video-online.me/internet/" + info[0] + "/" + info[1] + ".html";
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Project Free TV Disclaimer"))
                return null;

            string all = StringUtility.Extract(src.Replace("</td></tr><tr class=\"3\" bgcolor=\"#E3E3E3\" >", "</td></tr></table>"), "<a name=\"" + info[2] + "\">", "</td></tr></table>");

            ep.Title = StringUtility.Extract(all, "</a><b>", "</b");
            string nfo = StringUtility.Extract(all, "<td class=\"mnllinklist\" align=\"right\">", "/div>");
            ep.NoSeason = int.Parse(StringUtility.Extract(nfo, ">S", "E"));
            ep.NoEpisode = int.Parse(StringUtility.Extract(nfo, ep.NoSeason + "E", "&nbsp;"));
            string dt = StringUtility.Extract(nfo, "Air Date: ", "<");
            ep.ReleaseDate = DateTime.ParseExact(dt, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);


            string linkDeb = "class=\"mnllinklist dotted\">";
            int startP = all.IndexOf(linkDeb) + linkDeb.Length;
            while (startP >= linkDeb.Length)
            {
                int endP = all.IndexOf("</a>", startP);
                string itemP = all.Substring(startP, endP - startP).Trim();
                startP = all.IndexOf(linkDeb, endP) + linkDeb.Length;

                string website = StringUtility.Extract(itemP, "Host: ", "<br/>");
                string url = StringUtility.Extract(itemP, "href=\"http://www.free-tv-video-online.me/player/", "\"");
                if (url == null)
                {
                    url = StringUtility.Extract(itemP, "href=\"http://", "\"").Replace("/","_");
                }

                if (!ep.Links.ContainsKey(website))
                    ep.Links.Add(website, new List<string>());
                ep.Links[website].Add(url);
            }

            return ep;
        }


        public async Task<StreamingInfo> StreamAsync(string website, string args)
        {
            return null;
        }
    }
}
