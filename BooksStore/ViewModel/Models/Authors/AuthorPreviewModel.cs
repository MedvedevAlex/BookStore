using System;

namespace ViewModel.Models.Authors
{
    /// <summary>
    /// Модель Автор
    /// </summary>
    public class AuthorPreviewModel
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