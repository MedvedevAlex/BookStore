using System;
using ViewModel.Enums;

namespace ViewModel.Models.References
{
    /// <summary>
    /// Модель График работы магазина
    /// </summary>
    public class WorkSheduleModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Магазин
        /// </summary>
        public ShopModel Shop { get; set; }
        /// <summary>
        /// Начало работы
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// Окончание работы
        /// </summary>
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// День недели
        /// </summary>
        public Weekday Weekday { get; set; }
    }
}