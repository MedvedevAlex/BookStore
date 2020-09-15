using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Users;
using ViewModel.Responses;

namespace Test.Handlers
{
    /// <summary>
    /// Набор тестов для тестирования обработчика данных пользователь
    /// </summary>
    [TestFixture]
    public class UserHandlerTests
    {
        private readonly IUserHandler _userHandler;
        private Guid _createUserId;

        public UserHandlerTests()
        {
            var _services = ConfigDI.GetServiceProvider();
            _userHandler = _services.GetService<IUserHandler>();
        }

        /// <summary>
        /// Должен добавить пользователя
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task ShouldAddUser()
        {
            // Arrange
            var login = "Ruccalo";
            var role = "Admin";
            var modifiedUser = new UserModifyModel
            {
                Login = login,
                Password = "Ruccalo123",
                Role = role
            };
            // Act
            var result = await _userHandler.AddAsync(modifiedUser);
            _createUserId = result.Id;
            // Assert
            result.Should().NotBeNull();
            result.Password.Should().NotBeNullOrEmpty();
            result.RefreshToken.Should().NotBeNullOrEmpty();
            result.Login.Should().Be(login);
            result.Role.Should().Be(role);
        }

        /// <summary>
        /// Должен обновить пользователя
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task ShouldUpdateUser()
        {
            // Arrange
            var login = "Luigi";
            var role = "SuperUser";
            var modifiedUser = new UserModifyModel
            {
                Id = _createUserId,
                Login = login,
                Password = "superpuper",
                Role = role
            };
            // Act
            var result = await _userHandler.UpdateAsync(modifiedUser);
            _createUserId = result.Id;
            // Assert
            result.Should().NotBeNull();
            result.Password.Should().NotBeNullOrEmpty();
            result.RefreshToken.Should().NotBeNullOrEmpty();
            result.Login.Should().Be(login);
            result.Role.Should().Be(role);
        }

        /// <summary>
        /// Должен удалить пользователя
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task ShouldDeleteUser()
        {
            // Arrange
            var baseResponse = new BaseResponse();
            // Act
            var result = await _userHandler.DeleteAsync(_createUserId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(baseResponse);
        }

        /// <summary>
        /// Должен обновить обновление токена
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldUpdateRefreshTokenUser()
        {
            // Arrange
            var refreshToken = "2kYrPG5rPVJwzi6skdwjXtngll0So2C14EvA4JIoq3U=";
            var user = new UserModel
            {
                Id = Guid.Parse("367C6B4E-8650-481C-80D5-6DB6BF583095"),
                Login = "1",
                Password = "joGTNbiLAhq6eGZC/IuVZ6vBOVyWNpxtusxSuK0CFX0=",
                Role = "Common",
                RefreshToken = refreshToken,
            };
            // Act
            var result = await _userHandler.UpdateRefreshTokenAsync(user);
            // Assert
            result.Should().NotBeNull();
            result.RefreshToken.Should().NotBeNullOrEmpty();
            result.RefreshToken.Should().NotBeEquivalentTo(refreshToken);
        }

        /// <summary>
        /// Должен получить пользователя
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetUser()
        {
            // Arrange
            var userId = Guid.Parse("30BE92D8-E0DB-4386-9131-93D6CC4B7C47");
            var user = new UserModel
            {
                Id = userId,
                Login = "Admin",
                Password = "zkf+O+PEIGXDH1e3QH4VxzSZ+KmyTRdEAMcdTTZG2Us=",
                Role = "Admin",
                RefreshToken = "6tSd7w8IIfn/hjALkg956tmNv9B4D6Hln55ex5eeaqM=",
            };
            // Act
            var result = await _userHandler.GetAsync(userId);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

        /// <summary>
        /// Должен получить пользователя по логину
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetUserByLogin()
        {
            // Arrange
            var user = new UserModel
            {
                Id = Guid.Parse("108C5883-E2B7-4937-A04D-F7C059B8ACD3"),
                Login = "Granula",
                Password = "T/e1VM+cbVU1QVb/NrU7u22Ozs985MqQxlXY0vsgLqU=",
                Role = "Common",
                RefreshToken = "0FV7lKM5tM0tGfxe37/Ka4xOnaYgdjU5/T8VPPpJBfA=",
            };
            // Act
            var result = await _userHandler.GetAsync(user.Login);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }

        /// <summary>
        /// Должен получить пользователя по логину и паролю
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ShouldGetUserByLoginAndPassword()
        {
            // Arrange
            var user = new UserModel
            {
                Id = Guid.Parse("108C5883-E2B7-4937-A04D-F7C059B8ACD3"),
                Login = "Granula",
                Password = "T/e1VM+cbVU1QVb/NrU7u22Ozs985MqQxlXY0vsgLqU=",
                Role = "Common",
                RefreshToken = "0FV7lKM5tM0tGfxe37/Ka4xOnaYgdjU5/T8VPPpJBfA=",
            };
            var userAuth = new UserShortModel
            {
                Login = user.Login,
                Password = "granula"
            };
            // Act
            var result = await _userHandler.GetAsync(userAuth);
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }
    }
}