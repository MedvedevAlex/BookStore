using System;
using System.Collections.Generic;
using ViewModel.Enums;

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
        public int BookId { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата опубликования
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// Переплет
        /// </summary>
        public Cover Cover { get; set; }
        /// <summary>
        /// Жанр
        /// </summary>
        public Genre Genre { get; set; }
        /// <summary>
        /// Язык
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
        /// Размер
        /// </summary>
        public string Dimensions { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int NumbersPages { get; set; } // countpage
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Количество на складе
        /// </summary>
        public int QuantityStock { get; set; } // countstorage
        /// <summary>
        /// Количество выпущеных
        /// </summary>
        public int Edition { get; set; }
        /// <summary>
        /// Возрастное ограничение
        /// </summary>
        public byte AgeLimit { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// Количество купивших
        /// </summary>
        public int CountCustomers { get; set; }
        /// <summary>
        /// Средняя оценка
        /// </summary>
        public decimal AvgReview { get; set; }//ignore
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
