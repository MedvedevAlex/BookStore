namespace ViewModel.Models.Users
{
    /// <summary>
    /// Модель токен
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Токен
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
    }
}
