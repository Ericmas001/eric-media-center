using System;
using WatchSeriesAppPlugin.Entities;

namespace WatchSeriesAppPlugin.Panels.Navigation.Core
{
    public class UserEventArgs : EventArgs
    {
        private UserInfo m_Old;
        private UserInfo m_New;

        public UserInfo Old { get { return m_Old; } }

        public UserInfo New { get { return m_New; } }

        public UserEventArgs(UserInfo oldUser, UserInfo newUser)
        {
            m_Old = oldUser;
            m_New = newUser;
        }
    }

    public class NavInfo
    {
        public event EventHandler<UserEventArgs> UserSetted = delegate { };

        private string m_Name;
        private NavType m_TypeNav;
        private NavInfo[] m_Parents = new NavInfo[0];
        private UserInfo m_User;

        public UserInfo User
        {
            get { return m_User; }
            set
            {
                UserInfo oldUser = m_User;
                m_User = value;
                UserSetted(this, new UserEventArgs(oldUser, value));
            }
        }

        public NavInfo[] Parents
        {
            get { return m_Parents; }
            set { m_Parents = value; }
        }

        public NavType TypeNav
        {
            get { return m_TypeNav; }
            set { m_TypeNav = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public NavInfo[] FutureParents
        {
            get
            {
                NavInfo[] all = new NavInfo[m_Parents.Length + 1];
                m_Parents.CopyTo(all, 0);
                all[m_Parents.Length] = this;
                return all;
            }
        }

        public NavInfo(string name, NavType type, NavInfo[] parents, UserInfo user)
        {
            m_Name = name;
            m_TypeNav = type;
            m_Parents = parents;
            m_User = user;
        }

        public void FireUserSetted(UserInfo old, UserInfo newUser)
        {
            UserSetted(this, new UserEventArgs(old, newUser));
        }
    }
}