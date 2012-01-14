using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib.VideoParser;

namespace EMCVideoParserPluginLib.VideoWebsiteParser.Broken
{
    public class NovaMovParser
    {
        public ParsedVideoWebsite FindInterestingContent(string res, string url, System.Net.CookieContainer cookies)
        {
            string deb = "flashvars.file=\"";
            int ideb = res.IndexOf(deb) + deb.Length;
            if (ideb < deb.Length)
                return new ParsedVideoWebsite(url);
            int ifin = res.IndexOf("\"", ideb);
            return new ParsedVideoWebsite(url, ParsedVideoWebsite.Extension.Flv, res.Substring(ideb, ifin - ideb));
        }
    }
}
