﻿using System;
using System.Threading.Tasks;

namespace EMCCommon.VideoParser
{
    public class NovaMovParser : VideoWeedParser
    {
        public override async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string res = await base.GetDownloadUrlAsync(url, cookies);
            return Uri.UnescapeDataString(res);
        }
    }
}