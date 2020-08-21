using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Статус оплаты
    /// </summary>
    public enum PaymentStatus
    {
        [Description("Ошибка")]
        Error = 0,
        [Description("Ожидание оплаты")]
        PaymentWait = 1,
        [Description("Оплачено")]
        Paid = 2,
    }
}
