using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib.VideoParser;

namespace EMCFakeVP002PluginLib
{
    public class DummyWebsiteParser : IVideoWebsiteParser
    {
        #region IWebsiteParser Members

        public ParsedVideoWebsite FindInterestingContent(string content, string url, System.Net.CookieContainer cookies)
        {
            return new ParsedVideoWebsite(url);
        }

        #endregion
    }
}
