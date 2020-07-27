using System.Linq;
using AutoMapper;
using Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using ViewModel.Models.Interpreters;
using Model.Entities.JoinTables;
using ViewModel.Handlers;
using System;
using System.Collections.Generic;
using Model.Extensions;

namespace Service.PublisherRepos
{
    /// <summary>
    /// Хэндлер Переводчик
    /// </summary>
    public class InterpreterHandler : IInterpreterHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public InterpreterHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory(); ;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить переводчика
        /// </summary>
        /// <param name="interpreter">Модель переводчик</param>
        /// <returns>Модель переводчик</returns>
        public async Task<InterpreterViewModel> AddAsync(InterpreterModifyModel interpreter)
        {
            var interpreterEntity = _mapper.Map<Interpreter>(interpreter);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var newBooksEntitites = await context.Books
                    .Where(b => interpreter.BooksIds.Contains(b.Id))
                    .Select(b => new InterpreterBook() { Book = b, Interpreter = interpreterEntity })
                    .ToListAsync();
                interpreterEntity.InterpreterBooks = newBooksEntitites;

                await context.Interpreters.AddAsync(interpreterEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(interpreter.Id);
        }

        /// <summary>
        /// Обновить переводчика
        /// </summary>
        /// <param name="interpreter">Модель переводчик</param>
        /// <returns>Модель переводчик</returns>
        public async Task<InterpreterViewModel> UpdateAsync(InterpreterModifyModel interpreter)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var interpreterEntity = await context.Interpreters
                    .Include(i => i.InterpreterBooks)
                            .ThenInclude(ib => ib.Book)
                    .FirstOrDefaultAsync(i => i.Id == interpreter.Id);
                if (interpreterEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти переводчика");

                context.Entry(interpreterEntity).CurrentValues.SetValues(interpreter);

                var newBooksEntities = context.Books
                        .Where(b => interpreter.BooksIds.Contains(b.Id));

                context.TryUpdateManyToMany(interpreterEntity.InterpreterBooks, newBooksEntities
                    .Select(s => new InterpreterBook
                    {
                        InterpreterId = interpreterEntity.Id,
                        BookId = s.Id
                    }), s => s.BookId);

                context.Interpreters.Update(interpreterEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(interpreter.Id);
        }

        /// <summary>
        /// Удалить переводчика
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public async void DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var interpreterEntity = await context.Interpreters
                    .FirstOrDefaultAsync(i => i.Id == id);
                if (interpreterEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти переводчика");

                context.Interpreters.Remove(interpreterEntity);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получить переводчика
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель переводчик</returns>
        public async Task<InterpreterViewModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var interpreterEntity = await context.Interpreters
                    .Include(i => i.InterpreterBooks)
                        .ThenInclude(ib => ib.Book)
                            .ThenInclude(b => b.AuthorBooks)
                                .ThenInclude(ab => ab.Author)
                    .FirstOrDefaultAsync(i => i.Id == id);
                return _mapper.Map<InterpreterViewModel>(interpreterEntity);
            }
        }

        /// <summary>
        /// Пагинация переводчиков
        /// </summary>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция переводчиков</returns>
        public async Task<List<InterpreterPreviewModel>> GetAsync(int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.Interpreters
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<InterpreterPreviewModel>(s))
                    .ToListAsync();
            }
        }
    }
}
