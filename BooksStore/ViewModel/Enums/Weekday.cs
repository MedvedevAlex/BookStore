using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Дни недели
    /// </summary>
    public enum Weekday
    {
        [Description("Понедельник")]
        Monday = 1,
        [Description("Вторник")]
        Tuesday = 2,
        [Description("Среда")]
        Wednesday = 3,
        [Description("Четверг")]
        Thursday = 4,
        [Description("Пятница")]
        Friday = 5,
        [Description("Суббота")]
        Saturday = 6,
        [Description("Воскресенье")]
        Sunday = 7
    }
}
