using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCMasterPluginLib
{
    public interface IEMCParserPlugin : IEMCMasterPlugin
    {
        IWebsiteParser GetWebsiteParser(string uniqueName);
        string[] GetSupportedWebsites();
    }
}
