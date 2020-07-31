using System.Threading.Tasks;
using ViewModel.Models.Users;

namespace ViewModel.Handlers
{
    public interface IUserHandler
    {
        Task<UserModel> GetAsync(UserShortModel user);
    }
}