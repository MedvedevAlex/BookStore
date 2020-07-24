using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Художник
    /// </summary>
    [Route("api/[controller]")]
    public class PainterController : Controller
    {
        private readonly IPainterService _painterService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="painterService">Сервис Художник</param>
        public PainterController(IPainterService painterService)
        {
            _painterService = painterService;
        }

        /// <summary>
        /// Получить художника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель художника</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _painterService.GetAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Пагинация для получения художников
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция художников</returns>
        [HttpGet("GetPainters/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> Get([FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _painterService.GetAsync(takeCount, skipCount);
            return Ok(result);
        }

        /// <summary>
        /// Поиск по имени художника
        /// </summary>
        /// <param name="painterName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция художников</returns>
        [HttpGet("SearchByName/{painterName}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByName([FromRoute] string painterName, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _painterService.SearchByNameAsync(painterName, takeCount, skipCount);
            return Ok(result);
        }
    }
}
