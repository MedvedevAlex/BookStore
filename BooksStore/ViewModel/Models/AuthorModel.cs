﻿using System;
using System.Collections.Generic;

namespace ViewModel.Models
{
    /// <summary>
    /// Модель Автор
    /// </summary>
    public class AuthorModel
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
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Колекция книг
        /// </summary>
        public ICollection<AuthorBookModel> AuthorBooks { get; set; }
    }
}