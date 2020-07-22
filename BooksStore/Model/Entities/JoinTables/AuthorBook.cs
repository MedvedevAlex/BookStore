using System;

namespace Model.Entities.JoinTables
{
    /// <summary>
    /// Связующая таблица книги и автора
    /// </summary>
    public class AuthorBook
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
        /// Идентификатор автора
        /// </summary>
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Сущность Автор
        /// </summary>
        public Author Author { get; set; }
    }
}
