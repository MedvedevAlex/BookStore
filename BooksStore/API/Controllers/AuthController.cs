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
        /// <param name="login">Логин пользователя</param>
        /// <returns>Модель токен</returns>
        [HttpGet("{login}")]
        public async Task<IActionResult> Token([FromRoute] string login)
        {
            var response = await _authService.GetTokenAsync(login);
            return Ok(response);
        }

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель токен</returns>
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] UserShortModel user)
        {
            var response = await _authService.Register(user);
            return Ok(response);
        }
    }
}