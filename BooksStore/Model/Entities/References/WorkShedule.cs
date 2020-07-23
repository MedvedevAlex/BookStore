using System;
using ViewModel.Enums;

namespace Model.Entities.References
{
    /// <summary>
    /// Сущность График работы магазина
    /// </summary>
    public class WorkShedule
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Магазин
        /// </summary>
        public Shop Shop { get; set; }
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