using ViewModel.Models.Publishers;

namespace ViewModel.Responses.Publishers
{
    /// <summary>
    /// Ответ издатель
    /// </summary>
    public class PublisherViewResponse : BaseResponse
    {
        /// <summary>
        /// Модель издатель
        /// </summary>
        public PublisherViewModel Publisher { get; set; }
    }
}
