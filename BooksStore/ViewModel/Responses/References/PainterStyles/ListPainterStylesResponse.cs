using System.Collections.Generic;
using ViewModel.Models.References;

namespace ViewModel.Responses.References.PainterStyles
{
    /// <summary>
    /// Ответ коллекция художественных стилей
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
