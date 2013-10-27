using EMCRestService.Entries;
using EMCRestService.TvWebsites.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMCRestService.TvWebsites
{
    public interface ITvWebsite
    {
        Task<IEnumerable<ListedTvShow>> SearchAsync(string keywords);

        Task<IEnumerable<ListedTvShow>> StartsWithAsync(string letter);

        Task<TvShow> ShowAsync(string showId, bool full);

        Task<Episode> EpisodeAsync(string epId);

        Task<StreamingInfo> StreamAsync(string website, string args);

        string ShowURL(string showId);

        string EpisodeURL(string epId);
    }
}