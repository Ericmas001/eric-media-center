using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EricUtility;

namespace WatchSeriesAppPlugin
{
    public partial class NavPanel : UserControl
    {
        public event EventHandler<KeyEventArgs<NavPanel>> Navigating = delegate { };
        private NavPanel[] m_Parents = new NavPanel[0];

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
