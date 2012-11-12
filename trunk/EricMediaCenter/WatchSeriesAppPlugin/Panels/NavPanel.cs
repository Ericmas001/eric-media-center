using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EricUtility;
using WatchSeriesAppPlugin.Entities;

namespace WatchSeriesAppPlugin.Panels
{
    public partial class NavPanel : UserControl
    {
        public event EventHandler<KeyEventArgs<NavPanel>> Navigating = delegate { };
        private NavPanel[] m_Parents = new NavPanel[0];
        private UserInfo m_User;
        private MainPanel m_Global;

        public MainPanel Global
        {
            get { return m_Global; }
            set { m_Global = value; }
        }

        public UserInfo User
        {
            get { return m_User; }
            set
            {
                UserInfo oldUser = m_User;
                m_User = value;
                UserSetted(value, oldUser); 
            }
        }

        protected virtual void UserSetted(UserInfo newUsr, UserInfo oldUsr)
        {
            return;
        }

        public virtual string NavName
        {
            get { return "Panel"; }
        }

        public NavPanel[] Parents
        {
            get { return m_Parents; }
            set
            {
                m_Parents = value;
                navBar1.SetNav(this);
            }
        }

        public NavPanel[] FutureParents
        {
            get
            {
                NavPanel[] all = new NavPanel[m_Parents.Length + 1];
                m_Parents.CopyTo(all, 0);
                all[m_Parents.Length] = this;
                return all;
            }
        }
        public NavPanel()
        {
            InitializeComponent();
            navBar1.SetNav(this);
            navBar1.Navigating += new EventHandler<KeyEventArgs<NavPanel>>(navBar1_Navigating);
        }

        void navBar1_Navigating(object sender, KeyEventArgs<NavPanel> e)
        {
            Navigating(this, e);
        }

        public void Navigate(NavPanel next)
        {
            next.Parents = FutureParents;
            Navigating(this, new KeyEventArgs<NavPanel>(next));
        }
    }
}
