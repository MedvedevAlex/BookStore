﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using ViewModel.Interfaces.Repositories;

namespace Service.Repositories
{
    /// <summary>
    /// Репозиторий для общих методов получения информации по пользователе
    /// </summary>
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public UserInfoRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Получить идентификатор пользователя из токена
        /// </summary>
        /// <returns>Идентификатор пользователя</returns>
        public Guid GetUserIdFromToken()
        {
            var userId = _httpContextAccessor.HttpContext?.User?
                .FindFirst($"{nameof(Model.Entities.User)}{nameof(Model.Entities.User.Id)}")?.Value;
            if (Guid.TryParse(userId, out Guid guid))
                return guid;
            else
                throw new KeyNotFoundException("Не удалось получить идентификатор пользователя из токена");
        }
    }
}
