using System;

namespace Model.Entities.References
{
    /// <summary>
    /// Сущность(cправочник) Тип переплета
    /// </summary>
    public class CoverType
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