using System;
using System.Collections.Generic;

namespace ViewModel.Models.Books
{
    /// <summary>
    /// Модель для создания или обновления книги
    /// </summary>
    public class BookCreateModel
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
        /// Дата публикации
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// Идентификатор типа переплета
        /// </summary>
        public Guid CoverTypeId { get; set; }
        /// <summary>
        /// Идентификатор жанра
        /// </summary>
        public Guid GenreId { get; set; }
        /// <summary>
        /// Идентификатор языка
        /// </summary>
        public Guid LanguageId { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Уникальный 13-ти значный номер
        /// </summary>
        public string ISBN_13 { get; set; }
        /// <summary>
        /// Формат
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public short CountPage { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public short Weight { get; set; }
        /// <summary>
        /// Тираж
        /// </summary>
        public int Duplicate { get; set; }
        /// <summary>
        /// Возрастное ограничение
        /// </summary>
        public byte AgeLimit { get; set; }
        /// <summary>
        /// Идентификатор издателя
        /// </summary>
        public Guid PublisherId { get; set; }
        /// <summary>
        /// Идентификаторы авторов
        /// </summary>
        public ICollection<Guid> AuthorsIds { get; set; }
        /// <summary>
        /// Идентификаторы художников
        /// </summary>
        public ICollection<Guid> PaintersIds { get; set; }
        /// <summary>
        /// Идентификаторы переводчиков
        /// </summary>
        public ICollection<Guid> InterpretersIds { get; set; }
    }
}
