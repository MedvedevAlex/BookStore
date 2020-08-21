using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Books;
using ViewModel.Responses;
using ViewModel.Responses.Books;

namespace Model.Handlers
{
    /// <summary>
    /// Обработчик данных книга
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
        /// <param name="book">Модель книга</param>
        /// <returns>Модель книга</returns>
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
                    bookEntity.CoverType = coverType ?? throw new KeyNotFoundException("Ошибка: Не удалось найти тип переплета");
                    bookEntity.Genre = genre ?? throw new KeyNotFoundException("Ошибка: Не удалось найти жанр");
                    bookEntity.Language = language ?? throw new KeyNotFoundException("Ошибка: Не удалось найти язык");
                    bookEntity.Publisher = publisher ?? throw new KeyNotFoundException("Ошибка: Не удалось найти издателя");

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
        /// <param name="book">Модель книга</param>
        /// <returns>Модель книга</returns>
        public async Task<BookViewModel> UpdateAsync(BookModifyModel book)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var bookEntity = await context.Books
                    .Include(a => a.AuthorBooks)
                        .ThenInclude(ab => ab.Author)
                    .Include(b => b.InterpreterBooks)
                        .ThenInclude(ib => ib.Interpreter)
                    .Include(b => b.PainterBooks)
                        .ThenInclude(pb => pb.Painter)
                    .FirstOrDefaultAsync(b => b.Id == book.Id);
                if (bookEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти книгу");

                context.Entry(bookEntity).CurrentValues.SetValues(book);

                var coverType = await context.CoverTypes
                    .FirstOrDefaultAsync(ct => ct.Id == book.CoverTypeId);
                var genre = await context.Genres
                    .FirstOrDefaultAsync(g => g.Id == book.GenreId);
                var language = await context.Languages
                    .FirstOrDefaultAsync(l => l.Id == book.LanguageId);
                var publisher = await context.Publishers
                    .FirstOrDefaultAsync(p => p.Id == book.PublisherId);
                bookEntity.CoverType = coverType ?? throw new KeyNotFoundException("Ошибка: Не удалось найти тип переплета");
                bookEntity.Genre = genre ?? throw new KeyNotFoundException("Ошибка: Не удалось найти жанр");
                bookEntity.Language = language ?? throw new KeyNotFoundException("Ошибка: Не удалось найти язык");
                bookEntity.Publisher = publisher ?? throw new KeyNotFoundException("Ошибка: Не удалось найти издателя");

                var newAuthorsEntities = context.Authors
                    .Where(a => book.AuthorsIds.Contains(a.Id));
                var newPaintersEntities = context.Painters
                    .Where(p => book.PaintersIds.Contains(p.Id));
                var newInterpretersEntities = context.Interpreters
                    .Where(i => book.InterpretersIds.Contains(i.Id));

                context.TryUpdateManyToMany(bookEntity.AuthorBooks, newAuthorsEntities
                    .Select(a => new AuthorBook
                    {
                        BookId = bookEntity.Id,
                        AuthorId = a.Id
                    }), ab => ab.AuthorId);

                context.TryUpdateManyToMany(bookEntity.PainterBooks, newPaintersEntities
                    .Select(p => new PainterBook
                    {
                        BookId = bookEntity.Id,
                        PainterId = p.Id
                    }), pb => pb.PainterId);

                context.TryUpdateManyToMany(bookEntity.InterpreterBooks, newInterpretersEntities
                    .Select(i => new InterpreterBook
                    {
                        BookId = bookEntity.Id,
                        InterpreterId = i.Id
                    }), ib => ib.InterpreterId);

                context.Books.Update(bookEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(book.Id);
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Базовый ответ</returns>
        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var bookEntity = await context.Books
                    .FirstOrDefaultAsync(b => b.Id == id);
                context.Books.Remove(bookEntity);
                await context.SaveChangesAsync();
            }
            return new BaseResponse();
        }

        /// <summary>
        /// Получить книгу
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель книги</returns>
        public async Task<BookViewModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var bookEntity = await context.Books
                    .Include(b => b.CoverType)
                    .Include(b => b.Genre)
                    .Include(b => b.Language)
                    .Include(b => b.Publisher)
                    .Include(b => b.AuthorBooks)
                        .ThenInclude(ab => ab.Author)
                    .Include(b => b.InterpreterBooks)
                        .ThenInclude(ib => ib.Interpreter)
                    .Include(b => b.PainterBooks)
                        .ThenInclude(pb => pb.Painter)
                    .FirstOrDefaultAsync(b => b.Id == id);
                return _mapper.Map<BookViewModel>(bookEntity);
            }
        }

        /// <summary>
        /// Пагинация книг
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция книг</returns>
        public async Task<BookPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            var result = new BookPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = context.Books;
                result.PreviewBooks = await query
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Include(b => b.AuthorBooks)
                        .ThenInclude(ab => ab.Author)
                    .Select(b => _mapper.Map<BookPreviewModel>(b))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск книг по автору
        /// </summary>
        /// <param name="searchString">Имя автора</param>
        /// <returns>Ответ с коллекцией книг</returns>
        public async Task<BookPreviewResponse> SearchByAuthorAsync(string searchString, int takeCount, int skipCount)
        {
            var result = new BookPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = from author in context.Authors
                            join authorbook in context.AuthorBooks on author.Id equals authorbook.AuthorId
                            join book in context.Books on authorbook.BookId equals book.Id
                            where author.Name.Contains(searchString.Trim())
                            select book;

                result.PreviewBooks = await query
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(b => _mapper.Map<BookPreviewModel>(b))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск книг по названию
        /// </summary>
        /// <param name="searchString">Название книги</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Ответ с коллекцией книг</returns>
        public async Task<BookPreviewResponse> SearchByNameAsync(string searchString, int takeCount, int skipCount)
        {
            var result = new BookPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = context.Books
                    .Where(b => b.Name.Contains(searchString.Trim()));

                result.PreviewBooks = await query
                    .Include(b => b.AuthorBooks)
                            .ThenInclude(ab => ab.Author)
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(b => _mapper.Map<BookPreviewModel>(b))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск книг по жанру
        /// </summary>
        /// <param name="searchString">Название жанра</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Ответ с коллекцией книг</returns>
        public async Task<BookPreviewResponse> SearchByGenreAsync(string searchString, int takeCount, int skipCount)
        {
            var result = new BookPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var genresEntities = context.Genres
                    .Where(g => g.Name.Contains(searchString.Trim()))
                    .Select(g => g.Name);
                var query = context.Books
                    .Where(b => genresEntities.Contains(b.Genre.Name));

                result.PreviewBooks = await query
                    .Include(b => b.AuthorBooks)
                        .ThenInclude(ab => ab.Author)
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(b => _mapper.Map<BookPreviewModel>(b))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }
    }
}
