using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WatchSeriesAppPlugin.Panels.Navigation
{
    public partial class TestNavPanel : NavPanel
    {
        private string m_NavName = DateTime.Now.ToLongTimeString();
        public override string NavName
        {
            get
            {
                return m_NavName;
            }
        }
        public TestNavPanel()
        {
            InitializeComponent();
        }

        private void vButton1_Click(object sender, EventArgs e)
        {
            TestNavPanel next = new TestNavPanel();
            Navigate(next);
        }
    }
}
