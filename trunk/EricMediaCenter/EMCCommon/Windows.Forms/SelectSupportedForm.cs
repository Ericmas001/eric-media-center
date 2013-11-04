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
        const int ESP = 30;

        private int m_FormInitialHeight;
        private int m_GrpWebInitialHeight;
        private int m_GrpWebInitialTop;
        private int m_GrpLangInitialHeight;
        private int m_BtnSomeInitialTop;
        private int m_BtnAllInitialTop;

        private Dictionary<string, IEnumerable<string>> m_Supported;
        private IEnumerable<string> m_Choosen;
        private string m_Lang;

        public string Lang
        {
            get { return m_Lang; }
        }

        public IEnumerable<string> Choosen
        {
            get { return m_Choosen; }
        }


        int DeltaHeightLang { get { return (ESP * (m_Supported.Count - 1)); } }
        int DeltaHeightWebsites { get { return (ESP * (m_Supported[m_Lang].Count() - 1)); } }

        public SelectSupportedForm(Dictionary<string, IEnumerable<string>> supported, IEnumerable<string> choosen, string currentLang)
        {
            m_Supported = supported ?? new Dictionary<string, IEnumerable<string>>();
            m_Choosen = choosen;
            m_Lang = currentLang;
            InitializeComponent();
            SetInitialPos();

            DynamicFormSetup();
        }

        private void SetInitialPos()
        {
            m_FormInitialHeight = Height;
            m_GrpWebInitialHeight = grpWebsites.Height;
            m_GrpLangInitialHeight = grpLang.Height;
            m_GrpWebInitialTop = grpWebsites.Top;
            m_BtnSomeInitialTop = btnUseSome.Top;
            m_BtnAllInitialTop = btnUseAll.Top;
        }
        public void DynamicFormSetup()
        {
            DynamicWebsitesSetup();
            grpWebsites.Location = new Point(grpWebsites.Left, m_GrpWebInitialTop + DeltaHeightLang);
            grpLang.Size = new Size(grpLang.Width, m_GrpLangInitialHeight + DeltaHeightLang);
            btnUseAll.Location = new Point(btnUseAll.Left, m_BtnAllInitialTop + DeltaHeightLang);

            int offset = rdModel.Top + ESP;
            FillRadioBox(rdModel, m_Supported.Keys.First());
            string[] supportedLangArr = m_Supported.Keys.Skip(1).ToArray();
            for (int i = 0; i < supportedLangArr.Length; ++i)
            {
                RadioButton rd = new RadioButton();
                rd.AutoSize = true;
                FillRadioBox(rd, supportedLangArr[i]);
                rd.Location = new Point(rdModel.Left, offset + (i * ESP));
                grpLang.Controls.Add(rd);
            }

            grpLang.Controls.OfType<RadioButton>().ToList().ForEach(rd => rd.CheckedChanged += rd_CheckedChanged);
        }
        public void DynamicWebsitesSetup()
        {
            Size = new Size(Width, m_FormInitialHeight + DeltaHeightLang + DeltaHeightWebsites);
            grpWebsites.Size = new Size(grpWebsites.Width, m_GrpWebInitialHeight + DeltaHeightWebsites);
            btnUseSome.Location = new Point(btnUseSome.Left, m_BtnSomeInitialTop + DeltaHeightWebsites);
            int offset = chkModel.Top + ESP;
            FillCheckBox(chkModel, m_Supported[m_Lang].First());
            string[] supportedArr = m_Supported[m_Lang].Skip(1).ToArray();
            for (int i = 0; i < supportedArr.Length; ++i)
            {
                CheckBox chk = new CheckBox();
                chk.AutoSize = true;
                FillCheckBox(chk, supportedArr[i]);
                chk.Location = new Point(chkModel.Left, offset + (i * ESP));
                grpWebsites.Controls.Add(chk);
            }

            grpWebsites.Controls.OfType<CheckBox>().ToList().ForEach(chk => chk.CheckedChanged += chk_CheckedChanged);
            chk_CheckedChanged(null, null);
        }
        public void FillCheckBox(CheckBox chk, string text)
        {
            chk.Text = text;
            chk.Checked = m_Choosen.Contains(text);
        }
        public void FillRadioBox(RadioButton rd, string text)
        {
            rd.Text = text;
            rd.Checked = (text == m_Lang);
        }

        void rd_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                m_Lang = ((RadioButton)sender).Text;
                grpWebsites.Controls.OfType<CheckBox>().Where(chk => chk != chkModel).ToList().ForEach(chk => grpWebsites.Controls.Remove(chk));
                DynamicWebsitesSetup();
            }
        }

        void chk_CheckedChanged(object sender, EventArgs e)
        {
            btnUseSome.Enabled = grpWebsites.Controls.OfType<CheckBox>().Count(chk => chk.Checked) > 0;
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