using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services.References;
using ViewModel.Models.References;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Тип переплета
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
        /// <param name="coverType">Тип переплета</param>
        /// <returns>Тип переплета</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CoverTypeModel coverType)
        {
            var result = await _coverTypeService.AddAsync(coverType);
            return Ok(result);
        }

        /// <summary>
        /// Обновить тип переплета
        /// </summary>
        /// <param name="coverType">Модель тип переплета</param>
        /// <returns>Модель тип переплета</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CoverTypeModel coverType)
        {
            var result = await _coverTypeService.UpdateAsync(coverType);
            return Ok(result);
        }

        /// <summary>
        /// Удалить тип переплета
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _coverTypeService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Получить тип переплета по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель книги</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _coverTypeService.GetAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Получить типы переплета
        /// </summary>
        /// <returns>Коллекция типов переплета</returns>
        [HttpGet("GetCoverTypes")]
        public async Task<IActionResult> Get()
        {
            var result = await _coverTypeService.GetAsync();
            return Ok(result);
        }
    }
}