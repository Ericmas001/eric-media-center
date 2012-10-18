using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace EMCWatchSeriesWSPlugin.Entries
{
    public class ShowInfo : ShowSummaryInfo
    {
        public ShowInfo(ShowSummaryInfo i)
            : base(i.Name, i.Title, i.ReleaseYear)
        {
        }
        public ShowInfo(string name, string title, int releaseYear)
            : base(name, title, releaseYear)
        {
        }
        public ShowInfo(JObject r)
            : base(r)
        {
            // {
            // "ReleaseDate":"\/Date(1347865200000-0700)\/",
            // "Genre":"mystery",
            // "Status":"New Series",
            // "Network":"NBC (US)",
            // "Imdb":"tt2070791",
            // "Description":"What would you do without it all? In this epic adventure from J.J. Abrams' Bad Robot Productions...",
            // "NbEpisodes":5,
            // "RssFeed":"5921",
            // "Logo":"http://watchseries.eu/imagini/Revolution2012.JPG",
            // "Seasons":
            //  [
            //      {
            //      "SeasonNo":1,"NbEpisodes":5,"SeasonName":null,"Episodes":
            //       [
            //          {
            //          "EpisodeNo":1,
            //          "EpisodeId":194518,
            //          "EpisodeName":"revolution_(2012)_s1_e1-194518",
            //          "EpisodeTitle":"Pilot",
            //          "ReleaseDate":"\/Date(1347865200000-0700)\/"
            //          }
            //        ]
            //       }
            //  ],
            // "ShowName":"revolution_(2012)",
            // "ShowTitle":"Revolution (2012)",
            // "ReleaseYear":2012}
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
