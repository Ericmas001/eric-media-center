using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EricMediaCenter.Panels
{
    public partial class SettingsNavPanel : UserControl
    {
        public Dictionary<string, UserControl> m_SettingContents = new Dictionary<string, UserControl>()
            {
                {"Plugins",new PluginsSettingsContent()}
            };
        public SettingsNavPanel()
        {
            InitializeComponent();
            lstMenu.Items.AddRange(m_SettingContents.Keys.ToArray());
            if( lstMenu.Items.Count > 0 )
                lstMenu.SelectedIndex = 0;
            
        }
        public void Navigate(string content)
        {
            pnlContent.Controls.Clear();

            if (m_SettingContents.ContainsKey(content))
            {
                UserControl uctl = m_SettingContents[content];
                pnlContent.Controls.Add(uctl);
                uctl.Dock = DockStyle.Fill;
            }
        }

        private void lstMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMenu.SelectedIndex >= 0)
                Navigate(lstMenu.SelectedItem.ToString());
        }
    }
}
