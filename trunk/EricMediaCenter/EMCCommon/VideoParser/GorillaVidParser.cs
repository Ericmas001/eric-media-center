using EricUtility;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCCommon.VideoParser
{
    public class GorillaVidParser : IVideoParser
    {
        public int MaxSegments
        {
            get { return 10; }
        }
        public async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(url);
            while (res.Contains("Please wait while we verify your request"))
            {
                string id = StringUtility.Extract(res, "<input type=\"hidden\" name=\"id\" value=\"", "\">");
                string fname = StringUtility.Extract(res, "<input type=\"hidden\" name=\"fname\" value=\"", "\">");
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("op", "download1"),
                    new KeyValuePair<string, string>("usr_login", ""),
                    new KeyValuePair<string, string>("id", id),
                    new KeyValuePair<string, string>("fname", fname),
                    new KeyValuePair<string, string>("referer", ""),
                    new KeyValuePair<string, string>("channel", "cna"),
                    new KeyValuePair<string, string>("method_free", "tel%3Fchargement+libre+"),
                });
                res = await (await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).PostAsync("http://gorillavid.in/cna/" + id, content)).Content.ReadAsStringAsync();
            }
            return StringUtility.Extract(res, "file:\"", "\"");
        }
    }
}