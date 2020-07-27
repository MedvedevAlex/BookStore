using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}
