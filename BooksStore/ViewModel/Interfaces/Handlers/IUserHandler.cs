using System;
using System.Threading.Tasks;
using ViewModel.Models.Users;
using ViewModel.Responses;

namespace ViewModel.Interfaces.Handlers
{
    public interface IUserHandler
    {
        Task<UserModel> AddAsync(UserModifyModel user);
        Task<UserModel> UpdateAsync(UserModifyModel user);
        Task<UserModel> UpdateRefreshTokenAsync(Guid id, string refreshToken);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<UserModel> GetAsync(Guid id);
        Task<UserModel> GetAsync(string login);
        Task<UserShortModel> GetAsync(UserShortModel user);
    }
}