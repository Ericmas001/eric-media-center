using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;
using EricUtility;
using EricUtility.Networking.Gathering;

namespace EMCParserPluginLib.WebsiteParser
{
    public class MovShareParser : IWebsiteParser
    {
        public ParsedWebsite FindInterestingContent(string content, string url, System.Net.CookieContainer cookies)
        {
            //What a great robot check ! :)
            while (content.Contains("Please click continue to video to prove you're not a robot"))
                content = GatheringUtility.GetPageSource(url, cookies, "wm=1");

            string newurl = StringUtility.Extract(content, "s1.addVariable(\"file\",\"", "\"");
            if (newurl != null)
                return new ParsedWebsite(url, ParsedWebsite.Extension.Flv,newurl);
            else
            {
                string divxurl = StringUtility.Extract(content, "<param name=\"src\" value=\"", "\"");
                if (divxurl != null)
                    return new ParsedWebsite(url, ParsedWebsite.Extension.Avi, divxurl);
                else
                    return new ParsedWebsite(url);
            }
        }
    }
}
