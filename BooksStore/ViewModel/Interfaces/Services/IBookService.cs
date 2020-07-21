using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Interfaces.Services
{
    public interface IBookService
    {
        Task AddBook(BookModel book);
        Task DeleteBookAsync(int id);
        Task<BookModel> GetBookByIdAsync(int id);
        IEnumerable<BookModel> GetBooks(int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByAuthor(string searchString);
        IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount);
        Task UpdateBook(BookModel book);
    }
}