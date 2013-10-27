using EricUtility;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EMCCommon.VideoParser
{
    public class FileNukeParser : Abstract2StepsParser
    {
        public override string WaitingScreenSentence
        {
            get { return "Choose how to download"; }
        }

        public override async Task<IEnumerable<KeyValuePair<string, string>>> GetParameters(string res)
        {
            return (await base.GetParameters(res)).Union(new[]
                {
                    new KeyValuePair<string, string>("method_free", "Free"),
                });
        }

        public override string ExtractFile(string res)
        {
            return VideoParsingFactory.ExecuteScript(res.Extract("<div id=\"player_code\">", "</div>")).Extract("\"src=\"","\"");
        }
    }
}