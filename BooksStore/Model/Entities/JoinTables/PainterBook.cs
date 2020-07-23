using System;

namespace Model.Entities.JoinTables
{
    /// <summary>
    /// Связующая таблица книги и художника
    /// </summary>
    public class PainterBook
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
        /// Идентификатор художника
        /// </summary>
        public Guid PainterId { get; set; }
        /// <summary>
        /// Сущность Художник
        /// </summary>
        public Painter Painter { get; set; }
    }
}
