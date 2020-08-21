using System;
using System.Threading.Tasks;
using ViewModel.Models.Payments;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPaymentHandler
    {
        Task<PaymentModel> AddAsync(PaymentCreateModel payment);
        Task<PaymentModel> GetAsync(Guid id);
    }
}