﻿using System;
using System.Collections.Generic;
using ViewModel.Models.Authors;
using ViewModel.Models.Interpreters;
using ViewModel.Models.Painters;
using ViewModel.Models.Publishers;

namespace ViewModel.Models.Books
{
    /// <summary>
    /// Модель книга
    /// </summary>
    public class BookViewModel
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
        /// Назваименование переплета
        /// </summary>
        public string CoverType { get; set; }
        /// <summary>
        /// Жанр
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// Язык
        /// </summary>
        public string Language { get; set; }
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
        /// Издатель
        /// </summary>
        public PublisherShortModel Publisher { get; set; }
        /// <summary>
        /// Авторы
        /// </summary>
        public ICollection<AuthorShortModel> Authors { get; set; }
        /// <summary>
        /// Художники
        /// </summary>
        public ICollection<PainterShortModel> Painters { get; set; }
        /// <summary>
        /// Переводчики
        /// </summary>
        public ICollection<InterpreterShortModel> Interpreters { get; set; }
    }
}
