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
using EMCMasterPluginLib.Application;

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
            //panels.Add(btnTest.Name, new TestPanel());
            panels.Add(btnSettings.Name, new SettingsPanel());
            EMCGlobal.SupportedAppUpdated += new EricUtility.EmptyHandler(EMCGlobal_SupportedAppUpdated);
            EMCGlobal.ReloadApplicationPlugins();
        }

        void EMCGlobal_SupportedAppUpdated()
        {
            flowLayoutPanel1.Controls.Clear();
            UserControl settings = panels[btnSettings.Name];
            panels.Clear();
            panels.Add(btnSettings.Name, settings);
            foreach (string s in EMCGlobal.ApplicationPlugins.Keys)
            {
                IEMCApplicationPlugin plugin = EMCGlobal.ApplicationPlugins[s];
                IApplication app = plugin.GetApplication();
                vToggleButton btn = new vToggleButton();
                btn.AllowAnimations = true;
                btn.BackColor = System.Drawing.Color.Transparent;
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.Name = "btn" + s;
                btn.RoundedCornersMask = ((byte)(15));
                btn.Size = new System.Drawing.Size(136, 60);
                btn.StyleKey = "ToggleButton";
                btn.ShowFocusRectangle = true;
                btn.Text = app.Title;
                btn.Image = app.Icon;
                btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                btn.Toggle = System.Windows.Forms.CheckState.Unchecked;
                btn.UseVisualStyleBackColor = false;
                btn.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010BLUE;
                btn.ToggleStateChanged += new System.EventHandler(this.btnMenu_ToggleStateChanged);
                btn.KeyDown += new KeyEventHandler(btn_KeyDown);
                panels.Add(btn.Name, app.Content);
                flowLayoutPanel1.Controls.Add(btn);
            }
            if (!alreadyToggling)
            {
                if (flowLayoutPanel1.Controls.Count > 0)
                    ((vToggleButton)flowLayoutPanel1.Controls[0]).Toggle = System.Windows.Forms.CheckState.Checked;
                else
                    btnSettings.Toggle = CheckState.Checked;
            }
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
                    newUc.Focus();
                }
                button.Toggle = CheckState.Checked;
                alreadyToggling = false;
            }
        }

        private void btn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                btnMenu_ToggleStateChanged(sender, e);
        }
    }
}
