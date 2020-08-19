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
        public async Task<Guid> ConfirmAsync(OrderModel order)
        {
            var orderId = Guid.NewGuid();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var booksTask = context.Books
                    .Where(b => order.Books.Contains(b.Id))
                    .ToListAsync();

                var userId = _userInfoRepository.GetUserIdFromToken();
                var userTask = context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                var shopEntity = await context.Shops.FirstOrDefaultAsync(s => s.Id == order.ShopId);
                if (shopEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти магазин");

                var deliveryEntity = new Delivery
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderId,
                    Shop = shopEntity,
                    DateCreate = DateTime.Now,
                    DateDelivery = null,
                    Status = DeliveryStatus.Waiting,
                };
                var deliveryContextTask = context.Deliveries.AddAsync(deliveryEntity);

                var booksEntities = await booksTask;
                if (booksEntities.Count != order.Books.Count) throw new Exception("Ошибка: Не удалось найти все книги при добавлении к заказу");

                var userEntity = await userTask;
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти пользователя");

                var orderEntity = new Order
                {
                    Id = orderId,
                    User = userEntity,
                    Payment = null,
                    Delivery = deliveryEntity,
                    Status = OrderStatus.NotProcessed,
                    Amount = booksEntities.Sum(s => s.Price)
                };
                var orderContextTask = context.Orders.AddAsync(orderEntity);

                var goods = new List<GoodsOrder>();
                foreach (var book in booksEntities)
                {
                    goods.Add(new GoodsOrder
                    {
                        Id = Guid.NewGuid(),
                        Book = book,
                        Order = orderEntity,
                        Amount = book.Price
                    });
                }

                await context.AddRangeAsync(goods);
                await deliveryContextTask;
                await orderContextTask;
                await context.SaveChangesAsync();
            }
            return orderId;
        }
    }
}
