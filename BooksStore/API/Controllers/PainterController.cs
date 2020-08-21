using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Painters;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер художник
    /// </summary>
    [Route("api/[controller]")]
    public class PainterController : Controller
    {
        private readonly IPainterService _painterService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="painterService">Сервис художник</param>
        public PainterController(IPainterService painterService)
        {
            _painterService = painterService;
        }

        /// <summary>
        /// Добавить художника
        /// </summary>
        /// <param name="painter">Модель художник</param>
        /// <returns>Ответ художник</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PainterModifyModel painter)
        {
            var response = await _painterService.AddAsync(painter);
            return Ok(response);
        }

        /// <summary>
        /// Обновить художника
        /// </summary>
        /// <param name="painter">Модель художник</param>
        /// <returns>Ответ художник</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PainterModifyModel painter)
        {
            var response = await _painterService.UpdateAsync(painter);
            return Ok(response);
        }

        /// <summary>
        /// Удалить художника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор художника</param>
        /// <returns>Базовый ответ</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _painterService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить художника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор художника</param>
        /// <returns>Ответ художник</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _painterService.GetAsync(id);
            return Ok(response);
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
            var response = await _painterService.GetAsync(takeCount, skipCount);
            return Ok(response);
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
            var response = await _painterService.SearchByNameAsync(painterName, takeCount, skipCount);
            return Ok(response);
        }

        /// <summary>
        /// Поиск по стилю художника
        /// </summary>
        /// <param name="styleName">Наименоваине стиля</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция художников</returns>
        [HttpGet("SearchByStyle/{styleName}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByStyle([FromRoute] string styleName, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var response = await _painterService.SearchBySyleAsync(styleName, takeCount, skipCount);
            return Ok(response);
        }
    }
}
