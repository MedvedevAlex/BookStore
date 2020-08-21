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
    /// Обработчик данных тип переплета
    /// </summary>
    public class CoverTypeHandler : ICoverTypeHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public CoverTypeHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить тип переплета
        /// </summary>
        /// <param name="coverType">Модель тип переплета</param>
        /// <returns>Модель тип переплета</returns>
        public async Task<CoverTypeModel> AddAsync(CoverTypeModel coverType)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var coverTypeEntity = await context.CoverTypes
                    .FirstOrDefaultAsync(ct => ct.Id == coverType.Id 
                        || ct.Name.Trim().ToLower() == coverType.Name.Trim().ToLower());
                if (coverTypeEntity != null)
                    if (coverTypeEntity.Id == coverType.Id)
                        throw new KeyNotFoundException("Ошибка: Тип переплета с таким идентификатором уже сущетсвует");
                    else if (coverTypeEntity.Name.Trim().ToLower() == coverType.Name.Trim().ToLower())
                        throw new KeyNotFoundException("Ошибка: Тип переплета с таким именем уже существует");

                coverTypeEntity = _mapper.Map<CoverType>(coverType);

                await context.CoverTypes.AddAsync(coverTypeEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(coverType.Id);
        }

        /// <summary>
        /// Обновить тип переплета
        /// </summary>
        /// <param name="coverType">Модель тип переплета</param>
        /// <returns>Модель тип переплета</returns>
        public async Task<CoverTypeModel> UpdateAsync(CoverTypeModel coverType)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var coverTypeEntity = await context.CoverTypes
                    .FirstOrDefaultAsync(ct => ct.Id == coverType.Id);
                if (coverTypeEntity == null) throw new KeyNotFoundException("Ошибка: Тип переплета не найден");

                var coverTypeEntityName = await context.CoverTypes
                    .FirstOrDefaultAsync(ct => ct.Name.Trim().ToLower() == coverType.Name.Trim().ToLower());
                if (coverTypeEntityName != null) throw new KeyNotFoundException("Ошибка: Тип переплета с такими именем уже существует");

                context.Entry(coverTypeEntity).CurrentValues.SetValues(coverType);

                await context.SaveChangesAsync();
            }
            return await GetAsync(coverType.Id);
        }

        /// <summary>
        /// Удалить тип переплета
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public async void DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var coverTypeEntity = await context.CoverTypes
                    .FirstOrDefaultAsync(ct => ct.Id == id);
                if (coverTypeEntity == null) throw new KeyNotFoundException("Ошибка: Тип переплета не найден");

                context.CoverTypes.Remove(coverTypeEntity);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получить тип переплета
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель тип переплета</returns>
        public async Task<CoverTypeModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var coverTypeEntity = await context.CoverTypes
                    .FirstOrDefaultAsync(ct => ct.Id == id);
                return _mapper.Map<CoverTypeModel>(coverTypeEntity);
            }
        }

        /// <summary>
        /// Получить типы переплета
        /// </summary>
        /// <returns>Коллекция типов переплета</returns>
        public async Task<List<CoverTypeModel>> GetAsync()
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.CoverTypes
                    .Select(ct => _mapper.Map<CoverTypeModel>(ct))
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Поиск по наименованию 
        /// </summary>
        /// <param name="coverTypeName">Наименование типа переплета</param>
        /// <returns>Коллекция типов переплета</returns>
        public async Task<List<CoverTypeModel>> SearchByNameAsync(string coverTypeName)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return await context.CoverTypes
                    .Where(ct => ct.Name.Contains(coverTypeName))
                    .Select(ct => _mapper.Map<CoverTypeModel>(ct))
                    .ToListAsync();
            }
        }
    }
}
