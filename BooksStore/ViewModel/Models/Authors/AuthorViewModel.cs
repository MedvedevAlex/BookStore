﻿using System;
using System.Collections.Generic;
using ViewModel.Models.Books;

namespace ViewModel.Models.Authors
{
    /// <summary>
    /// Модель автор
    /// </summary>
    public class AuthorViewModel
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
        public ICollection<BookPreviewModel> Books { get; set; }
    }
}