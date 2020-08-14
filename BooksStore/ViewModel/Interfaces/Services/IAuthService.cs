using System;
using System.Threading.Tasks;
using ViewModel.Models.Responses.Users;
using ViewModel.Models.Users;

namespace ViewModel.Interfaces.Services
{
    public interface IAuthService
    {
        Task<TokenResponse> GetTokenAsync(UserShortModel userModel);
    }
}