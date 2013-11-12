using EMCCommon.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMCCommon.Windows.Forms
{
    public partial class GlobalSettingsForm : Form
    {
        public GlobalSettingsForm()
        {
            InitializeComponent();
            rdWsNormal.Text += WSUtility.NORMAL_WS_URL;
            rdWsDebug.Text += WSUtility.DEBUG_WS_URL;
            txtEMCDpath.Text = Properties.Settings.Default.emcd_path;
            txtEMCDfolder.Text = Properties.Settings.Default.emcd_output;
            ofdEMCDpath.InitialDirectory = txtEMCDpath.Text;
            string wsUrl = WSUtility.WsURL + "/";
            if (wsUrl == WSUtility.NORMAL_WS_URL)
                rdWsNormal.Checked = true;
            else if (wsUrl == WSUtility.DEBUG_WS_URL)
                rdWsDebug.Checked = true;
            else
            {
                txtWsCustom.Text = wsUrl;
                rdWsCustom.Checked = true;
            }
        }

        private void rdWsCustom_CheckedChanged(object sender, EventArgs e)
        {
            txtWsCustom.Enabled = rdWsCustom.Checked;
        }

        private void btnEMCDpath_Click(object sender, EventArgs e)
        {
            if (ofdEMCDpath.ShowDialog() == DialogResult.OK)
                txtEMCDpath.Text = ofdEMCDpath.FileName;
        }

        private void btnEMCDfolder_Click(object sender, EventArgs e)
        {
            if (fbdEMCDfolder.ShowDialog() == DialogResult.OK)
                txtEMCDpath.Text = fbdEMCDfolder.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.emcd_path = txtEMCDpath.Text;
            Properties.Settings.Default.emcd_output = txtEMCDfolder.Text;
            Properties.Settings.Default.Save();

            if (rdWsNormal.Checked)
                WSUtility.WsURL = WSUtility.NORMAL_WS_URL;
            else if (rdWsDebug.Checked)
                WSUtility.WsURL = WSUtility.DEBUG_WS_URL;
            else
                WSUtility.WsURL = txtWsCustom.Text;

            Close();
        }
    }
}
