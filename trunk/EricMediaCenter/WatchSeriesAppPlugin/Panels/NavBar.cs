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

namespace WatchSeriesAppPlugin.Panels
{
    public partial class NavBar : UserControl
    {
        public event EventHandler<KeyEventArgs<NavPanel>> Navigating = delegate { };
        private Dictionary<Button, NavPanel> m_Panels = new Dictionary<Button, NavPanel>();
        public NavBar()
        {
            InitializeComponent();
        }
        public void SetNav( NavPanel panel )
        {
            flowLayoutPanel1.Controls.Clear();
            m_Panels.Clear();
            vButton btnLogin = new vButton();
            btnLogin.Size = new System.Drawing.Size(23, 23);
            btnLogin.Text = "Login";
            flowLayoutPanel1.Controls.Add(btnLogin);
            btnLogin.AutoSize = true;
            btnLogin.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010BLACK;
            m_Panels.Add(btnLogin, null);
            btnLogin.Click += new EventHandler(btn_Click);
            foreach (NavPanel pnl in panel.Parents)
            {
                vButton btn = new vButton();
                btn.Size = new System.Drawing.Size(23, 23);
                btn.Text = pnl.NavName;
                flowLayoutPanel1.Controls.Add(btn);
                btn.AutoSize = true;
                btn.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
                m_Panels.Add(btn, pnl);
                btn.Click += new EventHandler(btn_Click);
            }
            btnCurrent.Text = panel.NavName;
            flowLayoutPanel1.Controls.Add(btnCurrent);
            btnCurrent.AutoSize = true;
            m_Panels.Add(btnCurrent, panel);
        }

        void btn_Click(object sender, EventArgs e)
        {
            Navigating(this, new KeyEventArgs<NavPanel>(m_Panels[(Button)sender]));
        }
    }
}
