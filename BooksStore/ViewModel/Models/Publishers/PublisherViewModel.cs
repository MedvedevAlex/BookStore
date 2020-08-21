using System;
using System.Collections.Generic;
using ViewModel.Models.Books;

namespace ViewModel.Models.Publishers
{
    /// <summary>
    /// Модель издатель
    /// </summary>
    public class PublisherViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Коллекция книг
        /// </summary>
        public ICollection<BookPreviewModel> Books { get; set; }
    }
}