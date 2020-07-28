using System;
using System.Threading.Tasks;
using ViewModel.Models.Books;
using ViewModel.Models.Responses;
using ViewModel.Models.Responses.Books;

namespace ViewModel.Handlers
{
    public interface IBookHandler
    {
        Task<BookViewModel> AddAsync(BookModifyModel book);
        Task<BookViewModel> UpdateAsync(BookModifyModel book);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<BookViewModel> GetAsync(Guid id);
        Task<BookPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<BookPreviewResponse> SearchByAuthorAsync(string searchString, int takeCount, int skipCount);
        Task<BookPreviewResponse> SearchByNameAsync(string searchString, int takeCount, int skipCount);
        Task<BookPreviewResponse> SearchByGenreAsync(string searchString, int takeCount, int skipCount);
    }
}