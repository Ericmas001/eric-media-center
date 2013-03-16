using EMCMasterPluginLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using WatchSeriesAppPlugin.Entities;
using WatchSeriesAppPlugin.Panels.Navigation.Core;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public partial class SearchNavPanel : NavPanel
    {
        public SearchNavInfo SearchInfo { get { return Info as SearchNavInfo; } }

        public SearchNavPanel()
        {
            InitializeComponent();
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            if (WSGlobal.Genres == null)
                WSGlobal.Genres = (List<string>)EMCGlobal.GetWebServiceResult("WatchSeries|AvailableGenres", null);
            SearchInfo.Choices = WSGlobal.Genres;
            lstChoices.Items.Clear();
            lstChoices.Items.AddRange(WSGlobal.Genres.ToArray());
            SearchInfo.IsLetter = false;
        }

        private void btnLetters_Click(object sender, EventArgs e)
        {
            if (WSGlobal.Letters == null)
                WSGlobal.Letters = (List<string>)EMCGlobal.GetWebServiceResult("WatchSeries|AvailableLetters", null);
            SearchInfo.Choices = WSGlobal.Letters;
            lstChoices.Items.Clear();
            lstChoices.Items.AddRange(WSGlobal.Letters.ToArray());
            SearchInfo.IsLetter = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchInfo.Keywords = txtSearch.Text;
            if (!String.IsNullOrWhiteSpace(txtSearch.Text))
                GetResult("Search", txtSearch.Text);
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex >= 0)
            {
                TvShowNavInfo showNfo = new TvShowNavInfo((ShowSummaryInfo)lstResults.SelectedItem, Info.FutureParents, Info.User);
                Navigate(showNfo);
            }
        }

        private void lstChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChoices.SelectedIndex >= 0)
                GetResult(SearchInfo.IsLetter ? "GetLetter" : "GetGenre", (string)lstChoices.SelectedItem);
        }

        private void GetResult(string command, string arg)
        {
            IEnumerable results = (IEnumerable)EMCGlobal.GetWebServiceResult("WatchSeries|" + command, arg);
            lstResults.Items.Clear();
            SearchInfo.Results.Clear();
            foreach (object o in results)
            {
                dynamic show = (dynamic)o;
                ShowSummaryInfo ssi = new ShowSummaryInfo(show.Name, show.Title, show.ReleaseYear);
                SearchInfo.Results.Add(ssi);
            }
            lstResults.Items.AddRange(SearchInfo.Results.ToArray());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchInfo.Keywords = txtSearch.Text;
        }

        protected override void InfoSetted(NavInfo oldI, NavInfo newI)
        {
            SearchNavInfo nfo = newI as SearchNavInfo;

            lstResults.Items.Clear();
            lstChoices.Items.Clear();

            txtSearch.Text = nfo.Keywords;
            lstResults.Items.AddRange(nfo.Results.ToArray());
            lstChoices.Items.AddRange(nfo.Choices.ToArray());

            base.InfoSetted(oldI, newI);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}