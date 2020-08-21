using System;
using System.Threading.Tasks;
using ViewModel.Models.Users;
using ViewModel.Responses;
using ViewModel.Responses.Users;

namespace ViewModel.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponse> AddAsync(UserModifyModel user);
        Task<UserResponse> UpdateAsync(UserModifyModel user);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<UserResponse> GetAsync(Guid id);
        Task<UserResponse> GetAsync(string login);
    }
}