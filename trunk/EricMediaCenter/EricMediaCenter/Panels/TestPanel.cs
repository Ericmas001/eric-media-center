﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using EricUtilityNetworking;
using System.Net;
using EricUtility.Networking.Gathering;
using EMCMasterPluginLib.VideoParser;

namespace EricMediaCenter.Panels
{
    public partial class TestPanel : UserControl
    {
        public TestPanel()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EMCGlobal.SupportedVideoParserUpdated += new EricUtility.EmptyHandler(EMCGlobal_SupportedWebsiteUpdated);
            EMCGlobal.ReloadVideoParserPlugins();
        }

        void EMCGlobal_SupportedWebsiteUpdated()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(EMCGlobal.SupportedVideoWebsites.Keys.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParsedVideoWebsite site = null;
            foreach (string s in EMCGlobal.SupportedVideoWebsites.Keys)
            {
                if (site == null && textBox1.Text.Contains(s))
                {
                    CookieContainer cookies = new CookieContainer();
                    site = EMCGlobal.SupportedVideoWebsites[s].FindInterestingContent(GatheringUtility.GetPageSource(textBox1.Text, cookies), textBox1.Text, cookies);
                }
            }

            if (site == null || !site.Success)
            {
                textBox2.Text = textBox1.Text = "ERROR !!";
            }
            else
            {
                textBox2.Text = site.VideoUrl;
                textBox3.Text = site.DownloadUrl;
            }
        }
    }
}
