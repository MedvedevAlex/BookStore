﻿using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Models.Users;

namespace Model.Handlers
{
    /// <summary>
    /// Обработчик данных пользователь
    /// </summary>
    public class UserHandler : IUserHandler
    {
        private readonly BookContextFactory _contextFactory;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Маппер</param>
        public UserHandler(IMapper mapper)
        {
            _contextFactory = new BookContextFactory();
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель пользователь</returns>
        public async Task<UserModel> AddAsync(UserModifyModel user)
        {
            var guid = Guid.NewGuid();
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Login == user.Login);
                if (userEntity != null) throw new Exception("Ошибка: Пользователь с таким логином уже существует");

                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                    rng.GetBytes(salt);
                
                var createUser = new User()
                {
                    Id = guid,
                    Login = user.Login,
                    Password = GenerateHashFromPassword(salt, user.Password),
                    Salt = Convert.ToBase64String(salt),
                    Role = user.Role
                };

                await context.Users.AddAsync(createUser);
                await context.SaveChangesAsync();
            }
            return await GetAsync(guid);
        }

        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модель пользователь</returns>
        public async Task<UserModel> GetAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == id);
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Пользователь не найден");

                return _mapper.Map<UserModel>(userEntity);
            }
        }

        /// <summary>
        /// Получить пользователя по логину
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель пользователь</returns>
        public async Task<UserModel> GetAsync(UserShortModel user)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Login == user.Login);
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Пользователя с таким логином не существует");

                return _mapper.Map<UserModel>(userEntity);
            }
        }

        /// <summary>
        /// генерация пароля и соли в хэш 
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string GenerateHashFromPassword(byte[] salt, string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
