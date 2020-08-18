using System;
using ViewModel.Enums;

namespace Model.Entities
{
    /// <summary>
    /// Сущность Оплата
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public Guid OrderId { get; set; }
        /// <summary>
        /// Заказ
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreate { get; set; }
        /// <summary>
        /// Дата оплаты
        /// </summary>
        public DateTime DatePayment { get; set; }
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