using ViewModel.Models.Authors;

namespace ViewModel.Responses.Authors
{
    /// <summary>
    /// Ответ автор
    /// </summary>
    public class AuthorViewResponse : BaseResponse
    {
        /// <summary>
        /// Модель автор
        /// </summary>
        public AuthorViewModel Author { get; set; }
    }
}
