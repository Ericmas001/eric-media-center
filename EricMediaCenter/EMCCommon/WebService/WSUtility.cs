using EricUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EMCCommon.WebService
{
    public class WSUtility
    {
        public static bool DebugMode = false;
        public static async Task<string> CallWS(string url)
        {
            string res = await new HttpClient().GetStringAsync(url);
            return StringUtility.RemoveHTMLTags(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(res)));
        }

        public static async Task<T> CallWS<T>(string ws, string command, params string[] parms)
        {
            List<string> path = new List<string> { (DebugMode ? "http://localhost:50082" : "http://emc.ericmas001.com"), ws, command };
            path.AddRange(parms);

            string url = String.Join("/", path.ToArray());
            try
            {
                string res = await new HttpClient().GetStringAsync(url);
                string toDeserialize = StringUtility.RemoveHTMLTags(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(res.Replace("&quot;", "'")).Replace("&quot;", "'")));
                return JsonConvert.DeserializeObject<T>(toDeserialize);
            }
            catch (Exception e)
            {
                Exception ex = e;
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                //MessageBox.Show(e.ToString());
                return default(T);
            }
        }
    }
}