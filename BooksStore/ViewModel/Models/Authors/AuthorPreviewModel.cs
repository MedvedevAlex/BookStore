using System;

namespace ViewModel.Models.Authors
{
    /// <summary>
    /// Модель книга
    /// </summary>
    public class AuthorPreviewModel
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