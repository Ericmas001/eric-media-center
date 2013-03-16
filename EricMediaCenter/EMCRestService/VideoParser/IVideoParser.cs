using System.Net;

namespace EMCRestService.VideoParser
{
    public interface IVideoParser
    {
        string BuildURL(string url, string args);

        string ParseArgs(string url);

        string GetDownloadURL(string url, CookieContainer cookies);
    }
}