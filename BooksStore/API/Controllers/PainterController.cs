using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Painters;

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
        /// Добавить художника
        /// </summary>
        /// <param name="painter">Модель художника</param>
        /// <returns>Модель художника</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PainterModifyModel painter)
        {
            var result = await _painterService.AddAsync(painter);
            return Ok(result);
        }

        /// <summary>
        /// Обновить художника
        /// </summary>
        /// <param name="painter">Модель художника</param>
        /// <returns>Модель художника</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PainterModifyModel painter)
        {
            var result = await _painterService.UpdateAsync(painter);
            return Ok(result);
        }

        /// <summary>
        /// Удалить художника
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _painterService.DeleteAsync(id);
            return Ok();
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
