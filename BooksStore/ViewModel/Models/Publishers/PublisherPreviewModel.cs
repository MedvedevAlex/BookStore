using System;

namespace ViewModel.Models.Publishers
{
    /// <summary>
    /// Модель издатель
    /// </summary>
    public class PublisherPreviewModel
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