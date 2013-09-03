using System.Net;
using System.Threading.Tasks;

namespace EMCTv.VideoParser
{
    public interface IVideoParser
    {
        Task<string> GetDownloadUrlAsync(string url, CookieContainer cookies);
    }
}