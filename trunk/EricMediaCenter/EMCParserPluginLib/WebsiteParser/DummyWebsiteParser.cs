using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;

namespace EMCParserPluginLib.WebsiteParser
{
    public class DummyWebsiteParser : IWebsiteParser
    {
        #region IWebsiteParser Members

        public ParsedWebsite FindInterestingContent(string content, string url, System.Net.CookieContainer cookies)
        {
            return new ParsedWebsite(url);
        }

        #endregion
    }
}
