using System;
using System.Collections.Generic;
using ViewModel.Models.Books;

namespace ViewModel.Models.Interpreters
{
    /// <summary>
    /// Модель Переводчик
    /// </summary>
    public class InterpreterViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя переводчика
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
        /// Коллекция книг
        /// </summary>
        public ICollection<BookPreviewModel> Books { get; set; }
    }
}