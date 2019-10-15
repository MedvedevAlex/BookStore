using InterfaceDB.Models;
using ServiceDb.BookRepos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infrastructure.WebBook
{
    public class WebBookScenario : IWebBookScenario
    {
        private readonly IBookRepository _bookRepository;

        public WebBookScenario(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        public IEnumerable<Book> GetBooks() 
            => _bookRepository.GetBooks();

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task CreateBookAsync(Book book) 
        {
            await _bookRepository.CreateBookAsync(book);
        }

        public async Task EditBookAsync(int id, Book book)
        {
            await _bookRepository.EditBook(id, book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task<ICollection<Book>> SearchByAuthorsAsync(string searchString)
        {
            return await _bookRepository.SearchByAuthorsAsync(searchString);
        }

        public async Task<ICollection<Book>> SearchByBooksNameAsync(string searchString)
        {
            return await _bookRepository.SearchByBooksNameAsync(searchString);
        }

        public async Task<ICollection<Book>> SearchByGenreAsync(string searchString)
        {
            return await _bookRepository.SearchByGenreAsync(searchString);
        }

        public async Task<ICollection<Book>> SearchByBooksDescriptionAsync(string searchString)
        {
            return await _bookRepository.SearchByBooksDescriptionAsync(searchString);
        }
    }
}
