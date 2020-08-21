using ViewModel.Models.Deliveries;

namespace ViewModel.Responses.Deliveries
{
    /// <summary>
    /// Ответ доставка
    /// </summary>
    public class DeliveryResponse : BaseResponse
    {
        /// <summary>
        /// Модель доставка
        /// </summary>
        public DeliveryModel Delivery { get; set; }
    }
}
