using System;
using System.Threading.Tasks;
using ViewModel.Models.Orders;

namespace ViewModel.Interfaces.Handlers
{
    public interface IOrderHandler
    {
        Task<Guid> ConfirmAsync(OrderModel order);
    }
}