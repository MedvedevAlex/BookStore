using System;

namespace Model.Entities
{
    /// <summary>
    /// Сущность товары к заказу
    /// </summary>
    public class GoodsOrder
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Сущность заказ
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// Сущность книга
        /// </summary>
        public Book Book { get; set; }
        /// <summary>
        /// Стоимость книги на момент создания заказа
        /// </summary>
        public decimal Amount { get; set; }
    }
}