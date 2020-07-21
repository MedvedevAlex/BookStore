using System.Collections.Generic;
using System.Linq;
using Model.Models;
using ViewModel.Interfaces.Handlers;
using AutoMapper;
using ViewModel.Models;

namespace Service.PainterRepos
{
    /// <summary>
    /// Хэндлер Художник
    /// </summary>
    public class PainterHandler : IPainterHandler
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Подключение к базе данных</param>
        /// <param name="mapper">Маппер</param>
        public PainterHandler(
            BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Поиск по имени художника
        /// </summary>
        /// <param name="painterName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns></returns>
        public IEnumerable<PainterModel> SearchByName(string painterName, int takeCount, int skipCount)
        {
            return _context.Painters
                .Where(p => p.Name.Contains(painterName))
                .Take(takeCount)
                .Skip(skipCount)
                .Select(s => _mapper.Map<PainterModel>(s));
        }
    }
}
