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
        private readonly IUserService _userService;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="userService">Сервис пользователь</param>
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель токен</returns>
        [HttpPost("/token")]
        public async Task<IActionResult> Token([FromBody] UserShortModel user)
        {
            var response = await _userService.GetTokenAsync(user);
            return Ok(response);
        }
    }
}