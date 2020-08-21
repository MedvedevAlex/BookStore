using ViewModel.Models.Users;

namespace ViewModel.Responses.Users
{
    /// <summary>
    /// Ответ пользователь
    /// </summary>
    public class UserResponse : BaseResponse
    {
        /// <summary>
        /// Модель пользователь
        /// </summary>
        public UserModel User{ get; set; }
    }
}
