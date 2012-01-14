using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib.VideoParser;
using EricUtility;
using EricUtility.Networking.Gathering;

namespace EMCVideoParserPluginLib.VideoWebsiteParser
{
    public class GorillaVidParser : IVideoWebsiteParser
    {
        public ParsedVideoWebsite FindInterestingContent(string res, string url, System.Net.CookieContainer cookies)
        {
            while (res.Contains("Please wait while we verify your request"))
            {
                string id = StringUtility.Extract(res, "<input type=\"hidden\" name=\"id\" value=\"", "\">");
                string fname = StringUtility.Extract(res, "<input type=\"hidden\" name=\"fname\" value=\"", "\">");
                string post = "op=download1&usr_login=&id=" + id + "&fname=" + fname + "&referer=&channel=cna&method_free=tel%3Fchargement+libre+";
                res = GatheringUtility.GetPageSource("http://gorillavid.com/cna/" + id, cookies, "op=download1&usr_login=&id=" + id + "&fname=" + fname + "&referer=&channel=cna&method_free=tel%3Fchargement+libre+");
            }

            string newurl = StringUtility.Extract(res, "file:\"", "\"");
            if (newurl != null)
                return new ParsedVideoWebsite(url, ParsedVideoWebsite.Extension.Flv, newurl);
            else
                return new ParsedVideoWebsite(url);
        }
    }
}
