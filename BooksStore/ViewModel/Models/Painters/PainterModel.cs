using System;
using System.Collections.Generic;
using ViewModel.Models.JoinTables;
using ViewModel.Models.References;

namespace ViewModel.Models.Painters
{
    /// <summary>
    /// Модель художник
    /// </summary>
    public class PainterModel
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
        /// Возраст
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Стиль
        /// </summary>
        public PainterStyleModel Style { get; set; }
        /// Коллекция книг
        /// </summary>
        public ICollection<PainterBookModel> PainterBooks { get; set; }
    }
}