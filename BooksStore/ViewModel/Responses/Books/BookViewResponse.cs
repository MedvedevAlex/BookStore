using ViewModel.Models.Books;

namespace ViewModel.Responses.Books
{
    /// <summary>
    /// Ответ книга
    /// </summary>
    public class BookViewResponse : BaseResponse
    {
        /// <summary>
        /// Модель книга
        /// </summary>
        public BookViewModel Book { get; set; }
    }
}
