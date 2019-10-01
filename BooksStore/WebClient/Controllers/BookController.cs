using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceDB.Enums;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebClient.Controllers
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

            try
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при добавлении в базу данных", e);
            }
            return Ok();
            //todo: сделать валидацию через TryValidateModel or Fluentvalidation
        }

        [HttpPut("{id}")]
        public async Task<StatusCodeResult> EditBook(int id, [FromBody]Book book)
        {
            if (id == book.BookId)
            {
                _context.Entry(book).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception("Ошибка при сохранении в базу данных", e);
                }
                return Ok();

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

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception("Ошибка при сохранении в базу данных", e);
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("SearchByAuthors")]
        public async Task<ICollection<Book>> SearchByAuthorsAsync([FromQuery]string searchString)
        {
            return await (from author in _context.Authors
                          join authorbook in _context.AuthorBooks on author.AuthorId equals authorbook.AuthorId
                          join book in _context.Books on authorbook.BookId equals book.BookId
                          where author.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select book).ToListAsync();
        }

        [HttpGet("SearchByBooks")]
        public async Task<ICollection<Book>> SearchByBooksAsync([FromQuery]string searchString)
        {
            return await (from book in _context.Books
                          where book.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select book).ToListAsync();
        }

        [HttpGet("SearchByGenre")]
        public async Task<ICollection<Book>> SearchByGenreAsync([FromQuery]string searchString)
        {
            var genreStringSearch = DictionariesSupport.ConvertGenreRus
                .Where(s => s.Value.StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Key);

            if (genreStringSearch.Count() == 0)
            {
                return new List<Book>();
            }

            return await (from book in _context.Books
                          where book.Genre.Equals(genreStringSearch.FirstOrDefault())
                          select book).ToListAsync();
        }

        [HttpGet("SearchByBooksDescription")]
        public async Task<ICollection<Book>> SearchByBooksDescriptionAsync([FromQuery]string searchString)
        {
            return await (from book in _context.Books
                          where book.Description.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select book).ToListAsync();
        }

        [HttpGet("SearchByPainters")]
        public async Task<ICollection<Painter>> SearchByPaintersAsync([FromQuery]string searchString)
        {
            return await (from painter in _context.Painters
                          where painter.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select painter).ToListAsync();
        }

        [HttpGet("SearchByPublishers")]
        public async Task<ICollection<Publisher>> SearchByPublishersAsync([FromQuery]string searchString)
        {
            return await (from publisher in _context.Publishers
                          where publisher.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select publisher).ToListAsync();
        }
    }
}