using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceDB.Models;

namespace BookStoreClient
{
    public interface IBookClient
    {
        Task<Book> CreateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<Book> EditBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
    }
}