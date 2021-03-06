﻿using EMCMasterPluginLib;
using EMCMasterPluginLib.Application;
using EricMediaCenter.Panels;
using EricUtility;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using VIBlend.WinForms.Controls;

namespace EricMediaCenter
{
    public partial class MainForm : Form
    {
        private bool alreadyToggling = false;
        public vToggleButton oldMenu;
        public Dictionary<string, UserControl> panels = new Dictionary<string, UserControl>();

        public MainForm()
        {
            InitializeComponent();
            panels.Add(btnSettings.Name, new SettingsNavPanel());
            EMCGlobal.SupportedAppUpdated += new EricUtility.EmptyHandler(EMCGlobal_SupportedAppUpdated);
            EMCGlobal.MainPanelChanged += new EventHandler<KeyValueEventArgs<string, UserControl>>(EMCGlobal_MainPanelChanged);
        }

        private void EMCGlobal_MainPanelChanged(object sender, KeyValueEventArgs<string, UserControl> e)
        {
            if (panels.ContainsKey("btn" + e.Key))
            {
                UserControl oldC = panels["btn" + e.Key];
                UserControl newC = e.Value;
                panels[oldMenu.Name] = newC;
                if (panel1.Controls.Contains(oldC))
                {
                    panel1.Controls.Remove(oldC);
                    if (newC != null)
                    {
                        newC.Name = "contentUC";
                        panel1.Controls.Add(newC);
                        newC.Dock = DockStyle.Fill;
                        newC.Focus();
                    }
                }
            }
        }

        private void EMCGlobal_SupportedAppUpdated()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EmptyHandler(EMCGlobal_SupportedAppUpdated));
                return;
            }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Hide();
            bool done = false;
            ThreadPool.QueueUserWorkItem((x) =>
            {
                using (var splashForm = new SplashForm())
                {
                    splashForm.Show();
                    while (!done)
                        Application.DoEvents();
                    splashForm.Close();
                }
            });

            EMCGlobal.ReloadApplicationPlugins();
            done = true;
            Show();
        }
    }
}