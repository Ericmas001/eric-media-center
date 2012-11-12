using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatchSeriesAppPlugin.Entities;
using EMCMasterPluginLib;
using System.Collections;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public partial class SearchNavPanel : NavPanel
    {
        private string m_NavName = "Search";
        private bool isLetter = false;
        public override string NavName
        {
            get
            {
                return m_NavName;
            }
        }
        public SearchNavPanel()
        {
            InitializeComponent();
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            if (Global.Genres == null)
                Global.Genres = (List<string>)EMCGlobal.GetWebServiceResult("WatchSeries|AvailableGenres", null);
            lstChoices.Items.Clear();
            lstChoices.Items.AddRange(Global.Genres.ToArray());
            isLetter = false;
        }

        private void btnLetters_Click(object sender, EventArgs e)
        {
            if (Global.Letters == null)
                Global.Letters = (List<string>)EMCGlobal.GetWebServiceResult("WatchSeries|AvailableLetters", null);
            lstChoices.Items.Clear();
            lstChoices.Items.AddRange(Global.Letters.ToArray());
            isLetter = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
                GetResult("Search", txtSearch.Text);
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex >= 0)
            {
                TVShowNavPanel showPnl = new TVShowNavPanel();
                showPnl.SetShow((ShowSummaryInfo)lstResults.SelectedItem);
                Navigate(showPnl);
            }
        }

        private void lstChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChoices.SelectedIndex >= 0)
                GetResult(isLetter?"GetLetter":"GetGenre", (string)lstChoices.SelectedItem);
        }

        private void GetResult(string command, string arg)
        {
            IEnumerable results = (IEnumerable)EMCGlobal.GetWebServiceResult("WatchSeries|" + command, arg);
            lstResults.Items.Clear();
            foreach (object o in results)
            {
                dynamic show = (dynamic)o;
                ShowSummaryInfo ssi = new ShowSummaryInfo(show.Name, show.Title, show.ReleaseYear);
                lstResults.Items.Add(ssi);
            }
        }
    }
}
