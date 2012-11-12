using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatchSeriesAppPlugin.Entities;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public partial class TestNavPanel : NavPanel
    {
        private string m_NavName = DateTime.Now.ToLongTimeString();
        public override string NavName
        {
            get
            {
                return m_NavName;
            }
        }
        protected override void UserSetted(UserInfo u, UserInfo old)
        {
            label1.Text = u == null ? "Guest" : u.Username;
            vButton2.Enabled = (u != null);
            vButton3.Enabled = (u != null);
            vButton4.Enabled = (u != null);
            textBox1.Enabled = (u != null);
            listBox1.Enabled = (u != null);
            if (u != old)
                RefreshList(u);
            base.UserSetted(u, old);
        }
        public TestNavPanel()
        {
            InitializeComponent();
        }

        private void vButton1_Click(object sender, EventArgs e)
        {
            TestNavPanel next = new TestNavPanel();
            Navigate(next);
        }

        private void vButton2_Click(object sender, EventArgs e)
        {
            //Add
            if (User != null && !String.IsNullOrWhiteSpace(textBox1.Text))
            {
                User.AddFav(textBox1.Text);
                textBox1.Text = "";
                RefreshList();
            }
        }

        private void vButton3_Click(object sender, EventArgs e)
        {
            //Remove
            if (User != null && listBox1.SelectedIndex >= 0)
            {
                User.DelFav(((UserFavoriteInfo)listBox1.SelectedItem).ShowName);
                RefreshList();
            }
        }

        public void RefreshList()
        {   
            RefreshList(User);
        }

        public void RefreshList(UserInfo u)
        {
            if (u == null)
                listBox1.Items.Clear();
            else
            {

                if (u.GetFavs())
                {
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(u.Favorites.Values.ToArray());
                }
                else
                    MessageBox.Show(u.LastMessage);
            }
        }

        private void vButton4_Click(object sender, EventArgs e)
        {
            //Refresh
            RefreshList();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                UserFavoriteInfo fav = (UserFavoriteInfo)listBox1.SelectedItem;
                ShowSummaryInfo ssi = new ShowSummaryInfo(fav.ShowName, fav.ShowTitle, -1);
                TVShowNavPanel showPnl = new TVShowNavPanel();
                showPnl.SetShow(ssi);
                Navigate(showPnl);
            }
        }

        private void vButton5_Click(object sender, EventArgs e)
        {
            Navigate(new SearchNavPanel());
        }
    }
}
