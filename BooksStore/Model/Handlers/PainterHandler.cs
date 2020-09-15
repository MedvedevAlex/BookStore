using System.Collections.Generic;
using System.Linq;
using ViewModel.Interfaces.Handlers;
using AutoMapper;
using Model;
using ViewModel.Models.Painters;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Model.Entities;
using Model.Entities.JoinTables;
using Model.Extensions;
using ViewModel.Responses;
using ViewModel.Responses.Painters;

namespace Service.PainterRepos
{
    /// <summary>
    /// Обработчик данных художник
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
        /// Добавить художника
        /// </summary>
        /// <param name="painter">Модель художник</param>
        /// <returns>Модель художник</returns>
        public async Task<PainterViewModel> AddAsync(PainterModifyModel painter)
        {
            painter.Id = Guid.NewGuid();
            var painterEntity = _mapper.Map<Painter>(painter);
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var styleEntity = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Id == painter.StyleId);
                painterEntity.Style = styleEntity ?? throw new KeyNotFoundException("Ошибка: не удалось найти стиль");

                var booksEntities = await context.Books
                    .Where(b => painter.BooksIds.Contains(b.Id))
                    .Select(b => new PainterBook() { Painter = painterEntity, Book = b })
                    .ToListAsync();
                painterEntity.PainterBooks = booksEntities;

                await context.AddAsync(painterEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(painter.Id);
        }

        /// <summary>
        /// Обновить художника
        /// </summary>
        /// <param name="painter">Модель художник</param>
        /// <returns>Модель художник</returns>
        public async Task<PainterViewModel> UpdateAsync(PainterModifyModel painter)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterEntity = await context.Painters
                    .Include(p => p.Style)
                    .Include(p => p.PainterBooks)
                        .ThenInclude(pb => pb.Book)
                    .FirstOrDefaultAsync(p => p.Id == painter.Id);
                if (painterEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти художника");

                context.Entry(painterEntity).CurrentValues.SetValues(painter);

                var styleEntity = await context.PainterStyles
                    .FirstOrDefaultAsync(ps => ps.Id == painter.StyleId);
                painterEntity.Style = styleEntity;

                var newBooksEntities = context.PainterBooks
                    .Where(pb => painter.BooksIds.Contains(pb.BookId));
                context.TryUpdateManyToMany(painterEntity.PainterBooks, newBooksEntities
                    .Select(pb => new PainterBook
                    {
                        PainterId = painterEntity.Id,
                        BookId = pb.BookId
                    }), pb => pb.BookId);

                context.Painters.Update(painterEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(painter.Id);
        }

        /// <summary>
        /// Удалить художника
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Базовый ответ</returns>
        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterEntity = await context.Painters
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (painterEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти художника");

                context.Painters.Remove(painterEntity);
                await context.SaveChangesAsync();
            }
            return new BaseResponse();
        }

        /// <summary>
        /// Получить художника
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель художник</returns>
        public async Task<PainterViewModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var painterEntity = await context.Painters
                    .Include(p => p.Style)
                    .Include(p => p.PainterBooks)
                        .ThenInclude(pb => pb.Book)
                    .FirstOrDefaultAsync(p => p.Id == id);
                return _mapper.Map<PainterViewModel>(painterEntity);
            }
        }

        /// <summary>
        /// Пагинация художников
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Ответ с коллекцией художников</returns>
        public async Task<PainterPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            var result = new PainterPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = context.Painters;
                result.PreviewPainters = await query
                    .Skip(skipCount)
                    .Take(takeCount)
                    .Include(p => p.Style)
                    .Select(p => _mapper.Map<PainterPreviewModel>(p))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск по имени художника
        /// </summary>
        /// <param name="painterName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Ответ с коллекцией художников</returns>
        public async Task<PainterPreviewResponse> SearchByNameAsync(string painterName, int takeCount, int skipCount)
        {
            var result = new PainterPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var query = context.Painters
                    .Where(p => p.Name.Contains(painterName.Trim()));

                result.PreviewPainters = await query
                    .Skip(skipCount)
                    .Take(takeCount)
                    .Include(p => p.Style)
                    .Select(p => _mapper.Map<PainterPreviewModel>(p))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }

        /// <summary>
        /// Поиск по стилю художника
        /// </summary>
        /// <param name="styleName">Наименоваине стиля</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Ответ с коллекцией художников</returns>
        public async Task<PainterPreviewResponse> SearchByStyleAsync(string styleName, int takeCount, int skipCount)
        {
            var result = new PainterPreviewResponse();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var stylesEntities = context.PainterStyles
                    .Where(ps => ps.Name.Contains(styleName.Trim()))
                    .Select(ps => ps.Name);
                var query = context.Painters
                    .Where(p => stylesEntities.Contains(p.Style.Name));

                result.PreviewPainters = await query
                    .Skip(skipCount)
                    .Take(takeCount)
                    .Include(p => p.Style)
                    .Select(p => _mapper.Map<PainterPreviewModel>(p))
                    .ToListAsync();
                result.Count = await query.CountAsync();
            }
            return result;
        }
    }
}
