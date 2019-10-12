using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EntityService.PublisherRepos
{
    public interface IPublisherRepository
    {
        Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString);
    }
}