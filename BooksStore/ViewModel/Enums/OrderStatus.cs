using System.ComponentModel;

namespace ViewModel.Enums
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum OrderStatus
    {
        [Description("Ошибка")]
        Error = 0,
        [Description("Не обработан")]
        NotProcessed = 1,
        [Description("В работе")]
        InWork = 2,
        [Description("Полностью выполнен")]
        FullyСompleted = 3,
        [Description("Частично выполнен")]
        PartiallyCompleted = 4,
        [Description("Отказ по вине покупателя")]
        FailureCustomer= 5,
        [Description("Отказ по вине компании")]
        FailureCompany= 6,
    }
}
