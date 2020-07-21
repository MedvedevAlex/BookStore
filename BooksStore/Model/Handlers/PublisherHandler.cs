using System.Collections.Generic;
using System.Linq;
using Model.Models;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models;
using AutoMapper;

namespace Service.PublisherRepos
{
    /// <summary>
    /// Хэндлер Издатель
    /// </summary>
    public class PublisherHandler : IPublisherHandler
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Подключение к бд</param>
        /// <param name="mapper">Маппер</param>
        public PublisherHandler(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Поиск по имени издателя
        /// </summary>
        /// <param name="publisherName">Имя издателя</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция издателей</returns>
        public IEnumerable<PublisherModel> SearchByName(string publisherName, int takeCount, int skipCount)
        {
            return _context.Publishers
                .Where(p => p.Name.Contains(publisherName))
                .Skip(skipCount)
                .Take(takeCount)
                .Select(s => _mapper.Map<PublisherModel>(s));
        }
    }
}
