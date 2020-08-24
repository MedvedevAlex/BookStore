using System;
using ViewModel.Enums;

namespace ViewModel.Models.Payments
{
    /// <summary>
    /// Модель создания платежа
    /// </summary>
    public class PaymentCreateModel
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public Guid OrderId { get; set; }
        /// <summary>
        /// Дата платежа
        /// </summary>
        public DateTime? DatePayment { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public PaymentStatus Status { get; set; }
    }
}