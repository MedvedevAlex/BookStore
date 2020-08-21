using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Interpreters;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер переводчик
    /// </summary>
    [Route("api/[controller]")]
    public class InterpreterController : Controller
    {
        private readonly IInterpreterService _interpreterService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="interpreterService">Сервис переводчик</param>
        public InterpreterController(IInterpreterService interpreterService)
        {
            _interpreterService = interpreterService;
        }

        /// <summary>
        /// Добавить переводчика
        /// </summary>
        /// <param name="interpreter">Модель переводчик</param>
        /// <returns>Ответ переводчик</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InterpreterModifyModel interpreter)
        {
            var response = await _interpreterService.AddAsync(interpreter);
            return Ok(response);
        }

        /// <summary>
        /// Обновить переводчика
        /// </summary>
        /// <param name="interpreter">Модель переводчик</param>
        /// <returns>Ответ перводчик</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InterpreterModifyModel interpreter)
        {
            var response = await _interpreterService.UpdateAsync(interpreter);
            return Ok(response);
        }

        /// <summary>
        /// Удалить переводчика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор переводчика</param>
        /// <returns>Базовый ответ</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _interpreterService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить переводчика по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор переводчика</param>
        /// <returns>Ответ переводчик</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _interpreterService.GetAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Пагинация переводчиков
        /// </summary>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция переводчиков</returns>
        [HttpGet("GetInterpreters/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> Get([FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var response = await _interpreterService.GetAsync(takeCount, skipCount);
            return Ok(response);
        }

        /// <summary>
        /// Пагинация переводчиков
        /// </summary>
        /// <param name="interpreterName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция переводчиков</returns>
        [HttpGet("SearchByName/{interpreterName}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByName([FromRoute] string interpreterName, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var response = await _interpreterService.SearchByNameAsync(interpreterName, takeCount, skipCount);
            return Ok(response);
        }
    }
}
