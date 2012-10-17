﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib.Application;
using EricUtility;
using System.IO;
using System.Reflection;
using EricUtility.Networking.Gathering;
using EMCMasterPluginLib;
using EMCMasterPluginLib.WebService;

namespace EMCMasterPluginLib
{
    public class EMCGlobal
    {

        public static event EmptyHandler AvailablePluginsUpdated = delegate { };
        public static event EmptyHandler SupportedWebServiceUpdated = delegate { };
        public static event EmptyHandler SupportedAppUpdated = delegate { };

        private static bool m_WebServiceLoaded = false;
        private static bool m_ApplicationLoaded = false;
        private static bool m_AvailablePluginsLoaded = false;

        private static Dictionary<string, IEMCApplicationPlugin> m_ApplicationPlugins = new Dictionary<string, IEMCApplicationPlugin>();
        private static Dictionary<string, IEMCWebServicePlugin> m_WebServicePlugins = new Dictionary<string, IEMCWebServicePlugin>();

        private static Dictionary<string, IWebService> m_WebServiceClients = new Dictionary<string, IWebService>();

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
        public static Dictionary<string, IWebService> WebServiceClients
        {
            get
            {
                if (!m_WebServiceLoaded)
                    ReloadWebServicePlugins();
                return EMCGlobal.m_WebServiceClients;
            }
            set { EMCGlobal.m_WebServiceClients = value; }
        }
        public static Dictionary<string, IEMCWebServicePlugin> WebServicePlugins
        {
            get
            {
                if (!m_WebServiceLoaded)
                    ReloadWebServicePlugins();
                return EMCGlobal.m_WebServicePlugins;
            }
            set { EMCGlobal.m_WebServicePlugins = value; }
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


        public static void ReloadWebServicePlugins()
        {

            if (!m_AvailablePluginsLoaded)
                RefreshAvailablePlugins();

            m_WebServicePlugins.Clear();

            // Load All Local WebServicePlugin
            IEnumerable<string> dlls = Directory.EnumerateFiles(EMCPath, "*.dll");
            foreach (string dll in dlls)
            {
                byte[] assemblyBytes = File.ReadAllBytes(dll);
                Assembly ass = Assembly.Load(assemblyBytes);
                Type[] types = ass.GetTypes();
                foreach (Type t in ass.GetTypes())
                {
                    if (t.GetInterface("IEMCWebServicePlugin") != null)
                    {
                        IEMCWebServicePlugin plugin = (IEMCWebServicePlugin)Activator.CreateInstance(t);
                        if (!m_WebServicePlugins.ContainsKey(plugin.UniqueName))
                        {
                            m_WebServicePlugins.Add(plugin.UniqueName, plugin);
                            foreach (string c in plugin.GetWebService().Commands.Keys)
                            {
                                string key = plugin.GetWebService().Title + "|" + c;
                                m_WebServiceClients.Add(key, plugin.GetWebService());
                            }
                        }
                    }
                }
            }

            m_WebServiceLoaded = true;
            SupportedAppUpdated();
        }
        public static object GetWebServiceResult(string c, string a)
        {
            IWebService client = m_WebServiceClients[c];
            string command = c.Substring(c.IndexOf('|')+1);
            if (!String.IsNullOrEmpty(a))
                a = "/" + a;
            string url = (client.BaseUrl + command + a).Replace('|', '/');
            string result;
            object res = null;
            try
            {
                result = StringUtility.RemoveHTMLTags(GatheringUtility.GetPageSource(url));
                res = client.GetResult(command, result);
            }
            catch (Exception ex)
            {
                res = ex;
            }
            return res;
        }
    }
}
