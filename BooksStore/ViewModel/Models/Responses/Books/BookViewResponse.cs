using ViewModel.Models.Books;

namespace ViewModel.Models.Responses.Books
{
    public class BookViewResponse : BaseResponse
    {
        public BookViewModel Book { get; set; }
    }
}
