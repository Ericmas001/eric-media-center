using EMCRestService.TvWebsites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCRestService.TvWebsites
{
    public interface ITvWebsite
    {
        IEnumerable<ListedTvShow> Search(string keywords);
        IEnumerable<ListedTvShow> StartsWith(string letter);
        TvShow Show(string name);
    }
}
