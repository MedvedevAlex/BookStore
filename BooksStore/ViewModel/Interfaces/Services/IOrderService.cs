using System;
using System.Threading.Tasks;
using ViewModel.Models.Orders;
using ViewModel.Models.Responses.Orders;

namespace ViewModel.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderResponse> ConfirmAsync(OrderModifyModel order);
        Task<OrderResponse> GetAsync(Guid id);
    }
}