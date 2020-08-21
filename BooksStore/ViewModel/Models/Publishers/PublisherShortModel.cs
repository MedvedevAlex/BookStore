using System;

namespace ViewModel.Models.Publishers
{
    /// <summary>
    /// Модель издатель
    /// </summary>
    public class PublisherShortModel
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