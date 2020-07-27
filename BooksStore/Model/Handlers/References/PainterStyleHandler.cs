using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers.References;
using ViewModel.Models.References;

namespace Model.Handlers
{
    /// <summary>
    /// Хэндлер Стиль художника
    /// </summary>
    public class PainterStyleHandler : IPainterStyleHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public PainterStyleHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить стиль художника
        /// </summary>
        /// <param name="painterStyle">Модель стиль художника</param>
        /// <returns>Модель стиль художника</returns>
        public async Task<PainterStyleModel> AddAsync(PainterStyleModel painterStyle)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterStyleEnity = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Id == painterStyle.Id
                    || ps.Name.Trim().ToLower() == painterStyle.Name.Trim().ToLower());
                if (painterStyleEnity != null)
                    if (painterStyleEnity.Id == painterStyle.Id)
                        throw new KeyNotFoundException("Ошибка: Стиль художника с таким идентификатором уже сущетсвует");
                    else if (painterStyleEnity.Name.Trim().ToLower() == painterStyle.Name.Trim().ToLower())
                        throw new KeyNotFoundException("Ошибка: Стиль художника с таким именем уже существует");

                painterStyleEnity = _mapper.Map<PainterStyle>(painterStyle);

                await context.PainterStyles.AddAsync(painterStyleEnity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(painterStyle.Id);
        }

        /// <summary>
        /// Обновить стиль художника
        /// </summary>
        /// <param name="painterStyle">Модель стиль художника</param>
        /// <returns>Модель стиль художника</returns>
        public async Task<PainterStyleModel> UpdateAsync(PainterStyleModel painterStyle)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterStyleEnity = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Id == painterStyle.Id);
                if (painterStyleEnity == null) throw new KeyNotFoundException("Ошибка: Стиль художника не найден");

                var painterStyleEnityName = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Name.Trim().ToLower() == painterStyle.Name.Trim().ToLower());
                if (painterStyleEnityName != null) throw new KeyNotFoundException("Ошибка: Стиль художника с такими именем уже существует");

                context.Entry(painterStyleEnity).CurrentValues.SetValues(painterStyle);

                await context.SaveChangesAsync();
            }
            return await GetAsync(painterStyle.Id);
        }

        /// <summary>
        /// Удалить стиль художника
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public async void DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterStyleEnity = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Id == id);
                if (painterStyleEnity == null) throw new KeyNotFoundException("Ошибка: Стиль художника не найден");

                context.PainterStyles.Remove(painterStyleEnity);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получить стиль художника
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Стиль художника</returns>
        public async Task<PainterStyleModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterStyleEnity = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Id == id);
                return _mapper.Map<PainterStyleModel>(painterStyleEnity);
            }
        }

        /// <summary>
        /// Получить стили художника
        /// </summary>
        /// <returns>Коллекция стилей художника</returns>
        public async Task<List<PainterStyleModel>> GetAsync()
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.PainterStyles
                    .Select(ps => _mapper.Map<PainterStyleModel>(ps))
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Поиск по наименованию 
        /// </summary>
        /// <param name="painterStyleName">Наименование стиля художника</param>
        /// <returns>Коллекция стилей художника</returns>
        public async Task<List<PainterStyleModel>> SearchByNameAsync(string painterStyleName)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.PainterStyles
                    .Where(ct => ct.Name.Contains(painterStyleName))
                    .Select(ct => _mapper.Map<PainterStyleModel>(ct))
                    .ToListAsync();
            }
        }
    }
}
