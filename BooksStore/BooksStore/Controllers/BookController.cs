using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookByIdAsync(int id)
        {
            if (id == 0)
            {
                return new Book();
            }
            return await _context.Books.FindAsync(id);
        }

        [HttpPost]
        public async Task<StatusCodeResult> CreateBookAsync([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            await _context.Books.AddAsync(book);

            int countSaveBook = await _context.SaveChangesAsync();
            if (countSaveBook == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<StatusCodeResult> EditBook(int id, [FromBody]Book book)
        {
            if (id == book.BookId)
            {
                _context.Entry(book).State = EntityState.Modified;

                int countSaveBook = await _context.SaveChangesAsync();
                if (countSaveBook == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> DeleteBookAsync(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);

                int countSaveBook = await _context.SaveChangesAsync();
                if (countSaveBook == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
