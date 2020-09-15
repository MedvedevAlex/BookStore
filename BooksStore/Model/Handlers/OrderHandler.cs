using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Enums;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Repositories;
using ViewModel.Models.Books;
using ViewModel.Models.Orders;

namespace Model.Handlers
{
    /// <summary>
    /// Обработчик данных заказ
    /// </summary>
    public class OrderHandler : IOrderHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;
        private readonly IUserInfoRepository _userInfoRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        /// <param name="userInfoRepository">Репозиторий информация о пользователе</param>
        public OrderHandler(IMapper mapper, IUserInfoRepository userInfoRepository)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
            _userInfoRepository = userInfoRepository;
        }

        /// <summary>
        /// Добавить заказа
        /// </summary>
        /// <param name="order">Модель заказ</param>
        /// <returns>Модель заказ</returns>
        public async Task<OrderModel> AddAsync(OrderModifyModel order)
        {
            var orderId = Guid.NewGuid();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var booksEntities = await context.Books
                    .Where(b => order.BooksIds.Contains(b.Id))
                    .ToListAsync();
                if (booksEntities.Count != order.BooksIds.Count) throw new KeyNotFoundException("Ошибка: Не удалось найти все книги при добавлении к заказу");

                var userId = _userInfoRepository.GetUserIdFromToken();
                var userEntity = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти пользователя");

                var orderEntity = new Order
                {
                    Id = orderId,
                    User = userEntity,
                    DateCreate = DateTime.Now,
                    Payment = null,
                    Delivery = null,
                    Status = OrderStatus.NotProcessed,
                    Amount = booksEntities.Sum(b => b.Price),
                    Description = order.Description
                };
                var orderContextTask = context.Orders.AddAsync(orderEntity);

                var goodsEntities = CreateGoods(booksEntities, orderEntity);

                await context.AddRangeAsync(goodsEntities);
                await orderContextTask;
                await context.SaveChangesAsync();
            }
            return await GetAsync(orderId);
        }

        /// <summary>
        /// Получить заказ
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель заказ</returns>
        public async Task<OrderModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var booksContextTask = await context.GoodsOrders
                    .Where(go => go.Order.Id == id)
                    .Select(go => go.Book)
                    .ToListAsync();
                var orderEntity = await context.Orders
                    .Include(o => o.Delivery)
                    .FirstOrDefaultAsync(o => o.Id == id);
                if (orderEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти заказ");

                var order = _mapper.Map<OrderModel>(orderEntity);
                order.Books = _mapper.Map<List<BookPreviewModel>>(booksContextTask);

                return order;
            }
        }

        /// <summary>
        /// Обновить статус заказа
        /// </summary>
        /// <param name="order">Модель заказ</param>
        /// <returns>Модель заказ</returns>
        public async Task<OrderModel> UpdateStatusAsync(OrderUpdateModel order)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var orderEntity = await context.Orders
                    .FirstOrDefaultAsync(o => o.Id == order.Id);
                if (orderEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти заказ");

                orderEntity.Status = order.Status;

                context.Orders.Update(orderEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(order.Id);
        }

        /// <summary>
        /// Создать привязку товаров к заказу
        /// </summary>
        /// <param name="booksEntities">Сущности книг</param>
        /// <param name="orderEntity">Сущность заказ</param>
        /// <returns>Сущности привязанных товаров</returns>
        private static List<GoodsOrder> CreateGoods(List<Book> booksEntities, Order orderEntity)
        {
            var goodsEntities = new List<GoodsOrder>();
            foreach (var book in booksEntities)
            {
                goodsEntities.Add(new GoodsOrder
                {
                    Id = Guid.NewGuid(),
                    Book = book,
                    Order = orderEntity,
                    Amount = book.Price
                });
            }
            return goodsEntities;
        }
    }
}
