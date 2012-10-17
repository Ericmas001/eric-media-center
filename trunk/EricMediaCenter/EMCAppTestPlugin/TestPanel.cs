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
            if (listBox1.SelectedIndex >= 0)
            {
                string listChoice = (string)listBox1.SelectedItem;
                string args = textBox1.Text;
                textBox3.Text = EMCGlobal.GetWebServiceResult(listChoice, args).ToString();
            }
        }

        private void TestPanel_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] keys = EMCGlobal.WebServiceClients.Keys.ToArray();
            Array.Sort(keys);
            listBox1.Items.AddRange(keys);
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string listChoice = (string)listBox1.SelectedItem;
                lblCommand.Text = EMCGlobal.WebServiceClients[listChoice].Commands[listChoice.Substring(listChoice.IndexOf('|') + 1)];
            }
        }
    }
}
