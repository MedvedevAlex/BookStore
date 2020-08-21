using System;
using ViewModel.Enums;

namespace ViewModel.Models.Orders
{
    /// <summary>
    /// Модель для обновления статуса заказа
    /// </summary>
    public class OrderUpdateModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public OrderStatus Status { get; set; }
    }
}