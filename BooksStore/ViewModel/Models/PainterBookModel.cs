namespace ViewModel.Models
{
    /// <summary>
    /// Связующая таблица книги и художника
    /// </summary>
    public class PainterBookModel
    {
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Книга
        /// </summary>
        public BookModel Book { get; set; }
        /// <summary>
        /// Идентификатор художника
        /// </summary>
        public int PainterId { get; set; }
        /// <summary>
        /// Художник
        /// </summary>
        public PainterModel Painter { get; set; }
    }
}
