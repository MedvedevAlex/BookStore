using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infrastructure.WebPublisher
{
    public interface IWebPublisherScenario
    {
        Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString);
    }
}