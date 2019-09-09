using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookContext db = new BookContext();

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return db.Books;
        }

        [HttpGet]
        public Book GetBook(int id)
        {
            Book book = db.Books.Find(id);
            return book;
        }

        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.Id)
            {
                db.Entry(book).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}
