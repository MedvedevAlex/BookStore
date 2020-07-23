using System;
using ViewModel.Models.Book;

namespace ViewModel.Models.JoinTables
{
    /// <summary>
    /// Связующая таблица книги и художника
    /// </summary>
    public class PainterBookModel
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
        /// Идентификатор художника
        /// </summary>
        public Guid PainterId { get; set; }
        /// <summary>
        /// Художник
        /// </summary>
        public PainterModel Painter { get; set; }
    }
}
