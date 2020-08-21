using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Books;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер книга
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="bookService">Сервис книга</param>
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book">Модель книга</param>
        /// <returns>Ответ книга</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookModifyModel book)
        {
            var response = await _bookService.AddAsync(book);
            return Ok(response);
        }

        /// <summary>
        /// Обновить книгу
        /// </summary>
        /// <param name="book">Модель книга</param>
        /// <returns>Ответ книга</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookModifyModel book)
        {
            var response = await _bookService.UpdateAsync(book);
            return Ok(response);
        }

        /// <summary>
        /// Удалить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Базовый ответ</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _bookService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Ответ книга</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _bookService.GetAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Пагинация для получения книг
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция книг</returns>
        [HttpGet("GetBooks/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> Get([FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var response = await _bookService.GetAsync(takeCount, skipCount);
            return Ok(response);
        }

        /// <summary>
        /// Поиск книг по автору
        /// </summary>
        /// <param name="searchString">Имя автора</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция книг</returns>
        [HttpGet("SearchByAuthor/{searchString}")]
        public async Task<IActionResult> SearchByAuthor([FromRoute] string searchString, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var response = await _bookService.SearchByAuthorAsync(searchString, takeCount, skipCount);
            return Ok(response);
        }

        /// <summary>
        /// Поиск книг по названию
        /// </summary>
        /// <param name="searchString">Название книги</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция книг</returns>
        [HttpGet("SearchByName/{searchString}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByName([FromRoute] string searchString, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var response = await _bookService.SearchByNameAsync(searchString, takeCount, skipCount);
            return Ok(response);
        }

        /// <summary>
        /// Поиск книг по жанру
        /// </summary>
        /// <param name="searchString">Название жанра</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция книг</returns>
        [HttpGet("SearchByGenre/{searchString}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByGenre([FromRoute] string searchString, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var response = await _bookService.SearchByGenreAsync(searchString, takeCount, skipCount);
            return Ok(response);
        }
    }
}