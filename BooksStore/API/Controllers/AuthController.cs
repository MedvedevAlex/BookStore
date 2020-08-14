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
        /// Получить токен
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель токен</returns>
        [HttpPost("/token")]
        public async Task<IActionResult> Token([FromBody] UserShortModel user)
        {
            var response = await _authService.GetTokenAsync(user);
            return Ok(response);
        }
    }
}