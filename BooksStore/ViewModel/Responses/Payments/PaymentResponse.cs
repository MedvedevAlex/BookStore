using ViewModel.Models.Publishers;

namespace ViewModel.Responses.Payments
{
    /// <summary>
    /// Ответ платеж
    /// </summary>
    public class PaymentResponse : BaseResponse
    {
        /// <summary>
        /// Модель оплата
        /// </summary>
        public PaymentModel Payment { get; set; }
    }
}
