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
    public class TvLinksWebsite : ITvWebsite
    {
        private async Task<IEnumerable<ListedTvShow>> AvailableShowsAsync(params string[] keywords)
        {
            List<ListedTvShow> availables = new List<ListedTvShow>();
            string src = await new HttpClient().GetStringAsync("http://www.tv-links.eu/tv-shows/all_links");
            string allShows = StringUtility.Extract(src, "<div class=\"cfix\">", "<div class=\"a_center pt_1\">");
            string itemp = "<li>";
            int start = allShows.IndexOf(itemp) + itemp.Length;
            while (start >= itemp.Length)
            {
                int end = allShows.IndexOf("</li>", start);
                end = end == -1 ? allShows.Length - 1 : end;
                string item = allShows.Substring(start, end - start);

                ListedTvShow entry = new ListedTvShow();
                entry.Name = StringUtility.Extract(item, "<a href=\"/tv-shows/", "/\" ");
                entry.Title = StringUtility.Extract(item, "<span class=\"c1\">", "<");
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

            string baseurl = "http://www.tv-links.eu/tv-shows/" + name + "/";
            string src = await new HttpClient().GetStringAsync(baseurl);

            if (src.Contains("Page not found!"))
                return null;
            show.Title = StringUtility.Extract(src, "<title>Watch ", " online free on Tv-links</title>");
            if (show.Title == null)
                return null;
            show.Title = show.Title.Trim();
            string n =  StringUtility.Extract(src, "<meta property=\"og:url\" content=\"http://www.tv-links.eu/tv-shows/", "/\"/>");
            if (n.ToLower() != name.ToLower())
                return null;
            string allSeasons = StringUtility.Extract(src, "<!--Episodes-->", "<!--End Episodes-->");
            string seasDeb = "<div class=\"bg_imp biggest bold dark clear";
            int startS = allSeasons.IndexOf(seasDeb) + seasDeb.Length;
            while (startS >= seasDeb.Length)
            {
                int endS = allSeasons.IndexOf("</ul>", startS);
                string itemS = allSeasons.Substring(startS, endS - startS).Trim();
                int no = int.Parse(StringUtility.Extract(itemS, ">Season ", "<") ?? "-1");
                startS = allSeasons.IndexOf(seasDeb, endS) + seasDeb.Length;
                if (no == -1)
                    continue;
                if (!show.Episodes.ContainsKey(no))
                    show.Episodes.Add(no, new List<ListedEpisode>());
                List<ListedEpisode> episodes = (List<ListedEpisode>)show.Episodes[no];
            

                string epDeb = "<li>";
                int startE = itemS.IndexOf(epDeb) + epDeb.Length;
                while (startE >= epDeb.Length)
                {
                    ListedEpisode episode = new ListedEpisode();
                    int endE = itemS.IndexOf("</li>", startE);
                    string itemE = itemS.Substring(startE, endE - startE).Trim();
                    startE = itemS.IndexOf(epDeb, endE) + epDeb.Length;
                    if (itemE.Contains("class=\"list cfix gray\""))
                        continue;

                    string noE = StringUtility.Extract(itemE, "/episode_", "/");
                    episode.Name = "season_" + no + "-episode_" + noE;
                    int id = int.Parse(noE);
                    episode.NoEpisode = int.Parse(noE);
                    episode.NoSeason = no;
                    episode.Title = StringUtility.Extract(itemE, "<span class=\"c2\">", "</span>");

                    string date = StringUtility.Extract(itemE, "<span class=\"c3", "</span>");
                    date = date.Substring(date.IndexOf('>') + 1).Replace("&nbsp;","");
                    episode.ReleaseDate = DateTime.MinValue;
                    if( !String.IsNullOrWhiteSpace(date))
                        episode.ReleaseDate = DateTime.ParseExact(date, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    episodes.Add(episode);
                }
                if (episodes.Count == 0)
                    show.Episodes.Remove(no);
            }
            ListedEpisode lastEp = show.Episodes.Last().Value.Last();
            show.NoLastEpisode = lastEp.NoEpisode;
            show.NoLastSeason = lastEp.NoSeason;
            return show;
        }
    }
}
