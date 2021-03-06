﻿using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Orders;
using ViewModel.Responses.Orders;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderHandler _orderHandler;

        public OrderService(IOrderHandler orderHandler)
        {
            _orderHandler = orderHandler;
        }

        public async Task<OrderResponse> AddAsync(OrderModifyModel order)
        {
            try
            {
                return new OrderResponse
                {
                    Order = await _orderHandler.AddAsync(order)
                };
            }
            catch (Exception e)
            {
                return new OrderResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<OrderResponse> UpdateStatusAsync(OrderUpdateModel order)
        {
            try
            {
                return new OrderResponse
                {
                    Order = await _orderHandler.UpdateStatusAsync(order)
                };
            }
            catch (Exception e)
            {
                return new OrderResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<OrderResponse> GetAsync(Guid id)
        {
            try
            {
                return new OrderResponse
                {
                    Order = await _orderHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new OrderResponse { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
