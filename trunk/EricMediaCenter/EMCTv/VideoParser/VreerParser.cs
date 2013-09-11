using EricUtility;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCTv.VideoParser
{
    public class VreerParser : IVideoParser
    {
        public async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(url);
            return StringUtility.Extract(res, "file: \"", "\"");
        }
    }
}