using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceDB.Models;
using ServiceDb.PublisherRepos;

namespace API.Infrastructure.WebPublisher
{
    public class WebPublisherScenario : IWebPublisherScenario
    {
        private readonly IPublisherRepository _publisherRepository;

        public WebPublisherScenario(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString)
        {
            return await _publisherRepository.SearchByPublishersAsync(searchString);
        }
    }
}
