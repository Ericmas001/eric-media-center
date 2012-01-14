using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib.VideoParser;

namespace EMCFakeVP001PluginLib
{
    public class Fake001VWPFactory : IEMCVideoParserPlugin
    {
        public Version Version
        {
            get { return new Version(0, 1, 0); }
        }
        private static readonly Dictionary<string, IVideoWebsiteParser> Supported = new Dictionary<string, IVideoWebsiteParser>()
        {
            {"iamfake001.com",new DummyWebsiteParser()},
            {"iamfake010.com",new DummyWebsiteParser()},
            {"iamfake100.com",new DummyWebsiteParser()},
        };

        public string UniqueName
        {
            get { return "fakeVideoParserEMC001"; }
        }

        public string FullName
        {
            get { return "EMC Fake Website VideoParser Factory 001"; }
        }

        public bool Load()
        {
            return true;
        }

        Dictionary<string, IVideoWebsiteParser> IEMCVideoParserPlugin.GetSupportedWebsites()
        {
            return Fake001VWPFactory.Supported;
        }
    }
}
