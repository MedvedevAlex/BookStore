using System;

namespace ViewModel.Models.Publishers
{
    /// <summary>
    /// Модель Издатель
    /// </summary>
    public class PublisherShortModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}