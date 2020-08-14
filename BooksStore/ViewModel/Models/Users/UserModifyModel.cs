namespace ViewModel.Models.Users
{
    /// <summary>
    /// Модель для создания и обновления пользователя
    /// </summary>
    public class UserModifyModel
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
