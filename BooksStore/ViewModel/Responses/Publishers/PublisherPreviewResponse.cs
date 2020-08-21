using System.Collections.Generic;
using ViewModel.Models.Publishers;

namespace ViewModel.Responses.Publishers
{
    /// <summary>
    /// Ответ издатель
    /// </summary>
    public class PublisherPreviewResponse : BaseResponse
    {
        /// <summary>
        /// Коллекция издателей
        /// </summary>
        public List<PublisherPreviewModel> PreviewPublishers { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count { get; set; }
    }
}
