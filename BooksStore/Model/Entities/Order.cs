using System;
using ViewModel.Enums;

namespace Model.Entities
{
    /// <summary>
    /// Сущность заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Сущность пользователь(покупатель)
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Сущность платеж
        /// </summary>
        public Payment Payment { get; set; }
        /// <summary>
        /// Сущность доставка
        /// </summary>
        public Delivery Delivery { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreate { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        public string Description { get; set; }
    }
}