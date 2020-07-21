using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Handlers
{
    public interface IBookHandler
    {
        Task AddBookAsync(BookModel book);
        Task DeleteBookAsync(int id);
        Task<BookModel> GetBookByIdAsync(int id);
        IEnumerable<BookModel> GetBooks(int takeCount, int skipCount);
        IEnumerable<BookModel> SearchBooksByAuthor(string searchString);
        IEnumerable<BookModel> SearchBooksByName(string searchString, int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByGenreAsync(string searchString, int takeCount, int skipCount);
        Task UpdateBookAsync(BookModel book);
    }
}