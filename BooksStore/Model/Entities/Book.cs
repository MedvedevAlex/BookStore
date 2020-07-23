using Model.Entities.JoinTables;
using Model.Entities.References;
using System;
using System.Collections.Generic;

namespace Model.Entities
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
        /// Cущность Тип переплета
        /// </summary>
        public CoverType CoverType { get; set; }
        /// <summary>
        /// Сущность Жанр
        /// </summary>
        public Genre Genre { get; set; }
        /// <summary>
        /// Сущность Язык
        /// </summary>
        public Language Language { get; set; }
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
        public Publisher Publisher { get; set; }
        /// <summary>
        /// Коллекция авторов
        /// </summary>
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        /// <summary>
        /// Коллекция художников
        /// </summary>
        public virtual ICollection<PainterBook> PainterBooks { get; set; }
        /// <summary>
        /// Коллекция переводчиков
        /// </summary>
        public virtual ICollection<InterpreterBook> InterpreterBooks { get; set; }
    }
}
