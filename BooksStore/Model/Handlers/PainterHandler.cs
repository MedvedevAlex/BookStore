using System.Collections.Generic;
using System.Linq;
using ViewModel.Interfaces.Handlers;
using AutoMapper;
using Model;
using ViewModel.Models.Painters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Model.Entities;
using Model.Entities.JoinTables;

namespace Service.PainterRepos
{
    /// <summary>
    /// Хэндлер Художник
    /// </summary>
    public class PainterHandler : IPainterHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public PainterHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить художника
        /// </summary>
        /// <param name="painter">Модель художника</param>
        /// <returns>Модель художника</returns>
        public async Task<PainterViewModel> AddAsync(PainterModifyModel painter)
        {
            var painterEntity = _mapper.Map<Painter>(painter);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var styleEntity = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Id == painter.StyleId);
                painterEntity.Style = styleEntity ?? throw new KeyNotFoundException("Ошибка: не удалось найти стиль");

                var booksEntities = await context.Books
                    .Where(b => painter.Books.Contains(b.Id))
                    .Select(b => new PainterBook() { Painter = painterEntity, Book = b })
                    .ToListAsync();
                painterEntity.PainterBooks = booksEntities;

                await context.AddAsync(painterEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(painter.Id);
        }

        /// <summary>
        /// Получить художника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель художник</returns>
        public async Task<PainterViewModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterEntity = await context.Painters
                    .Include(p => p.Style)
                    .Include(p => p.PainterBooks)
                        .ThenInclude(pb => pb.Book)
                    .FirstOrDefaultAsync(p => p.Id == id);
                return _mapper.Map<PainterViewModel>(painterEntity);
            }
        }

        /// <summary>
        /// Получить художников
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция художников</returns>
        public async Task<List<PainterViewModel>> GetAsync(int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.Painters
                    .Include(p => p.Style)
                    .Include(p => p.PainterBooks)
                        .ThenInclude(pb => pb.Book)
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<PainterViewModel>(s))
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Поиск по имени художника
        /// </summary>
        /// <param name="painterName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция художников</returns>
        public async Task<List<PainterViewModel>> SearchByNameAsync(string painterName, int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.Painters
                    .Include(p => p.Style)
                    .Include(p => p.PainterBooks)
                        .ThenInclude(pb => pb.Book)
                    .Where(p => p.Name.Contains(painterName))
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<PainterViewModel>(s))
                    .ToListAsync();
            }
        }
    }
}
