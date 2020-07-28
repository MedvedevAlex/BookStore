using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Authors;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Автор
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Добавить автора
        /// </summary>
        /// <param name="author">Модель автор</param>
        /// <returns>Модель автор</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AuthorModifyModel author)
        {
            var result = await _authorService.AddAsync(author);
            return Ok(result);
        }

        /// <summary>
        /// Обновить автора
        /// </summary>
        /// <param name="author">Модель автор</param>
        /// <returns>Модель автор</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AuthorModifyModel author)
        {
            var result = await _authorService.UpdateAsync(author);
            return Ok(result);
        }

        /// <summary>
        /// Удалить автора
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _authorService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Получить автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель автор</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _authorService.GetAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Пагинация авторов
        /// </summary>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция авторов</returns>
        [HttpGet("GetAuthors/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> Get([FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _authorService.GetAsync(takeCount, skipCount);
            return Ok(result);
        }
    }
}