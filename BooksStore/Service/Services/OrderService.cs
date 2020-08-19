using AutoMapper;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Orders;
using ViewModel.Models.Responses.Orders;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderHandler _orderHandler;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderHandler orderHandler)
        {
            _mapper = mapper;
            _orderHandler = orderHandler;
        }


        public async Task<OrderResponse> ConfirmAsync(OrderModel order)
        {
            try
            {
                return new OrderResponse
                {
                    Id = await _orderHandler.ConfirmAsync(order)
                };
            }
            catch (Exception e)
            {
                return new OrderResponse { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
