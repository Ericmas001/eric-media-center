using EMCRestService.TvWebsites.Entities;
using EricUtility;
using EricUtility.Networking.Gathering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            //string allSeasons = StringUtility.Extract(src, "<div id=\"seasons\">", "</div>");
            //string seasDeb = "<a id=";
            //int startS = allSeasons.IndexOf(seasDeb) + seasDeb.Length;
            //while (startS >= seasDeb.Length)
            //{
            //    int endS = allSeasons.IndexOf("</span>", startS);
            //    string itemS = allSeasons.Substring(startS, endS - startS).Trim();
            //    String sInfo = StringUtility.Extract(itemS, "javascript:show_season(", "\")'>");
            //    string[] eps = sInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            //    Dictionary<int, DateTime> infos = new Dictionary<int, DateTime>();
            //    foreach (string ep in eps)
            //    {
            //        string[] parts = ep.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            //        if (parts.Length > 2)
            //        {
            //            int id = int.Parse(parts[2]);
            //            try
            //            {
            //                DateTime date = DateTime.ParseExact(parts.Last(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            //                infos.Add(id, date);
            //            }
            //            catch { }
            //        }
            //    }

            //    startS = allSeasons.IndexOf(seasDeb, endS) + seasDeb.Length;
            //    int no = 0;
            //    if (!int.TryParse(StringUtility.Extract(itemS, "lseason_", "\""), out no))
            //        continue;
            //    if (!show.Episodes.ContainsKey(no))
            //        show.Episodes.Add(no, new List<ListedEpisode>());
            //    List<ListedEpisode> episodes = (List<ListedEpisode>)show.Episodes[no];

            //    string epDeb = "<a name=";
            //    int startE = itemS.IndexOf(epDeb) + epDeb.Length;
            //    while (startE >= epDeb.Length)
            //    {
            //        ListedEpisode episode = new ListedEpisode();
            //        int endE = itemS.IndexOf("</a>", startE);
            //        string itemE = itemS.Substring(startE, endE - startE).Trim();

            //        episode.Name = StringUtility.Extract(itemE, "/player/", "/");
            //        int id = int.Parse(episode.Name);
            //        episode.NoEpisode = int.Parse(StringUtility.Extract(itemE, ">Episode ", " -"));
            //        episode.NoSeason = no;
            //        episode.Title = itemE.Substring(itemE.LastIndexOf(" - ") + 3);

            //        episode.ReleaseDate = DateTime.MinValue;
            //        if (infos.ContainsKey(id))
            //        {
            //            episode.ReleaseDate = infos[id];
            //            if (episode.ReleaseDate <= DateTime.Now)
            //            {
            //                episodes.Insert(0, episode);
            //                if (show.NoLastSeason == 0)
            //                {
            //                    show.NoLastSeason = episode.NoSeason;
            //                    show.NoLastEpisode = episode.NoEpisode;
            //                }
            //            }
            //        }
            //        startE = itemS.IndexOf(epDeb, endE) + epDeb.Length;
            //    }
            //}
            return show;
        }
    }
}
