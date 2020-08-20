using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Orders;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Заказ
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="orderService">Сервис заказ</param>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Подтверждение заказа
        /// </summary>
        /// <param name="order">Модель заказ</param>
        /// <returns>Ответ заказ</returns>
        [HttpPost("Confirm")]
        public async Task<IActionResult> Confirm([FromBody] OrderModifyModel order)
        {
            var response = await _orderService.ConfirmAsync(order);
            return Ok(response);
        }

        /// <summary>
        /// Получить заказ по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Ответ заказ</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _orderService.GetAsync(id);
            return Ok(response);
        }
    }
}