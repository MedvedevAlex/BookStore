using System;
using System.Threading.Tasks;
using ViewModel.Models.Deliveries;
using ViewModel.Responses.Deliveries;

namespace ViewModel.Interfaces.Services
{
    public interface IDeliveryService
    {
        Task<DeliveryResponse> AddAsync(DeliveryModifyModel delivery);
        Task<DeliveryResponse> UpdateAsync(DeliveryModifyModel delivery);
        Task<DeliveryResponse> GetAsync(Guid id);
    }
}