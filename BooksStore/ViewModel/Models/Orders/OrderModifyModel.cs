using System;
using System.Collections.Generic;

namespace ViewModel.Models.Orders
{
    /// <summary>
    /// Модель для создания или обновления заказа
    /// </summary>
    public class OrderModifyModel
    {
        /// <summary>
        /// Колекция книг
        /// </summary>
        public ICollection<Guid> Books { get; set; }
        /// <summary>
        /// Идентификатор магазина для доставки
        /// </summary>
        public Guid ShopId { get; set; }
    }
}