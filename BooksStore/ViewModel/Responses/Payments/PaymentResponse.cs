using ViewModel.Models.Payments;

namespace ViewModel.Responses.Payments
{
    /// <summary>
    /// Ответ платеж
    /// </summary>
    public class PaymentResponse : BaseResponse
    {
        /// <summary>
        /// Модель платеж
        /// </summary>
        public PaymentModel Payment { get; set; }
    }
}
