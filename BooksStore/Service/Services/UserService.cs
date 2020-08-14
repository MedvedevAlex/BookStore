using System;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Responses;
using ViewModel.Models.Responses.Users;
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

        public async Task<UserResponse> AddAsync(UserModifyModel user)
        {
            try
            {
                return new UserResponse
                {
                    User = await _userHandler.AddAsync(user)
                };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<UserResponse> UpdateAsync(UserModifyModel user)
        {
            try
            {
                return new UserResponse
                {
                    User = await _userHandler.UpdateAsync(user)
                };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            try
            {
                return await _userHandler.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return new BaseResponse { Success = false, ErrorMessage = e.Message };
            }
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

        public async Task<UserResponse> GetAsync(string login)
        {
            try
            {
                return new UserResponse
                {
                    User = await _userHandler.GetAsync(login)
                };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
