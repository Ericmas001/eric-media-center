using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCMasterPluginLib;
using EricUtility;
using EricUtility.Networking.Gathering;

namespace EMCParserPluginLib.WebsiteParser
{
    public class PutLockerSockShareParser : IWebsiteParser
    {
        public ParsedWebsite FindInterestingContent(string res, string url, System.Net.CookieContainer cookies)
        {
            string beginurl = "http://www.sockshare.com";
            if( url.Contains("www.putlocker.com") )
                beginurl = "http://www.putlocker.com";
           
            while (res.Contains("Continue as Free User"))
            {
                string u = GatheringUtility.GetPageUrl(url, cookies, "", "application/x-www-form-urlencoded");
                url = beginurl + u;
                string hash = StringUtility.Extract(res, "<input type=\"hidden\" value=\"", "\"");
                res = GatheringUtility.GetPageSource(url, cookies, "hash=" + hash + "&confirm=Continue+as+Free+User");
            }
            if (res.Contains("This file doesn't exist"))
                return new ParsedWebsite(url);
            string rssU = beginurl + StringUtility.Extract(res, "playlist: '", "',");
            string info = GatheringUtility.GetPageSource(rssU, cookies);
            string result = StringUtility.Extract(info, "<media:content url=\"", "\"");

            return new ParsedWebsite(url, ParsedWebsite.Extension.Flv, result);
        }
    }
}
