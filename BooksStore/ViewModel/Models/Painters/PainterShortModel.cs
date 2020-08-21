using System;

namespace ViewModel.Models.Painters
{
    /// <summary>
    /// Модель художник
    /// </summary>
    public class PainterShortModel
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
