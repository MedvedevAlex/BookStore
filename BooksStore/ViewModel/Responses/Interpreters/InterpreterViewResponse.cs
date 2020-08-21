using ViewModel.Models.Interpreters;

namespace ViewModel.Responses.Interpreters
{
    /// <summary>
    /// Ответ переводчик
    /// </summary>
    public class InterpreterViewResponse : BaseResponse
    {
        /// <summary>
        /// Модель переводчик
        /// </summary>
        public InterpreterViewModel Interpreter { get; set; }
    }
}
