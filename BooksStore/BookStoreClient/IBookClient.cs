using System.Collections.Generic;
using System.Threading.Tasks;
using BooksStore.Models;

namespace BookStoreClient
{
    public interface IBookClient
    {
        Task<Book> CreateBook(Book book);
        Task<Book> DeleteBook(int id);
        Task<Book> EditBook(Book book);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(int id);
    }
}