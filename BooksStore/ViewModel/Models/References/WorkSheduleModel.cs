using System;
using ViewModel.Enums;

namespace ViewModel.Models.References
{
    /// <summary>
    /// Модель график работы магазина
    /// </summary>
    public class WorkSheduleModel
    {
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