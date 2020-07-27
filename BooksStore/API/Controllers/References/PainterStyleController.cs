using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services.References;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Тип переплета
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class PainterStyleController : ControllerBase
    {
        private readonly IPainterStyleService _painterStyleService;

        public PainterStyleController(IPainterStyleService painterStyleService)
        {
            _painterStyleService = painterStyleService;
        }

        /// <summary>
        /// Получить стиль художника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель стиль художника</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _painterStyleService.GetAsync(id);
            return Ok(result);
        }
    }
}