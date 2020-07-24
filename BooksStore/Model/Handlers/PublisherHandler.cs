using System.Collections.Generic;
using System.Linq;
using ViewModel.Interfaces.Handlers;
using AutoMapper;
using Model;
using ViewModel.Models.Publishers;

namespace Service.PublisherRepos
{
    /// <summary>
    /// Хэндлер Издатель
    /// </summary>
    public class PublisherHandler : IPublisherHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public PublisherHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory(); ;
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
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                return context.Publishers
                .Where(p => p.Name.Contains(publisherName))
                .Skip(skipCount)
                .Take(takeCount)
                .Select(s => _mapper.Map<PublisherModel>(s));
            }
        }
    }
}
