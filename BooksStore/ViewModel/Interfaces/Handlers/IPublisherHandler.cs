using System;
using System.Threading.Tasks;
using ViewModel.Models.Publishers;
using ViewModel.Responses;
using ViewModel.Responses.Publishers;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPublisherHandler
    {
        Task<PublisherViewModel> AddAsync(PublisherModifyModel publisher);
        Task<PublisherViewModel> UpdateAsync(PublisherModifyModel publisher);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<PublisherViewModel> GetAsync(Guid id);
        Task<PublisherPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<PublisherPreviewResponse> SearchByNameAsync(string publisherName, int takeCount, int skipCount);
    }
}