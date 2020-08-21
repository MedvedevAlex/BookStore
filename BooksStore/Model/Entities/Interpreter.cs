using Model.Entities.JoinTables;
using System;
using System.Collections.Generic;

namespace Model.Entities
{
    /// <summary>
    /// Сущность переводчик
    /// </summary>
    public class Interpreter
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
        public virtual ICollection<InterpreterBook> InterpreterBooks { get; set; }
    }
}