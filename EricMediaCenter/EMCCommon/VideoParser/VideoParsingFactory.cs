using EMCCommon.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    {"filenuke.com",new FileNukeParser()},
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

        public static string ExecuteScript(string script)
        {
            string scripts = script.Replace("eval", "function fct42() {return").Replace(".split('|')))", ".split('|')))}");
            WebBrowser wb = new WebBrowser();
            wb.Navigate("about:blank");
            wb.Document.Write(scripts);
            return wb.Document.InvokeScript("fct42").ToString();
        }
    }
}