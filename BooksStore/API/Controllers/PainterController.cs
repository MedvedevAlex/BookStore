using Microsoft.AspNetCore.Mvc;
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
        /// Поиск по имени художника
        /// </summary>
        /// <param name="painterName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция художников</returns>
        [HttpGet("SearchByName/{painterName}/take/{takeCount}/skip/{skipCount}")]
        public IActionResult SearchByName(
            [FromRoute] string painterName, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = _painterService.SearchByName(painterName, takeCount, skipCount);
            return Ok(result);
        }
    }
}
