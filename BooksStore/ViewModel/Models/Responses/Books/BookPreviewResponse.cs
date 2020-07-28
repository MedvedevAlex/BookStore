using System.Collections.Generic;
using ViewModel.Models.Books;

namespace ViewModel.Models.Responses.Books
{
    public class BookPreviewResponse : BaseResponse
    {
        public List<BookPreviewModel> PreviewBooks { get; set; }
        public int Count { get; set; }
    }
}
