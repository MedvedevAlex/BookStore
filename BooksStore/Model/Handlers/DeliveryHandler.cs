using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Enums;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Deliveries;

namespace Model.Handlers
{
    /// <summary>
    /// Обработчик данных доставка
    /// </summary>
    public class DeliveryHandler : IDeliveryHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public DeliveryHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить доставку
        /// </summary>
        /// <param name="delivery">Модель доставка</param>
        /// <returns>Модель доставка</returns>
        public async Task<DeliveryModel> AddAsync(DeliveryCreatedModel delivery)
        {
            var guidDelivery = Guid.NewGuid();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var shopTask = context.Shops.FirstOrDefaultAsync(s => s.Id == delivery.ShopId);

                var deliveryEntity = _mapper.Map<Delivery>(delivery);
                deliveryEntity.Id = guidDelivery;
                deliveryEntity.DateCreate = DateTime.Now;
                deliveryEntity.Status = DeliveryStatus.Waiting;

                deliveryEntity.Shop = await shopTask ?? throw new KeyNotFoundException("Ошибка: Не удалось найти магазин");
                var orderTask = context.Orders.FirstOrDefaultAsync(o => o.Id == delivery.OrderId);
                deliveryEntity.OrderId = delivery.OrderId;
                deliveryEntity.Order = await orderTask ?? throw new KeyNotFoundException("Ошибка: Не удалось найти заказ");

                await context.Deliveries.AddAsync(deliveryEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(guidDelivery);
        }

        /// <summary>
        /// Обновить доставку
        /// </summary>
        /// <param name="delivery">Модель доставка</param>
        /// <returns>Модель доставка</returns>
        public async Task<DeliveryModel> UpdateAsync(DeliveryModifyModel delivery)
        {
            using(var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var deliveryEntity = await context.Deliveries
                    .Include(d => d.Shop)
                    .FirstOrDefaultAsync(d => d.Id == delivery.Id);
                if (deliveryEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти доставку");

                if (deliveryEntity.Shop?.Id != delivery.ShopId)
                {
                    var shopEntity = await context.Shops
                        .FirstOrDefaultAsync(s => s.Id == delivery.ShopId);
                    deliveryEntity.Shop = shopEntity ?? throw new KeyNotFoundException("Ошибка: Не удалось найти магазин");
                }
                deliveryEntity.DateDelivery = delivery.DateDelivery;
                deliveryEntity.Status = delivery.Status;

                context.Deliveries.Update(deliveryEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(delivery.Id);
        }

        /// <summary>
        /// Получить доставку
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель доставка</returns>
        public async Task<DeliveryModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var deliveryEntity = await context.Deliveries
                    .Include(d => d.Shop)
                        .ThenInclude(s => s.WorkShedule)
                    .FirstOrDefaultAsync(d => d.Id == id);
                if (deliveryEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти доставку");

                return _mapper.Map<DeliveryModel>(deliveryEntity);
            }
        }
    }
}
