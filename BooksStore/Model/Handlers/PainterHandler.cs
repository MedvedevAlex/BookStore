using System.Collections.Generic;
using System.Linq;
using ViewModel.Interfaces.Handlers;
using AutoMapper;
using Model;
using ViewModel.Models.Painters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

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
        /// Получить художника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель художник</returns>
        public async Task<PainterModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterEntity = await context.Painters
                    .Include(p => p.Style)
                    .Include(p => p.PainterBooks)
                        .ThenInclude(p => p.Book)
                    .FirstOrDefaultAsync(p => p.Id == id);
                return _mapper.Map<PainterModel>(painterEntity);
            }
        }

        /// <summary>
        /// Получить художников
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns></returns>
        public async Task<List<PainterModel>> GetAsync(int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.Painters
                    .Include(p => p.Style)
                    .Include(p => p.PainterBooks)
                        .ThenInclude(p => p.Book)
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<PainterModel>(s))
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
        public async Task<List<PainterModel>> SearchByNameAsync(string painterName, int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.Painters
                    .Include(p => p.Style)
                    .Include(p => p.PainterBooks)
                        .ThenInclude(p => p.Book)
                    .Where(p => p.Name.Contains(painterName))
                    .Take(takeCount)
                    .Skip(skipCount)
                    .Select(s => _mapper.Map<PainterModel>(s))
                    .ToListAsync();
            }
        }
    }
}
