using EricUtility;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCCommon.VideoParser
{
    public class VreerParser : IVideoParser
    {
        public int MaxSegments
        {
            get { return 2; }
        }

        public async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(url);
            return res.Extract("file: \"", "\"");
        }
    }
}