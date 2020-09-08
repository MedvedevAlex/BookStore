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
using ViewModel.Models.Authors;
using ViewModel.Responses;
using ViewModel.Responses.Authors;

namespace Model.Handlers
{
    /// <summary>
    /// Обработчик данных автор
    /// </summary>
    public class AuthorHandler : IAuthorHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public AuthorHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить автора
        /// </summary>
        /// <param name="author">Модель автор</param>
        /// <returns>Модель автор</returns>
        public async Task<AuthorViewModel> AddAsync(AuthorModifyModel author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var booksEntities = await context.Books
                    .Where(b => author.BooksIds.Contains(b.Id))
                    .Select(b => new AuthorBook() { Book = b, Author = authorEntity })
                    .ToListAsync();
                authorEntity.AuthorBooks = booksEntities;

                await context.Authors.AddAsync(authorEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(author.Id);
        }

        /// <summary>
        /// Обновить автора
        /// </summary>
        /// <param name="author">Модель автор</param>
        /// <returns>Модель автор</returns>
        public async Task<AuthorViewModel> UpdateAsync(AuthorModifyModel author)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var authorEntity = await context.Authors
                    .Include(a => a.AuthorBooks)
                            .ThenInclude(ab => ab.Book)
                    .FirstOrDefaultAsync(a => a.Id == author.Id);
                if (authorEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти автора");

                context.Entry(authorEntity).CurrentValues.SetValues(author);

                var newBooksEntities = context.Books
                        .Where(b => author.BooksIds.Contains(b.Id));

                context.TryUpdateManyToMany(authorEntity.AuthorBooks, newBooksEntities
                    .Select(b => new AuthorBook
                    {
                        AuthorId = authorEntity.Id,
                        BookId = b.Id
                    }), ab => ab.BookId);

                context.Authors.Update(authorEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(author.Id);
        }

        /// <summary>
        /// Удалить автора
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Базовый ответ</returns>
        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var authorEntity = await context.Authors
                    .FirstOrDefaultAsync(a => a.Id == id);
                if (authorEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти автора");

                context.Authors.Remove(authorEntity);
                await context.SaveChangesAsync();
            }
            return new BaseResponse();
        }

        /// <summary>
        /// Получить автора
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель автор</returns>
        public async Task<AuthorViewModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var authorEntity = await context.Authors
                    .Include(a => a.AuthorBooks)
                        .ThenInclude(ab => ab.Book)
                    .FirstOrDefaultAsync(a => a.Id == id);
                return _mapper.Map<AuthorViewModel>(authorEntity);
            }
        }

        /// <summary>
        /// Пагинация авторов
        /// </summary>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция авторов</returns>
        public async Task<AuthorPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            var result = new AuthorPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = context.Authors;
                result.PreviewAuthors = await query
                    .Skip(skipCount)
                    .Take(takeCount)
                    .Select(a => _mapper.Map<AuthorPreviewModel>(a))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск по имени
        /// </summary>
        /// <param name="authorName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция авторов</returns>
        public async Task<AuthorPreviewResponse> SearchByNameAsync(string authorName, int takeCount, int skipCount)
        {
            var result = new AuthorPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = context.Authors
                    .Where(a => a.Name.Contains(authorName));
                result.PreviewAuthors = await query
                    .Skip(skipCount)
                    .Take(takeCount)
                    .Select(a => _mapper.Map<AuthorPreviewModel>(a))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }
    }
}
