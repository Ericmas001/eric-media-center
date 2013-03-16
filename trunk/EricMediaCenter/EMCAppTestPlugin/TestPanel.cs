using EMCMasterPluginLib;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

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
                object res = EMCGlobal.GetWebServiceResult(listChoice, args);
                if (res is string)
                    textBox3.Text = res.ToString();
                else if (res is IList)
                {
                    textBox3.Text = res.ToString() + Environment.NewLine;
                    foreach (object o in (IList)res)
                        textBox3.Text += o.ToString() + Environment.NewLine;
                }
                else if (res is IDictionary)
                {
                    textBox3.Text = res.ToString() + Environment.NewLine;
                    foreach (object k in ((IDictionary)res).Keys)
                    {
                        object value = ((IDictionary)res)[k];
                        if (value is IList)
                        {
                            textBox3.Text += "> " + k.ToString() + Environment.NewLine;
                            foreach (object v in ((IList)value))
                            {
                                textBox3.Text += ">>> " + v.ToString() + Environment.NewLine;
                            }
                        }
                        else
                            textBox3.Text += "> " + k.ToString() + ": " + value.ToString() + Environment.NewLine;
                    }
                }
                else
                    textBox3.Text = res.ToString();
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