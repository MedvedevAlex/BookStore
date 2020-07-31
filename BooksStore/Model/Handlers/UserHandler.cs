using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
