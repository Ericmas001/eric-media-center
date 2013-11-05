using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMCRestService.StreamingWebsites.Entities
{
    public interface IListedStreamingItem
    {
        string Name { get; set; }
        string Title { get; set; }
    }
}
