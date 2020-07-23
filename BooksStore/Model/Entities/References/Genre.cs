﻿using System;

namespace Model.Entities.References
{
    /// <summary>
    /// Сущность(cправочник) Жанр
    /// </summary>
    public class Genre
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