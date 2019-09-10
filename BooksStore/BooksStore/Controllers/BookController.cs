using System.Collections.Generic;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
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
        public Book GetBookById(int id)
        {
            Book book = _context.Books.Find(id);
            return book;
        }

        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.Id)
            {
                _context.Entry(book).State = EntityState.Modified;

                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            Book book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
