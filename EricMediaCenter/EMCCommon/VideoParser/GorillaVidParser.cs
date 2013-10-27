using EricUtility;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace EMCCommon.VideoParser
{
    public class GorillaVidParser : Abstract2StepsParser
    {
        public override string WaitingScreenSentence
        {
            get { return "Please wait while we verify your request"; }
        }

        public override async Task<IEnumerable<KeyValuePair<string, string>>> GetParameters(string res)
        {
            return (await base.GetParameters(res)).Union(new[]
                {
                    new KeyValuePair<string, string>("channel", ""),
                    new KeyValuePair<string, string>("method_free", "Free Download"),
                });
        }
    }
}