using Model.Entities;
using System.Collections.Generic;

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
        public int Id { get; set; }
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
