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
using WatchSeriesAppPlugin.Panels.Navigation.Core;
using EMCMasterPluginLib;

namespace WatchSeriesAppPlugin.Panels
{
    public partial class MainPanel : UserControl
    {
        public MainPanel()
        {
            InitializeComponent();
            WSGlobal.PanelMain = this;

            WSGlobal.LoginPanel.UserLoggedIn += new EventHandler<EricUtility.KeyEventArgs<UserInfo>>(loginPanel_UserLoggedIn);
            WSGlobal.LoginPanel.WrongScreen += new EricUtility.EmptyHandler(loginPanel_WrongScreen);
            
            WSGlobal.RegisterPanel.UserLoggedIn += new EventHandler<EricUtility.KeyEventArgs<UserInfo>>(loginPanel_UserLoggedIn);
            WSGlobal.RegisterPanel.WrongScreen += new EricUtility.EmptyHandler(regPanel_WrongScreen);
            
            WSGlobal.PanelTest.Navigating += new EventHandler<EricUtility.KeyEventArgs<NavInfo>>(nav_Navigating);
            WSGlobal.PanelSearch.Navigating += new EventHandler<EricUtility.KeyEventArgs<NavInfo>>(nav_Navigating);
            WSGlobal.PanelTVShow.Navigating += new EventHandler<EricUtility.KeyEventArgs<NavInfo>>(nav_Navigating);
        }

        void loginPanel_UserLoggedIn(object sender, EricUtility.KeyEventArgs<UserInfo> e)
        {
            WSGlobal.User = e.Key;
            if (e.Key == null)
            {
                //Enter as a guest
                SetContent(WSGlobal.Navigate(new SearchNavInfo(new NavInfo[0], WSGlobal.User)));
            }
            else
            {
                //Enter as a user
                SetContent(WSGlobal.Navigate(new TestNavInfo(new NavInfo[0], WSGlobal.User)));
            }
        }

        void nav_Navigating(object sender, EricUtility.KeyEventArgs<NavInfo> e)
        {
            if (e.Key == null)
                SetContent(WSGlobal.LoginPanel);
            else
                SetContent(WSGlobal.Navigate(e.Key));
        }
        
        void loginPanel_WrongScreen()
        {
            SetContent(WSGlobal.RegisterPanel);
        }

        void regPanel_WrongScreen()
        {
            SetContent(WSGlobal.LoginPanel);
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            SetContent(WSGlobal.LoginPanel);
        }

        private void SetContent(UserControl newUc)
        {
            EMCGlobal.ChangeMainPanel("WatchSeriesApp", newUc);
        }
    }
}
