using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;
using EricUtility;

namespace EMCVideoParserPluginLib.VideoWebsiteParser.Broken
{
    public class VideoWeedParser
    {
        public ParsedVideoWebsite FindInterestingContent(string res, string url, System.Net.CookieContainer cookies)
        {
            string file = StringUtility.Extract(res, "flashvars.file=\"", "\";");
            if (file == null)
                return new ParsedVideoWebsite(url);

            return new ParsedVideoWebsite(url, ParsedVideoWebsite.Extension.Flv, file);
        }
    }
}
