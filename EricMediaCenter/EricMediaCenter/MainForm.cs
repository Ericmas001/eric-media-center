using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using EMCMasterPluginLib;
using EricUtility.Networking.Gathering;
using EricUtilityNetworking;
using System.Net;
using EricMediaCenter.Panels;
using VIBlend.WinForms.Controls;

namespace EricMediaCenter
{
    public partial class MainForm : Form
    {
        bool alreadyToggling = false;
        public vToggleButton oldMenu;
        public Dictionary<string, UserControl> panels = new Dictionary<string, UserControl>();
        public MainForm()
        {
            InitializeComponent();
            panels.Add(btnTest.Name, new TestPanel());
            panels.Add(btnSettings.Name, new SettingsPanel());
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
        }

        private void btnMenu_ToggleStateChanged(object sender, EventArgs e)
        {
            if (!alreadyToggling)
            {
                alreadyToggling = true;
                vToggleButton button = sender as vToggleButton;
                UserControl newUc = null;
                if (panels.ContainsKey(button.Name))
                    newUc = panels[button.Name];
                UserControl oldUc = null;
                if (panel1.Controls.ContainsKey("contentUC"))
                    oldUc = panel1.Controls["contentUC"] as UserControl;
                if (oldUc == newUc)
                {
                    button.Toggle = CheckState.Checked;
                    alreadyToggling = false;
                    return;
                }
                if (oldMenu != null)
                    oldMenu.Toggle = CheckState.Unchecked;
                oldMenu = button;
                if (oldUc != null)
                    panel1.Controls.Remove(oldUc);
                if (newUc != null)
                {
                    newUc.Name = "contentUC";
                    panel1.Controls.Add(newUc);
                    newUc.Dock = DockStyle.Fill;
                }
                button.Toggle = CheckState.Checked;
                alreadyToggling = false;
            }
        }
    }
}
