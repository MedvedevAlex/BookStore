using System;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Interfaces.Services;
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

        public async Task<UserResponse> GetAsync(UserShortModel user)
        {
            try
            {
                return new UserResponse
                {
                    User = await _userHandler.GetAsync(user)
                };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
