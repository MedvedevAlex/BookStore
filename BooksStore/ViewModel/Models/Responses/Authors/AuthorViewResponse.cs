using ViewModel.Models.Authors;

namespace ViewModel.Models.Responses.Authors
{
    public class AuthorViewResponse : BaseResponse
    {
        public AuthorViewModel Author { get; set; }
    }
}
