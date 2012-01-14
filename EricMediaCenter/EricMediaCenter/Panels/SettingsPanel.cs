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
using EMCMasterPluginLib.VideoParser;
using EricUtilityNetworking;

namespace EricMediaCenter.Panels
{
    public partial class SettingsPanel : UserControl
    {
        public SettingsPanel()
        {
            InitializeComponent();
            EMCGlobal.SupportedVideoParserUpdated += new EricUtility.EmptyHandler(EMCGlobal_SupportedWebsiteUpdated);
        }

        void EMCGlobal_SupportedWebsiteUpdated()
        {
            dgvVideoParser.Rows.Clear();
            foreach (string name in EMCGlobal.AvailablesPluginsByCat["VideoParser"].Keys)
            {
                Version v = EMCGlobal.AvailablesPluginsByCat["VideoParser"][name];
                string desc = "";
                Version myV = new Version();
                string dwl = "Download";
                if (EMCGlobal.VideoParserPlugins.ContainsKey(name))
                {
                    IEMCVideoParserPlugin plugin = EMCGlobal.VideoParserPlugins[name];
                    desc = plugin.FullName;
                    myV = plugin.Version;
                    if (v <= myV)
                        dwl = "";
                }

                dgvVideoParser.Rows.Add(name, desc, myV, v, dwl);
            }
        }

        private void dgvVideoParser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colDownload.Index)
            {
                DataGridViewRow row = dgvVideoParser.Rows[e.RowIndex];
                string next = "http://www.ericmas001.com/EMC/plugins/" + row.Cells[colName.Index].Value + "_" + row.Cells[colNewVersion.Index].Value + ".dll";
                DownloadItem it = new DownloadItem(next, EMCGlobal.EMCPath, row.Cells[colName.Index].Value + ".dll");
                row.Cells[colDownload.Index].Value = "";
                it.DownloadFileCompleted += new AsyncCompletedEventHandler(it_DownloadFileCompleted);
                it.StartDownload();
            }
        }

        void it_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            EMCGlobal.ReloadVideoParserPlugins();
        }

        private void SettingsPanel_Load(object sender, EventArgs e)
        {
            EMCGlobal.ReloadVideoParserPlugins();
        }
    }
}
