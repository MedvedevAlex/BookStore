﻿using System;
using System.Collections.Generic;
using ViewModel.Models.JoinTables;

namespace ViewModel.Models.Interpreters
{
    /// <summary>
    /// Модель переводчик
    /// </summary>
    public class InterpreterModel
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
        public virtual ICollection<InterpreterBookModel> InterpreterBooks { get; set; }
    }
}