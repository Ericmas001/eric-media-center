using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;
using EMCParserPluginLib.ParsedWebsite;

namespace EMCParserPluginLib.WebsiteParser
{
    public class MegaVideoParser : IWebsiteParser
    {
        #region IWebsiteParser Members

        public AbstractParsedWebsite FindInterestingContent(string content, string url, System.Net.CookieContainer cookies)
        {
            return new DummyParsedWebsite(url);
        }

        #endregion
    }
}
