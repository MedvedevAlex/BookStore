using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Interfaces.Services
{
    public interface IBookService
    {
        Task Add(BookModel book);
        Task Delete(int id);
        Task<BookModel> GetByIdAsync(int id);
        IEnumerable<BookModel> Get(int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByAuthor(string searchString);
        IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount);
        Task Update(BookModel book);
    }
}