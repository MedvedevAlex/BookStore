using System;
using System.Collections.Generic;
using ViewModel.Models.Books;

namespace ViewModel.Models.Painters
{
    /// <summary>
    /// Модель Художник
    /// </summary>
    public class PainterViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя художника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Наименование стиля
        /// </summary>
        public string Style { get; set; }
        /// Коллекция книг
        /// </summary>
        public ICollection<BookPreviewModel> Books { get; set; }
    }
}