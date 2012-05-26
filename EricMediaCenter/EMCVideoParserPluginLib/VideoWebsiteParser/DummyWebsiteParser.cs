using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib.VideoParser;

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

        #region IVideoWebsiteParser Members

        public string BuildURL(string url, string args)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
