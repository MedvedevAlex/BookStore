using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Users;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер авторизация
    /// </summary>
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="authService">Сервис авторизации</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Ответ токен</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserShortModel user)
        {
            var response = await _authService.RegisterAsync(user);
            return Ok(response);
        }

        /// <summary>
        /// Авторизовать пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Ответ токен</returns>
        [HttpPost("Authorize")]
        public async Task<IActionResult> Authorize([FromBody] UserShortModel user)
        {
            var response = await _authService.AuthorizeAsync(user);
            return Ok(response);
        }

        /// <summary>
        /// Обновить токен
        /// </summary>
        /// <param name="model">Модель обновление токена</param>
        /// <returns>Ответ токен</returns>
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenModel model)
        {
            var response = await _authService.RefreshTokenAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        /// <returns>Ответ токен</returns>
        [HttpGet("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var response = await _authService.RevokeTokenAsync();
            return Ok(response);
        }
    }
}