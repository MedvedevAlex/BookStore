using System.Collections.Generic;
using System.Linq;
using ViewModel.Interfaces.Handlers;
using AutoMapper;
using Model;
using ViewModel.Models.Painters;

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
        /// Поиск по имени художника
        /// </summary>
        /// <param name="painterName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция художников</returns>
        public IEnumerable<PainterModel> SearchByName(string painterName, int takeCount, int skipCount)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return context.Painters
                .Where(p => p.Name.Contains(painterName))
                .Take(takeCount)
                .Skip(skipCount)
                .Select(s => _mapper.Map<PainterModel>(s));
            }
        }
    }
}
