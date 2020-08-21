using System;
using System.Collections.Generic;

namespace ViewModel.Models.Authors
{
    /// <summary>
    /// Модель для создания или обновления автора
    /// </summary>
    public class AuthorModifyModel
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
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Колекция книг
        /// </summary>
        public ICollection<Guid> BooksIds { get; set; }
    }
}