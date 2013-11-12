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
        public static string NORMAL_WS_URL { get { return "http://ws.ericmas001.com/emc/"; } }
        public static string DEBUG_WS_URL { get { return "http://localhost:50082/"; } }
        private static string m_WsURL = NORMAL_WS_URL.Remove(NORMAL_WS_URL.Length - 1);

        public static string WsURL
        {
            get { return WSUtility.m_WsURL; }
            set 
            {
                if (value.EndsWith("/"))
                    WSUtility.m_WsURL = value.Remove(value.Length - 1);
                else
                    WSUtility.m_WsURL = value; 
            }
        }
        public static async Task<string> CallWS(string url)
        {
            string res = await new HttpClient().GetStringAsync(url);
            return StringUtility.RemoveHTMLTags(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(res)));
        }

        public static async Task<T> CallWS<T>(string ws, string command, params string[] parms)
        {
            List<string> path = new List<string> { WsURL, ws, command };
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