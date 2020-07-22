using System;

namespace Model.Entities
{
    /// <summary>
    /// Модель Стиль художника
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