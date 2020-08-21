using System;
using ViewModel.Enums;
using ViewModel.Models.Shops;

namespace ViewModel.Models.Deliveries
{
    /// <summary>
    /// Модель доставка
    /// </summary>
    public class DeliveryModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Магазин
        /// </summary>
        public ShopModel Shop { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreate { get; set; }
        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTime? DateDelivery { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public DeliveryStatus Status { get; set; }
    }
}