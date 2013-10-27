using EricUtility;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace EMCCommon.VideoParser
{
    public class FastStreamParser : Abstract2StepsParser
    {
        public override string WaitingScreenSentence
        {
            get { return "<input type=\"submit\" name=\"imhuman\" value=\"Continue to video\" id=\"btn_download\">"; }
        }

        public override async Task<IEnumerable<KeyValuePair<string, string>>> GetParameters(string res)
        {
            string hash = res.Extract("<input type=\"hidden\" name=\"hash\" value=\"", "\">");
            Thread.Sleep(2000);
            return (await base.GetParameters(res)).Union(new[]
                {
                    new KeyValuePair<string, string>("hash", hash),
                });
        }
    }
}