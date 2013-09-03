using EMCTv.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EMCTv.VideoParser
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
                };
            }
        }

        public static async Task<bool> GetDownloadURLAsync(StreamingInfo si)
        {
            if (Parsers.ContainsKey(si.Website))
            {
                si.DownloadURL = await Parsers[si.Website].GetDownloadUrlAsync(si.StreamingURL, new CookieContainer());
                return true;
            }
            return false;
        }
    }
}
