using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace EMCUserWSPlugin.Entries
{
    public class UserFavoritesResponse : UserDetailedResponse
    {
        private Dictionary<string, UserFavoriteInfo> m_Favorites;

        public Dictionary<string, UserFavoriteInfo> Favorites
        {
            get { return m_Favorites; }
            set { m_Favorites = value; }
        }

        public UserFavoritesResponse(bool success, string message)
            : base(success, message)
        {
        }

        public UserFavoritesResponse(bool success, string token, DateTime validUntil, Dictionary<string, UserFavoriteInfo> favs)
            : base(success, token, validUntil)
        {
            m_Favorites = favs;
        }

        public UserFavoritesResponse(JObject r)
            : base(r)
        {
            //{"success":true,"favorites":[{"username":"zeus","showname":"chuck","lastViewedSeason":3,"lastViewedEpisode":3,"showtitle":"Chuck","lastSeason":5,"lastEpisode":13},{"username":"zeus","showname":"dexter","lastViewedSeason":null,"lastViewedEpisode":null,"showtitle":"Dexter","lastSeason":7,"lastEpisode":3},{"username":"zeus","showname":"fringe","lastViewedSeason":4,"lastViewedEpisode":13,"showtitle":"Fringe","lastSeason":5,"lastEpisode":3},{"username":"zeus","showname":"homeland","lastViewedSeason":1,"lastViewedEpisode":12,"showtitle":"Homeland","lastSeason":2,"lastEpisode":3},{"username":"zeus","showname":"shameless","lastViewedSeason":null,"lastViewedEpisode":null,"showtitle":"Shameless","lastSeason":10,"lastEpisode":7}],"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:00:49"}
            //{"success":false,"problem":"User already exist"}
            if (Success)
                m_Favorites = UserFavoriteInfo.DeserializeFavs(this, (JArray)r["favorites"]);
            else
                m_Favorites = new Dictionary<string, UserFavoriteInfo>();
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}