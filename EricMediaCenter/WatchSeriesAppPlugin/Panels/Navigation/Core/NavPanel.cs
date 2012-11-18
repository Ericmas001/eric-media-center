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
using WatchSeriesAppPlugin.Panels.Navigation;

namespace WatchSeriesAppPlugin.Panels.Navigation.Core
{
    public partial class NavPanel : UserControl
    {
        public event EventHandler<KeyEventArgs<NavInfo>> Navigating = delegate { };
        private NavInfo m_Info;

        public NavInfo Info
        {
            get { return m_Info; }
            set
            {
                NavInfo old = m_Info;
                m_Info = value;
                InfoSetted(old, value);
            }
        }
        protected virtual void InfoSetted(NavInfo oldI, NavInfo newI)
        {
            newI.UserSetted += new EventHandler<UserEventArgs>(info_UserSetted);
            navBar1.SetNav(newI);
        }
        protected virtual void info_UserSetted(object sender, UserEventArgs args)
        {
            return;
        }
        public NavPanel()
        {
            InitializeComponent();
            navBar1.Navigating += new EventHandler<KeyEventArgs<NavInfo>>(navBar1_Navigating);
        }

        void navBar1_Navigating(object sender, KeyEventArgs<NavInfo> e)
        {
            Navigating(this, e);
        }

        public virtual void Navigate(NavInfo next)
        {
            next.Parents = m_Info.FutureParents;
            Navigating(this, new KeyEventArgs<NavInfo>(next));
        }
    }
}
