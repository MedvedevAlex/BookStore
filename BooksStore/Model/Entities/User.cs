using System;

namespace Model.Entities
{
    /// <summary>
    /// Сущность пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Соль
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// Обновление токена
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
