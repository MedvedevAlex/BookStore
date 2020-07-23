using System;
using System.Collections.Generic;
using ViewModel.Models.References;

namespace ViewModel.Models
{
    /// <summary>
    /// Модель Магазин
    /// </summary>
    public class ShopModel
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
        public ICollection<WorkSheduleModel> WorkShedule { get; set; }
    }
}