using System;
using ViewModel.Enums;

namespace Model.Entities
{
    /// <summary>
    /// Сущность Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор покупателя
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public Book Book { get; set; }
        /// <summary>
        /// Оплата
        /// </summary>
        public Payment Payment { get; set; }
        /// <summary>
        /// Доставка
        /// </summary>
        public Delivery Delivery { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Amount { get; set; }
    }
}