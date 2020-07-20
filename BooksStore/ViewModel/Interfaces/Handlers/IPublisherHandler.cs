using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPublisherHandler
    {
        Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString);
    }
}