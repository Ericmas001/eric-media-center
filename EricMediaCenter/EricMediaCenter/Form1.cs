using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using EMCMasterPluginLib;
using EricUtility.Networking.Gathering;
using EricUtilityNetworking;

namespace EricMediaCenter
{
    public partial class Form1 : Form
    {
        IEMCParserPlugin parser = null;

        string next = null;

        /// <summary>
        ///   Gets the fully qualified name of the ".options.xml" file.
        /// </summary>
        /// <remarks>
        ///   If a path does not exist, one is created in the following format:
        ///   <para>
        ///   <see cref="Environment.SpecialFolder">ApplicationData</see>\
        ///    <see cref="Application.CompanyName"/>\ 
        ///    <see cref="Application.ProductName"/>\ 
        ///    <i>appname</i>.options.xml
        ///   </para>
        ///   <para>
        ///    A typical <b>OptionsPath</b>, is 
        ///    "C:\Documents and Settings\<i>username</i>\Application Data\<i>company</i>\<i>product</i>\<i>appname</i>.exe.options.xml".
        ///    </para>
        /// </remarks>
        private static string EMCPath
        {
            get
            {
                // Build the directory.
                StringBuilder path = new StringBuilder();
                path.Append(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                path.Append(Path.DirectorySeparatorChar);
                path.Append("Eric Media Center");
                lock (typeof(UserOptions))
                {
                    string dir = path.ToString();
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                }
                return path.ToString();
            }
        }
        private static string ParserPath
        {
            get
            {
                // Build the directory.
                StringBuilder path = new StringBuilder();
                path.Append(EMCPath);

                // Add the file name.
                path.Append(Path.DirectorySeparatorChar);
                path.Append("EMCParser.dll");

                return path.ToString();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(ParserPath))
            {
                byte[] assemblyBytes = File.ReadAllBytes(ParserPath);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                bool found = false;
                foreach (Type t in ass.GetTypes())
                {
                    if (!found && t.GetInterface("IEMCParserPlugin") != null)
                    {
                        found = true;
                        parser = (IEMCParserPlugin)Activator.CreateInstance(t);
                        listBox1.Items.AddRange(parser.GetSupportedWebsites());
                        label1.Text = "Parser loaded, version " + parser.Version;
                    }
                }
            }
            else
                label1.Text = "No Parser found";
            
                string list = GatheringUtility.GetPageSource("http://www.ericmas001.com/EMC/plugins/list.txt");
                string[] plugins = list.Split('\n');
                foreach (string p in plugins)
                {
                    string[] info = p.Split(';');
                    string name = info[0];
                    Version v = new Version(info[1]);
                    if( name == "parser" )
                    {
                        if (parser == null || v > parser.Version)
                        {
                            label1.Text = "A new version of the parser is available !!!";
                            next = "http://www.ericmas001.com/EMC/plugins/parser_" + v.ToString(3) + ".dll";
                            button1.Visible = true;
                        }
                        else
                            button1.Visible = false;
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadItem it = new DownloadItem(next, EMCPath, "EMCParser.dll");
            button1.Visible = false;
            it.DownloadFileCompleted += new AsyncCompletedEventHandler(it_DownloadFileCompleted);
            it.StartDownload();
        }

        void it_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "Téléchargement terminé";

            if (File.Exists(ParserPath))
            {
                byte[] assemblyBytes = File.ReadAllBytes(ParserPath);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                bool found = false;
                foreach (Type t in ass.GetTypes())
                {
                    if (!found && t.GetInterface("IEMCParserPlugin") != null)
                    {
                        found = true;
                        parser = (IEMCParserPlugin)Activator.CreateInstance(t);
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(parser.GetSupportedWebsites());
                        label1.Text = "Parser loaded, version " + parser.Version;
                    }
                }
            }
            else
                label1.Text = "No Parser found";
        }
    }
}
