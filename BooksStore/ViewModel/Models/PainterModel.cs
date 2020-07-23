using System;
using System.Collections.Generic;
using ViewModel.Models.JoinTables;
using ViewModel.Models.References;

namespace ViewModel.Models
{
    /// <summary>
    /// Модель Художник
    /// </summary>
    public class PainterModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя художника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>/// <summary>
        /// Идентификатор художественного стиля
        /// </summary>
        public PainterStyleModel Style { get; set; }
        /// Коллекция книг
        /// </summary>
        public ICollection<PainterBookModel> PainterBooks { get; set; }
    }
}
