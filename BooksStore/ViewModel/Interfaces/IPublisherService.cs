using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel.PublisherRepos
{
    public interface IPublisherService
    {
        Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString);
    }
}