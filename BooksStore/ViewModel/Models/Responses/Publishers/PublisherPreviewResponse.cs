using System.Collections.Generic;
using ViewModel.Models.Publishers;

namespace ViewModel.Models.Responses.Publishers
{
    public class PublisherPreviewResponse : BaseResponse
    {
        public List<PublisherPreviewModel> PreviewPublishers { get; set; }
        public int Count { get; set; }
    }
}
