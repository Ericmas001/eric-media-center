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
using EricUtilityNetworking;
using System.Net;
using EricUtility.Networking.Gathering;
using EMCMasterPluginLib.VideoParser;

namespace EricMediaCenter.Panels
{
    public partial class TestPanel : UserControl
    {
        IEMCVideoParserPlugin parser = null;
        IEMCVideoParserPlugin parser1 = null;
        IEMCVideoParserPlugin parser2 = null;

        string next = null;
        string nextF1 = null;
        string nextF2 = null;

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
                path.Append("EMCVideoParser.dll");

                return path.ToString();
            }
        }
        private static string ParserFake1Path
        {
            get
            {
                // Build the directory.
                StringBuilder path = new StringBuilder();
                path.Append(EMCPath);

                // Add the file name.
                path.Append(Path.DirectorySeparatorChar);
                path.Append("EMCFakeVP001.dll");

                return path.ToString();
            }
        }
        private static string ParserFake2Path
        {
            get
            {
                // Build the directory.
                StringBuilder path = new StringBuilder();
                path.Append(EMCPath);

                // Add the file name.
                path.Append(Path.DirectorySeparatorChar);
                path.Append("EMCFakeVP002.dll");

                return path.ToString();
            }
        }
        public TestPanel()
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
                    if (!found && t.GetInterface("IEMCVideoParserPlugin") != null)
                    {
                        found = true;
                        parser = (IEMCVideoParserPlugin)Activator.CreateInstance(t);
                        listBox1.Items.AddRange(parser.GetSupportedWebsites().Keys.ToArray());
                        lblOfficialVP.Text = "Parser loaded, version " + parser.Version;
                    }
                }
            }
            else
            {
                parser = null;
                lblOfficialVP.Text = "No Parser found";
            }
            if (File.Exists(ParserFake1Path))
            {
                byte[] assemblyBytes = File.ReadAllBytes(ParserFake1Path);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                bool found = false;
                foreach (Type t in ass.GetTypes())
                {
                    if (!found && t.GetInterface("IEMCVideoParserPlugin") != null)
                    {
                        found = true;
                        parser1 = (IEMCVideoParserPlugin)Activator.CreateInstance(t);
                        listBox1.Items.AddRange(parser1.GetSupportedWebsites().Keys.ToArray());
                        lblFakeVP001.Text = "Parser loaded, version " + parser1.Version;
                    }
                }
            }
            else
            {
                parser1 = null;
                lblFakeVP001.Text = "No Parser found";
            }
            if (File.Exists(ParserFake2Path))
            {
                byte[] assemblyBytes = File.ReadAllBytes(ParserFake2Path);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                bool found = false;
                foreach (Type t in ass.GetTypes())
                {
                    if (!found && t.GetInterface("IEMCVideoParserPlugin") != null)
                    {
                        found = true;
                        parser2 = (IEMCVideoParserPlugin)Activator.CreateInstance(t);
                        listBox1.Items.AddRange(parser2.GetSupportedWebsites().Keys.ToArray());
                        lblFakeVP002.Text = "Parser loaded, version " + parser2.Version;
                    }
                }
            }
            else
            {
                parser1 = null;
                lblFakeVP002.Text = "No Parser found";
            }

            string list = GatheringUtility.GetPageSource("http://www.ericmas001.com/EMC/plugins/list.txt");
            string[] plugins = list.Split('\n');
            foreach (string p in plugins)
            {
                string[] info = p.Split(';');
                string name = info[0];
                Version v = new Version(info[1]);
                if (name == "videoParserEMC")
                {
                    if (parser == null || v > parser.Version)
                    {
                        lblOfficialVP.Text = "A new version of the parser is available !!!";
                        next = "http://www.ericmas001.com/EMC/plugins/" + name + "_" + v.ToString(3) + ".dll";
                        btnOfficialVP.Visible = true;
                    }
                    else
                        btnOfficialVP.Visible = false;
                }
                if (name == "EMCFakeVP001PluginLib")
                {
                    if (parser1 == null || v > parser1.Version)
                    {
                        lblFakeVP001.Text = "A new version of the parser is available !!!";
                        nextF1 = "http://www.ericmas001.com/EMC/plugins/" + name + "_" + v.ToString(3) + ".dll";
                        btnFakeVP001.Visible = true;
                    }
                    else
                        btnFakeVP001.Visible = false;
                }
                if (name == "EMCFakeVP002PluginLib")
                {
                    if (parser2 == null || v > parser2.Version)
                    {
                        lblFakeVP002.Text = "A new version of the parser is available !!!";
                        nextF2 = "http://www.ericmas001.com/EMC/plugins/" + name + "_" + v.ToString(3) + ".dll";
                        btnFakeVP002.Visible = true;
                    }
                    else
                        btnFakeVP002.Visible = false;
                }
            }

            //TEST
            //parser = new VideoWebsiteParserFactory();
            //listBox1.Items.AddRange(parser.GetSupportedWebsites());
            //label1.Text = "Parser loaded, version " + parser.Version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadItem it = new DownloadItem(next, EMCPath, "EMCVideoParser.dll");
            btnOfficialVP.Visible = false;
            it.DownloadFileCompleted += new AsyncCompletedEventHandler(it_DownloadFileCompleted);
            it.StartDownload();
        }

        private void btnFakeVP001_Click(object sender, EventArgs e)
        {
            DownloadItem it = new DownloadItem(nextF1, EMCPath, "EMCFakeVP001.dll");
            btnFakeVP001.Visible = false;
            it.DownloadFileCompleted += new AsyncCompletedEventHandler(it_DownloadFile1Completed);
            it.StartDownload();
        }

        private void btnFakeVP002_Click(object sender, EventArgs e)
        {
            DownloadItem it = new DownloadItem(nextF2, EMCPath, "EMCFakeVP002.dll");
            btnFakeVP002.Visible = false;
            it.DownloadFileCompleted += new AsyncCompletedEventHandler(it_DownloadFile2Completed);
            it.StartDownload();
        }

        void it_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lblOfficialVP.Text = "Téléchargement terminé";

            if (File.Exists(ParserPath))
            {
                byte[] assemblyBytes = File.ReadAllBytes(ParserPath);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                bool found = false;
                foreach (Type t in ass.GetTypes())
                {
                    if (!found && t.GetInterface("IEMCVideoParserPlugin") != null)
                    {
                        found = true;
                        parser = (IEMCVideoParserPlugin)Activator.CreateInstance(t);
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(parser.GetSupportedWebsites().Keys.ToArray());
                        lblOfficialVP.Text = "Parser loaded, version " + parser.Version;
                    }
                }
            }
            else
            {
                parser = null;
                lblOfficialVP.Text = "No Video Parser found";
            }
        }

        void it_DownloadFile1Completed(object sender, AsyncCompletedEventArgs e)
        {
            lblFakeVP001.Text = "Téléchargement terminé";

            if (File.Exists(ParserFake1Path))
            {
                byte[] assemblyBytes = File.ReadAllBytes(ParserFake1Path);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                bool found = false;
                foreach (Type t in ass.GetTypes())
                {
                    if (!found && t.GetInterface("IEMCVideoParserPlugin") != null)
                    {
                        found = true;
                        parser = (IEMCVideoParserPlugin)Activator.CreateInstance(t);
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(parser.GetSupportedWebsites().Keys.ToArray());
                        lblFakeVP001.Text = "Parser loaded, version " + parser.Version;
                    }
                }
            }
            else
            {
                parser = null;
                lblFakeVP001.Text = "No Video Parser found";
            }
        }

        void it_DownloadFile2Completed(object sender, AsyncCompletedEventArgs e)
        {
            lblFakeVP002.Text = "Téléchargement terminé";

            if (File.Exists(ParserFake2Path))
            {
                byte[] assemblyBytes = File.ReadAllBytes(ParserFake2Path);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                bool found = false;
                foreach (Type t in ass.GetTypes())
                {
                    if (!found && t.GetInterface("IEMCVideoParserPlugin") != null)
                    {
                        found = true;
                        parser = (IEMCVideoParserPlugin)Activator.CreateInstance(t);
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(parser.GetSupportedWebsites().Keys.ToArray());
                        lblFakeVP002.Text = "Parser loaded, version " + parser.Version;
                    }
                }
            }
            else
            {
                parser = null;
                lblFakeVP002.Text = "No Video Parser found";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParsedVideoWebsite site = null;
            if (parser != null)
            {
                foreach (string s in parser.GetSupportedWebsites().Keys)
                {
                    if (site == null && textBox1.Text.Contains(s))
                    {
                        CookieContainer cookies = new CookieContainer();
                        site = parser.GetSupportedWebsites()[s].FindInterestingContent(GatheringUtility.GetPageSource(textBox1.Text, cookies), textBox1.Text, cookies);
                    }
                }
            }
            if (site == null || !site.Success)
            {
                textBox2.Text = textBox1.Text = "ERROR !!";
            }
            else
            {
                textBox2.Text = site.VideoUrl;
                textBox3.Text = site.DownloadUrl;
            }
        }
    }
}
