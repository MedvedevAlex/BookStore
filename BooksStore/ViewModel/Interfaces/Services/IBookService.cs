using System;
using System.Threading.Tasks;
using ViewModel.Models.Books;
using ViewModel.Models.Responses;
using ViewModel.Models.Responses.Books;

namespace ViewModel.Interfaces.Services
{
    public interface IBookService
    {
        Task<BookViewResponse> AddAsync(BookModifyModel book);
        Task<BookViewResponse> UpdateAsync(BookModifyModel book);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<BookViewResponse> GetAsync(Guid id);
        Task<BookPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<BookPreviewResponse> SearchByAuthorAsync(string searchString, int takeCount, int skipCount);
        Task<BookPreviewResponse> SearchByGenreAsync(string searchString, int takeCount, int skipCount);
        Task<BookPreviewResponse> SearchByNameAsync(string searchString, int takeCount, int skipCount);
    }
}