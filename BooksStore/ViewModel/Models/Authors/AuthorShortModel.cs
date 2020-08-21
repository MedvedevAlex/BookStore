using System;

namespace ViewModel.Models.Authors
{
    /// <summary>
    /// Модель автор
    /// </summary>
    public class AuthorShortModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
}