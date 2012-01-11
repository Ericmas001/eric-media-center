using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;
using EMCVideoParserPluginLib.VideoWebsiteParser;

namespace EMCVideoParserPluginLib
{
    public class VideoWebsiteParserFactory : IEMCVideoParserPlugin
    {
        public Version Version
        {
            get { return new Version(0, 2, 5); }
        }
        private static readonly Dictionary<string, IVideoWebsiteParser> Supported = new Dictionary<string, IVideoWebsiteParser>()
        {
            //{"megavideo.com",new MegaVideoParser()}, BROKEN
            //{"novamov.com",new NovaMovParser()}, BROKEN

            //{"playhd.org",new PlayHDParser()}, GONE :(
            
            {"gorillavid.com",new GorillaVidParser()},
            {"movshare.net",new MovShareParser()},
            {"putlocker.com",new PutLockerSockShareParser()},
            {"sockshare.com",new PutLockerSockShareParser()},
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

        public IVideoWebsiteParser GetWebsiteParser(string uniqueName)
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
