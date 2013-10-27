﻿using EMCCommon.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EMCCommon.VideoParser
{
    public class VideoParsingFactory
    {
        public static Dictionary<string, IVideoParser> Parsers
        {
            get
            {
                return new Dictionary<string, IVideoParser>()
                {
                    {"gorillavid.in",new GorillaVidParser()},
                    {"gorillavid.com",new GorillaVidParser()},
                    {"putlocker.com",new PutLockerSockShareParser()},
                    {"sockshare.com",new PutLockerSockShareParser()},
                    {"divxstage.eu",new VideoWeedParser()},
                    {"movshare.net",new VideoWeedParser()},
                    {"novamov.com",new NovaMovParser()},
                    {"nowvideo.eu",new VideoWeedParser()},
                    {"videoweed.es",new VideoWeedParser()},
                    {"vidbull.com",new VidBullParser()},
                    {"vreer.com",new VreerParser()},
                    {"faststream.in",new FastStreamParser()},
                };
            }
        }

        public static async Task<bool> GetDownloadURLAsync(StreamingInfo si)
        {
            if (Parsers.ContainsKey(si.Website))
            {
                si.DownloadURL = await Parsers[si.Website].GetDownloadUrlAsync(si.StreamingURL, new CookieContainer());
                si.MaxSegments = Parsers[si.Website].MaxSegments;
                return true;
            }
            return false;
        }
    }
}