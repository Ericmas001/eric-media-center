using EricUtility;
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
    }
}
