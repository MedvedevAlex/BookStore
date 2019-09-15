using Microsoft.EntityFrameworkCore;

namespace InterfaceDB.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Painter> Painters { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API с использованием рефлексии
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<>).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
