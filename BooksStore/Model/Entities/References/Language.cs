using System;

namespace Model.Entities.References
{
    /// <summary>
    /// Сущность(cправочник) Язык
    /// </summary>
    public class Language
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