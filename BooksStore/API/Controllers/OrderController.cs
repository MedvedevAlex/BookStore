using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Orders;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер заказ
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
        /// Создать заказ
        /// </summary>
        /// <param name="order">Модель заказ</param>
        /// <returns>Ответ заказ</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderModifyModel order)
        {
            var response = await _orderService.AddAsync(order);
            return Ok(response);
        }

        /// <summary>
        /// Обновить статус заказа
        /// </summary>
        /// <param name="order">Модель заказ</param>
        /// <returns>Ответ заказ</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromBody] OrderUpdateModel order)
        {
            var response = await _orderService.UpdateStatusAsync(order);
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