using Model.Entities.References;
using System;
using System.Collections.Generic;

namespace Model.Entities
{
    /// <summary>
    /// Сущность магазин
    /// </summary>
    public class Shop
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
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// График работы на неделю
        /// </summary>
        public virtual ICollection<WorkShedule> WorkShedule { get; set; }
    }
}