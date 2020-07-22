using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Enums;
using ViewModel.Handlers;
using ViewModel.Models;

namespace Model.Handlers
{
    /// <summary>
    /// Хэндлер Книги
    /// </summary>
    public class BookHandler : IBookHandler
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public BookHandler(
            BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Пагинация для получения книг
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция книг</returns>
        public IEnumerable<BookModel> Get(int takeCount, int skipCount)
        {
            return _context.Books
                .Skip(skipCount)
                .Take(takeCount)
                .Select(s => _mapper.Map<BookModel>(s));
        }

        /// <summary>
        /// Получить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель книги</returns>
        public async Task<BookModel> GetByIdAsync(Guid id)
        {
            var bookEntity = await _context.Books
                .FirstOrDefaultAsync(b => b.Id == id);
            return _mapper.Map<BookModel>(bookEntity);
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        public async Task AddAsync(BookModel book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            try
            {
                await _context.Books.AddAsync(bookEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Ошибка при добавлении в базу данных", e);
            }
        }

        /// <summary>
        /// Обновить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        public async Task UpdateAsync(BookModel book)
        {
            try
            {
                var bookEntity = await _context.Books
                    .FirstOrDefaultAsync(b => b.Id == book.Id);
                if (bookEntity == null)
                    throw new KeyNotFoundException("Ошибка: Не удалось найти обновляему книгу");
                bookEntity = _mapper.Map<Book>(book);
                _context.Entry(bookEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Ошибка при сохранении в базу данных", e);
            }
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var bookEntity = await _context.Books
                    .FirstOrDefaultAsync(b => b.Id == id);
                _context.Books.Remove(bookEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException("Ошибка при сохранении в базу данных", e);
            }
        }

        /// <summary>
        /// Поиск книг по автору
        /// </summary>
        /// <param name="searchString">Имя автора</param>
        /// <returns>Колекция книг</returns>
        public IEnumerable<BookModel> SearchByAuthor(string searchString)
        {
            var booksEntities = from author in _context.Authors
                                join authorbook in _context.AuthorBooks on author.Id equals authorbook.AuthorId
                                join book in _context.Books on authorbook.BookId equals book.Id
                                where author.Name.Contains(searchString)
                                select book;
            return _mapper.Map<IEnumerable<BookModel>>(booksEntities);
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
            var booksEntities = _context.Books
                .Where(b => b.Name.Contains(searchString))
                .Skip(skipCount)
                .Take(takeCount);
            return _mapper.Map<IEnumerable<BookModel>>(booksEntities);
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
