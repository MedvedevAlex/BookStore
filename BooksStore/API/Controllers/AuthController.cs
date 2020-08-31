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
        /// Обновление токена
        /// </summary>
        /// <param name="refreshToken">Обновление токена</param>
        /// <returns>Ответ токен</returns>
        [HttpGet("{refreshToken}")]
        public async Task<IActionResult> Refresh(string refreshToken)
        {
            var response = await _authService.RefreshTokenAsync(refreshToken);
            return Ok(response);
        }
    }
}