using EMCRestService.Entries;
using EMCRestService.MovieWebsites.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMCRestService.MovieWebsites
{
    public interface IMovieWebsite
    {
        Task<IEnumerable<ListedMovie>> SearchAsync(string keywords);

        Task<IEnumerable<ListedMovie>> StartsWithAsync(string letter);

        Task<Movie> MovieAsync(string movieId);

        Task<StreamingInfo> StreamAsync(string website, string args);

        string MovieURL(string movieId);
    }
}