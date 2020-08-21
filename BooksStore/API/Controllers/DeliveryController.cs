using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Deliveries;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер доставка
    /// </summary>
    [Route("api/[controller]")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="deliveryService">Сервис доставка</param>
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        /// <summary>
        /// Добавить доставку
        /// </summary>
        /// <param name="delivery">Модель доставка</param>
        /// <returns>Ответ доставка</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DeliveryModifyModel delivery)
        {
            var response = await _deliveryService.AddAsync(delivery);
            return Ok(response);
        }

        /// <summary>
        /// Получить доставку по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор доставки</param>
        /// <returns>Ответ доставка</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _deliveryService.GetAsync(id);
            return Ok(response);
        }
    }
}
