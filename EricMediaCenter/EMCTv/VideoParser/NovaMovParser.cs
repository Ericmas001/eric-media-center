using EricUtility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace EMCTv.VideoParser
{

    public class NovaMovParser : VideoWeedParser
    {
        public int MaxSegments
        {
            get { return 10; }
        }
        public override async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string res = await base.GetDownloadUrlAsync(url, cookies);
            return Uri.UnescapeDataString(res);
        }
    }
}