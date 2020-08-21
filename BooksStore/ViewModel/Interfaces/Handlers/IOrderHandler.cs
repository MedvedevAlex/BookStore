using System;
using System.Threading.Tasks;
using ViewModel.Models.Orders;

namespace ViewModel.Interfaces.Handlers
{
    public interface IOrderHandler
    {
        Task<OrderModel> AddAsync(OrderModifyModel order);
        Task<OrderModel> UpdateStatusAsync(OrderUpdateModel order);
        Task<OrderModel> GetAsync(Guid id);
    }
}