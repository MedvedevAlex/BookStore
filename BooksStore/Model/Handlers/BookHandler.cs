using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Extensions;
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
        /// Добавить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns>Модель книги</returns>
        public async Task<BookViewModel> AddAsync(BookModifyModel book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                try
                {
                    var coverType = await context.CoverTypes
                        .FirstOrDefaultAsync(ct => ct.Id == book.CoverTypeId);
                    var genre = await context.Genres
                        .FirstOrDefaultAsync(g => g.Id == book.GenreId);
                    var language = await context.Languages
                        .FirstOrDefaultAsync(l => l.Id == book.LanguageId);
                    var publisher = await context.Publishers
                        .FirstOrDefaultAsync(p => p.Id == book.PublisherId);
                    bookEntity.CoverType = coverType ?? throw new KeyNotFoundException("Ошибка: не удалось найти тип переплета");
                    bookEntity.Genre = genre ?? throw new KeyNotFoundException("Ошибка: не удалось найти жанр");
                    bookEntity.Language = language ?? throw new KeyNotFoundException("Ошибка: не удалось найти язык");
                    bookEntity.Publisher = publisher ?? throw new KeyNotFoundException("Ошибка: не удалось найти издателя");

                    var newAuthorsEntities = await context.Authors
                        .Where(a => book.AuthorsIds.Contains(a.Id))
                        .Select(a => new AuthorBook() { Book = bookEntity, Author = a })
                        .ToListAsync();
                    var newPaintersEntities = await context.Painters
                        .Where(p => book.PaintersIds.Contains(p.Id))
                        .Select(p => new PainterBook() { Book = bookEntity, Painter = p })
                        .ToListAsync();
                    var newInterpretersEntities = await context.Interpreters
                        .Where(i => book.InterpretersIds.Contains(i.Id))
                        .Select(i => new InterpreterBook() { Book = bookEntity, Interpreter = i })
                        .ToListAsync();
                    bookEntity.AuthorBooks = newAuthorsEntities;
                    bookEntity.PainterBooks = newPaintersEntities;
                    bookEntity.InterpreterBooks = newInterpretersEntities;

                    await context.Books.AddAsync(bookEntity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Ошибка при добавлении в базу данных", e);
                }
            }
            return await GetAsync(book.Id);
        }

        /// <summary>
        /// Обновить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        public async Task<BookViewModel> UpdateAsync(BookModifyModel book)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                try
                {
                    var bookEntity = await context.Books
                        .Include(ab => ab.AuthorBooks)
                            .ThenInclude(ar => ar.Author)
                        .Include(ib => ib.InterpreterBooks)
                            .ThenInclude(ir => ir.Interpreter)
                        .Include(pb => pb.PainterBooks)
                            .ThenInclude(pr => pr.Painter)
                        .FirstOrDefaultAsync(b => b.Id == book.Id);
                    if (bookEntity == null)
                        throw new KeyNotFoundException("Ошибка: Не удалось найти книгу");

                    context.Entry(bookEntity).CurrentValues.SetValues(book);

                    var coverType = await context.CoverTypes
                        .FirstOrDefaultAsync(ct => ct.Id == book.CoverTypeId);
                    var genre = await context.Genres
                        .FirstOrDefaultAsync(g => g.Id == book.GenreId);
                    var language = await context.Languages
                        .FirstOrDefaultAsync(l => l.Id == book.LanguageId);
                    var publisher = await context.Publishers
                        .FirstOrDefaultAsync(p => p.Id == book.PublisherId);
                    bookEntity.CoverType = coverType ?? throw new KeyNotFoundException("Ошибка: не удалось найти тип переплета");
                    bookEntity.Genre = genre ?? throw new KeyNotFoundException("Ошибка: не удалось найти жанр");
                    bookEntity.Language = language ?? throw new KeyNotFoundException("Ошибка: не удалось найти язык");
                    bookEntity.Publisher = publisher ?? throw new KeyNotFoundException("Ошибка: не удалось найти издателя");

                    var newAuthorsEntities = context.Authors
                        .Where(a => book.AuthorsIds.Contains(a.Id));
                    var newPaintersEntities = context.Painters
                        .Where(p => book.PaintersIds.Contains(p.Id));
                    var newInterpretersEntities = context.Interpreters
                        .Where(i => book.InterpretersIds.Contains(i.Id));

                    context.TryUpdateManyToMany(bookEntity.AuthorBooks, newAuthorsEntities
                        .Select(s => new AuthorBook
                        {
                            BookId = bookEntity.Id,
                            AuthorId = s.Id
                        }), s => s.AuthorId);

                    context.TryUpdateManyToMany(bookEntity.PainterBooks, newPaintersEntities
                        .Select(p => new PainterBook
                        {
                            BookId = bookEntity.Id,
                            PainterId = p.Id
                        }), p => p.PainterId);

                    context.TryUpdateManyToMany(bookEntity.InterpreterBooks, newInterpretersEntities
                        .Select(i => new InterpreterBook
                        {
                            BookId = bookEntity.Id,
                            InterpreterId = i.Id
                        }), i => i.InterpreterId);

                    context.Books.Update(bookEntity);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new KeyNotFoundException("Ошибка при сохранении в базу данных", e);
                }
            }
            return await GetAsync(book.Id);
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
        /// Получить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель книги</returns>
        public async Task<BookViewModel> GetAsync(Guid id)
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
        /// Поиск книг по автору
        /// </summary>
        /// <param name="searchString">Имя автора</param>
        /// <returns>Колекция книг</returns>
        public async Task<List<BookPreviewModel>> SearchByAuthorAsync(string searchString, int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await (from author in context.Authors
                                    join authorbook in context.AuthorBooks on author.Id equals authorbook.AuthorId
                                    join book in context.Books on authorbook.BookId equals book.Id
                                    where author.Name.Contains(searchString.Trim())
                                    select book)
                                    .Take(takeCount)
                                    .Skip(skipCount)
                                    .Select(s => _mapper.Map<BookPreviewModel>(s))
                                    .ToListAsync();
            }
        }

        /// <summary>
        /// Поиск книг по названию
        /// </summary>
        /// <param name="searchString">Название книги</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns></returns>
        public async Task<List<BookPreviewModel>> SearchByNameAsync(string searchString, int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.Books
                    .Where(b => b.Name.Contains(searchString.Trim()))
                    .Include(ab => ab.AuthorBooks)
                            .ThenInclude(ar => ar.Author)
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<BookPreviewModel>(s))
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Поиск книг по жанру
        /// </summary>
        /// <param name="searchString">Название жанра</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Колекция книг</returns>
        public async Task<List<BookPreviewModel>> SearchByGenreAsync(string searchString, int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var genresEntities = await context.Genres
                    .Where(g => g.Name.Contains(searchString.Trim()))
                    .Select(s => s.Name)
                    .ToListAsync();

                return await context.Books
                    .Where(b => genresEntities.Contains(b.Genre.Name))
                    .Include(ab => ab.AuthorBooks)
                        .ThenInclude(ar => ar.Author)
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<BookPreviewModel>(s))
                    .ToListAsync();
            }
        }
    }
}
