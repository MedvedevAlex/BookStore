using System.Collections.Generic;
using ViewModel.Models.Authors;

namespace ViewModel.Models.Responses.Authors
{
    public class AuthorPreviewResponse : BaseResponse
    {
        public List<AuthorPreviewModel> PreviewAuthors { get; set; }
        public int Count { get; set; }
    }
}
