﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services.References;
using ViewModel.Models.References;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Стиль художника
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
        /// <returns>Модель стиль художника</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PainterStyleModel painterStyle)
        {
            var result = await _painterStyleService.AddAsync(painterStyle);
            return Ok(result);
        }

        /// <summary>
        /// Обновить стиль художника
        /// </summary>
        /// <param name="painterStyle">Модель стиль художника</param>
        /// <returns>Модель стиль художника</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PainterStyleModel painterStyle)
        {
            var result = await _painterStyleService.UpdateAsync(painterStyle);
            return Ok(result);
        }

        /// <summary>
        /// Получить стиль художника по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель стиль художника</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _painterStyleService.GetAsync(id);
            return Ok(result);
        }
    }
}