using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Authors;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер автор
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="authorService">Сервис автор</param>
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Добавить автора
        /// </summary>
        /// <param name="author">Модель автор</param>
        /// <returns>Ответ автор</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AuthorModifyModel author)
        {
            var response = await _authorService.AddAsync(author);
            return Ok(response);
        }

        /// <summary>
        /// Обновить автора
        /// </summary>
        /// <param name="author">Модель автор</param>
        /// <returns>Ответ автор</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AuthorModifyModel author)
        {
            var response = await _authorService.UpdateAsync(author);
            return Ok(response);
        }

        /// <summary>
        /// Удалить автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <returns>Базовые ответ</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _authorService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить автора по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор автора</param>
        /// <returns>Ответ автор</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _authorService.GetAsync(id);
            return Ok(response);
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
            var response = await _authorService.GetAsync(takeCount, skipCount);
            return Ok(response);
        }

        /// <summary>
        /// Поиск по имени
        /// </summary>
        /// <param name="authorName">Имя художника</param>
        /// <param name="takeCount">Количество получаемых записей</param>
        /// <param name="skipCount">Количество пропущенных записей</param>
        /// <returns>Коллекция авторов</returns>
        [HttpGet("SearchByName/{authorName}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByName([FromRoute] string authorName, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var response = await _authorService.SearchByNameAsync(authorName, takeCount, skipCount);
            return Ok(response);
        }
    }
}