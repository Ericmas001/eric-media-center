using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;

namespace WatchSeriesAppPlugin.Entities
{
    public class UserInfo
    {
        private string m_Username;
        private string m_Password;
        private string m_Token;
        private DateTime m_ValidUntil;
        private string m_LastMessage;
        private Dictionary<string,UserFavoriteInfo> m_Favorites;

        public Dictionary<string, UserFavoriteInfo> Favorites
        {
            get { return m_Favorites; }
            set { m_Favorites = value; }
        }

        public string Username
        {
            get { return m_Username; }
            set { m_Username = value; }
        }

        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        public string Token
        {
            get { return m_Token; }
            set { m_Token = value; }
        }

        public DateTime ValidUntil
        {
            get { return m_ValidUntil; }
            set { m_ValidUntil = value; }
        }

        public string LastMessage
        {
            get { return m_LastMessage; }
            set { m_LastMessage = value; }
        }

        public UserInfo(string username, string password)
        {
            m_Username = username;
            m_Password = password;
        }
        public bool Connect()
        {
            if (!String.IsNullOrWhiteSpace(m_Token) && ((ValidUntil - DateTime.Now).Minutes >= 1))
                return true;

            if (string.IsNullOrWhiteSpace(m_Username) || string.IsNullOrWhiteSpace(m_Password))
            {
                m_LastMessage = "Not all the required fields have been filled!";
                return false;
            }

            dynamic res = EMCGlobal.GetWebServiceResult("User|Connect", m_Username + "/" + m_Password);
            if (res.Success)
            {
                m_Token = res.Token;
                m_ValidUntil = res.ValidUntil;
            }
            else
                m_LastMessage = res.Message;
            return res.Success;
        }
        public bool GetFavs()
        {
            if (!Connect())
                return false;
            dynamic res = EMCGlobal.GetWebServiceResult("User|GetFavs", m_Token);
            if (res.Success)
            {
                m_Favorites = new Dictionary<string, UserFavoriteInfo>();
                foreach( string k in res.Favorites.Keys)
                {
                    var v = res.Favorites[k];
                    m_Favorites.Add(k, new UserFavoriteInfo(v.ShowName, v.ShowTitle, v.LastSeason, v.LastEpisode, v.LastViewedSeason, v.LastViewedEpisode));
                }
                m_Token = res.Token;
                m_ValidUntil = res.ValidUntil;
            }
            else
                m_LastMessage = res.Message;
            return res.Success;
        }

        internal bool Register()
        {
            if (!String.IsNullOrWhiteSpace(m_Token))
            {
                m_LastMessage = "Already Connected";
                return false;
            }

            if (string.IsNullOrWhiteSpace(m_Username) || string.IsNullOrWhiteSpace(m_Password))
            {
                m_LastMessage = "Not all the required fields have been filled!";
                return false;
            }

            dynamic res = EMCGlobal.GetWebServiceResult("User|Register", m_Username + "/" + m_Password);
            if (res.Success)
            {
                return Connect();
            }
            else
                m_LastMessage = res.Message;
            return res.Success;
        }
    }

}
