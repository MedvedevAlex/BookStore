using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceDB.Models;
using DBLayerAPI.PublisherLayers;

namespace API.EntityService.PublisherRepos
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IPublisherLayer _publisherLayer;

        public PublisherRepository(IPublisherLayer publisherLayer)
        {
            _publisherLayer = publisherLayer;
        }

        public async Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString)
        {
            return await _publisherLayer.SearchByPublishersAsync(searchString);
        }
    }
}
