using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Repositories;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Users;
using ViewModel.Responses.Users;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserHandler _userHandler;
        private readonly IMapper _mapper;
        private readonly ISecurityTokenValidator _securityTokenValidator;
        private readonly IUserInfoRepository _userInfoRepository;

        public AuthService(
            IUserHandler userHandler,
            IMapper mapper,
            ISecurityTokenValidator securityTokenValidator,
            IUserInfoRepository userInfoRepository)
        {
            _userHandler = userHandler;
            _mapper = mapper;
            _securityTokenValidator = securityTokenValidator;
            _userInfoRepository = userInfoRepository;
        }

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Ответ токен</returns>
        public async Task<TokenResponse> RegisterAsync(UserShortModel user)
        {
            try
            {
                var userModify = _mapper.Map<UserModifyModel>(user);
                userModify.Role = "Common";
                var createUser = await _userHandler
                    .AddAsync(userModify);
                return await GetTokenAsync(createUser.Login);
            }
            catch (Exception e)
            {
                return new TokenResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Авторизовать пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Ответ токен</returns>
        public async Task<TokenResponse> AuthorizeAsync(UserShortModel user)
        {
            try
            {
                var userShort = await _userHandler.GetAsync(user);
                return await GetTokenAsync(userShort.Login);
            }
            catch (Exception e)
            {
                return new TokenResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Обновить токен
        /// </summary>
        /// <param name="refreshToken">Обновление токена</param>
        /// <returns>Ответ токен</returns>
        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken)
        {
            try
            {
                var userId = _userInfoRepository.GetUserIdFromToken();
                var user = await _userHandler.GetAsync(userId);

                if (user.RefreshToken != refreshToken)
                    throw new Exception("Ошибка: Обновленные токены не совпадают");

                var updatedUser = await _userHandler.UpdateRefreshTokenAsync(userId, refreshToken);
                return AssembleToken(updatedUser);
            }
            catch (Exception e)
            {
                return new TokenResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Ответ токен</returns>
        private async Task<TokenResponse> GetTokenAsync(string login)
        {
            try
            {
                var user = await _userHandler.GetAsync(login);
                return AssembleToken(user);
            }
            catch (Exception e)
            {
                return new TokenResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Собрать токен
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Ответ токен</returns>
        private TokenResponse AssembleToken(UserModel user)
        {
            var identity = GetIdentityAsync(user);
            var encodedJwt = GenerateToken(identity);

            return new TokenResponse
            {
                AccessToken = encodedJwt,
                Login = identity.Name,
                RefreshToken = user.RefreshToken
            };
        }

        /// <summary>
        /// Сгенерировать токен
        /// </summary>
        /// <param name="identity">Утверждения</param>
        /// <param name="lifeTime">Время жизни токена</param>
        /// <returns>Токен</returns>
        private static string GenerateToken(ClaimsIdentity identity, int lifeTime = AuthOptions.LIFETIME)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(lifeTime)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        /// <summary>
        /// Получить утверждения (клаймы)
        /// </summary>
        /// <param name="login">Модель пользователь</param>
        /// <returns>Модель утверждения</returns>
        private ClaimsIdentity GetIdentityAsync(UserModel user)
        {
            if (user.Role == null)
                user.Role = "Common";
            var claims = new List<Claim>()
            {
                new Claim($"{nameof(Model.Entities.User)}{nameof(Model.Entities.User.Id)}", $"{user.Id}"),
                new Claim(nameof(Model.Entities.User.Login), user.Login),
                new Claim(nameof(Model.Entities.User.Role), user.Role)
            };
            return new ClaimsIdentity(
                claims,
                "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
