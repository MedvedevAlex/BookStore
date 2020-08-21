using ViewModel.Interfaces.Handlers;
using System.Threading.Tasks;
using System;
using ViewModel.Models.Responses.Deliveries;
using ViewModel.Models.Deliveries;
using ViewModel.Interfaces.Services;

namespace Service.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryHandler _deliveryHandler;

        public DeliveryService(IDeliveryHandler deliveryHandler)
        {
            _deliveryHandler = deliveryHandler;
        }

        public async Task<DeliveryResponse> AddAsync(DeliveryModifyModel delivery)
        {
            try
            {
                return new DeliveryResponse()
                {
                    Delivery = await _deliveryHandler.AddAsync(delivery)
                };
            }
            catch (Exception e)
            {
                return new DeliveryResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<DeliveryResponse> GetAsync(Guid id)
        {
            try
            {
                return new DeliveryResponse()
                {
                    Delivery = await _deliveryHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new DeliveryResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
