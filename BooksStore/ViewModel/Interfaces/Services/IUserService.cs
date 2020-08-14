﻿using System;
using System.Threading.Tasks;
using ViewModel.Models.Responses.Users;
using ViewModel.Models.Users;

namespace ViewModel.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetAsync(Guid id);
        Task<UserResponse> GetAsync(UserShortModel user);
    }
}