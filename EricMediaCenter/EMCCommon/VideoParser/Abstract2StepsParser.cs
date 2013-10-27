using EricUtility;
using EricUtility.Networking.Gathering;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCCommon.VideoParser
{
    public abstract class Abstract2StepsParser : IVideoParser
    {
        public virtual int MaxSegments
        {
            get { return 2; }
        }

        public abstract string WaitingScreenSentence { get; }

        public virtual async Task<IEnumerable<KeyValuePair<string, string>>> GetParameters(string res)
        {
            string id = res.Extract("<input type=\"hidden\" name=\"id\" value=\"", "\">");
            string fname = res.Extract("<input type=\"hidden\" name=\"fname\" value=\"", "\">");
            return new[]
                {
                    new KeyValuePair<string, string>("op", "download1"),
                    new KeyValuePair<string, string>("usr_login", ""),
                    new KeyValuePair<string, string>("id", id),
                    new KeyValuePair<string, string>("fname", fname),
                    new KeyValuePair<string, string>("referer", ""),
                };
        }

        public virtual string ExtractFile(string res)
        {
            return res.Extract("file: \"", "\"");
        }

        public async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(url);
            while (res.Contains(WaitingScreenSentence))
            {
                HttpContent content = new FormUrlEncodedContent(await GetParameters(res));
                res = await (await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).PostAsync(url, content)).Content.ReadAsStringAsync();
            }
            return ExtractFile(res);
        }
    }
}