using System;
using System.Threading.Tasks;
using ViewModel.Models.Deliveries;

namespace ViewModel.Interfaces.Handlers
{
    public interface IDeliveryHandler
    {
        Task<DeliveryModel> AddAsync(DeliveryModifyModel delivery);
        Task<DeliveryModel> GetAsync(Guid id);
    }
}