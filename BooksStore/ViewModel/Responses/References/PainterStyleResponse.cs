using ViewModel.Models.References;

namespace ViewModel.Responses.References
{
    /// <summary>
    /// Ответ художественный стиль художника
    /// </summary>
    public class PainterStyleResponse : BaseResponse
    {
        /// <summary>
        /// Модель художественный стиль
        /// </summary>
        public PainterStyleModel Style { get; set; }
    }
}
