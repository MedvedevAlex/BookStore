using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Books;

namespace ViewModel.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<BookPreviewModel>> GetAsync(int takeCount, int skipCount);
        Task<BookViewModel> GetAsync(Guid id);
        Task<BookViewModel> AddAsync(BookCreateModel book);
        Task<BookViewModel> UpdateAsync(BookCreateModel book);
        Task Delete(Guid id);
        Task<List<BookPreviewModel>> SearchByAuthorAsync(string searchString, int takeCount, int skipCount);
        Task<List<BookPreviewModel>> SearchByGenreAsync(string searchString, int takeCount, int skipCount);
        Task<List<BookPreviewModel>> SearchByNameAsync(string searchString, int takeCount, int skipCount);
    }
}