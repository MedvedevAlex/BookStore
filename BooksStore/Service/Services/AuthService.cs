using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Repositories;
using ViewModel.Interfaces.Services;
using ViewModel.Models;
using ViewModel.Models.Users;
using ViewModel.Responses;
using ViewModel.Responses.Users;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserHandler _userHandler;
        private readonly IMapper _mapper;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IOptionsMonitor<TokenSettings> _tokenSettings;

        public AuthService(
            IUserHandler userHandler,
            IMapper mapper,
            IUserInfoRepository userInfoRepository, 
            IOptionsMonitor<TokenSettings> tokenSettings)
        {
            _userHandler = userHandler;
            _mapper = mapper;
            _userInfoRepository = userInfoRepository;
            _tokenSettings = tokenSettings;
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
                return GetToken(createUser);
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
                var userModel = await _userHandler.GetAsync(user);
                return GetToken(userModel);
            }
            catch (Exception e)
            {
                return new TokenResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Обновить токен
        /// </summary>
        /// <param name="model">Модель обновление токена</param>
        /// <returns>Ответ токен</returns>
        public async Task<TokenResponse> RefreshTokenAsync(RefreshTokenModel model)
        {
            try
            {
                var user = await _userHandler.GetAsync(model.Login);

                if (user.RefreshToken != model.RefreshToken)
                    throw new Exception("Ошибка: Обновленные токены не совпадают");

                var updatedUser = await _userHandler.UpdateRefreshTokenAsync(user);
                return AssembleToken(updatedUser, _tokenSettings.CurrentValue.LifeTime);
            }
            catch (Exception e)
            {
                return new TokenResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Отозвать токен
        /// </summary>
        /// <returns>Базовый ответ</returns>
        public async Task<BaseResponse> RevokeTokenAsync()
        {
            try
            {
                var userId = _userInfoRepository.GetUserIdFromToken();
                var user = await _userHandler.GetAsync(userId);
                AssembleToken(user, -1);
                return new BaseResponse();
            }
            catch (Exception e)
            {
                return new BaseResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Ответ токен</returns>
        private TokenResponse GetToken(UserModel user)
        {
            try
            {
                return AssembleToken(user, _tokenSettings.CurrentValue.LifeTime);
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
        private TokenResponse AssembleToken(UserModel user, int lifeTime)
        {
            var identity = GetIdentityAsync(user);
            var encodedJwt = GenerateToken(identity, lifeTime);

            return new TokenResponse
            {
                AccessToken = encodedJwt,
                Login = user.Login,
                RefreshToken = user.RefreshToken
            };
        }

        /// <summary>
        /// Сгенерировать токен
        /// </summary>
        /// <param name="identity">Утверждения</param>
        /// <param name="lifeTime">Время жизни токена</param>
        /// <returns>Токен</returns>
        private string GenerateToken(ClaimsIdentity identity, int lifeTime)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenSettings.CurrentValue.Key));
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: _tokenSettings.CurrentValue.Issuer,
                    audience: _tokenSettings.CurrentValue.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(lifeTime)),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        /// <summary>
        /// Получить утверждения (клаймы)
        /// </summary>
        /// <param name="user">Модель пользователь</param>
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
