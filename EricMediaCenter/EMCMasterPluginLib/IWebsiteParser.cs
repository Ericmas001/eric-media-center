using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace EMCMasterPluginLib
{
    public interface IWebsiteParser
    {
        AbstractParsedWebsite FindInterestingContent(string content, string url, CookieContainer cookies);
    }
}
