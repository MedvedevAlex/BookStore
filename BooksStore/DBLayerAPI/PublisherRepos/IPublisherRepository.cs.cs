using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDb.PublisherRepos
{
    public interface IPublisherRepository
    {
        Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString);
    }
}