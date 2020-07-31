using Microsoft.IdentityModel.Tokens;
using Serivce;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Users;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserHandler _userHandler;

        public UserService(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="userModel">Модель пользователь</param>
        /// <returns>Модель токен</returns>
        public async Task<TokenResponse> GetTokenAsync(UserShortModel userModel)
        {
            var identity = await GetIdentityAsync(userModel);

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

        /// <summary>
        /// Получить утверждения (клаймы)
        /// </summary>
        /// <param name="userModel">Модель пользователь</param>
        /// <returns>Модель утверждения</returns>
        private async Task<ClaimsIdentity> GetIdentityAsync(UserShortModel userModel)
        {
            var user = await _userHandler.GetAsync(userModel);
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };
            return new ClaimsIdentity(
                claims, 
                "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
