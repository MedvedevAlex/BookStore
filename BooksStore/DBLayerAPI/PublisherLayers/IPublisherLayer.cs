using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBLayerAPI.PublisherLayers
{
    public interface IPublisherLayer
    {
        Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString);
    }
}