using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.WebBook;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IWebBookScenario _webBookScenario;

        public BookController(IWebBookScenario webBookScenario)
        {
            _webBookScenario = webBookScenario;
        }

        
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _webBookScenario.GetBooks();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _webBookScenario.GetBookByIdAsync(id);
        }

        [HttpPost]
        public async Task<StatusCodeResult> CreateBookAsync([FromBody]Book book)
        {
            await _webBookScenario.CreateBookAsync(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<StatusCodeResult> EditBookAsync(int id, [FromBody]Book book)
        {
            await _webBookScenario.EditBookAsync(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> DeleteBookAsync(int id)
        {
            await _webBookScenario.DeleteBookAsync(id);
            return Ok();
        }

        [HttpGet("SearchByAuthors")]
        public async Task<ICollection<Book>> SearchByAuthorsAsync([FromQuery]string searchString)
        {
            return await _webBookScenario.SearchByAuthorsAsync(searchString);
        }

        [HttpGet("SearchByBooksName")]
        public async Task<ICollection<Book>> SearchByBooksAsync([FromQuery]string searchString)
        {
            return await _webBookScenario.SearchByBooksNameAsync(searchString);
        }

        [HttpGet("SearchByGenre")]
        public async Task<ICollection<Book>> SearchByGenreAsync([FromQuery]string searchString)
        {
            return await _webBookScenario.SearchByGenreAsync(searchString);
        }

        [HttpGet("SearchByBooksDescription")]
        public async Task<ICollection<Book>> SearchByBooksDescriptionAsync([FromQuery]string searchString)
        {
            return await _webBookScenario.SearchByBooksDescriptionAsync(searchString);
        }
    }
}