using System.Collections.Generic;
using ViewModel.Models.Books;

namespace ViewModel.Responses.Books
{
    /// <summary>
    /// Ответ книга
    /// </summary>
    public class BookPreviewResponse : BaseResponse
    {
        /// <summary>
        /// Коллекция книг
        /// </summary>
        public List<BookPreviewModel> PreviewBooks { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count { get; set; }
    }
}
