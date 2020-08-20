using System;
using System.Threading.Tasks;
using ViewModel.Models.Orders;

namespace ViewModel.Interfaces.Handlers
{
    public interface IOrderHandler
    {
        Task<OrderModel> ConfirmAsync(OrderModifyModel order);
        Task<OrderModel> GetAsync(Guid id);
    }
}