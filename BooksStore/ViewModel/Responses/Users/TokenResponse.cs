namespace ViewModel.Responses.Users
{
    /// <summary>
    /// Ответ токен
    /// </summary>
    public class TokenResponse : BaseResponse
    {
        /// <summary>
        /// Токен
        /// </summary>
        public string AccessToken { get; set; }
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
