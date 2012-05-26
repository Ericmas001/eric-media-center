using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace EMCRestService.VideoParser
{
    public interface IVideoParser
    {
        string BuildURL(string url, string args);
        string GetDownloadURL(string url, CookieContainer cookies);
    }
}