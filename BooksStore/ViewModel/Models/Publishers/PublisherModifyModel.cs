using System;
using System.Collections.Generic;

namespace ViewModel.Models.Publishers
{
    /// <summary>
    /// Модель для создания и обновления издателя
    /// </summary>
    public class PublisherModifyModel
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
        /// Коллекция идентификаторов книг
        /// </summary>
        public ICollection<Guid> BooksIds { get; set; }
    }
}