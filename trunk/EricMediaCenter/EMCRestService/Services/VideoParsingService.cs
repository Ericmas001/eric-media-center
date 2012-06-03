using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using EricUtility.Networking.Gathering;
using EricUtility;
using EricUtility2011;
using System.Globalization;
using System.Net;
using EMCRestService.VideoParser;

namespace EMCRestService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class VideoParsingService
    {
        public static Dictionary<string, IVideoParser> Parsers
        {
            get
            {
                return new Dictionary<string, IVideoParser>()
                {
                    {"gorillavid.in",new GorillaVidParser()},
                    {"putlocker.com",new PutLockerSockShareParser()},
                    {"sockshare.com",new PutLockerSockShareParser()},
                };
            }
        }

        [WebGet(UriTemplate = "AvailableWebsites")]
        public string AvailableWebsites()
        {
            return JsonConvert.SerializeObject(Parsers.Keys.ToArray());
        }
        [WebGet(UriTemplate = "Parse/{website}/{args}")]
        public string Parse(string website, string args)
        {
            if (Parsers.ContainsKey(website))
            {
                string url = Parsers[website].BuildURL(website, args);
                CookieContainer cookies = new CookieContainer();
                string site = Parsers[website].GetDownloadURL(url, cookies);
                if (site != null)
                    return JsonConvert.SerializeObject(site);
            }
            return null;
        }
    }
}