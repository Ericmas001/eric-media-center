using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatchSeriesAppPlugin.Entities;
using WatchSeriesAppPlugin.Panels.Navigation.Core;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public partial class TestNavPanel : NavPanel
    {
        public TestNavInfo TestInfo { get { return Info as TestNavInfo; } }

        protected override void InfoSetted(NavInfo oldI, NavInfo newI)
        {
            TestNavInfo nfo = newI as TestNavInfo;
            label1.Text = nfo.User == null ? "Guest" : nfo.User.Username;
            vButton2.Enabled = (nfo.User != null);
            vButton3.Enabled = (nfo.User != null);
            vButton4.Enabled = (nfo.User != null);
            textBox1.Enabled = (nfo.User != null);
            listBox1.Enabled = (nfo.User != null);
            RefreshList(nfo.User);
            base.InfoSetted(oldI, newI);
        }
        public TestNavPanel()
        {
            InitializeComponent();
        }

        private void vButton1_Click(object sender, EventArgs e)
        {
            TestNavInfo next = new TestNavInfo(Info.FutureParents, Info.User);
            Navigate(next);
        }

        private void vButton2_Click(object sender, EventArgs e)
        {
            //Add
            if (Info.User != null && !String.IsNullOrWhiteSpace(textBox1.Text))
            {
                Info.User.AddFav(textBox1.Text);
                textBox1.Text = "";
                RefreshList();
            }
        }

        private void vButton3_Click(object sender, EventArgs e)
        {
            //Remove
            if (Info.User != null && listBox1.SelectedIndex >= 0)
            {
                Info.User.DelFav(((UserFavoriteInfo)listBox1.SelectedItem).ShowName);
                RefreshList();
            }
        }

        public void RefreshList()
        {
            RefreshList(Info.User);
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
                TvShowNavInfo nfo = new TvShowNavInfo(ssi, Info.FutureParents, Info.User);
                Navigate(nfo);
            }
        }

        private void vButton5_Click(object sender, EventArgs e)
        {
            Navigate(new SearchNavInfo(Info.FutureParents, Info.User));
        }
    }
}
