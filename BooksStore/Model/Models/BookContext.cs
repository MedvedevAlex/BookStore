using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Painter> Painters { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(b => new { b.BookId, b.AuthorId });
            modelBuilder.Entity<PainterBook>()
                .HasKey(b => new { b.BookId, b.PainterId });
            // использование Fluent API с использованием рефлексии
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<>).Assembly);
            base.OnModelCreating(modelBuilder);

            // Добавить сидирование данных
        }
    }
}
