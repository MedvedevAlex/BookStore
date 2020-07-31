using System.Threading.Tasks;
using ViewModel.Models.Users;

namespace ViewModel.Interfaces.Services
{
    public interface IUserService
    {
        Task<TokenResponse> GetTokenAsync(UserShortModel userModel);
    }
}