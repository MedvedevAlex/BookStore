using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Payments;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер платеж
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        /// <summary>
        /// Коструктор
        /// </summary>
        /// <param name="paymentService">Сервис платеж</param>
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Добавить платеж
        /// </summary>
        /// <param name="payment">Модель создание платежа</param>
        /// <returns>Ответ плажет</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PaymentCreateModel payment)
        {
            var response = await _paymentService.AddAsync(payment);
            return Ok(response);
        }

        /// <summary>
        /// Обновить платеж
        /// </summary>
        /// <param name="payment">Модель обновления платежа</param>
        /// <returns>Ответ платеж</returns>
        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] PaymentUpdateModel payment)
        {
            var response = await _paymentService.UpdateStatusAsync(payment);
            return Ok(response);
        }

        /// <summary>
        /// Получить платеж по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор платежа</param>
        /// <returns>Ответ платеж</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _paymentService.GetAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить платеж по идентификатору c информацией о заказе
        /// </summary>
        /// <param name="id">Идентификатор платежа</param>
        /// <returns>Ответ платеж</returns>
        [HttpGet("GetWithOrder/{id}")]
        public async Task<IActionResult> GetWithOrder([FromRoute] Guid id)
        {
            var response = await _paymentService.GetWithOrderAsync(id);
            return Ok(response);
        }
    }
}
