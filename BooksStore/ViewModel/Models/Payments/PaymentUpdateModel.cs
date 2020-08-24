using System;
using ViewModel.Enums;

namespace ViewModel.Models.Payments
{
    /// <summary>
    /// Модель обновления платежа
    /// </summary>
    public class PaymentUpdateModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
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