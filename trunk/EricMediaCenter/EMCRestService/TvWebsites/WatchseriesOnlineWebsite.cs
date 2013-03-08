using EMCRestService.TvWebsites.Entities;
using EricUtility;
using EricUtility.Networking.Gathering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMCRestService.TvWebsites
{
    public class WatchseriesOnlineWebsite : ITvWebsite
    {
        private IEnumerable<ListedTvShow> AvailableShows(params string[] keywords)
        {
            List<ListedTvShow> availables = new List<ListedTvShow>();
            string src = GatheringUtility.GetPageSource("http://www.watchseries-online.eu/2005/07/index.html");
            string allShows = StringUtility.Extract(src, "<div id=\"ddmcc_container\">","<div class=\"cleared\">");
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
        public IEnumerable<ListedTvShow> Search(string keywords)
        {
            return AvailableShows(keywords.Split(' '));
        }
        public IEnumerable<ListedTvShow> StartsWith(string letter)
        {
            char debut = letter.ToLower()[0];
            return AvailableShows(debut.ToString()).Where(x => x.Title.ToLower()[0] == debut || ((debut < 'a' || debut > 'z') && (x.Title.ToLower()[0]< 'a' || x.Title.ToLower()[0] > 'z')));
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
                string[] tparts = title.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
                string[] sparts = showname.Split(' ');
                episode.Title = String.Join(" ",tparts.Skip(sparts.Length + 1));
                string nfo = tparts[sparts.Length].Trim();
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
                    episode.NoEpisode = int.Parse(nfo.Substring(nfo.IndexOf('E')+1));
                }
                else
                    episode.NoSeason = episode.NoEpisode = -1;

                string date = StringUtility.Extract(itemP, "alt=\"PostDateIcon\" />", " | ").Replace("\n", "").Replace("th", "").Replace("st", "").Replace("nd", "").Replace("rd", "");
                episode.ReleaseDate = DateTime.ParseExact(date, "MMMM d, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                eps.Add(episode);
            }
            return eps;
        }

        public TvShow Show(string name)
        {
            TvShow show = new TvShow();
            show.Name = name;

            string baseurl = "http://www.watchseries-online.eu/category/" + name;
            string src = GatheringUtility.GetPageSource(baseurl);

            if (src.Contains("Page not found"))
                return null;
            show.Title = StringUtility.Extract(src, "Episodes Available for: &#8216;", "&#8217;");
            if (show.Title == null)
                return null;
            List<ListedEpisode> eps = GetEpisodesOnPage(show.Title, src);

            if (src.Contains("<ol class=\"wp-paginate\">"))
            {
                string navig = StringUtility.Extract(src, "<ol class=\"wp-paginate\">", "class=\"next\">");
                navig = navig.Substring(navig.LastIndexOf("class='page'>"));
                int nbPages = int.Parse(StringUtility.Extract(navig, ">", "</"));
                Parallel.For(2, nbPages + 1, i => eps.AddRange(GetEpisodesOnPage(show.Title, GatheringUtility.GetPageSource(baseurl + "/page/" + i))));
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
                show.Episodes.Add(no,epis);
            }
            ListedEpisode lastEp = show.Episodes.Last().Value.Last();
            show.NoLastEpisode = lastEp.NoEpisode;
            show.NoLastSeason = lastEp.NoSeason;
            return show;
        }
    }
}
