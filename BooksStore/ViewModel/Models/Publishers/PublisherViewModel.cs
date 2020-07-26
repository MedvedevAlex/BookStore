using System;
using System.Collections.Generic;
using ViewModel.Models.Books;

namespace ViewModel.Models.Publishers
{
    /// <summary>
    /// Модель Издатель
    /// </summary>
    public class PublisherViewModel
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
        public ICollection<BookPreviewModel> Books { get; set; }
    }
}