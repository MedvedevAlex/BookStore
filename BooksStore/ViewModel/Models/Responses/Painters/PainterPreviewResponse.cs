using System.Collections.Generic;
using ViewModel.Models.Painters;

namespace ViewModel.Models.Responses.Painters
{
    public class PainterPreviewResponse : BaseResponse
    {
        public List<PainterPreviewModel> PreviewPainters { get; set; }
        public int Count { get; set; }
    }
}
