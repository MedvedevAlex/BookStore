using System.Collections.Generic;
using ViewModel.Models.Interpreters;

namespace ViewModel.Models.Responses.Interpreters
{
    public class InterpreterPreviewResponse : BaseResponse
    {
        public List<InterpreterPreviewModel> PreviewInterpreters { get; set; }
        public int Count { get; set; }
    }
}
