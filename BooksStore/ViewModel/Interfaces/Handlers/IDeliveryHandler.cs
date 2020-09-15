using System;
using System.Threading.Tasks;
using ViewModel.Models.Deliveries;

namespace ViewModel.Interfaces.Handlers
{
    public interface IDeliveryHandler
    {
        Task<DeliveryModel> AddAsync(DeliveryCreatedModel delivery);
        Task<DeliveryModel> UpdateAsync(DeliveryModifyModel delivery);
        Task<DeliveryModel> GetAsync(Guid id);
    }
}