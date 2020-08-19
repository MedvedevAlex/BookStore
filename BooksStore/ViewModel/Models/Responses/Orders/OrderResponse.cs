using System;

namespace ViewModel.Models.Responses.Orders
{
    /// <summary>
    /// Ответ заказ
    /// </summary>
    public class OrderResponse : BaseResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
