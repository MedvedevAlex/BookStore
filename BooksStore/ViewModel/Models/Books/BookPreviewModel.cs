using System;
using System.Collections.Generic;
using ViewModel.Models.Authors;

namespace ViewModel.Models.Books
{
    /// <summary>
    /// Книга
    /// </summary>
    public class BookPreviewModel
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
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Авторы
        /// </summary>
        public ICollection<AuthorShortModel> Authors { get; set; }
    }
}
