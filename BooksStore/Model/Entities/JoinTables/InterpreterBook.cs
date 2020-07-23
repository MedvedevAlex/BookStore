using System;

namespace Model.Entities.JoinTables
{
    /// <summary>
    /// Связующая таблица книги и переводчика
    /// </summary>
    public class InterpreterBook
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public Guid BookId { get; set; }
        /// <summary>
        /// Сущность Книга
        /// </summary>
        public Book Book { get; set; }
        /// <summary>
        /// Идентификатор переводчика
        /// </summary>
        public Guid IntepreterId { get; set; }
        /// <summary>
        /// Сущность Переводчик
        /// </summary>
        public Interpreter Interpreter { get; set; }
    }
}
