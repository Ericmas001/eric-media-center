using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace EMCMasterPluginLib.VideoParser
{
    public interface IVideoWebsiteParser
    {
        ParsedVideoWebsite FindInterestingContent(string content, string url, CookieContainer cookies);
    }
}
