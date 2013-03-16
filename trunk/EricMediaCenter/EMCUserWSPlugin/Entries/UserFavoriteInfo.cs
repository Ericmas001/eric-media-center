using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace EMCUserWSPlugin.Entries
{
    public class UserFavoriteInfo
    {
        private string m_UserName;
        private string m_ShowName;
        private string m_ShowTitle;
        private int m_LastSeason;
        private int m_LastEpisode;
        private int m_LastViewedSeason;
        private int m_LastViewedEpisode;
        private UserFavoritesResponse m_Response;

        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        public string ShowName
        {
            get { return m_ShowName; }
            set { m_ShowName = value; }
        }

        public string ShowTitle
        {
            get { return m_ShowTitle; }
            set { m_ShowTitle = value; }
        }

        public int LastSeason
        {
            get { return m_LastSeason; }
            set { m_LastSeason = value; }
        }

        public int LastEpisode
        {
            get { return m_LastEpisode; }
            set { m_LastEpisode = value; }
        }

        public int LastViewedSeason
        {
            get { return m_LastViewedSeason; }
            set { m_LastViewedSeason = value; }
        }

        public int LastViewedEpisode
        {
            get { return m_LastViewedEpisode; }
            set { m_LastViewedEpisode = value; }
        }

        public UserFavoriteInfo(UserFavoritesResponse response, string userName, string showName, string showTitle, int lastSeason, int lastEpisode, int lastViewedSeason, int lastViewedEpisode)
        {
            m_UserName = userName;
            m_ShowName = showName;
            m_ShowTitle = showTitle;
            m_LastSeason = lastSeason;
            m_LastEpisode = lastEpisode;
            m_LastViewedSeason = lastViewedSeason;
            m_LastViewedEpisode = lastViewedEpisode;
            m_Response = response;
        }

        public static Dictionary<string, UserFavoriteInfo> DeserializeFavs(UserFavoritesResponse response, JArray results)
        {
            Dictionary<string, UserFavoriteInfo> all = new Dictionary<string, UserFavoriteInfo>();
            foreach (JObject r in results)
            {
                UserFavoriteInfo info = new UserFavoriteInfo(response, r);
                all.Add(info.ShowName, info);
            }
            return all;
        }

        public UserFavoriteInfo(UserFavoritesResponse response, JObject r)
        {
            //{
            //"username":"zeus",
            //"showname":"chuck",
            //"lastViewedSeason":3,
            //"lastViewedEpisode":3,
            //"showtitle":"Chuck",
            //"lastSeason":5,
            //"lastEpisode":13
            //}
            m_UserName = r.Value<string>("username");
            m_ShowName = r.Value<string>("showname");
            m_ShowTitle = r.Value<string>("showtitle");
            m_LastSeason = r.Value<int?>("lastSeason") ?? -1;
            m_LastEpisode = r.Value<int?>("lastEpisode") ?? -1;
            m_LastViewedSeason = r.Value<int?>("lastViewedSeason") ?? -1;
            m_LastViewedEpisode = r.Value<int?>("lastViewedEpisode") ?? -1;
            m_Response = response;
        }

        public override string ToString()
        {
            return m_ShowTitle + " (" + m_ShowName + "): LastEpisode: " + m_LastSeason + "x" + m_LastEpisode + ", " + m_UserName + " watched: " + m_LastViewedSeason + "x" + m_LastViewedEpisode;
        }
    }
}