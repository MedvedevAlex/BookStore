using ViewModel.Interfaces.Services;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Publishers;
using System;
using System.Threading.Tasks;
using ViewModel.Models.Responses.Publishers;
using ViewModel.Models.Responses;

namespace Service.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherHandler _publisherHandler;

        public PublisherService(IPublisherHandler publisherHandler)
        {
            _publisherHandler = publisherHandler;
        }

        public async Task<PublisherViewResponse> AddAsync(PublisherModifyModel publisher)
        {
            try
            {
                return new PublisherViewResponse()
                {
                    Publisher = await _publisherHandler.AddAsync(publisher)
                };
            }
            catch (Exception e)
            {
                return new PublisherViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PublisherViewResponse> UpdateAsync(PublisherModifyModel publisher)
        {
            try
            {
                return new PublisherViewResponse()
                {
                    Publisher = await _publisherHandler.UpdateAsync(publisher)
                };
            }
            catch (Exception e)
            {
                return new PublisherViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            try
            {
                return await _publisherHandler.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return new BaseResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PublisherViewResponse> GetAsync(Guid id)
        {
            try
            {
                return new PublisherViewResponse()
                {
                    Publisher = await _publisherHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new PublisherViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PublisherPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            try
            {
                return await _publisherHandler.GetAsync(takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new PublisherPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PublisherPreviewResponse> SearchByNameAsync(string publisherName, int takeCount, int skipCount)
        {
            try
            {
                return await _publisherHandler.SearchByNameAsync(publisherName, takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new PublisherPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
