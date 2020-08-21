﻿using ViewModel.Interfaces.Handlers;
using System.Threading.Tasks;
using System;
using ViewModel.Responses.Payments;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Payments;

namespace Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentHandler _paymentHandler;

        public PaymentService(IPaymentHandler paymentHandler)
        {
            _paymentHandler = paymentHandler;
        }

        public async Task<PaymentResponse> AddAsync(PaymentCreateModel payment)
        {
            try
            {
                return new PaymentResponse()
                {
                    Payment = await _paymentHandler.AddAsync(payment)
                };
            }
            catch (Exception e)
            {
                return new PaymentResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<PaymentResponse> GetAsync(Guid id)
        {
            try
            {
                return new PaymentResponse()
                {
                    Payment = await _paymentHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new PaymentResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}