using System.Collections.Generic;
using ViewModel.Models.Interpreters;

namespace ViewModel.Responses.Interpreters
{
    /// <summary>
    /// Ответ переводчик
    /// </summary>
    public class InterpreterPreviewResponse : BaseResponse
    {
        /// <summary>
        /// Коллекция переводчиков
        /// </summary>
        public List<InterpreterPreviewModel> PreviewInterpreters { get; set; }
        /// <summary>
        /// Общее количество
        /// </summary>
        public int Count { get; set; }
    }
}
