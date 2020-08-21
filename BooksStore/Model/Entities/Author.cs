using Model.Entities.JoinTables;
using System;
using System.Collections.Generic;

namespace Model.Entities
{
    /// <summary>
    /// Сущность автор
    /// </summary>
    public class Author
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
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Колекция книг
        /// </summary>
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}