using Microsoft.IdentityModel.Tokens;
using Serivce;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Responses.Users;
using ViewModel.Models.Users;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserHandler _userHandler;

        public AuthService(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public async Task<UserResponse> GetAsync(Guid id)
        {
            try
            {
                return new UserResponse
                {
                    User = await _userHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        /// <summary>
        /// Получить токен
        /// </summary>
        /// <param name="userModel">Модель пользователь</param>
        /// <returns>Модель токен</returns>
        public async Task<TokenResponse> GetTokenAsync(UserShortModel userModel)
        {
            ClaimsIdentity identity = null;
            try
            {
                identity = await GetIdentityAsync(userModel);
            }
            catch (Exception e)
            {
                return new TokenResponse { Success = false, ErrorMessage = e.Message };
            }

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
            var user = await _userHandler.GetAsync(userModel.Login);
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
