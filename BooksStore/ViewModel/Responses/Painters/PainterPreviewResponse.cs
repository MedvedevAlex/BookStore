using System.Collections.Generic;
using ViewModel.Models.Painters;

namespace ViewModel.Responses.Painters
{
    /// <summary>
    /// Ответ художник
    /// </summary>
    public class PainterPreviewResponse : BaseResponse
    {
        /// <summary>
        /// Коллекция художников
        /// </summary>
        public List<PainterPreviewModel> PreviewPainters { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count { get; set; }
    }
}
