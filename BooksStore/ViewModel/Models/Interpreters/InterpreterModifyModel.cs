using System;
using System.Collections.Generic;

namespace ViewModel.Models.Interpreters
{
    /// <summary>
    /// Модель переводчик
    /// </summary>
    public class InterpreterModifyModel
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
        /// Коллекция книг
        /// </summary>
        public ICollection<Guid> BooksIds { get; set; }
    }
}