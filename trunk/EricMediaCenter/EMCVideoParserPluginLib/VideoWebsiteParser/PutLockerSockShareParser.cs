using System;
using System.Collections.Generic;
using System.Text;
using EMCMasterPluginLib.VideoParser;
using EricUtility;
using EricUtility.Networking.Gathering;

namespace EMCVideoParserPluginLib.VideoWebsiteParser
{
    public class PutLockerSockShareParser : IVideoWebsiteParser
    {
        public ParsedVideoWebsite FindInterestingContent(string res, string url, System.Net.CookieContainer cookies)
        {
            string beginurl = "http://www.sockshare.com";
            if( url.Contains("www.putlocker.com") )
                beginurl = "http://www.putlocker.com";
           
            while (res.Contains("Continue as Free User"))
            {
                string u = GatheringUtility.GetPageUrl(url, cookies, "", "application/x-www-form-urlencoded");
                string hash = StringUtility.Extract(res, "<input type=\"hidden\" value=\"", "\"");
                res = GatheringUtility.GetPageSource(url, cookies, "hash=" + hash + "&confirm=Continue+as+Free+User");
            }
            if (res.Contains("This file doesn't exist"))
                return new ParsedVideoWebsite(url);
            string rssU = beginurl + StringUtility.Extract(res, "playlist: '", "',");
            string info = GatheringUtility.GetPageSource(rssU, cookies);
            string result = StringUtility.Extract(info, "<media:content url=\"", "\"");

            return new ParsedVideoWebsite(url, ParsedVideoWebsite.Extension.Flv, result);
        }
    }
}
