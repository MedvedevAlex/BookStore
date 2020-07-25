using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Books;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Книги
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns>Модель книги</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookCreateModel book)
        {
            var result = await _bookService.AddAsync(book);
            return Ok(result);
        }

        /// <summary>
        /// Обновить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookCreateModel book)
        {
            var result = await _bookService.UpdateAsync(book);
            return Ok(result);
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _bookService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Получить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель книги</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _bookService.GetAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Пагинация для получения книг
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция книг</returns>
        [HttpGet("getbooks/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> Get([FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _bookService.GetAsync(takeCount, skipCount);
            return Ok(result);
        }

        /// <summary>
        /// Поиск книг по автору
        /// </summary>
        /// <param name="searchString">Имя автора</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Колекция книг</returns>
        [HttpGet("SearchByAuthor/{searchString}")]
        public async Task<IActionResult> SearchByAuthor([FromRoute] string searchString, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _bookService.SearchByAuthorAsync(searchString, takeCount, skipCount);
            return Ok(result);
        }

        /// <summary>
        /// Поиск книг по названию
        /// </summary>
        /// <param name="searchString">Название книги</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns></returns>
        [HttpGet("SearchByName/{searchString}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByName([FromRoute] string searchString, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _bookService.SearchByNameAsync(searchString, takeCount, skipCount);
            return Ok(result);
        }

        /// <summary>
        /// Поиск книг по жанру
        /// </summary>
        /// <param name="searchString">Название жанра</param>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Колекция книг</returns>
        [HttpGet("SearchByGenre/{searchString}/take/{takeCount}/skip/{skipCount}")]
        public async Task<IActionResult> SearchByGenre([FromRoute] string searchString, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = await _bookService.SearchByGenreAsync(searchString, takeCount, skipCount);
            return Ok(result);
        }
    }
}