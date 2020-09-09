namespace ViewModel.Models.Users
{
    /// <summary>
    /// Модель обновление токена
    /// </summary>
    public class RefreshTokenModel
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Обновление токена
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
