using ViewModel.Models.Users;

namespace ViewModel.Models.Responses.Users
{
    /// <summary>
    /// Модель токен
    /// </summary>
    public class UserResponse : BaseResponse
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserModel User{ get; set; }
    }
}
