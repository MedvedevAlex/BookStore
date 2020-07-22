using System;
using System.Collections.Generic;

namespace Model.Models
{
    /// <summary>
    /// Сущность книга
    /// </summary>
    public class Book
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
        public Guid TypeCoverId { get; set; }
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
        /// Уникальный 10-ти значный номер
        /// </summary>
        public string ISBN_10 { get; set; }
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
        public int CountPage { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// Тираж
        /// </summary>
        public int Duplicate { get; set; }
        /// <summary>
        /// Возрастное ограничение
        /// </summary>
        public byte AgeLimit { get; set; }

        public Publisher Publisher { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }

        public virtual ICollection<PainterBook> PainterBooks { get; set; }
    }
}
