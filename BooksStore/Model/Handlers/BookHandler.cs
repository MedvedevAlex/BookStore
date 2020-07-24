using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.JoinTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Models.Books;

namespace Model.Handlers
{
    /// <summary>
    /// Хэндлер Книги
    /// </summary>
    public class BookHandler : IBookHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public BookHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
        }

        /// <summary>
        /// Пагинация для получения книг
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция превью книг</returns>
        public async Task<List<BookPreviewModel>> GetAsync(int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.Books
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Include(ab => ab.AuthorBooks)
                        .ThenInclude(ar => ar.Author)
                    .Select(s => _mapper.Map<BookPreviewModel>(s))
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Получить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель книги</returns>
        public async Task<BookViewModel> GetByIdAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var bookEntity = await context.Books
                .Include(c => c.CoverType)
                .Include(g => g.Genre)
                .Include(l => l.Language)
                .Include(p => p.Publisher)
                .Include(ab => ab.AuthorBooks)
                    .ThenInclude(ar => ar.Author)
                .Include(ib => ib.InterpreterBooks)
                    .ThenInclude(ir => ir.Interpreter)
                .Include(pb => pb.PainterBooks)
                    .ThenInclude(pr => pr.Painter)
                .FirstOrDefaultAsync(b => b.Id == id);
                return _mapper.Map<BookViewModel>(bookEntity);
            }
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        public async Task AddAsync(BookCreateModel book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                try
                {
                    var coverType = context.CoverTypes
                        .FirstOrDefault(ct => ct.Id == book.CoverTypeId);
                    var genre = context.Genres
                        .FirstOrDefault(g => g.Id == book.GenreId);
                    var language = context.Languages
                        .FirstOrDefault(l => l.Id == book.LanguageId);
                    var publisher = context.Publishers
                        .FirstOrDefault(p => p.Id == book.PublisherId);
                    bookEntity.CoverType = coverType ?? throw new KeyNotFoundException("Ошибка: не удалось найти тип переплета");
                    bookEntity.Genre = genre ?? throw new KeyNotFoundException("Ошибка: не удалось найти жанр");
                    bookEntity.Language = language ?? throw new KeyNotFoundException("Ошибка: не удалось найти язык");
                    bookEntity.Publisher = publisher ?? throw new KeyNotFoundException("Ошибка: не удалось найти издателя");

                    var authorsEntities = context.Authors
                        .Where(a => book.AuthorsIds.Contains(a.Id))
                        .Select(a => new AuthorBook() { Book = bookEntity, Author = a })
                        .ToList();
                    var paintersEntities = context.Painters
                        .Where(p => book.PaintersIds.Contains(p.Id))
                        .Select(p => new PainterBook() { Book = bookEntity, Painter = p })
                        .ToList();
                    var interpretersEntities = context.Interpreters
                        .Where(i => book.InterpretersIds.Contains(i.Id))
                        .Select(i => new InterpreterBook() { Book = bookEntity, Interpreter = i })
                        .ToList();
                    bookEntity.AuthorBooks = authorsEntities;
                    bookEntity.PainterBooks = paintersEntities;
                    bookEntity.InterpreterBooks = interpretersEntities;

                    await context.Books.AddAsync(bookEntity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Ошибка при добавлении в базу данных", e);
                }
            }
        }

        /// <summary>
        /// Обновить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        public async Task UpdateAsync(BookModel book)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                try
                {
                    var bookEntity = await context.Books
                        .FirstOrDefaultAsync(b => b.Id == book.Id);
                    if (bookEntity == null)
                        throw new KeyNotFoundException("Ошибка: Не удалось найти обновляему книгу");
                    bookEntity = _mapper.Map<Book>(book);
                    context.Entry(bookEntity).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Ошибка при сохранении в базу данных", e);
                }
            }
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                try
                {
                    var bookEntity = await context.Books
                        .FirstOrDefaultAsync(b => b.Id == id);
                    context.Books.Remove(bookEntity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Ошибка при сохранении в базу данных", e);
                }
            }
        }

        /// <summary>
        /// Поиск книг по автору
        /// </summary>
        /// <param name="searchString">Имя автора</param>
        /// <returns>Колекция книг</returns>
        public IEnumerable<BookModel> SearchByAuthor(string searchString)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var booksEntities = from author in context.Authors
                                    join authorbook in context.AuthorBooks on author.Id equals authorbook.AuthorId
                                    join book in context.Books on authorbook.BookId equals book.Id
                                    where author.Name.Contains(searchString)
                                    select book;
                return _mapper.Map<IEnumerable<BookModel>>(booksEntities);
            }
        }

        /// <summary>
        /// Поиск книг по названию
        /// </summary>
        /// <param name="searchString">Название книги</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns></returns>
        public IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var booksEntities = context.Books
                .Where(b => b.Name.Contains(searchString))
                .Skip(skipCount)
                .Take(takeCount);
                return _mapper.Map<IEnumerable<BookModel>>(booksEntities);
            }
        }

        ///// <summary>
        ///// Поиск книг по жанру
        ///// </summary>
        ///// <param name="searchString">Название жанра</param>
        ///// <param name="takeCount">Количество получаемых</param>
        ///// <param name="skipCount">Количество пропущенных</param>
        ///// <returns>Колекция книг</returns>
        //public IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount)
        //{
        //    var genreStringSearch = DictionariesSupport.ConvertGenreRus
        //        .FirstOrDefault(g => g.Value.Contains(searchString));
        //    // проверить если не нашел жанры

        //    var booksEntities = _context.Books
        //        .Where(b => b.GenreId == genreStringSearch.Key)
        //        .Skip(skipCount)
        //        .Take(takeCount);
        //    return _mapper.Map<IEnumerable<BookModel>>(booksEntities);
        //}
    }
}
