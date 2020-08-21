using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Publishers;

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
        /// Получить платеж
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель платеж</returns>
        public async Task<PaymentModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var paymentEntity = await context.Payments
                    .Include(p => p.Order)
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (paymentEntity == null) throw new KeyNotFoundException("Ошибка: Не удалось найти платеж");

                return _mapper.Map<PaymentModel>(paymentEntity);
            }
        }
    }
}
