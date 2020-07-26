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
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Выпущенные книги
        /// </summary>
        public ICollection<Guid> BooksIds { get; set; }
    }
}