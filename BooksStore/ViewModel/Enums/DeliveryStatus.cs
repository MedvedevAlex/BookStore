using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Статус доставки
    /// </summary>
    public enum DeliveryStatus
    {
        [Description("Ошибка")]
        Error = 0,
        [Description("Ожидание прибытия заказа на склад")]
        Waiting = 1,
        [Description("Доставка")]
        Delivery = 2,
        [Description("Выполнен")]
        Completed = 3,
    }
}
