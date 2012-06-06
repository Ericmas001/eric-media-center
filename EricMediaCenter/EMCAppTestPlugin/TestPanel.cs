using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Net;
using EMCMasterPluginLib;
using EricUtility.Networking.Gathering;

namespace EMCAppTestPlugin
{
    public partial class TestPanel : UserControl
    {
        public TestPanel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* ParsedVideoWebsite site = null;
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
            }*/
        }
    }
}
