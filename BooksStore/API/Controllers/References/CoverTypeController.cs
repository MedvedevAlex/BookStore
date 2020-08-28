using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services.References;
using ViewModel.Models.References;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер тип переплета
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class CoverTypeController : ControllerBase
    {
        private readonly ICoverTypeService _coverTypeService;

        public CoverTypeController(ICoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService;
        }

        /// <summary>
        /// Добавить тип переплета
        /// </summary>
        /// <param name="coverType">Модель тип переплета</param>
        /// <returns>Ответ тип переплета</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CoverTypeModel coverType)
        {
            var response = await _coverTypeService.AddAsync(coverType);
            return Ok(response);
        }

        /// <summary>
        /// Обновить тип переплета
        /// </summary>
        /// <param name="coverType">Модель тип переплета</param>
        /// <returns>Ответ тип переплета</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CoverTypeModel coverType)
        {
            var response = await _coverTypeService.UpdateAsync(coverType);
            return Ok(response);
        }

        /// <summary>
        /// Удалить тип переплета
        /// </summary>
        /// <param name="id">Идентификатор типа переплета</param>
        /// <returns>Базовый ответ</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var response = _coverTypeService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить тип переплета по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор типа переплета</param>
        /// <returns>Модель тип переплета</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _coverTypeService.GetAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить типы переплета
        /// </summary>
        /// <returns>Ответ с коллекцией типов переплета</returns>
        [HttpGet("GetCoverTypes")]
        public async Task<IActionResult> Get()
        {
            var response = await _coverTypeService.GetAsync();
            return Ok(response);
        }

        /// <summary>
        /// Поиск по наименованию
        /// </summary>
        /// <param name="coverTypeName">Намиенование типа переплета</param>
        /// <returns>Ответ с коллекцией типов переплета</returns>
        [HttpGet("SearchByName/{coverTypeName}")]
        public async Task<IActionResult> SearchByName([FromRoute] string coverTypeName)
        {
            var response = await _coverTypeService.SearchByNameAsync(coverTypeName);
            return Ok(response);
        }
    }
}