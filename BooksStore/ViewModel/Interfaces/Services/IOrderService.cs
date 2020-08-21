using System;
using System.Threading.Tasks;
using ViewModel.Models.Orders;
using ViewModel.Responses.Orders;

namespace ViewModel.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderResponse> AddAsync(OrderModifyModel order);
        Task<OrderResponse> UpdateStatusAsync(OrderUpdateModel order);
        Task<OrderResponse> GetAsync(Guid id);
    }
}