using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Book;

namespace ViewModel.Interfaces.Services
{
    public interface IBookService
    {
        Task Add(BookModel book);
        Task Delete(Guid id);
        Task<BookModel> GetByIdAsync(Guid id);
        IEnumerable<BookViewModel> Get(int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByAuthor(string searchString);
        //IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount);
        Task Update(BookModel book);
    }
}