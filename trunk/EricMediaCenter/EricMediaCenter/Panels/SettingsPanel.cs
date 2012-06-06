using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EricUtility.Networking.Gathering;
using System.Reflection;
using EricUtilityNetworking;
using EMCMasterPluginLib;
using EMCMasterPluginLib.Application;

namespace EricMediaCenter.Panels
{
    public partial class SettingsPanel : UserControl
    {
        public SettingsPanel()
        {
            InitializeComponent();
            EMCGlobal.SupportedAppUpdated += new EricUtility.EmptyHandler(EMCGlobal_SupportedAppUpdated);
        }

        void EMCGlobal_SupportedAppUpdated()
        {
            dgvApplication.Rows.Clear();
            foreach (string name in EMCGlobal.AvailablesPluginsByCat["Application"].Keys)
            {
                Version v = EMCGlobal.AvailablesPluginsByCat["Application"][name];
                string desc = "";
                Version myV = new Version();
                string dwl = "Download";
                if (EMCGlobal.ApplicationPlugins.ContainsKey(name))
                {
                    IEMCApplicationPlugin plugin = EMCGlobal.ApplicationPlugins[name];
                    desc = plugin.FullName;
                    myV = plugin.Version;
                    if (v <= myV)
                        dwl = "";
                }

                dgvApplication.Rows.Add(name, desc, myV, v, dwl);
            }
            dgvApplication.ClearSelection();
        }

        void it_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            EMCGlobal.ReloadApplicationPlugins();
        }

        private void SettingsPanel_Load(object sender, EventArgs e)
        {
            EMCGlobal.ReloadApplicationPlugins();
        }

        private void dgvApplication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colDownload2.Index)
            {
                DataGridViewRow row = dgvApplication.Rows[e.RowIndex];
                string next = "http://www.ericmas001.com/EMC/plugins/" + row.Cells[colPlugin2.Index].Value + "_" + row.Cells[colAvailable2.Index].Value + ".dll";
                DownloadItem it = new DownloadItem(next, EMCGlobal.EMCPath, row.Cells[colPlugin2.Index].Value + ".dll");
                row.Cells[colDownload2.Index].Value = "";
                it.DownloadFileCompleted += new AsyncCompletedEventHandler(it_DownloadFileCompleted);
                it.StartDownload();
            }
        }
    }
}
