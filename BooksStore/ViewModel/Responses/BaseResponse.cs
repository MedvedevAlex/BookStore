namespace ViewModel.Responses
{
    /// <summary>
    /// Базовый ответ
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Успех выполненя запроса
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// Сообщение об ошибке в случае ошибки
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
