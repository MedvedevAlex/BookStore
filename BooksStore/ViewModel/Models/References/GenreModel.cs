using System;

namespace ViewModel.Models.References
{
    /// <summary>
    /// Модель Жанр
    /// </summary>
    public class GenreModel
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