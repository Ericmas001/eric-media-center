﻿using EMCRestService.TvWebsites.Entities;
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
    public class ProjectFreeTvWebsite : ITvWebsite
    {
        private IEnumerable<ListedTvShow> AvailableShows(params string[] keywords)
        {
            List<ListedTvShow> availables = new List<ListedTvShow>();
            string src = GatheringUtility.GetPageSource("http://www.free-tv-video-online.me/internet/");
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
        public IEnumerable<ListedTvShow> Search(string keywords)
        {
            return AvailableShows(keywords.Split(' '));
        }
        public IEnumerable<ListedTvShow> StartsWith(string letter)
        {
            char debut = letter.ToLower()[0];
            return AvailableShows(debut.ToString()).Where(x => x.Title.ToLower()[0] == debut || ((debut < 'a' || debut > 'z') && (x.Title.ToLower()[0] < 'a' || x.Title.ToLower()[0] > 'z')));
        }
        public TvShow Show(string name)
        {
            TvShow show = new TvShow();
            show.Name = name;

            string baseurl = "http://www.free-tv-video-online.me/internet/" + name;
            string src = GatheringUtility.GetPageSource(baseurl);

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
                //string url = baseurl + "/" + StringUtility.Extract(itemS, "<a href=\"", "\">");
                int no = int.Parse(StringUtility.Extract(itemS, "<b>Season ", "</b>"));
                seasons.Add(no, StringUtility.Extract(itemS, "<a href=\"", "\">"));
                show.Episodes.Add(no, new List<ListedEpisode>());
                startS = allSeasons.IndexOf(seasDeb, endS) + seasDeb.Length;
            }

            Parallel.ForEach(seasons.Keys, no =>
            {
                List<ListedEpisode> episodes = (List<ListedEpisode>)show.Episodes[no];
                string srcS = GatheringUtility.GetPageSource(baseurl + "/" + seasons[no]);
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
                    ep.Name = StringUtility.Extract(itemS, "<a name=\"", "\"></a>") + "-" + seasons[no];
                    ep.Title = StringUtility.Extract(itemS, "</a><b>", "</b></td>");
                    string nfo = StringUtility.Extract(itemS, "<td class=\"mnllinklist\" align=\"right\">", "/div>");
                    ep.NoSeason = int.Parse(StringUtility.Extract(nfo, ">S", "E"));
                    ep.NoEpisode = int.Parse(StringUtility.Extract(nfo, ep.NoSeason + "E", "&nbsp;"));
                    string dt = StringUtility.Extract(nfo, "Air Date: ", "<");
                    ep.ReleaseDate = DateTime.ParseExact(dt, "dd MMMM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    episodes.Add(ep);
                    startE = allEps.IndexOf(epDeb, endE) + epDeb.Length;
                }
            });

            ListedEpisode lastEp = show.Episodes.Last().Value.Last();
            show.NoLastEpisode = lastEp.NoEpisode;
            show.NoLastSeason = lastEp.NoSeason;
            return show;
        }
    }
}
