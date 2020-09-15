using System;
using ViewModel.Enums;

namespace ViewModel.Models.Deliveries
{
    /// <summary>
    /// Модель обновления доставки
    /// </summary>
    public class DeliveryModifyModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идетнификатор магазина
        /// </summary>
        public Guid ShopId { get; set; }
        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTime DateDelivery { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public DeliveryStatus Status { get; set; }
    }
}