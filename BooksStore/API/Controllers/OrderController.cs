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
        [Authorize]
        [HttpPost("/Confirm")]
        public async Task<IActionResult> Confirm([FromBody] OrderModel order)
        {
            var response = await _orderService.ConfirmAsync(order);
            return Ok(response);
        }
    }
}