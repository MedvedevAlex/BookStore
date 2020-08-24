using System;
using System.Threading.Tasks;
using ViewModel.Models.Payments;
using ViewModel.Responses.Payments;

namespace ViewModel.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponse> AddAsync(PaymentCreateModel payment);
        Task<PaymentResponse> UpdateStatusAsync(PaymentUpdateModel payment);
        Task<PaymentResponse> GetAsync(Guid id);
        Task<PaymentDetailResponse> GetWithOrderAsync(Guid id);
    }
}