using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Publishers;

namespace ViewModel.Interfaces.Services
{
    public interface IPublisherService
    {
        Task<PublisherViewModel> GetAsync(Guid id);
        IEnumerable<PublisherModel> SearchByName(string publisherName, int takeCount, int skipCount);
    }
}