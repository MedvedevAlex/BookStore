using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Книги
    /// </summary>
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
        /// Пагинация для получения книг
        /// </summary>
        /// <param name="takeCount">Количество получаемых</param>
        /// <param name="skipCount">Количество пропущенных</param>
        /// <returns>Коллекция книг</returns>
        [HttpGet("getbooks/take/{takeCount}/skip/{skipCount}")]
        public IActionResult GetBooks([FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = _bookService.Get(takeCount, skipCount);
            return Ok(result);
        }

        /// <summary>
        /// Получить книгу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель книги</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] Guid id)
        {
            var result = await _bookService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] BookModel book)
        {
            _bookService.Add(book);
            return Ok();
        }

        /// <summary>
        /// Обновить книгу
        /// </summary>
        /// <param name="book">Модель книги</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] BookModel book)
        {
            _bookService.Update(book);
            return Ok();
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
        /// Поиск книг по автору
        /// </summary>
        /// <param name="searchString">Имя автора</param>
        /// <returns>Колекция книг</returns>
        [HttpGet("SearchByAuthor/{searchString}")]
        public IActionResult SearchByAuthor([FromRoute] string searchString)
        {
            var result = _bookService.SearchByAuthor(searchString);
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
        public IActionResult SearchByName([FromRoute] string searchString, [FromRoute] int takeCount, [FromRoute] int skipCount)
        {
            var result = _bookService.SearchByName(searchString, takeCount, skipCount);
            return Ok(result);
        }

        ///// <summary>
        ///// Поиск книг по жанру
        ///// </summary>
        ///// <param name="searchString">Название жанра</param>
        ///// <param name="takeCount">Количество получаемых</param>
        ///// <param name="skipCount">Количество пропущенных</param>
        ///// <returns>Колекция книг</returns>
        //[HttpGet("SearchByGenre/{searchString}/take/{takeCount}/skip/{skipCount}")]
        //public IActionResult SearchByGenre([FromRoute] string searchString, [FromRoute] int takeCount, [FromRoute] int skipCount)
        //{
        //    var result = _bookService.SearchByGenre(searchString, takeCount, skipCount);
        //    return Ok(result);
        //}
    }
}