using System;
using System.Threading.Tasks;
using ViewModel.Models.Authors;
using ViewModel.Models.Responses;
using ViewModel.Models.Responses.Authors;

namespace ViewModel.Handlers
{
    public interface IAuthorHandler
    {
        Task<AuthorViewModel> AddAsync(AuthorModifyModel author);
        Task<AuthorViewModel> UpdateAsync(AuthorModifyModel author);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<AuthorViewModel> GetAsync(Guid id);
        Task<AuthorPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<AuthorPreviewResponse> SearchByNameAsync(string authorName, int takeCount, int skipCount);
    }
}