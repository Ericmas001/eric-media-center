using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;
using EMCParserPluginLib.WebsiteParser;

namespace EMCParserPluginLib
{
    public class WebsiteParserFactory : IEMCParserPlugin
    {
        public Version Version
        {
            get { return new Version(0, 2, 3); }
        }
        private static readonly Dictionary<string, IWebsiteParser> Supported = new Dictionary<string, IWebsiteParser>()
        {
            {"megavideo.com",new MegaVideoParser()},
            {"movshare.net",new MovShareParser()},
        };

        public string UniqueName
        {
            get { return "parser"; }
        }

        public string FullName
        {
            get { return "Website Parser Factory"; }
        }

        public bool Load()
        {
            return true;
        }

        public IWebsiteParser GetWebsiteParser(string uniqueName)
        {
            if (Supported.ContainsKey(uniqueName))
                return Supported[uniqueName];
            return new DummyWebsiteParser();
        }

        public string[] GetSupportedWebsites()
        {
            return Supported.Keys.ToArray();
        }
    }
}
