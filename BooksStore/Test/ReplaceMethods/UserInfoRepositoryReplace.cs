using System;
using ViewModel.Interfaces.Repositories;

namespace Test.ReplaceMethods
{
    public class UserInfoRepositoryReplace : IUserInfoRepository
    {
        /// <summary>
        /// Получить идентификатор пользователя из токена
        /// </summary>
        /// <returns>Идентификатор пользователя</returns>
        public Guid GetUserIdFromToken()
        {
            return Guid.Parse("108C5883-E2B7-4937-A04D-F7C059B8ACD3");
        }
    }
}
