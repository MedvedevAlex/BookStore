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
        /// Колекция идентификаторов книг
        /// </summary>
        public ICollection<Guid> BooksIds { get; set; }
    }
}