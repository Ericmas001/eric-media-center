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
    public class TubePlusWebsite : ITvWebsite
    {
        private async Task<IEnumerable<ListedTvShow>> AvailableShowsAsync(string baseurl)
        {
            List<ListedTvShow> availables = new List<ListedTvShow>();
            string src = await new HttpClient().GetStringAsync(baseurl);
            string allShows = StringUtility.Extract(src, "<div id=\"list_body\">", "<div id=\"list_footer\">");
            string itemp = "<div class=\"list_item";
            int start = allShows.IndexOf(itemp) + itemp.Length;
            while (start >= itemp.Length)
            {
                int end = allShows.IndexOf("</div><div class=\"list_item", start);
                end = end == -1 ? allShows.Length - 1 : end;
                string item = allShows.Substring(start, end - start);

                ListedTvShow entry = new ListedTvShow();
                entry.Name = StringUtility.Extract(item, "/player/", "/");
                entry.Title = StringUtility.Extract(item, "<b>", "</b>");
                availables.Add(entry);
                start = allShows.IndexOf(itemp, end) + itemp.Length;
            }
            ListedTvShow[] items = availables.ToArray();
            Array.Sort(items);
            return items;
        }
        public async Task<IEnumerable<ListedTvShow>> SearchAsync(string keywords)
        {
            return await AvailableShowsAsync("http://www.tubeplus.me/search/tv-shows/" + keywords.Replace(" ", "_") + "/");
        }
        public async Task<IEnumerable<ListedTvShow>> StartsWithAsync(string letter)
        {
            return await AvailableShowsAsync("http://www.tubeplus.me/browse/tv-shows/All_Genres/" + letter + "/");
        }

        public async Task<TvShow> ShowAsync(string name)
        {
            int bidon = 0;
            if (!int.TryParse(name, out bidon))
                return null;
            TvShow show = new TvShow();
            show.Name = name;

            string baseurl = "http://www.tubeplus.me/info/" + name + "/";
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Movie have been removed"))
                return null;
            show.Title = StringUtility.Extract(src, "<title>TUBE+ - \"", "\"");
            if (show.Title == null)
                return null;
            string allSeasons = StringUtility.Extract(src, "<div id=\"seasons\">", "</div>");
            string seasDeb = "<a id=";
            int startS = allSeasons.IndexOf(seasDeb) + seasDeb.Length;
            while (startS >= seasDeb.Length)
            {
                int endS = allSeasons.IndexOf("</span>", startS);
                string itemS = allSeasons.Substring(startS, endS - startS).Trim();
                String sInfo = StringUtility.Extract(itemS, "javascript:show_season(", "\")'>");
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
                if (!int.TryParse(StringUtility.Extract(itemS, "lseason_", "\""), out no))
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

                    episode.Name = StringUtility.Extract(itemE, "/player/", "/");
                    int id = int.Parse(episode.Name);
                    episode.NoEpisode = int.Parse(StringUtility.Extract(itemE, ">Episode ", " -"));
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


        public Task<Episode> EpisodeAsync(string epId)
        {
            return null;
        }
    }
}
