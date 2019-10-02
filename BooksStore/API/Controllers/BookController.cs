using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using API.EntityService;
using API.Filters;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        [HttpPost]
        public async Task<StatusCodeResult> CreateBookAsync([FromBody]Book book)
        {
            await _bookRepository.CreateBookAsync(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<StatusCodeResult> EditBookAsync(int id, [FromBody]Book book)
        {
            await _bookRepository.EditBookAsync(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }

        [HttpGet("SearchByAuthors")]
        public async Task<ICollection<Book>> SearchByAuthorsAsync([FromQuery]string searchString)
        {
            return await _bookRepository.SearchByAuthorsAsync(searchString);
        }

        [HttpGet("SearchByBooksName")]
        public async Task<ICollection<Book>> SearchByBooksAsync([FromQuery]string searchString)
        {
            return await _bookRepository.SearchByBooksNameAsync(searchString);
        }

        [HttpGet("SearchByGenre")]
        public async Task<ICollection<Book>> SearchByGenreAsync([FromQuery]string searchString)
        {
            return await _bookRepository.SearchByGenreAsync(searchString);
        }

        [HttpGet("SearchByBooksDescription")]
        public async Task<ICollection<Book>> SearchByBooksDescriptionAsync([FromQuery]string searchString)
        {
            return await _bookRepository.SearchByBooksDescriptionAsync(searchString);
        }

        [HttpGet("SearchByPainters")]
        public async Task<ICollection<Painter>> SearchByPaintersAsync([FromQuery]string searchString)
        {
            return await _bookRepository.SearchByPaintersAsync(searchString);
        }

        [HttpGet("SearchByPublishers")]
        public async Task<ICollection<Publisher>> SearchByPublishersAsync([FromQuery]string searchString)
        {
            return await _bookRepository.SearchByPublishersAsync(searchString);
        }
    }
}