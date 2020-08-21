using System;
using System.Threading.Tasks;
using ViewModel.Models.Publishers;
using ViewModel.Responses;
using ViewModel.Responses.Publishers;

namespace ViewModel.Interfaces.Services
{
    public interface IPublisherService
    {
        Task<PublisherViewResponse> AddAsync(PublisherModifyModel publisher);
        Task<PublisherViewResponse> UpdateAsync(PublisherModifyModel publisher);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<PublisherViewResponse> GetAsync(Guid id);
        Task<PublisherPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<PublisherPreviewResponse> SearchByNameAsync(string publisherName, int takeCount, int skipCount);
    }
}