using EricUtility;
using EricUtility.Networking.Gathering;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EMCMovie.VideoParser
{
    public class PutLockerSockShareParser : IVideoParser
    {
        public int MaxSegments
        {
            get { return 10; }
        }
        public async Task<string> GetDownloadUrlAsync(string url, System.Net.CookieContainer cookies)
        {
            string res = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(url);
            string u = GatheringUtility.GetPageUrl(url, cookies, "", "application/x-www-form-urlencoded");
            string beginurl = "http://www.sockshare.com";
            if (u.Contains("putlocker.com"))
                beginurl = "http://www.putlocker.com";

            while (res.Contains("Continue as Free User"))
            {
                string hash = StringUtility.Extract(res, "<input type=\"hidden\" value=\"", "\"");
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("hash", hash),
                    new KeyValuePair<string, string>("confirm", "Continue+as+Free+User"),
                });
                res = await (await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).PostAsync(u, content)).Content.ReadAsStringAsync();
            }
            if (res.Contains("This file doesn't exist"))
                return null;
            //string rssU = beginurl + StringUtility.Extract(res, "playlist: '", "',");
            //string info = await new HttpClient(new HttpClientHandler() { CookieContainer = cookies }).GetStringAsync(rssU);
            //return StringUtility.Extract(info, "<media:content url=\"", "\"");
            string getFile = beginurl + "/get_file.php?" + StringUtility.Extract(res, "<a href=\"/get_file.php?", "\"");
            string finalU = GatheringUtility.GetPageUrl(getFile, cookies, "", "application/x-www-form-urlencoded");
            return finalU;
        }
    }
}