using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers.References;
using ViewModel.Models.References;
using ViewModel.Responses;
using ViewModel.Responses.References.PainterStyles;

namespace Model.Handlers
{
    /// <summary>
    /// Обработчик данных стиль художника
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
        /// <returns>Базовый ответ</returns>
        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterStyleEnity = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Id == id);
                if (painterStyleEnity == null) throw new KeyNotFoundException("Ошибка: Стиль художника не найден");

                var painterEntity = await context.Painters
                    .FirstOrDefaultAsync(p => p.Style == painterStyleEnity);
                if (painterEntity != null) throw new Exception("Ошибка: Удаление невозможно так как существуют художники которые используют этот стиль");

                context.PainterStyles.Remove(painterStyleEnity);
                await context.SaveChangesAsync();
            }
            return new BaseResponse();
        }

        /// <summary>
        /// Получить стиль художника
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель стиль художника</returns>
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
        /// <returns>Ответ с коллекцией стилей художника</returns>
        public async Task<ListPainterStylesResponse> GetAsync()
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var styles = await context.PainterStyles
                    .Select(ps => _mapper.Map<PainterStyleModel>(ps))
                    .ToListAsync();
                return new ListPainterStylesResponse { Styles = styles, Count = styles.Count };
            }
        }

        /// <summary>
        /// Поиск по наименованию 
        /// </summary>
        /// <param name="painterStyleName">Наименование стиля художника</param>
        /// <returns>Ответ с коллекцией стилей художника</returns>
        public async Task<ListPainterStylesResponse> SearchByNameAsync(string painterStyleName)
        {
            var response = new ListPainterStylesResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                response.Styles = await context.PainterStyles
                    .Where(ps => ps.Name.Contains(painterStyleName))
                    .Select(ps => _mapper.Map<PainterStyleModel>(ps))
                    .ToListAsync();
                response.Count = await context.PainterStyles.CountAsync();
            }
            return response;
        }
    }
}
