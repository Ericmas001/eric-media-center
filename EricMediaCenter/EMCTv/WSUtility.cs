using EricUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EMCTv
{
    public class WSUtility
    {
        public static async Task<string> CallWS(string url)
        {
            string res = await new HttpClient().GetStringAsync(url);
            return StringUtility.RemoveHTMLTags(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(res)));
        }
        public static async Task<T> CallWS<T>(string ws, string command, params string[] parms)
        {
            string url = "http://emc.ericmas001.com/" + ws + "/" + command + "/" + String.Join("/", parms);
            string res = await new HttpClient().GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(StringUtility.RemoveHTMLTags(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(res))));
        }
    }
}
