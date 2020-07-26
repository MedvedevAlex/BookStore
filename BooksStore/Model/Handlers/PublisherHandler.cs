using System.Collections.Generic;
using System.Linq;
using ViewModel.Interfaces.Handlers;
using AutoMapper;
using Model;
using ViewModel.Models.Publishers;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

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
        /// Добавить издателя
        /// </summary>
        /// <param name="publisher">Модель издатель</param>
        /// <returns>Модель издатель</returns>
        public async Task<PublisherViewModel> AddAsync(PublisherModifyModel publisher)
        {
            var publisherEntity = _mapper.Map<Publisher>(publisher);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var booksEntities = await context.Books
                    .Where(b => publisher.BooksIds.Contains(b.Id))
                    .ToListAsync();
                publisherEntity.Books = booksEntities;

                await context.AddAsync(publisherEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(publisher.Id);
        }

        /// <summary>
        /// Обновить издателя
        /// </summary>
        /// <param name="publisher">Модель издатель</param>
        /// <returns>Модель издатель</returns>
        public async Task<PublisherViewModel> UpdateAsync(PublisherModifyModel publisher)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var publisherEntity = await context.Publishers
                    .Include(p => p.Books)
                    .FirstOrDefaultAsync(p => p.Id == publisher.Id);
                if (publisherEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти издателя");

                context.Entry(publisherEntity).CurrentValues.SetValues(publisher);

                var booksEntities = await context.Books
                    .Where(b => publisher.BooksIds.Contains(b.Id))
                    .ToListAsync();
                publisherEntity.Books = booksEntities;

                context.Update(publisherEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(publisher.Id);
        }

        /// <summary>
        /// Получить издателя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель издатель</returns>
        public async Task<PublisherViewModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var publisherEntity =  await context.Publishers
                    .Include(p => p.Books)
                        .ThenInclude(b => b.AuthorBooks)
                            .ThenInclude(ab => ab.Author)
                    .FirstOrDefaultAsync(p => p.Id == id);
                return _mapper.Map<PublisherViewModel>(publisherEntity);
                
            }
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
