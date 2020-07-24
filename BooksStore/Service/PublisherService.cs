using System.Collections.Generic;
using ViewModel.Interfaces.Services;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Publishers;

namespace Service.PublisherRepos
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherHandler _publisherHandler;

        public PublisherService(IPublisherHandler publisherHandler)
        {
            _publisherHandler = publisherHandler;
        }

        public IEnumerable<PublisherModel> SearchByName(string publisherName, int takeCount, int skipCount)
        {
            return _publisherHandler.SearchByName(publisherName, takeCount, skipCount);
        }
    }
}
