using System;
using System.Threading.Tasks;
using ViewModel.Responses.Payments;

namespace ViewModel.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponse> GetAsync(Guid id);
    }
}