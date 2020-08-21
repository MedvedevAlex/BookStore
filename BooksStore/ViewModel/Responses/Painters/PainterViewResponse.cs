using ViewModel.Models.Painters;

namespace ViewModel.Responses.Painters
{
    /// <summary>
    /// Ответ художник
    /// </summary>
    public class PainterViewResponse : BaseResponse
    {
        /// <summary>
        /// Модель художник
        /// </summary>
        public PainterViewModel Painter { get; set; }
    }
}
