using System.Collections.Generic;
using ViewModel.Models.Authors;

namespace ViewModel.Responses.Authors
{
    /// <summary>
    /// Ответ автор
    /// </summary>
    public class AuthorPreviewResponse : BaseResponse
    {
        /// <summary>
        /// Коллекция авторов
        /// </summary>
        public List<AuthorPreviewModel> PreviewAuthors { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count { get; set; }
    }
}
