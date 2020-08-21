using Model.Entities.JoinTables;
using Model.Entities.References;
using System;
using System.Collections.Generic;

namespace Model.Entities
{
    /// <summary>
    /// Сущность художник
    /// </summary>
    public class Painter
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// НАименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Сущность художественный стиль
        /// </summary>
        public PainterStyle Style { get; set; }
        /// <summary>
        /// Коллекция книг
        /// </summary>
        public virtual ICollection<PainterBook> PainterBooks { get; set; }
    }
}