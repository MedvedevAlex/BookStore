using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;

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
    }
}
