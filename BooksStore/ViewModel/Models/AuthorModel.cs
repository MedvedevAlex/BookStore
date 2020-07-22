using System;
using System.Collections.Generic;

namespace ViewModel.Models
{
    /// <summary>
    /// Модель Автор
    /// </summary>
    public class AuthorModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя автора
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст автора
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Краткая биография автора
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Колекция книг
        /// </summary>
        public virtual ICollection<AuthorBookModel> AuthorBooks { get; set; }
    }
}