using System;
using System.Threading.Tasks;
using ViewModel.Models.Responses;
using ViewModel.Models.Users;

namespace ViewModel.Handlers
{
    public interface IUserHandler
    {
        Task<UserModel> AddAsync(UserModifyModel user);
        Task<UserModel> UpdateAsync(UserModifyModel user);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<UserModel> GetAsync(Guid id);
        Task<UserModel> GetAsync(string login);
    }
}