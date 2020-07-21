using System.Collections.Generic;
using ViewModel.Models;

namespace ViewModel.Interfaces.Services
{
    public interface IPublisherService
    {
        IEnumerable<PublisherModel> SearchByName(string publisherName, int takeCount, int skipCount);
    }
}