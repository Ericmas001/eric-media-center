using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMCMoviesAZPlugin
{
    public partial class MoviesAZPanel : UserControl
    {
        SearchMoviePanel searchPanel = new SearchMoviePanel();
        public MoviesAZPanel()
        {
            InitializeComponent();
            searchPanel.SearchStarted += new SearchHandler(searchPanel_SearchStarted);

            Controls.Add(searchPanel);
            searchPanel.Dock = DockStyle.Fill;
        }

        void searchPanel_SearchStarted(SearchType type, string value)
        {
            Controls.Clear();
        }
    }
}
