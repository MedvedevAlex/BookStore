using System;

namespace Model.Entities
{
    /// <summary>
    /// Сущность Стиль художника
    /// </summary>
    public class PainterStyle
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