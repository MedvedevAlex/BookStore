using System;
using System.Collections.Generic;
using ViewModel.Models.JoinTables;

namespace ViewModel.Models
{
    /// <summary>
    /// Сущность Переводчик
    /// </summary>
    public class InterpreterModel
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
        public virtual ICollection<InterpreterBookModel> InterpeterBooks { get; set; }
    }
}