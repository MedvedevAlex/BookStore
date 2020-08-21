using System;
using System.Collections.Generic;
using ViewModel.Models.Books;

namespace ViewModel.Models.Publishers
{
    /// <summary>
    /// Модель издатель
    /// </summary>
    public class PublisherModel
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
        public ICollection<BookModel> Books { get; set; }
    }
}