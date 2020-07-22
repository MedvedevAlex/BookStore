﻿using System;
using System.Collections.Generic;

namespace Model.Models
{
    /// <summary>
    /// Сущность Автор
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя автора
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст автора
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Краткая биография автора
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Колекция книг
        /// </summary>
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}