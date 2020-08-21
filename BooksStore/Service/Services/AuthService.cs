using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Users;
using ViewModel.Responses.Users;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserHandler _userHandler;
        private readonly IMapper _mapper;

        public AuthService(IUserHandler userHandler, IMapper mapper)
        {
            _userHandler = userHandler;
            _mapper = mapper;
        }

        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Ответ токен</returns>
        public async Task<TokenResponse> Register(UserShortModel user)
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
        public async Task<TokenResponse> Authorize(UserShortModel user)
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
        /// Получить токен
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Ответ токен</returns>
        public async Task<TokenResponse> GetTokenAsync(string login)
        {
            try
            {
                var identity = await GetIdentityAsync(login);

                var now = DateTime.UtcNow;
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: identity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return new TokenResponse
                {
                    AccessToken = encodedJwt,
                    Login = identity.Name
                };
            }
            catch (Exception e)
            {
                return new TokenResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Получить утверждения (клаймы)
        /// </summary>
        /// <param name="login">Модель пользователь</param>
        /// <returns>Модель утверждения</returns>
        private async Task<ClaimsIdentity> GetIdentityAsync(string login)
        {
            var user = await _userHandler.GetAsync(login);
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
