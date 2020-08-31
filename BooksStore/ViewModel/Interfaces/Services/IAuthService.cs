﻿using System.Threading.Tasks;
using ViewModel.Models.Users;
using ViewModel.Responses.Users;

namespace ViewModel.Interfaces.Services
{
    public interface IAuthService
    {
        Task<TokenResponse> RegisterAsync(UserShortModel user);
        Task<TokenResponse> AuthorizeAsync(UserShortModel user);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken);
    }
}