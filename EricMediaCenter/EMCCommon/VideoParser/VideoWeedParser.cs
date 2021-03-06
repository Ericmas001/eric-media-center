﻿using EricUtility;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCCommon.VideoParser
{
    //  var flashvars = {};
    //            flashvars.width=653;
    //            flashvars.height=438;
    //            flashvars.domain="http://www.divxstage.eu";
    //            flashvars.file="589453691bc7a";
    //            flashvars.filekey="173.246.30.178-9ae51ff4244d5cdc61fa6758be238285"; a009103a5ea053f843d6a6928370e372
    //            flashvars.advURL="http://www.divxstage.eu/file/589453691bc7a";
    //===>
    // domain + /api/player.api.php? + file + key
    //http://www.divxstage.eu/api/player.api.php?file=589453691bc7a&&key=173.246.30.178-9ae51ff4244d5cdc61fa6758be238285

    //===>
    //url=http://s23.divxstage.eu/dl/0fb562a24399dc2446d985ea78c4fdf9/52266bf3/ff51ed18a37ab0e7323f56537e331a83d5.flv&title=S01E12+The+Sleep+of+Babies%26asdasdas&site_url=http://www.divxstage.eu/video/589453691bc7a&seekparm=&enablelimit=0

    public class VideoWeedParser : IVideoParser
    {
        public int MaxSegments
        {
            get { return 10; }
        }

        public virtual async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(url);
            string domain = res.Extract("flashvars.domain=\"", "\"");
            string file = res.Extract("flashvars.file=\"", "\"");
            string key = res.Extract("flashvars.filekey=\"", "\"");
            string info = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(domain + "/api/player.api.php?file=" + file + "&key=" + key);
            string finalUrl = info.Extract( "url=", "&");
            return finalUrl;
        }
    }
}