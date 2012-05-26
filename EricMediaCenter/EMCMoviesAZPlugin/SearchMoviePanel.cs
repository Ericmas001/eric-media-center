using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VIBlend.WinForms.Controls;

namespace EMCMoviesAZPlugin
{
    public delegate void SearchHandler(SearchType type, string value);
    public partial class SearchMoviePanel : UserControl
    {
        public event SearchHandler SearchStarted = delegate { };
        public SearchMoviePanel()
        {
            InitializeComponent();
            string letters = "#ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char l in letters)
            {
                vButton btn = new vButton();
                btn.AllowAnimations = true;
                btn.BackColor = System.Drawing.Color.Transparent;
                btn.Name = "btnLetter" + l;
                btn.RoundedCornersMask = ((byte)(15));
                btn.Size = new System.Drawing.Size(30, 19);
                btn.Text = l.ToString();
                btn.UseVisualStyleBackColor = false;
                btn.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010BLUE;
                btn.Margin = new Padding(1);
                btn.Click += new EventHandler(btnLetter_Click);
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        void btnLetter_Click(object sender, EventArgs e)
        {
            SearchStarted(SearchType.Letter, ((Button)sender).Name.Replace("btnLetter", ""));
        }

        private void MoviesAZPanel_Load(object sender, EventArgs e)
        {
        }
    }
}
