using System;

namespace Model.Entities
{
    /// <summary>
    /// Сущность Товары Заказ
    /// </summary>
    public class GoodsOrder
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public Book Book { get; set; }
        /// <summary>
        /// Стоимость книги на момент создания заказа
        /// </summary>
        public decimal Amount { get; set; }
    }
}