using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Users;
using ViewModel.Responses;

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

                var salt = GenerateSalt();

                var createUser = _mapper.Map<User>(user);
                createUser.Id = guid;
                createUser.Password = GenerateHashFromPassword(salt, user.Password);
                createUser.Salt = Convert.ToBase64String(salt);

                await context.Users.AddAsync(createUser);
                await context.SaveChangesAsync();
            }
            return await GetAsync(guid);
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель пользователь</returns>
        public async Task<UserModel> UpdateAsync(UserModifyModel user)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == user.Id);
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Пользователь не найден");

                context.Entry(userEntity).CurrentValues.SetValues(user);

                userEntity.Password = GenerateHashFromPassword(Convert.FromBase64String(userEntity.Salt), user.Password);

                context.Users.Update(userEntity);
                await context.SaveChangesAsync();
                return await GetAsync(userEntity.Id);
            }
        }

        /// <summary>
        /// Обновить обновление токена
        /// </summary>
        /// <param name="refreshToken">Строка обновление токена</param>
        /// <returns>Модель пользователь</returns>
        public async Task<UserModel> UpdateRefreshTokenAsync(Guid id, string refreshToken)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == id);
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Пользователь не найден");

                userEntity.RefreshToken = refreshToken;

                context.Users.Update(userEntity);
                await context.SaveChangesAsync();
                return await GetAsync(userEntity.Id);
            }
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Базовый ответ</returns>
        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == id);
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Пользователь не найден");

                context.Users.Remove(userEntity);
                await context.SaveChangesAsync();
            }
            return new BaseResponse();
        }

        /// <summary>
        /// Получить пользователя
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
        /// <param name="login">Логин</param>
        /// <returns>Модель пользователь</returns>
        public async Task<UserModel> GetAsync(string login)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Login == login);
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Пользователя с таким логином не существует");

                return _mapper.Map<UserModel>(userEntity);
            }
        }

        /// <summary>
        /// Получить пользователя по логину и паролю
        /// </summary>
        /// <param name="user">Модель пользователь</param>
        /// <returns>Модель пользователь</returns>
        public async Task<UserShortModel> GetAsync(UserShortModel user)
        {
            using (var context = _contextFactory.CreateDbContext(new string[0]))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Login == user.Login);
                if (userEntity == null) throw new KeyNotFoundException("Ошибка: Пользователя с таким логином не существует");

                var passwordHash = GenerateHashFromPassword(Convert.FromBase64String(userEntity.Salt), user.Password);
                
                if (userEntity.Password != passwordHash) throw new KeyNotFoundException("Ошибка: Пользователя с таким логином и паролем не существует");

                return _mapper.Map<UserShortModel>(userEntity);
            }
        }

        /// <summary>
        /// Сгенерировать пароль и соль в хэш 
        /// </summary>
        /// <param name="salt">Соль</param>
        /// <param name="password">Пароль</param>
        /// <returns>Строка хэш</returns>
        private string GenerateHashFromPassword(byte[] salt, string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        /// <summary>
        /// Сгенерировать соль
        /// </summary>
        /// <returns>Соль массивом байт</returns>
        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);
            return salt;
        }

        /// <summary>
        /// Сгенерировать строку для обновление токена
        /// </summary>
        /// <returns></returns>
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
