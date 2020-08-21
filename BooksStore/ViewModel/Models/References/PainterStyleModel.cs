using System;

namespace ViewModel.Models.References
{
    /// <summary>
    /// Модель стиль художника
    /// </summary>
    public class PainterStyleModel
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