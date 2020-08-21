using System;

namespace Model.Entities.References
{
    /// <summary>
    /// Сущность(cправочник) стиль художника
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