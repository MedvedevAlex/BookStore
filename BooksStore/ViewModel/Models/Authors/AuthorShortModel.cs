using System;

namespace ViewModel.Models.Authors
{
    /// <summary>
    /// Модель Автор
    /// </summary>
    public class AuthorShortModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя автора
        /// </summary>
        public string Name { get; set; }
    }
}