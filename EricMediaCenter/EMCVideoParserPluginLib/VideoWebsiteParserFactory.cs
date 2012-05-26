using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib;
using EMCVideoParserPluginLib.VideoWebsiteParser;
using EMCMasterPluginLib.VideoParser;

namespace EMCVideoParserPluginLib
{
    public class VideoWebsiteParserFactory : IEMCVideoParserPlugin
    {
        public Version Version
        {
            get { return new Version(0, 3, 1); }
        }
        private static readonly Dictionary<string, IVideoWebsiteParser> Supported = new Dictionary<string, IVideoWebsiteParser>()
        {
            //{"megavideo.com",new MegaVideoParser()},  BROKEN :(
            //{"novamov.com",new NovaMovParser()},      BROKEN :(
            //{"videoweed.com",new VideoWeedParser()},  BROKEN :(
            //{"videoweed.es",new VideoWeedParser()},   BROKEN :(
            //{"youtube.com",new YoutubeParser()},      BROKEN :(
            //{"zshare.net",new ZShareParser()},        BROKEN :(
            
            //{"playhd.org",new PlayHDParser()},    GONE :(
            //{"wisevid.com",new WiseVidParser()},  GONE :(
            
            {"gorillavid.com",new GorillaVidParser()},
            {"gorillavid.in",new GorillaVidParser()},
            {"movshare.net",new MovShareParser()},
            {"putlocker.com",new PutLockerSockShareParser()},
            {"sockshare.com",new PutLockerSockShareParser()},
            {"stagevu.com",new StageVuParser()},
        };

        public string UniqueName
        {
            get { return "videoParserEMC"; }
        }

        public string FullName
        {
            get { return "Official Website VideoParser"; }
        }

        public bool Load()
        {
            return true;
        }

        public Dictionary<string, IVideoWebsiteParser> GetSupportedWebsites()
        {
            return VideoWebsiteParserFactory.Supported;
        }
    }
}
