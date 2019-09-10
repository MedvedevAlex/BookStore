using System.Collections.Generic;
using BooksStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookContext _db = new BookContext();

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _db.Books;
        }

        [HttpGet("{id}")]
        public Book GetBookById(int id)
        {
            Book book = _db.Books.Find(id);
            return book;
        }

        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.Id)
            {
                _db.Entry(book).State = EntityState.Modified;

                _db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            Book book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }
        }
    }
}
