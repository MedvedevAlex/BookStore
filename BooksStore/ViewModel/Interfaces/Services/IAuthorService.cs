using System;
using System.Threading.Tasks;
using ViewModel.Models.Authors;
using ViewModel.Models.Responses;
using ViewModel.Models.Responses.Authors;

namespace ViewModel.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<AuthorViewResponse> AddAsync(AuthorModifyModel author);
        Task<AuthorViewResponse> UpdateAsync(AuthorModifyModel author);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<AuthorViewResponse> GetAsync(Guid id);
        Task<AuthorPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<AuthorPreviewResponse> SearchByNameAsync(string authorName, int takeCount, int skipCount);
    }
}