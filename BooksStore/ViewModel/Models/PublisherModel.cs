using System.Collections.Generic;

namespace ViewModel.Models
{
    /// <summary>
    /// Издатель
    /// </summary>
    public class PublisherModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int PublisherId { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Короткое название
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Корпорация
        /// </summary>
        public string Corporation { get; set; }
        /// <summary>
        /// Выпущенные книги
        /// </summary>
        public ICollection<BookModel> Books { get; set; }
    }
}