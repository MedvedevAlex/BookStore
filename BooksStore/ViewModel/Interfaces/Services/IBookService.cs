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
        IEnumerable<BookModel> SearchByAuthor(string searchString);
        //IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount);
    }
}