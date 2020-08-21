using System;
using System.ComponentModel.DataAnnotations.Schema;
using ViewModel.Enums;

namespace Model.Entities
{
    /// <summary>
    /// Сущность доставка
    /// </summary>
    [Table("Deliveries")]
    public class Delivery
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Сущность магазин
        /// </summary>
        public Shop Shop { get; set; }
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public Guid OrderId { get; set; }
        /// <summary>
        /// Сущность заказ
        /// </summary>
        public Order Order { get; set; }
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