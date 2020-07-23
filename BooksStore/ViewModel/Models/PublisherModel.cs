using System;
using System.Collections.Generic;

namespace ViewModel.Models
{
    /// <summary>
    /// Модель Издатель
    /// </summary>
    public class PublisherModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Выпущенные книги
        /// </summary>
        public ICollection<BookModel> Books { get; set; }
    }
}