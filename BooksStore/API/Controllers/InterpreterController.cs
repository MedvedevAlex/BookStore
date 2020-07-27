using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Interpreters;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Переводчик
    /// </summary>
    [Route("api/[controller]")]
    public class InterpreterController : Controller
    {
        private readonly IInterpreterService _interpreterService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="interpreterService">Сервис Переводчик</param>
        public InterpreterController(IInterpreterService interpreterService)
        {
            _interpreterService = interpreterService;
        }

        /// <summary>
        /// Добавить переводчика
        /// </summary>
        /// <param name="interpreter">Модель переводчик</param>
        /// <returns>Модель переводчик</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InterpreterModifyModel interpreter)
        {
            var result = await _interpreterService.AddAsync(interpreter);
            return Ok(result);
        }

        /// <summary>
        /// Получить переводчика
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель переводчик</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _interpreterService.GetAsync(id);
            return Ok(result);
        }
    }
}
