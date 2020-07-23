using System;
using System.Collections.Generic;
using ViewModel.Models.JoinTables;
using ViewModel.Models.References;

namespace ViewModel.Models
{
    /// <summary>
    /// Книга
    /// </summary>
    public class BookModel
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
        /// Жанр
        /// </summary>
        public GenreModel Genre { get; set; }
        /// <summary>
        /// Язык
        /// </summary>
        public LanguageModel Language { get; set; }
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
        /// <summary>
        /// Издатель
        /// </summary>
        public PublisherModel Publisher { get; set; }
        /// <summary>
        /// Авторы
        /// </summary>
        public ICollection<AuthorBookModel> AuthorBooks { get; set; }
        /// <summary>
        /// Художники
        /// </summary>
        public ICollection<PainterBookModel> PainterBooks { get; set; }
    }
}
