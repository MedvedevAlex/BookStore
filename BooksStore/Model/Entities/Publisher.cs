using System;
using System.Collections.Generic;

namespace Model.Entities
{
    /// <summary>
    /// Сущность издатель
    /// </summary>
    public class Publisher
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Коллекция книг
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}