using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities.References;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers.References;
using ViewModel.Models.References;

namespace Model.Handlers
{
    /// <summary>
    /// Хэндлер Тип переплета
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
                if (coverTypeEntity != null ) 
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

    }
}
