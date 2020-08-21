using System.Threading.Tasks;
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
            var response = await _authService.Register(user);
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
            var response = await _authService.Authorize(user);
            return Ok(response);
        }

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Ответ токен</returns>
        [HttpGet("{login}")]
        public async Task<IActionResult> Token([FromRoute] string login)
        {
            var response = await _authService.GetTokenAsync(login);
            return Ok(response);
        }
    }
}