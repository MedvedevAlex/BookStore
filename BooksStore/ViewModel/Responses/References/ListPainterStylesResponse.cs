using System.Collections.Generic;
using ViewModel.Models.References;

namespace ViewModel.Responses.References
{
    /// <summary>
    /// Ответ художественный стили художника
    /// </summary>
    public class ListPainterStylesResponse : BaseResponse
    {
        /// <summary>
        /// Коллекция художественных стилей
        /// </summary>
        public List<PainterStyleModel> Styles { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count { get; set; }
    }
}
