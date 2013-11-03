using EMCCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace EMCCommon.Windows.Forms
{
    public partial class SelectSupportedForm : Form
    {
        private IEnumerable<string> m_Supported;
        private IEnumerable<string> m_Choosen;

        public IEnumerable<string> Choosen
        {
            get { return m_Choosen; }
        }

        public SelectSupportedForm(IEnumerable<string> supported, IEnumerable<string> choosen)
        {
            m_Supported = supported ?? new string[0];
            m_Choosen = choosen;
            InitializeComponent();
            AddCheckBoxes();
            grpWebsites.Controls.OfType<CheckBox>().ToList().ForEach(chk => chk.CheckedChanged += chk_CheckedChanged);
            chk_CheckedChanged(null, null);
        }

        void chk_CheckedChanged(object sender, EventArgs e)
        {
            btnUseSome.Enabled = grpWebsites.Controls.OfType<CheckBox>().Count(chk => chk.Checked) > 0;
        }
        public void AddCheckBoxes()
        {
            int more = (30 * (m_Supported.Count() - 1));
            Size = new Size(Width, Height + more);
            grpWebsites.Size = new Size(grpWebsites.Width, grpWebsites.Height + more);
            btnUseSome.Location = new Point(btnUseSome.Left, btnUseSome.Top + more);
            int offset = chkModel.Top + 30;
            FillCheckBox(chkModel, m_Supported.First());
            string[] supportedArr = m_Supported.Skip(1).ToArray();
            for (int i = 0; i < supportedArr.Length; ++i)
            {
                CheckBox chk = new CheckBox();
                chk.AutoSize = true;
                FillCheckBox(chk, supportedArr[i]);
                chk.Location = new Point(chkModel.Left, offset + (i * 30));
                grpWebsites.Controls.Add(chk);
            }
        }
        public void FillCheckBox(CheckBox chk, string text)
        {
            chk.Text = text;
            chk.Checked =  m_Choosen.Contains(text);
        }

        private void btnUseAll_Click(object sender, EventArgs e)
        {
            m_Choosen = new string[0];
            Close();
        }

        private void btnUseSome_Click(object sender, EventArgs e)
        {
            m_Choosen = grpWebsites.Controls.OfType<CheckBox>().Where(x => x.Checked).Select(x => x.Text);
            Close();
        }
    }
}