using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    /// Хэндлер Заказ
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
        /// Подтверждение заказа
        /// </summary>
        /// <param name="order">Модель заказ</param>
        /// <returns>Идентификатор заказа</returns>
        public async Task<OrderModel> ConfirmAsync(OrderModifyModel order)
        {
            var orderId = Guid.NewGuid();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var deliveryContextTask = CreateDelivery(context, order.ShopId, orderId, out Delivery deliveryEntity);
                await deliveryContextTask;

                var booksTask = context.Books
                    .Where(b => order.Books.Contains(b.Id))
                    .ToListAsync();

                var userId = _userInfoRepository.GetUserIdFromToken();
                var userTask = context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                var booksEntities = await booksTask;
                if (booksEntities.Count != order.Books.Count) throw new KeyNotFoundException("Ошибка: Не удалось найти все книги при добавлении к заказу");

                var userEntity = await userTask;
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти пользователя");

                var orderEntity = new Order
                {
                    Id = orderId,
                    User = userEntity,
                    Payment = null,
                    Delivery = null,
                    Status = OrderStatus.NotProcessed,
                    Amount = booksEntities.Sum(s => s.Price)
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
                    .Where(g => g.Order.Id == id)
                    .Select(g => g.Book)
                    .ToListAsync();
                var orderEntity = await context.Orders
                    .Include(d => d.Delivery)
                    .FirstOrDefaultAsync(o => o.Id == id);
                if (orderEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти заказ");

                var order = _mapper.Map<OrderModel>(orderEntity);
                order.Books = _mapper.Map<List<BookPreviewModel>>(booksContextTask);

                return order;
            }
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

        /// <summary>
        /// Создать доставку для заказа
        /// </summary>
        /// <param name="context">Подключение к </param>
        /// <param name="shopId">Идентификатор магазина</param>
        /// <param name="orderId">Идентификатор заказа</param>
        /// <returns>Информация о изменениях(добавление заказа в таблицу)</returns>
        private static ValueTask<EntityEntry<Delivery>> CreateDelivery(BookContext context, Guid shopId, Guid orderId, out Delivery deliveryEntity)
        {
            var shopEntity = context.Shops.FirstOrDefaultAsync(s => s.Id == shopId).Result;
            if (shopEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти магазин");

            deliveryEntity = new Delivery
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                Shop = shopEntity,
                DateCreate = DateTime.Now,
                DateDelivery = null,
                Status = DeliveryStatus.Waiting,
            };
            return context.Deliveries.AddAsync(deliveryEntity);
        }
    }
}
