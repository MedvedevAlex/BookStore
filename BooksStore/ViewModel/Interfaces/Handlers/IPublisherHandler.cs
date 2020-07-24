using System.Collections.Generic;
using ViewModel.Models;
using ViewModel.Models.Publishers;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPublisherHandler
    {
        IEnumerable<PublisherModel> SearchByName(string publisherName, int takeCount, int skipCount);
    }
}