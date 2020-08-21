using System;
using ViewModel.Enums;
using ViewModel.Models.Orders;

namespace ViewModel.Models.Publishers
{
    /// <summary>
    /// Модель платеж
    /// </summary>
    public class PaymentModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Сущность заказ
        /// </summary>
        public OrderModel Order { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreate { get; set; }
        /// <summary>
        /// Дата оплаты
        /// </summary>
        public DateTime? DatePayment { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public PaymentStatus Status { get; set; }
        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Amount { get; set; }
    }
}