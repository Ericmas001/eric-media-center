using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VIBlend.WinForms.Controls;
using System.Reflection;
using EricUtility;
using WatchSeriesAppPlugin.Panels.Navigation;

namespace WatchSeriesAppPlugin.Panels.Navigation.Core
{
    public partial class NavBar : UserControl
    {
        public event EventHandler<KeyEventArgs<NavInfo>> Navigating = delegate { };
        private Dictionary<Button, NavInfo> m_Infos = new Dictionary<Button, NavInfo>();
        public NavBar()
        {
            InitializeComponent();
        }
        public void SetNav(NavInfo info)
        {
            flowLayoutPanel1.Controls.Clear();
            m_Infos.Clear();
            vButton btnLogin = new vButton();
            btnLogin.Size = new System.Drawing.Size(23, 23);
            btnLogin.Text = "Login";
            flowLayoutPanel1.Controls.Add(btnLogin);
            btnLogin.AutoSize = true;
            btnLogin.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010BLACK;
            m_Infos.Add(btnLogin, null);
            btnLogin.Click += new EventHandler(btn_Click);
            foreach (NavInfo nfo in info.Parents)
            {
                vButton btn = new vButton();
                btn.Size = new System.Drawing.Size(23, 23);
                btn.Text = nfo.Name;
                flowLayoutPanel1.Controls.Add(btn);
                btn.AutoSize = true;
                btn.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
                m_Infos.Add(btn, nfo);
                btn.Click += new EventHandler(btn_Click);
            }
            btnCurrent.Text = info.Name;
            flowLayoutPanel1.Controls.Add(btnCurrent);
            btnCurrent.AutoSize = true;
            m_Infos.Add(btnCurrent, info);
        }

        void btn_Click(object sender, EventArgs e)
        {
            Navigating(this, new KeyEventArgs<NavInfo>(m_Infos[(Button)sender]));
        }
    }
}
