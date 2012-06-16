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
using EricUtility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            if (listBox1.SelectedIndex >= 0 && !string.IsNullOrEmpty(textBox1.Text))
            {
                string url = "http://emc.ericmas001.com/VideoParsing/Parse/" + listBox1.SelectedItem.ToString() + "/" + textBox1.Text;
                string result = StringUtility.RemoveHTMLTags(GatheringUtility.GetPageSource(url));
                JObject r = JsonConvert.DeserializeObject<dynamic>(result);
                if (r == null)
                    textBox3.Text = "ERROR !!";
                else
                    textBox3.Text = r["downloadURL"].ToString();
            }
        }

        private void TestPanel_Load(object sender, EventArgs e)
        {
            string url = "http://emc.ericmas001.com/VideoParsing/AvailableWebsites";
            string result = StringUtility.RemoveHTMLTags(GatheringUtility.GetPageSource(url));
            JArray results = JsonConvert.DeserializeObject<dynamic>(result);
            listBox1.Items.AddRange(results.ToArray());
            listBox1.SelectedIndex = 0;
        }
    }
}
