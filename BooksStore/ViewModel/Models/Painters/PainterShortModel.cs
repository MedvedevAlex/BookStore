using System;

namespace ViewModel.Models.Painters
{
    /// <summary>
    /// Модель Художник
    /// </summary>
    public class PainterShortModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя художника
        /// </summary>
        public string Name { get; set; }
    }
}
