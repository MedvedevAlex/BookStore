using ViewModel.Models.References;

namespace ViewModel.Responses.References.CoverTypes
{
    /// <summary>
    /// Ответ тип переплета
    /// </summary>
    public class CoverTypeResponse : BaseResponse
    {
        /// <summary>
        /// Модель тип переплета
        /// </summary>
        public CoverTypeModel CoverType { get; set; }
    }
}
