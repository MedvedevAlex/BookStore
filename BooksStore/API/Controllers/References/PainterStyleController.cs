﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services.References;
using ViewModel.Models.References;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер стиль художника
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class PainterStyleController : ControllerBase
    {
        private readonly IPainterStyleService _painterStyleService;

        public PainterStyleController(IPainterStyleService painterStyleService)
        {
            _painterStyleService = painterStyleService;
        }

        /// <summary>
        /// Добавить стиль художника
        /// </summary>
        /// <param name="painterStyle">Модель стиль художника</param>
        /// <returns>Ответ стиль художника</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PainterStyleModel painterStyle)
        {
            var response = await _painterStyleService.AddAsync(painterStyle);
            return Ok(response);
        }

        /// <summary>
        /// Обновить стиль художника
        /// </summary>
        /// <param name="painterStyle">Модель стиль художника</param>
        /// <returns>Ответ стиль художника</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PainterStyleModel painterStyle)
        {
            var response = await _painterStyleService.UpdateAsync(painterStyle);
            return Ok(response);
        }

        /// <summary>
        /// Удалить стиль художника
        /// </summary>
        /// <param name="id">Идентификатор стиля художника</param>
        /// <returns>Базовый ответ</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var response = _painterStyleService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить стиль художника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор стиля художника</param>
        /// <returns>Ответ стиль художника</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _painterStyleService.GetAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить стили художника
        /// </summary>
        /// <returns>Ответ с коллекцией стилей художника</returns>
        [HttpGet("GetPainterStyles")]
        public async Task<IActionResult> Get()
        {
            var response = await _painterStyleService.GetAsync();
            return Ok(response);
        }

        /// <summary>
        /// Поиск по наименованию
        /// </summary>
        /// <param name="painterStyleName">Намиенование стиля художника</param>
        /// <returns>Ответ с коллекцией стилей художника</returns>
        [HttpGet("SearchByName/{painterStyleName}")]
        public async Task<IActionResult> SearchByName([FromRoute] string painterStyleName)
        {
            var response = await _painterStyleService.SearchByNameAsync(painterStyleName);
            return Ok(response);
        }
    }
}