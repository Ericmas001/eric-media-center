using System;
using System.Collections.Generic;
using System.Text;

namespace EMCMasterPluginLib.VideoParser
{
    public interface IEMCVideoParserPlugin : IEMCMasterPlugin
    {
        //IVideoWebsiteParser GetWebsiteParser(string uniqueName);
        //string[] GetSupportedWebsites();
        Dictionary<string,IVideoWebsiteParser> GetSupportedWebsites();
    }
}
