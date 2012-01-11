using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;

namespace EMCParserPluginLib.WebsiteParser.Broken
{
    public class NovaMovParser
    {
        public ParsedWebsite FindInterestingContent(string res, string url, System.Net.CookieContainer cookies)
        {
            string deb = "flashvars.file=\"";
            int ideb = res.IndexOf(deb) + deb.Length;
            if (ideb < deb.Length)
                return new ParsedWebsite(url);
            int ifin = res.IndexOf("\"", ideb);
            return new ParsedWebsite(url, ParsedWebsite.Extension.Flv, res.Substring(ideb, ifin - ideb));
        }
    }
}
