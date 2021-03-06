﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using System.Linq;
using ViewModel.Models.Payments;
using ViewModel.Models.Books;

namespace Model.Handlers
{
    /// <summary>
    /// Обработчик данных платеж
    /// </summary>
    public class PaymentHandler : IPaymentHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public PaymentHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить платеж
        /// </summary>
        /// <param name="payment">Модель создания платежа</param>
        /// <returns>Модель платеж</returns>
        public async Task<PaymentModel> AddAsync(PaymentCreateModel payment)
        {
            var paymentId = Guid.NewGuid();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var orderEntity = await context.Orders
                    .FirstOrDefaultAsync(o => o.Id == payment.OrderId);
                var paymentEntity = _mapper.Map<Payment>(payment);
                paymentEntity.Id = paymentId;
                paymentEntity.Order = orderEntity ?? throw new KeyNotFoundException("Ошибка: Не удалось найти заказ");
                paymentEntity.DateCreate = DateTime.Now;
                paymentEntity.Amount = orderEntity.Amount;
                paymentEntity.Status = payment.Status;

                await context.Payments.AddAsync(paymentEntity);
                await context.SaveChangesAsync();
            }
            return await GetAsync(paymentId);
        }

        /// <summary>
        /// Обновить платеж
        /// </summary>
        /// <param name="payment">Модель обновления платежа</param>
        /// <returns>Модель платеж</returns>
        public async Task<PaymentModel> UpdateAsync(PaymentUpdateModel payment)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var paymentEntity = await context.Payments
                    .FirstOrDefaultAsync(p => p.Id == payment.Id);
                if (paymentEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти платеж");
                if (payment.DatePayment != null) 
                    paymentEntity.DatePayment = payment.DatePayment;
                paymentEntity.Status = payment.Status;

                context.Payments.Update(paymentEntity);
                await context.SaveChangesAsync();

                return await GetAsync(payment.Id);
            }
        }

        /// <summary>
        /// Получить платеж
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель платеж</returns>
        public async Task<PaymentModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var paymentEntity = await context.Payments
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (paymentEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти платеж");

                return _mapper.Map<PaymentModel>(paymentEntity);
            }
        }

        /// <summary>
        /// Получить платеж с информацией о заказе
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель платеж с информацией о заказе</returns>
        public async Task<PaymentDetailModel> GetWithOrderAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var paymentEntity = await context.Payments
                    .Include(p => p.Order)
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (paymentEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти платеж");

                var payment = _mapper.Map<PaymentDetailModel>(paymentEntity);
                payment.Order.Books = await context.GoodsOrders
                    .Where(go => go.Order.Id == paymentEntity.OrderId)
                    .Select(go => _mapper.Map<BookPreviewModel>(go.Book))
                    .ToListAsync();

                return payment;
            }
        }
    }
}
