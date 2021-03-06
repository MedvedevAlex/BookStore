﻿using ViewModel.Models.Payments;

namespace ViewModel.Responses.Payments
{
    /// <summary>
    /// Ответ платеж c информацией о заказе
    /// </summary>
    public class PaymentDetailResponse : BaseResponse
    {
        /// <summary>
        /// Модель платеж с информацией о заказе
        /// </summary>
        public PaymentDetailModel Payment { get; set; }
    }
}
