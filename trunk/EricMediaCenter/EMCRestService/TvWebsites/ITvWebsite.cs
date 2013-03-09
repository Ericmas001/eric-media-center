using EMCRestService.TvWebsites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMCRestService.TvWebsites
{
    public interface ITvWebsite
    {
        Task<IEnumerable<ListedTvShow>> SearchAsync(string keywords);
        Task<IEnumerable<ListedTvShow>> StartsWithAsync(string letter);
        Task<TvShow> ShowAsync(string showId);
        Task<Episode> EpisodeAsync(string epId);
    }
}
