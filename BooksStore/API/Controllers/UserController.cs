using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Users;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер Авторизация
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="userService">Сервис пользователь</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель пользователь</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserModifyModel user)
        {
            var response = await _userService.AddAsync(user);
            return Ok(response);
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель пользователь</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModifyModel user)
        {
            var response = await _userService.UpdateAsync(user);
            return Ok(response);
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель пользователь</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _userService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить пользоавтеля по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Модель пользователь</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _userService.GetAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Получить пользователя по логину
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns></returns>
        [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> Get([FromRoute] string login)
        {
            var response = await _userService.GetAsync(login);
            return Ok(response);
        }
    }
}