using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Publishers;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPublisherHandler
    {
        Task<PublisherViewModel> AddAsync(PublisherModifyModel publisher);
        Task<PublisherViewModel> GetAsync(Guid id);
        IEnumerable<PublisherModel> SearchByName(string publisherName, int takeCount, int skipCount);
    }
}