using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.Application;
using EricUtility;
using System.IO;
using System.Reflection;
using EricUtility.Networking.Gathering;
using EMCMasterPluginLib;

namespace EMCMasterPluginLib
{
    public class EMCGlobal
    {

        public static event EmptyHandler AvailablePluginsUpdated = delegate { };
        public static event EmptyHandler SupportedVideoParserUpdated = delegate { };
        public static event EmptyHandler SupportedAppUpdated = delegate { };

        private static bool m_VideoParserLoaded = false;
        private static bool m_ApplicationLoaded = false;
        private static bool m_AvailablePluginsLoaded = false;

        private static Dictionary<string, IEMCApplicationPlugin> m_ApplicationPlugins = new Dictionary<string, IEMCApplicationPlugin>();


        private static Dictionary<string, Version> m_AvailablesPlugins = new Dictionary<string,Version>();
        private static Dictionary<string, Dictionary<string, Version>> m_AvailablesPluginsByCat = new Dictionary<string,Dictionary<string,Version>>();

        public static Dictionary<string, IEMCApplicationPlugin> ApplicationPlugins
        {
            get
            {
                if (!m_ApplicationLoaded)
                    ReloadApplicationPlugins(); 
                return EMCGlobal.m_ApplicationPlugins;
            }
            set { EMCGlobal.m_ApplicationPlugins = value; }
        }

        public static Dictionary<string, Version> AvailablesPlugins
        {
            get
            {
                if (!m_AvailablePluginsLoaded)
                    RefreshAvailablePlugins();
                return EMCGlobal.m_AvailablesPlugins;
            }
        }

        public static Dictionary<string, Dictionary<string, Version>> AvailablesPluginsByCat
        {
            get
            {
                if (!m_AvailablePluginsLoaded)
                    RefreshAvailablePlugins();
                return EMCGlobal.m_AvailablesPluginsByCat;
            }
        }

        public static string EMCPath
        {
            get
            {
                // Build the directory.
                StringBuilder path = new StringBuilder();
                path.Append(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                path.Append(Path.DirectorySeparatorChar);
                path.Append("Eric Media Center");
                lock (typeof(EMCGlobal))
                {
                    string dir = path.ToString();
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                }
                return path.ToString();
            }

        }



/*===============================================================================================*/



        public static void RefreshAvailablePlugins()
        {
            m_AvailablesPlugins.Clear();
            m_AvailablesPluginsByCat.Clear();

            // Load All Available Plugin Versions
            string list = GatheringUtility.GetPageSource("http://www.ericmas001.com/EMC/plugins/list.txt");
            string[] plugins = list.Replace("\r", "").Split('\n');
            Dictionary<string, Version> UpToDateVPs = new Dictionary<string, Version>();
            foreach (string p in plugins)
            {
                string[] info = p.Split(';');
                string name = info[0];
                Version v = new Version(info[1]);
                string cat = info[2];
                m_AvailablesPlugins.Add(name, v);
                if( !m_AvailablesPluginsByCat.ContainsKey(cat))
                    m_AvailablesPluginsByCat.Add(cat,new Dictionary<string,Version>());
                m_AvailablesPluginsByCat[cat].Add(name, v);
            }

            m_AvailablePluginsLoaded = true;
            AvailablePluginsUpdated();
        }


        public static void ReloadApplicationPlugins()
        {

            if (!m_AvailablePluginsLoaded)
                RefreshAvailablePlugins();

            m_ApplicationPlugins.Clear();

            // Load All Local ApplicationPlugin
            IEnumerable<string> dlls = Directory.EnumerateFiles(EMCPath, "*.dll");
            foreach (string dll in dlls)
            {
                byte[] assemblyBytes = File.ReadAllBytes(dll);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                bool found = false;
                foreach (Type t in ass.GetTypes())
                {
                    if (!found && t.GetInterface("IEMCApplicationPlugin") != null)
                    {
                        found = true;
                        IEMCApplicationPlugin plugin = (IEMCApplicationPlugin)Activator.CreateInstance(t);
                        m_ApplicationPlugins.Add(plugin.UniqueName, plugin);
                    }
                }
            }

            m_ApplicationLoaded = true;
            SupportedAppUpdated();
        }
    }
}
