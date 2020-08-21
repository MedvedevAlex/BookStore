using System;
using System.Threading.Tasks;
using ViewModel.Models.Publishers;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPaymentHandler
    {
        Task<PaymentModel> GetAsync(Guid id);
    }
}