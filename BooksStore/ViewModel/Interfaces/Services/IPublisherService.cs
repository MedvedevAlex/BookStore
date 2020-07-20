using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel.Interfaces.Services
{
    public interface IPublisherService
    {
        Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString);
    }
}