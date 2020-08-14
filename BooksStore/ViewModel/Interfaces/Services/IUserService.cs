using System;
using System.Threading.Tasks;
using ViewModel.Models.Responses;
using ViewModel.Models.Responses.Users;
using ViewModel.Models.Users;

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