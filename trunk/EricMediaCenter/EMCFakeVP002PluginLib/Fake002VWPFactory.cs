using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib.VideoParser;

namespace EMCFakeVP002PluginLib
{
    public class Fake002VWPFactory : IEMCVideoParserPlugin
    {
        public Version Version
        {
            get { return new Version(0, 2, 0); }
        }
        private static readonly Dictionary<string, IVideoWebsiteParser> Supported = new Dictionary<string, IVideoWebsiteParser>()
        {
            {"iamfake002.com",new DummyWebsiteParser()},
            {"iamfake020.com",new DummyWebsiteParser()},
            {"iamfake200.com",new DummyWebsiteParser()},
        };

        public string UniqueName
        {
            get { return "fakeVideoParserEMC002"; }
        }

        public string FullName
        {
            get { return "EMC Fake Website VideoParser Factory 002"; }
        }

        public bool Load()
        {
            return true;
        }

        Dictionary<string, IVideoWebsiteParser> IEMCVideoParserPlugin.GetSupportedWebsites()
        {
            return Fake002VWPFactory.Supported;
        }
    }
}
