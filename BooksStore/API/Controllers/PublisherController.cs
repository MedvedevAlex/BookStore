using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Publishers;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Издатель
    /// </summary>
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="publisherService">Сервис Издатель</param>
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        /// <summary>
        /// Добавить издателя
        /// </summary>
        /// <param name="publisher">Модель издатель</param>
        /// <returns>Модель издатель</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PublisherModifyModel publisher)
        {
            var result = await _publisherService.AddAsync(publisher);
            return Ok(result);
        }

        /// <summary>
        /// Обновить издателя
        /// </summary>
        /// <param name="publisher">Модель издатель</param>
        /// <returns>Модель издатель</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PublisherModifyModel publisher)
        {
            var result = await _publisherService.UpdateAsync(publisher);
            return Ok(result);
        }

        /// <summary>
        /// Удалить издателя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _publisherService.DeleteAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Получить издателя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель издатель</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _publisherService.GetAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Пагинация издателей
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция издателей</returns>
        [HttpGet("GetPublishers/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> Get([FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _publisherService.GetAsync(takeCount, skipCount);
            return Ok(result);
        }

        /// <summary>
        /// Поиск по имени издателя
        /// </summary>
        /// <param name="publisherName">Имя издателя</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция издателей</returns>
        [HttpGet("SearchByName/{publisherName}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByName([FromRoute] string publisherName, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _publisherService.SearchByNameAsync(publisherName, takeCount, skipCount);
            return Ok(result);
        }
    }
}
