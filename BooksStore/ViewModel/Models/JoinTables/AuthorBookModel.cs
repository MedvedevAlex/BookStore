using System;
using ViewModel.Models.Authors;
using ViewModel.Models.Books;

namespace ViewModel.Models.JoinTables
{
    /// <summary>
    /// Связующая таблица книги и автора
    /// </summary>
    public class AuthorBookModel
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
        /// Идентификатор автора
        /// </summary>
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Автор
        /// </summary>
        public AuthorModel Author { get; set; }
    }
}
