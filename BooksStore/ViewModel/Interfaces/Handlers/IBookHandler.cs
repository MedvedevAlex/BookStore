using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Books;

namespace ViewModel.Handlers
{
    public interface IBookHandler
    {
        Task<List<BookPreviewModel>> GetAsync(int takeCount, int skipCount);
        Task<BookViewModel> GetAsync(Guid id);
        Task<BookViewModel> AddAsync(BookCreateModel book);
        Task DeleteAsync(Guid id);
        Task<BookViewModel> UpdateAsync(BookCreateModel book);
        Task<List<BookPreviewModel>> SearchByAuthorAsync(string searchString, int takeCount, int skipCount);
        Task<List<BookPreviewModel>> SearchByNameAsync(string searchString, int takeCount, int skipCount);
        Task<List<BookPreviewModel>> SearchByGenreAsync(string searchString, int takeCount, int skipCount);
    }
}