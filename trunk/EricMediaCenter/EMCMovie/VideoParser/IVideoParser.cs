using System.Net;
using System.Threading.Tasks;

namespace EMCMovie.VideoParser
{
    public interface IVideoParser
    {
        int MaxSegments { get; }
        Task<string> GetDownloadUrlAsync(string url, CookieContainer cookies);
    }
}