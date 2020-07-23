using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Entities.References;
using System.Reflection;

namespace Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        #region Основные сущности
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Painter> Painters { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Interpreter> Interpreters { get; set; }
        public DbSet<Shop> Shops { get; set; }
        #endregion
        #region Свзящующие таблицы
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<PainterBook> PainterBooks { get; set; }
        public DbSet<InterpreterBook> InterpreterBooks { get; set; }
        #endregion
        #region Справочники
        public DbSet<PainterStyle> PainterStyles { get; set; }
        public DbSet<Language> Languages{ get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<WorkShedule> WorkShedules { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(b => new { b.BookId, b.AuthorId });
            modelBuilder.Entity<PainterBook>()
                .HasKey(b => new { b.BookId, b.PainterId });
            modelBuilder.Entity<InterpreterBook>()
                .HasKey(b => new { b.BookId, b.IntepreterId });
            modelBuilder.Entity<Shop>()
                .HasMany(ws => ws.WorkShedule)
                .WithOne(s => s.Shop);
            // использование Fluent API с использованием рефлексии
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Добавить сидирование данных
        }
    }
}
