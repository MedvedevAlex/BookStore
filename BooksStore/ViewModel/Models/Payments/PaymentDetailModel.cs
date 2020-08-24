using System;
using ViewModel.Enums;
using ViewModel.Models.Orders;

namespace ViewModel.Models.Payments
{
    /// <summary>
    /// Модель платеж c информацией о заказе
    /// </summary>
    public class PaymentDetailModel
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