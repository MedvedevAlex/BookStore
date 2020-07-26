using System.Collections.Generic;
using ViewModel.Interfaces.Services;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Publishers;
using System;
using System.Threading.Tasks;

namespace Service.PublisherRepos
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherHandler _publisherHandler;

        public PublisherService(IPublisherHandler publisherHandler)
        {
            _publisherHandler = publisherHandler;
        }

        public async Task<PublisherViewModel> AddAsync(PublisherModifyModel publisher)
        {
            return await _publisherHandler.AddAsync(publisher);
        }

        public async Task<PublisherViewModel> GetAsync(Guid id)
        {
            return await _publisherHandler.GetAsync(id);
        }

        public async Task<PublisherViewModel> UpdateAsync(PublisherModifyModel publisher)
        {
            return await _publisherHandler.UpdateAsync(publisher);
        }

        public IEnumerable<PublisherModel> SearchByName(string publisherName, int takeCount, int skipCount)
        {
            return _publisherHandler.SearchByName(publisherName, takeCount, skipCount);
        }
    }
}
