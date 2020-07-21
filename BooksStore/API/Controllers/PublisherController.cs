﻿using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;

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
        /// Поиск по имени издателя
        /// </summary>
        /// <param name="publisherName">Имя издателя</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция издателей</returns>
        [HttpGet("SearchByName/{publisherName}/take/{takeCount}/skip/{skipCount}")]
        public IActionResult SearchByName([FromRoute] string publisherName, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = _publisherService.SearchByName(publisherName, takeCount, skipCount);
            return Ok(result);
        }
    }
}
