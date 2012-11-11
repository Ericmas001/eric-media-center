using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatchSeriesAppPlugin.Panels.Navigation;
using WatchSeriesAppPlugin.Entities;

namespace WatchSeriesAppPlugin.Panels
{
    public partial class MainPanel : UserControl
    {
        private List<string> m_Letters;

        public List<string> Letters
        {
            get { return m_Letters; }
            set { m_Letters = value; }
        }
        private List<string> m_Genres;

        public List<string> Genres
        {
            get { return m_Genres; }
            set { m_Genres = value; }
        }
        private UserInfo m_User;
        private LoginPanel m_LoginPanel = new LoginPanel();
        private RegisterPanel m_RegisterPanel = new RegisterPanel();
        public MainPanel()
        {
            InitializeComponent();
            Navigate(m_LoginPanel);
        }

        void loginPanel_UserLoggedIn(object sender, EricUtility.KeyEventArgs<UserInfo> e)
        {
            m_User = e.Key;
            if (e.Key == null)
            {
                //Enter as a guest
                Navigate(new SearchNavPanel());
            }
            else
            {
                //Enter as a user
                Navigate(new TestNavPanel());
            }
        }

        void nav_Navigating(object sender, EricUtility.KeyEventArgs<NavPanel> e)
        {
            if (e.Key == null)
                Navigate(m_LoginPanel);
            else
                Navigate(e.Key);
        }

        public void Navigate(UserControl pnl)
        {
            pnlContent.Controls.Clear();
            pnl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(pnl);
            if (pnl is NavPanel)
            {
                NavPanel nav = pnl as NavPanel;
                nav.User = m_User;
                nav.Navigating += new EventHandler<EricUtility.KeyEventArgs<NavPanel>>(nav_Navigating);
                nav.Global = this;
            }
            if (pnl is LoginPanel)
            {
                LoginPanel loginPanel = pnl as LoginPanel;
                loginPanel.UserLoggedIn += new EventHandler<EricUtility.KeyEventArgs<UserInfo>>(loginPanel_UserLoggedIn);
                loginPanel.WrongScreen += new EricUtility.EmptyHandler(loginPanel_WrongScreen);
            }
            if (pnl is RegisterPanel)
            {
                RegisterPanel regPanel = pnl as RegisterPanel;
                regPanel.UserLoggedIn += new EventHandler<EricUtility.KeyEventArgs<UserInfo>>(loginPanel_UserLoggedIn);
                regPanel.WrongScreen += new EricUtility.EmptyHandler(regPanel_WrongScreen);
            }
        }

        void loginPanel_WrongScreen()
        {
            Navigate(m_RegisterPanel);
        }

        void regPanel_WrongScreen()
        {
            Navigate(m_LoginPanel);
        }
    }
}
