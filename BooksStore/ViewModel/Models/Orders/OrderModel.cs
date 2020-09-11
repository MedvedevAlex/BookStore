using System;
using System.Collections.Generic;
using ViewModel.Enums;
using ViewModel.Models.Books;

namespace ViewModel.Models.Orders
{
    /// <summary>
    /// Модель заказ
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Коллекция книг
        /// </summary>
        public ICollection<BookPreviewModel> Books { get; set; }
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