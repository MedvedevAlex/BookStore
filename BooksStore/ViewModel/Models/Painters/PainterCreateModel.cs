using System;
using System.Collections.Generic;

namespace ViewModel.Models.Painters
{
    /// <summary>
    /// Модель для создания или обновления художника
    /// </summary>
    public class PainterCreateModel
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
        /// <summary>
        /// Идентификатор стиля
        /// </summary>
        public Guid StyleId { get; set; }
        /// Коллекция книг
        /// </summary>
        public ICollection<Guid> Books { get; set; }
    }
}