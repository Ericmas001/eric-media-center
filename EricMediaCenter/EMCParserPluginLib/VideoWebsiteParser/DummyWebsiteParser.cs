using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;

namespace EMCVideoParserPluginLib.VideoWebsiteParser
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
