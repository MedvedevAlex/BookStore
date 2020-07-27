using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
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
