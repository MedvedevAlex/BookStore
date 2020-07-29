using System;
using ViewModel.Enums;

namespace Model.Entities
{
    /// <summary>
    /// Сущность Картинка
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор книги
        /// </summary>
        public Guid BookId { get; set; }
        /// <summary>
        /// Идентификатор картинки на гугл диске
        /// </summary>
        public string GoogleFileId { get; set; }
        /// <summary>
        /// Название картинки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Тип картинки
        /// </summary>
        public ImageType ImageType { get; set; }
        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string Link { get; set; }
    }
}
