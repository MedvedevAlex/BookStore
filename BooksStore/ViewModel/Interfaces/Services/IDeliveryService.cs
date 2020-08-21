using System;
using System.Threading.Tasks;
using ViewModel.Models.Deliveries;
using ViewModel.Models.Responses.Deliveries;

namespace ViewModel.Interfaces.Services
{
    public interface IDeliveryService
    {
        Task<DeliveryResponse> AddAsync(DeliveryModifyModel delivery);
        Task<DeliveryResponse> GetAsync(Guid id);
    }
}