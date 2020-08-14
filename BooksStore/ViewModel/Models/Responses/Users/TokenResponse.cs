namespace ViewModel.Models.Responses.Users
{
    /// <summary>
    /// Модель токен
    /// </summary>
    public class TokenResponse : BaseResponse
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
