using Microsoft.EntityFrameworkCore;

namespace BooksStore.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
