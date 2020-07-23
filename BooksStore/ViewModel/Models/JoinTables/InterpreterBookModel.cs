﻿using System;
using ViewModel.Models.Book;

namespace ViewModel.Models.JoinTables
{
    /// <summary>
    /// Связующая таблица книги и переводчика
    /// </summary>
    public class InterpreterBookModel
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public Guid BookId { get; set; }
        /// <summary>
        /// Книга
        /// </summary>
        public BookModel Book { get; set; }
        /// <summary>
        /// Идентификатор переводчика
        /// </summary>
        public Guid InterpreterId { get; set; }
        /// <summary>
        /// Переводчик
        /// </summary>
        public InterpreterModel Interpreter { get; set; }
    }
}
