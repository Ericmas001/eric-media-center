using System;
using System.Collections.Generic;
using System.Text;

namespace EMCMasterPluginLib
{
    public interface IEMCVideoParserPlugin : IEMCMasterPlugin
    {
        IVideoWebsiteParser GetWebsiteParser(string uniqueName);
        string[] GetSupportedWebsites();
    }
}
