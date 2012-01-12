using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib;
using EricUtility;
using EricUtility.Networking.Gathering;

namespace EMCVideoParserPluginLib.VideoWebsiteParser
{
    public class StageVuParser : IVideoWebsiteParser
    {
        public ParsedVideoWebsite FindInterestingContent(string res, string url, System.Net.CookieContainer cookies)
        {
            string id = StringUtility.Extract(res, "pluginplaying[", "]");
            if (id == null)
                return new ParsedVideoWebsite(url);
            string file = StringUtility.Extract(res, "url[" + id + "] = '", "';");
            if (file == null)
                return new ParsedVideoWebsite(url);
            return new ParsedVideoWebsite(url, ParsedVideoWebsite.Extension.Avi, file);
        }
    }
}
