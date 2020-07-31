namespace ViewModel.Models.Users
{
    /// <summary>
    /// Модель пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }
    }
}
