using ViewModel.Models.Orders;

namespace ViewModel.Responses.Orders
{
    /// <summary>
    /// Ответ заказ
    /// </summary>
    public class OrderResponse : BaseResponse
    {
        /// <summary>
        /// Модель заказ
        /// </summary>
        public OrderModel Order { get; set; }
    }
}
